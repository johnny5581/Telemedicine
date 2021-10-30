﻿/* 
 * Copyright (c) 2020, Firely (info@fire.ly) and contributors
 * See the file CONTRIBUTORS for details.
 * 
 * This file is licensed under the BSD 3-Clause license
 * available at https://raw.githubusercontent.com/FirelyTeam/firely-net-sdk/master/LICENSE
 */

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hl7.Fhir.Utility
{
    public static class TaskHelper
    {
        public static T Await<T>(Func<Task<T>> asyncFunc)
        {
#if NET40
            return TaskEx.Run(asyncFunc).GetAwaiter().GetResult();
#else
            // Call GetAwaiter() rather then .Result to unwrap the AggregateException
            return Task.Run(asyncFunc).GetAwaiter().GetResult();
#endif
        }

        public static void Await(Func<Task> asyncFunc)
        {
#if NET40
            TaskEx.Run(asyncFunc).GetAwaiter().GetResult();
#else
            // Call GetAwaiter() rather then .Result to unwrap the AggregateException
            Task.Run(asyncFunc).GetAwaiter().GetResult();
#endif
        }

        public static async Task<bool> AnyAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
        {
            foreach (var elem in source)
                if (await predicate(elem).ConfigureAwait(false)) return true;

            return false;
        }
    }
}
