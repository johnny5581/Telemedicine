using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Telemedicine.Forms
{
    /// <summary>
    /// 支援排序與Filter的BindingList
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.ComponentModel.BindingList{T}" />
    public class SortableBindingList<T> : BindingList<T>, ISortableBindingList
    {
        private readonly Dictionary<Type, PropertyComparer<T>> _comparers;
        private bool _sorted;
        private ListSortDirection _listSortDirection;
        private PropertyDescriptor _propertyDescriptor;
        private Func<T, bool> _filterPredicate;
        private string _filter = "";
        private IList<T> _originals;

        protected SortableBindingList(IList<T> list) : base(list)
        {
            _originals = list.Select(r => r).ToList();
            _comparers = new Dictionary<Type, PropertyComparer<T>>();
        }
        public SortableBindingList() : this(new List<T>())
        {
        }

        public SortableBindingList(IEnumerable<T> enumeration) : this(new List<T>(enumeration))
        {
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public Func<T, bool> FilterPredicate
        {
            get { return _filterPredicate; }
            set
            {
                _filterPredicate = value;
                DoFilter();
            }
        }
        [DefaultValue("")]
        public string FilterString
        {
            get { return _filter; }
            set
            {
                if (_filter == value) return;
                Func<T, bool> predicate;
                if (TryCreateFilterPredicate(value, out predicate))
                {
                    FilterPredicate = predicate;
                    _filter = value;
                }
            }
        }
        public bool SuspendListChanged { get; set; }


        protected override bool SupportsSortingCore
        {
            get { return true; }
        }
        protected override bool IsSortedCore
        {
            get { return _sorted; }
        }

        protected override PropertyDescriptor SortPropertyCore
        {
            get { return _propertyDescriptor; }
        }

        protected override ListSortDirection SortDirectionCore
        {
            get { return _listSortDirection; }
        }

        protected override bool SupportsSearchingCore
        {
            get { return true; }
        }

        public void NotifyListChanged(ListChangedType changedType, int index = -1)
        {
            var args = new ListChangedEventArgs(changedType, index);
            OnListChanged(args);
        }

        public void AddRange(IEnumerable<T> enumeration)
        {
            foreach (var item in enumeration)
            {
                Add(item);
                OnAddingNew(new AddingNewEventArgs(item));
            }
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        public void Sort<TValue>(Func<T, TValue> propertySelector, IComparer<TValue> valueComparer = null)
        {
            var comparer = new PropertySelectionComparer<TValue>(propertySelector, valueComparer ?? Comparer<TValue>.Default);
            Sort(comparer);
        }
        public void Sort(IComparer<T> comparer)
        {
            List<T> itemsList = (List<T>)Items;
            itemsList.Sort(comparer);
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }
        public void Sort(string name, ListSortDirection direction)
        {
            var property = TypeDescriptor.GetProperties(typeof(T)).Find(name, true);
            ApplySortCore(property, direction);
        }
        public void Sort(string name)
        {
            string propertyDescriptorName = null;
            if (_propertyDescriptor != null)
                propertyDescriptorName = _propertyDescriptor.Name;
            if (string.Equals(propertyDescriptorName, name, StringComparison.OrdinalIgnoreCase))
                ApplySortCore(_propertyDescriptor, _listSortDirection == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending);
            else
                Sort(name, ListSortDirection.Ascending);
        }
        public void ChangeList()
        {
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        public void Filter(Func<object, bool> predicate)
        {
            //清除既有的清單            
            Items.Clear();
            IEnumerable<T> list = _originals;
            list = _originals.Where(r => predicate(r));
            foreach (var item in list)
                Items.Add(item);
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        protected override void ApplySortCore(PropertyDescriptor property, ListSortDirection direction)
        {
            List<T> itemsList = (List<T>)Items;

            Type propertyType = property.PropertyType;
            PropertyComparer<T> comparer;
            if (!_comparers.TryGetValue(propertyType, out comparer))
            {
                comparer = new PropertyComparer<T>(property, direction);
                _comparers.Add(propertyType, comparer);
            }

            comparer.SetPropertyAndDirection(property, direction);
            itemsList.Sort(comparer);

            _propertyDescriptor = property;
            _listSortDirection = direction;
            _sorted = true;

            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        protected override int FindCore(PropertyDescriptor property, object key)
        {
            int count = Count;
            for (int i = 0; i < count; ++i)
            {
                T element = this[i];
                if (property.GetValue(element).Equals(key))
                {
                    return i;
                }
            }
            return -1;
        }


        protected override void RemoveSortCore()
        {
            _sorted = false;
            _propertyDescriptor = base.SortPropertyCore;
            _listSortDirection = base.SortDirectionCore;

            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        private static PropertyInfo GetPropertyInfoFromExpression(LambdaExpression lambda)
        {
            var memberExp = ExtractMemberExpression(lambda.Body);
            if (memberExp == null)
                throw new ArgumentException("must be member access expression");
            if (memberExp.Member.DeclaringType == null)
                throw new InvalidOperationException("property does not have declaring type");
            return memberExp.Member.DeclaringType.GetProperty(memberExp.Member.Name);
        }
        private static MemberExpression ExtractMemberExpression(Expression expression)
        {
            if (expression.NodeType == ExpressionType.MemberAccess)
                return ((MemberExpression)expression);
            if (expression.NodeType == ExpressionType.Convert)
            {
                var operand = ((UnaryExpression)expression).Operand;
                return ExtractMemberExpression(operand);
            }
            return null;
        }




        /// <summary>
        /// Try to create filter predicate.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        private static bool TryCreateFilterPredicate(string filter, out Func<T, bool> predicate)
        {
            try
            {
                predicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<T, bool>(filter).Compile();
                return true;
            }
            catch
            {
                predicate = null;
                return false;
            }
        }

        private void DoFilter()
        {
            //清除既有的清單            
            Items.Clear();

            IEnumerable<T> list = _originals;
            if (_filterPredicate != null)
                list = _originals.Where(_filterPredicate);

            foreach (var item in list)
                Items.Add(item);
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        public class PropertySelectionComparer<TValue> : IComparer<T>
        {
            private readonly Func<T, TValue> _selector;
            private readonly IComparer<TValue> _valueComparer;

            public PropertySelectionComparer(Func<T, TValue> selector, IComparer<TValue> valueComparer)
            {
                _selector = selector;
                _valueComparer = valueComparer;
            }

            public int Compare(T x, T y)
            {
                var isEmptyX = x == null;
                var isEmptyY = y == null;
                if (isEmptyX && isEmptyY)
                    return 0;
                else if (isEmptyX)
                    return 1;
                else if (isEmptyY)
                    return -1;
                else
                    return _valueComparer.Compare(_selector(x), _selector(y));
            }
        }
        public class PropertyComparer<TProperty> : IComparer<TProperty>
        {
            private readonly IComparer comparer;
            private PropertyDescriptor propertyDescriptor;
            private int reverse;

            public PropertyComparer(PropertyDescriptor property, ListSortDirection direction)
            {
                propertyDescriptor = property;
                Type comparerForPropertyType = typeof(Comparer<>).MakeGenericType(property.PropertyType);
                comparer = (IComparer)comparerForPropertyType.InvokeMember("Default", BindingFlags.Static | BindingFlags.GetProperty | BindingFlags.Public, null, null, null);
                SetListSortDirection(direction);
            }

            #region IComparer<T> Members

            public int Compare(TProperty x, TProperty y)
            {
                return reverse * comparer.Compare(propertyDescriptor.GetValue(x), propertyDescriptor.GetValue(y));
            }

            #endregion

            private void SetPropertyDescriptor(PropertyDescriptor descriptor)
            {
                propertyDescriptor = descriptor;
            }

            private void SetListSortDirection(ListSortDirection direction)
            {
                reverse = direction == ListSortDirection.Ascending ? 1 : -1;
            }

            public void SetPropertyAndDirection(PropertyDescriptor descriptor, ListSortDirection direction)
            {
                SetPropertyDescriptor(descriptor);
                SetListSortDirection(direction);
            }
        }
        private class PropertyEqualityComparer : IEqualityComparer<T>
        {
            private readonly PropertyInfo _property;

            public PropertyEqualityComparer(PropertyInfo property)
            {
                _property = property;
            }

            public bool Equals(T x, T y)
            {
                var isLeftNull = object.Equals(x, default(T));
                var isRightNull = object.Equals(y, default(T));
                if (isLeftNull && isRightNull)
                    return true;
                else if (isLeftNull || isRightNull)
                    return false;

                var v1 = _property.GetValue(x, null);
                var v2 = _property.GetValue(y, null);
                return Equals(v1, v2);
            }

            public int GetHashCode(T obj)
            {
                if (obj == null)
                    return 0;
                var value = _property.GetValue(obj, null);
                if (value == null)
                    return 0;
                return value.GetHashCode();
            }
        }
    }

    public interface ISortableBindingList : IBindingList
    {
        bool SuspendListChanged { get; set; }
        void ChangeList();
        void Filter(Func<object, bool> predicate);
    }

}

