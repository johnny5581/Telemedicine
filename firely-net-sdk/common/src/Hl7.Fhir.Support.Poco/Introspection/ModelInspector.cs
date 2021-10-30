/* 
 * Copyright (c) 2014, Firely (info@fire.ly) and contributors
 * See the file CONTRIBUTORS for details.
 * 
 * This file is licensed under the BSD 3-Clause license
 * available at https://raw.githubusercontent.com/FirelyTeam/firely-net-sdk/master/LICENSE
 */

#nullable enable

using Hl7.Fhir.Model;
using Hl7.Fhir.Specification;
using Hl7.Fhir.Utility;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Hl7.Fhir.Introspection
{
    /// <summary>
    /// A cache of FHIR type mappings found on .NET classes.
    /// </summary>
    /// <remarks>POCO's in the "common" assemblies
    /// can reflect the definition of multiple releases of FHIR using <see cref="IFhirVersionDependent"/>
    /// attributes. A <see cref="ModelInspector"/> will always capture the metadata for one such
    /// <see cref="Specification.FhirRelease" /> which is passed to it in the constructor.
    /// </remarks>
    public class ModelInspector : IStructureDefinitionSummaryProvider
    {
        private static readonly ConcurrentDictionary<string, ModelInspector> _inspectedAssemblies = new();

        public static void Clear() => _inspectedAssemblies.Clear();

        /// <summary>
        /// Returns a fully configured <see cref="ModelInspector"/> with the
        /// FHIR metadata contents of the given assembly. Calling this function repeatedly for
        /// the same assembly will return the same inspector.
        /// </summary>
        /// <remarks>If the assembly given is FHIR Release specific, the returned inspector will contain
        /// metadata for that release only. If the assembly is the common assembly, it will contain
        /// metadata for the most recent release for those common classes.</remarks>
        public static ModelInspector ForAssembly(Assembly a)
        {
            return _inspectedAssemblies.GetOrAdd(a.FullName ?? throw Error.ArgumentNull(nameof(a.FullName)), _ => configureInspector(a));

            static ModelInspector configureInspector(Assembly a)
            {
                if (a.GetCustomAttribute<FhirModelAssemblyAttribute>() is not FhirModelAssemblyAttribute modelAssemblyAttr)
                    throw new InvalidOperationException($"Assembly {a.FullName} cannot be used to supply FHIR metadata," +
                        $" as it is not marked with a {nameof(FhirModelAssemblyAttribute)} attribute.");

                var newInspector = new ModelInspector(modelAssemblyAttr.Since);
                newInspector.Import(a);

                // Make sure we always include the common types too. 
                var commonAssembly = typeof(Resource).GetTypeInfo().Assembly;
                if (a.FullName != commonAssembly.FullName)
                    newInspector.Import(commonAssembly);

                // And finally, the System/CQL primitive types
                foreach (var cqlType in getCqlTypes())
                    newInspector.ImportType(cqlType);

                return newInspector;

                static IEnumerable<Type> getCqlTypes()
                {
                    return typeof(ElementModel.Types.Any).GetTypeInfo().Assembly.GetExportedTypes().
                        Where(typ => typeof(ElementModel.Types.Any).IsAssignableFrom(typ));
                }
            }
        }

        /// <summary>
        /// Constructs a ModelInspector that will reflect the FHIR metadata for the given FHIR release
        /// </summary>
        public ModelInspector(FhirRelease fhirRelease)
        {
            FhirRelease = fhirRelease;
        }

        public readonly FhirRelease FhirRelease;

        // Index for easy lookup of datatypes.
        private readonly ConcurrentDictionary<string, ClassMapping> _classMappingsByName =
            new(StringComparer.OrdinalIgnoreCase);

        private readonly ConcurrentDictionary<Type, ClassMapping> _classMappingsByType = new();

        private readonly ConcurrentDictionary<string, ClassMapping> _classMappingsByCanonical = new();

        /// <summary>
        /// Locates all types in the assembly representing FHIR metadata and extracts
        /// the data as <see cref="ClassMapping"/>s.
        /// </summary>
        public IReadOnlyList<ClassMapping> Import(Assembly assembly)
        {
            if (assembly == null) throw Error.ArgumentNull(nameof(assembly));

#if NET40
            IEnumerable<Type> exportedTypes = assembly.GetExportedTypes();
#else
            IEnumerable<Type> exportedTypes = assembly.ExportedTypes;
#endif

            return exportedTypes.Select(t => ImportType(t))
                .Where(cm => cm is not null)
                .ToList()!;
        }

        /// <summary>
        /// Extracts the FHIR metadata from a <see cref="Type"/> into a <see cref="ClassMapping"/>.
        /// </summary>
        public ClassMapping? ImportType(Type type)
        {
            // When explicitly importing a (newer?) class mapping for the same
            // model type name, overwrite the old entry.            
            if (!ClassMapping.TryGetMappingForType(type, FhirRelease, out var mapping))
                return null;

            RegisterTypeMapping(type, mapping!);
            return mapping;
        }

        internal void RegisterTypeMapping(Type t, ClassMapping mapping)
        {
            _classMappingsByName[mapping!.Name] = mapping;
            _classMappingsByType[t] = mapping;

            if (mapping.Canonical is not null)
                _classMappingsByCanonical[mapping.Canonical] = mapping;
        }

        /// <summary>
        /// Retrieves an already imported <see cref="ClassMapping" /> given a FHIR type name.
        /// </summary>
        /// <remarks>The search for the mapping by namem is case-insensitive.</remarks>
        public ClassMapping? FindClassMapping(string fhirTypeName) =>
            _classMappingsByName.TryGetValue(fhirTypeName, out var entry) ? entry : null;

        /// <summary>
        /// Retrieves an already imported <see cref="ClassMapping" /> given a Type.
        /// </summary>
        public ClassMapping? FindClassMapping(Type t) =>
            _classMappingsByType.TryGetValue(t, out var entry) ? entry : null;

        /// <summary>
        /// Retrieves an already imported <see cref="ClassMapping" /> given a canonical.
        /// </summary>
        public ClassMapping? FindClassMappingByCanonical(string canonical) =>
            _classMappingsByCanonical.TryGetValue(canonical, out var entry) ? entry : null;

        /// <summary>
        /// List of PropertyMappings for this class, in the order of listing in the FHIR specification.
        /// </summary>
        public ICollection<ClassMapping> ClassMappings => _classMappingsByName.Values;

        /// <inheritdoc cref="IStructureDefinitionSummaryProvider.Provide(string)"/>
        public IStructureDefinitionSummary? Provide(string canonical) =>
            canonical.Contains("/") ?
                FindClassMappingByCanonical(canonical)
                : FindClassMapping(canonical);
    }
}

#nullable restore