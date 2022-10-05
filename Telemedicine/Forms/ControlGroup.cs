using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Telemedicine.Forms
{
    public abstract class ComponentGroup
    {
        public abstract class ChangedEventArgs : EventArgs
        {
            public abstract bool IsEmpty { get; }
        }

        public delegate void SelectedItemChangedEventHandler(object sender, SelectedItemChangedEventArgs e);
        public class SelectedItemChangedEventArgs : ChangedEventArgs
        {
            private readonly object _value;
            private readonly Component _component;
            public SelectedItemChangedEventArgs()
            {
            }
            public SelectedItemChangedEventArgs(object value, Component component)
            {
                _value = value;
                _component = component;
            }

            public object Value
            {
                get
                {
                    return _value;
                }
            }

            public Component Component
            {
                get
                {
                    return _component;
                }
            }
            public override bool IsEmpty
            {
                get
                {
                    return _component == null;
                }
            }
        }
    }

    public abstract class ComponentGroup<TValue, TComponent> : ComponentGroup, IEnumerable<KeyValuePair<TValue, TComponent>> where TComponent : Component
    {
        private readonly IDictionary<TValue, TComponent> _map;

        public ComponentGroup(IDictionary<TValue, TComponent> map)
        {
            _map = map;
        }
        public ComponentGroup() : this(new Dictionary<TValue, TComponent>())
        {
        }
        public ComponentGroup(IEqualityComparer<TValue> comparer) : this(new Dictionary<TValue, TComponent>(comparer))
        {
        }


        public IEnumerable<TComponent> GetComponents()
        {
            return _map.Values;
        }


        public virtual TValue GetSelectedValue()
        {
            var selecteds = GetSelectedItems();
            return selecteds.Select(r => r.Key).FirstOrDefault();
        }
        public virtual TValue[] GetSelectedValues()
        {
            var selecteds = GetSelectedItems();
            return selecteds.Select(r => r.Key).ToArray();
        }
        public virtual TComponent GetSelectedComponent()
        {
            var selecteds = GetSelectedItems();
            return selecteds.Select(r => r.Value).FirstOrDefault();
        }
        public virtual TComponent[] GetSelectedComponents()
        {
            var selecteds = GetSelectedItems();
            return selecteds.Select(r => r.Value).ToArray();
        }

        public bool TryGetSelected(out TValue value)
        {
            var selecteds = GetSelectedItems();
            value = selecteds.Select(r => r.Key).FirstOrDefault();
            return selecteds.Count() > 0;
        }

        public virtual TComponent GetComponent(TValue value)
        {
            TComponent component;
            if (_map.TryGetValue(value, out component))
                return component;
            return null;
        }
        public virtual void SetSelection(TValue value)
        {
            TComponent component;
            if (_map.TryGetValue(value, out component))
            {
                if (TrySetComponentSelected(component))
                    RaiseSelectionChanged();
            }
        }
        public virtual void Clear()
        {
            if (TryClearComponentSelected())
                RaiseSelectionChanged();
        }
        public bool ContainsValue(TValue value)
        {
            return _map.ContainsKey(value);
        }

        public virtual void Add(TValue key, TComponent value)
        {
            _map.Add(key, value);
        }
        protected abstract bool IsSelected(TComponent component);
        protected abstract bool TrySetComponentSelected(TComponent component);
        protected abstract bool TryClearComponentSelected();
        protected abstract void RaiseSelectionChanged();

        protected IEnumerable<KeyValuePair<TValue, TComponent>> GetSelectedItems()
        {
            foreach (var pair in _map)
            {
                if (IsSelected(pair.Value))
                    yield return pair;
            }
        }

        protected virtual TValue GetValue(TComponent component)
        {
            return _map.FirstOrDefault(r => r.Value == component).Key;
        }
        #region IEnumerable
        public IEnumerator<KeyValuePair<TValue, TComponent>> GetEnumerator()
        {
            return _map.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _map.GetEnumerator();
        }
        #endregion 
    }
    public class RadioButtonGroup<T> : ComponentGroup<T, RadioButton>
    {
        public event SelectedItemChangedEventHandler SelectedItemChanged;
        public override void Add(T key, RadioButton value)
        {
            base.Add(key, value);
            value.CheckedChanged += Item_CheckedChanged;
        }
        protected override bool IsSelected(RadioButton component)
        {
            return component.Checked;
        }
        protected override bool TrySetComponentSelected(RadioButton component)
        {
            if (component != null)
                component.Checked = true;
            return component != null;
        }
        protected override bool TryClearComponentSelected()
        {
            var selection = GetSelectedComponent();
            if (selection != null)
                selection.Checked = false;
            return selection != null;
        }
        protected override void RaiseSelectionChanged()
        {
            var selections = GetSelectedItems();
            if (selections.Count() > 0)
            {
                var selection = selections.FirstOrDefault();
                OnSelectedItemChanged(selection.Key, selection.Value);
            }
            else
            {
                OnSelectedItemChanged();
            }
        }

        protected void OnSelectedItemChanged()
        {
            var args = new SelectedItemChangedEventArgs();
            OnSelectedItemChanged(args);
        }
        protected void OnSelectedItemChanged(T value, RadioButton component)
        {
            var args = new SelectedItemChangedEventArgs(value, component);
            OnSelectedItemChanged(args);
        }
        protected void OnSelectedItemChanged(SelectedItemChangedEventArgs e)
        {
            var handler = SelectedItemChanged;
            if (handler != null)
                handler(this, e);
        }
        private void Item_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox = sender as RadioButton;
            if (checkBox != null && checkBox.Checked)
                RaiseSelectionChanged();
        }
    }

    public class DynamicComponentGroup<T, TComponent> : ComponentGroup<T, TComponent>
        where TComponent : Component
    {
        private readonly Func<TComponent, bool> _condSelection;
        private readonly Func<TComponent, bool> _setSelectionAction;
        private readonly Func<bool> _clearAction;
        private readonly Action<TComponent[], T[]> _raiseEventAction;

        public DynamicComponentGroup(Func<TComponent, bool> selectionCondition, Func<TComponent, bool> setSelectionAction,
            Func<bool> clearAction, Action<TComponent[], T[]> raiseEventAction)
        {
            _condSelection = selectionCondition;
            _setSelectionAction = setSelectionAction;
            _clearAction = clearAction;
            _raiseEventAction = raiseEventAction;
        }

        protected override bool IsSelected(TComponent component)
        {
            return _condSelection(component);
        }

        protected override void RaiseSelectionChanged()
        {
            _raiseEventAction(GetSelectedComponents(), GetSelectedValues());
        }

        protected override bool TryClearComponentSelected()
        {
            return _clearAction();
        }

        protected override bool TrySetComponentSelected(TComponent component)
        {
            return _setSelectionAction(component);
        }
    }

}

