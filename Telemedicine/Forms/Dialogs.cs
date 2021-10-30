using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telemedicine.Forms
{
    public abstract class MessageDialog
    {
        #region 屬性
        public string Caption { get; set; }
        public string Message { get; set; }
        public string SubMessage { get; set; }
        public object Icon { get; set; }
        public int IconSize { get; set; }
        #endregion

        protected DialogResult ShowDialog(IMessageDialog dialog, object parent)
        {
            SetText(dialog);
            return dialog.ShowDialog(parent);
        }

        protected void Show(IMessageDialog dialog, object parent)
        {
            SetText(dialog);
            dialog.Show(parent);
        }

        protected void SetText(IMessageDialog dialog)
        {
            dialog.Caption = Caption;
            dialog.Message = Message;
            dialog.SubMessage = SubMessage;
            dialog.ChangeIcon(Icon, IconSize);
        }
    }


    #region InputDialog
    public class InputDialog : MessageDialog
    {
        private static Func<IInputDialog> _dialogFactory;
        public static Func<IInputDialog> DialogFactory
        {
            get
            {
                if (_dialogFactory == null)
                    return () => new CgInputDialogForm();
                return _dialogFactory;
            }
            set { _dialogFactory = value; }
        }
        private Delegate _validator;
        public InputDialog(string message, string caption = null, object icon = null, string inputText = null, char secretChar = char.MinValue)
        {
            Message = message;
            Caption = caption;
            Icon = icon;
            InputText = inputText;
            SecretChar = secretChar;
        }
        #region 屬性
        public string InputText { get; private set; }
        public char SecretChar { get; set; }
        public bool IsSecretInput { get; set; }
        public IInputDialogKeyboard Keyboard { get; set; }
        #endregion

        public void UseValidator(Func<string, string> validator)
        {
            _validator = validator;
        }
        public void UseRequiredValidator(string message)
        {
            _validator = new Func<string, string>(text => string.IsNullOrEmpty(text) ? message : null);
        }
        public void UseKeyboard(IInputDialogKeyboard keyboard)
        {
            Keyboard = keyboard;
        }
        public void UseKeyboard<T>() where T : IInputDialogKeyboard, new()
        {
            UseKeyboard(new T());
        }


        public string ShowDialog(IInputDialog dialog, object parent)
        {
            if (Keyboard != null)
                dialog.SetKeyboard(Keyboard);
            if (IsSecretInput)
                dialog.SecretInput();
            dialog.ChangeSubMessageStyle(null, Color.Red);
            dialog.InputText = InputText;
            string text = null;
            if (DialogResult.OK == base.ShowDialog(dialog, parent))
                text = dialog.InputText;
            return text;
        }


        public static string GetInput(IInputDialog dialog, object parent, string message, IInputDialogKeyboard keyboard = null, string inputText = null, bool secret = false, string caption = null, string messageError = null, object icon = null)
        {
            var d = new InputDialog(message, caption, icon, inputText);
            d.Keyboard = keyboard;
            d.SubMessage = messageError;

            d.IsSecretInput = secret;
            return d.ShowDialog(dialog, parent);
        }

        public static string GetInput<T>(object parent, string message, IInputDialogKeyboard keyboard = null, string inputText = null, string caption = null, string messageError = null, object icon = null)
            where T : class, IInputDialog, new()
        {
            var dialog = new T();
            return GetInput(dialog, parent, message, keyboard, inputText, false, caption, messageError, icon);
        }

        public static string GetInput(object parent, string message, IInputDialogKeyboard keyboard = null, string inputText = null, string caption = null, string messageError = null, object icon = null)
        {
            if (DialogFactory == null)
                throw new NullReferenceException("dialog factory is empty");
            var dialog = DialogFactory();
            return GetInput(dialog, parent, message, keyboard, inputText, false, caption, messageError, icon);
        }
        public static string GetSecretInput(IInputDialog dialog, object parent, string message, IInputDialogKeyboard keyboard = null, string inputText = null, string caption = null, string messageError = null, object icon = null)
        {
            return GetInput(dialog, parent, message, keyboard, inputText, true, caption, messageError, icon);
        }

        public static string GetSecretInput<T>(object parent, string message, IInputDialogKeyboard keyboard = null, string inputText = null, string caption = null, string messageError = null, object icon = null)
            where T : class, IInputDialog, new()
        {
            var dialog = new T();
            return GetSecretInput(dialog, parent, message, keyboard, inputText, caption, messageError, icon);
        }

        public static string GetSecretInput(object parent, string message, IInputDialogKeyboard keyboard = null, string inputText = null, string caption = null, string messageError = null, object icon = null)
        {
            if (DialogFactory == null)
                throw new NullReferenceException("dialog factory is empty");
            var dialog = DialogFactory();
            return GetSecretInput(dialog, parent, message, keyboard, inputText, caption, messageError, icon);
        }
    }
    public interface IInputDialog : IMessageDialog
    {
        string InputText { get; set; }
        void SetKeyboard(IInputDialogKeyboard keyboard);
        void SecretInput(char secretChar = char.MinValue);
    }
    public interface IInputDialogKeyboard : IDisposable
    {
        event KeyboardInputEventHandler KeyboardInput;
    }
    public delegate void KeyboardInputEventHandler(object sender, KeyboardInputEventArgs e);
    public class KeyboardInputEventArgs : EventArgs
    {
        public KeyboardInputEventArgs(string keyCode)
        {
            KeyCode = keyCode;
            IsCommand = false;
        }
        public KeyboardInputEventArgs(Func<string, string> handler)
        {
            Handler = handler;
            IsCommand = true;
        }
        public bool IsCommand { get; private set; }
        public string KeyCode { get; private set; }
        public Func<string, string> Handler { get; private set; }

        public string Invoke(string text)
        {
            if (Handler != null)
                return Handler(text);
            return text;
        }
    }
    #endregion

    #region PickerDialog
    public class PickerDialog : MessageDialog
    {
        private static Func<IPickerDialog> _dialogFactory;
        public static Func<IPickerDialog> DialogFactory
        {
            get
            {
                if (_dialogFactory == null)
                    return () => new CgPickerDialogForm();
                return _dialogFactory;
            }
            set { _dialogFactory = value; }
        }


        private ICollection<PickerItem> _items;
        public PickerDialog(string message, string caption = null, object icon = null)
        {
            Message = message;
            Caption = caption;
            Icon = icon;
            _items = new List<PickerItem>();
        }

        #region 屬性
        public ICollection<PickerItem> Items
        {
            get { return _items; }
        }
        public Delegate Selector { get; set; }
        public bool MultiSelection { get; set; }
        #endregion


        public void SetDataSource<T, TValue>(IEnumerable<T> items, Func<T, string> textResolver, Func<T, TValue> valueResolver)
        {
            if (valueResolver == null)
                throw new NullReferenceException("value resolver");
            if (textResolver == null)
                textResolver = r => r.ToString();

            Items.Clear();
            foreach (var item in items)
            {
                var pickerItem = new PickerItem(item, textResolver, valueResolver);
                Items.Add(pickerItem);
            }
        }
        public void SetDataSource<T>(IEnumerable<T> items, Func<T, string> textResolver)
        {
            Func<T, T> valueResolver = r => r;
            SetDataSource(items, textResolver, valueResolver);
        }
        public void SetDataSource(object[] items, string[] texts, object[] values)
        {
            Items.Clear();
            for (var i = 0; i < items.Length; i++)
            {
                var pickerItem = new PickerItem(items[i], texts[i], values[i]);
                Items.Add(pickerItem);
            }
        }
        public object[] ShowDialog(IPickerDialog dialog, object parent)
        {
            dialog.Selector = Selector;
            dialog.MultiSelection = MultiSelection;
            dialog.AddItems(Items);
            if (base.ShowDialog(dialog, parent) == DialogResult.OK)
                return dialog.SelectedItems;
            return new object[0];
        }

        private static PickerDialog CreatePickerDialog(string message, Delegate selector,
            string caption = null, string messageError = null, object icon = null)
        {
            var d = new PickerDialog(message, caption, icon);
            d.SubMessage = messageError;
            d.Selector = selector;
            return d;
        }
        public static TValue[] GetSelections<T, TValue>(IPickerDialog dialog, object parent, string message,
            IEnumerable<T> items, Func<T, string> textResolver, Func<T, TValue> valueResolver, Func<T, bool> selector,
            string caption = null, string messageError = null, object icon = null)
        {
            var d = CreatePickerDialog(message, selector, caption, messageError, icon);
            d.MultiSelection = true;
            d.SetDataSource(items, textResolver, valueResolver);
            var selected = d.ShowDialog(dialog, parent);
            return selected.Cast<TValue>().ToArray();
        }
        public static T[] GetSelections<T>(IPickerDialog dialog, object parent, string message,
            IEnumerable<T> items, Func<T, string> textResolver = null, Func<T, bool> selector = null,
            string caption = null, string messageError = null, object icon = null)
        {
            var d = CreatePickerDialog(message, selector, caption, messageError, icon);
            d.MultiSelection = true;
            d.SetDataSource(items, textResolver);
            var selected = d.ShowDialog(dialog, parent);
            return selected.Cast<T>().ToArray();
        }
        public static TValue GetSelection<T, TValue>(IPickerDialog dialog, object parent, string message,
            IEnumerable<T> items, Func<T, string> textResolver, Func<T, TValue> valueResolver, Func<T, bool> selector,
            string caption = null, string messageError = null, object icon = null)
        {
            var d = CreatePickerDialog(message, selector, caption, messageError, icon);
            d.SetDataSource(items, textResolver, valueResolver);
            var selected = d.ShowDialog(dialog, parent);
            var value = selected.FirstOrDefault();
            if (value == null && typeof(TValue).IsValueType)
                return default(TValue);
            return (TValue)value;
        }
        public static T GetSelection<T>(IPickerDialog dialog, object parent, string message,
            IEnumerable<T> items, Func<T, string> textResolver = null, Func<T, bool> selector = null,
            string caption = null, string messageError = null, object icon = null)
        {
            var d = CreatePickerDialog(message, selector, caption, messageError, icon);
            d.SetDataSource(items, textResolver);
            var selected = d.ShowDialog(dialog, parent);
            var value = selected.FirstOrDefault();
            if (value == null && typeof(T).IsValueType)
                return default(T);
            return (T)value;
        }
        public static TValue[] GetSelections<T, TValue>(object parent, string message,
           IEnumerable<T> items, Func<T, string> textResolver, Func<T, TValue> valueResolver, Func<T, bool> selector,
           string caption = null, string messageError = null, object icon = null)
        {
            if (DialogFactory == null)
                throw new NullReferenceException("dialog factory is empty");
            var dialog = DialogFactory();
            return GetSelections(dialog, parent, message, items, textResolver, valueResolver, selector, caption, messageError, icon);
        }
        public static T[] GetSelections<T>(object parent, string message,
            IEnumerable<T> items, Func<T, string> textResolver = null, Func<T, bool> selector = null,
            string caption = null, string messageError = null, object icon = null)
        {
            if (DialogFactory == null)
                throw new NullReferenceException("dialog factory is empty");
            var dialog = DialogFactory();
            return GetSelections(dialog, parent, message, items, textResolver, selector, caption, messageError, icon);
        }
        public static TValue GetSelection<T, TValue>(object parent, string message,
            IEnumerable<T> items, Func<T, string> textResolver, Func<T, TValue> valueResolver, Func<T, bool> selector,
            string caption = null, string messageError = null, object icon = null)
        {
            if (DialogFactory == null)
                throw new NullReferenceException("dialog factory is empty");
            var dialog = DialogFactory();
            return GetSelection(dialog, parent, message, items, textResolver, valueResolver, selector, caption, messageError, icon);
        }
        public static T GetSelection<T>(object parent, string message,
            IEnumerable<T> items, Func<T, string> textResolver = null, Func<T, bool> selector = null,
            string caption = null, string messageError = null, object icon = null)
        {
            if (DialogFactory == null)
                throw new NullReferenceException("dialog factory is empty");
            var dialog = DialogFactory();
            return GetSelection(dialog, parent, message, items, textResolver, selector, caption, messageError, icon);
        }

        public class PickerItem : OptionItem
        {
            public PickerItem(object item) : base(item)
            {
            }

            public PickerItem(string text) : base(text)
            {
            }

            public PickerItem(object item, Delegate textResolver, Delegate valueResolver) : base(item, textResolver, valueResolver)
            {
            }

            public PickerItem(object item, string text, object value) : base(item, text, value)
            {
            }
        }
    }

    public interface IPickerDialog : IMessageDialog
    {
        object[] SelectedItems { get; }
        bool MultiSelection { get; set; }
        Delegate Selector { get; set; }
        void AddItem(PickerDialog.PickerItem item);
        void AddItems(IEnumerable<PickerDialog.PickerItem> items);
        void ClearItems();
    }
    #endregion

    #region LoadingDialog

    public class LoadingDialog : MessageDialog
    {
        private static Func<ILoadingDialog> _dialogFactory;
        public static Func<ILoadingDialog> DialogFactory
        {
            get
            {
                if (_dialogFactory == null)
                    return () => new CgLoadingDialogForm();
                return _dialogFactory;
            }
            set { _dialogFactory = value; }
        }

        protected Task<DialogResult> _mainThread;
        protected CancellationTokenSource _cts;
        protected CancellationToken _ct;
        public LoadingDialog()
        {
            Interval = 100;
        }
        public Func<ILoadingDialog, bool?> Validator { get; set; }
        public Action<ILoadingDialog> PreValidateAction { get; set; }
        public int Interval { get; set; }
        public bool Synchronizable { get; set; }

        public Exception LastError { get; private set; }

        public DialogResult ShowDialog(ILoadingDialog dialog, object parent)
        {
            _cts = new CancellationTokenSource();
            _ct = _cts.Token;
            var state = new TaskState { dialog = dialog, synchronizable = Synchronizable };
            _mainThread = Task.Factory.StartNew(MainProcess, state, _ct, TaskCreationOptions.AttachedToParent, TaskScheduler.Current)
                .ContinueWith(CloseProcess, TaskScheduler.FromCurrentSynchronizationContext());
            base.ShowDialog(dialog, parent);
            //return _mainThread.Result;
            while (!_mainThread.IsCompleted)
            {
                Application.DoEvents();
                Thread.Sleep(10);
            }
            return _mainThread.Result;
        }

        public virtual DialogResult ShowDialog(object parent)
        {
            if (DialogFactory == null)
                throw new NullReferenceException("dialog factory is empty");
            return ShowDialog(DialogFactory(), parent);
        }


        protected virtual bool MainProcess(object obj)
        {
            bool? result = null;
            var state = (TaskState)obj;
            // 等待畫面出現
            while (!state.dialog.IsShown)
            {
                Application.DoEvents();
                Thread.Sleep(10);
            }
            while (!result.HasValue)
            {
                _ct.ThrowIfCancellationRequested();
                if (PreValidateAction != null)
                    PreValidateAction(state.dialog);

                _ct.ThrowIfCancellationRequested();
                if (state.synchronizable)
                    result = (bool?)state.dialog.Invoke(Validator);
                else
                    result = Validator(state.dialog);
                _ct.ThrowIfCancellationRequested();
                if (!result.HasValue)
                {
                    Thread.Sleep(Interval);
                    _ct.ThrowIfCancellationRequested();
                }
            }
            if (result.HasValue)
                return result.Value;
            throw new InvalidOperationException("result must have value");
        }

        protected DialogResult CloseProcess(Task<bool> task)
        {
            var state = (TaskState)task.AsyncState;
            state.dialog.Close(); // 不管怎樣都先關掉再說
            if (task.IsCanceled)
                return DialogResult.Cancel;
            else if (task.IsFaulted)
            {
                //throw task.Exception.InnerException;
                LastError = task.Exception.InnerException;
                return DialogResult.Abort;
            }
            else if (task.Result)
                return DialogResult.Yes;
            else
                return DialogResult.No;
        }

        protected struct TaskState
        {
            public ILoadingDialog dialog;
            public bool synchronizable;
        }

    }

    public interface ILoadingDialog : IMessageDialog
    {
        int ProgressValue { get; set; }
        int ProgressMaximum { get; set; }
        string ProgressMessage { get; set; }
    }
    #endregion

    #region SplashDialog
    public class SplashDialog : LoadingDialog
    {
        private static Func<ILoadingDialog> _dialogFactory;
        public new static Func<ILoadingDialog> DialogFactory
        {
            get
            {
                if (_dialogFactory == null)
                    return () => new CgSplashForm();
                return _dialogFactory;
            }
            set { _dialogFactory = value; }
        }
        private readonly SplashActionItemCollection _splashAcitonItems;
        private SplashActionCache _cache;
        public SplashDialog()
        {
            _splashAcitonItems = new SplashActionItemCollection();
        }
        public SplashDialog(SplashActionItemCollection collection)
        {
            _splashAcitonItems = collection;
        }



        public SplashActionItemCollection SplashActionItems
        {
            get { return _splashAcitonItems; }
        }
        public event SplashActionLoadingEventHandler Loading;
        public event SplashActionExecutedEventHandler Executed;

        protected override bool MainProcess(object obj)
        {
            //base.MainProcess(obj);
            var state = (TaskState)obj;

            while (!state.dialog.IsShown)
            {
                Application.DoEvents();
                Thread.Sleep(10);
            }
            if (_splashAcitonItems == null)
                return false;
            var enumerator = _splashAcitonItems.GetEnumerator();
            var cache = _cache ?? new SplashActionCache();
            var total = _splashAcitonItems.Count;
            state.dialog.Invoke(new Action(() => state.dialog.ProgressMaximum = total));
            Exception lastError;
            var index = 0;
            while (enumerator.MoveNext())
            {
                _ct.ThrowIfCancellationRequested();
                var item = enumerator.Current;
                lastError = null;
                try
                {
                    var loadingArgs = new SplashActionLoadingEventArgs(item, state.dialog, cache);
                    OnSplashActionLoading(loadingArgs);
                    if (loadingArgs.Cancel) // 取消執行                
                        return false;

                    if (item.Condition != null && !item.Condition(state.dialog, cache))
                    {
                        continue;
                    }

                    _ct.ThrowIfCancellationRequested();
                    //Delegate action = new Action<int, SplashActionItem, ILoadingDialog, IDictionary<string, object>>(ExecuteSplashActionItem);
                    //if (state.synchronizable)
                    //    state.dialog.Invoke(action, new object[] { ++index, item, state.dialog, cache });
                    //else
                    //action.DynamicInvoke(++index, item, state.dialog, cache);
                    ExecuteSplashActionItem(++index, item, state.dialog, cache);

                }
                catch (AggregateException ex)
                {
                    lastError = ex.InnerException;
                }
                catch (TargetInvocationException ex)
                {
                    lastError = ex.InnerException;
                }
                catch (Exception ex)
                {
                    lastError = ex;
                }
                _ct.ThrowIfCancellationRequested();
                var executedArgs = new SplashActionExecutedEventArgs(index, item, state.dialog, cache, lastError);
                OnSplashActionExecuted(executedArgs);
                if (executedArgs.LastError != null && !executedArgs.Continue)
                    throw new SplashException(index, item, lastError);
            }
            return true;
        }
        public override DialogResult ShowDialog(object parent)
        {
            if (DialogFactory == null)
                throw new NullReferenceException("dialog factory is empty");
            return ShowDialog(DialogFactory(), parent);
        }
        public DialogResult ShowDialog(ILoadingDialog dialog, object parent, SplashActionCache cache)
        {
            _cache = cache;
            return ShowDialog(dialog, parent);
        }
        public DialogResult ShowDialog(object parent, SplashActionCache cache)
        {
            _cache = cache;
            return ShowDialog(parent);
        }

        private void ExecuteSplashActionItem(int index, SplashActionItem item, ILoadingDialog dialog, SplashActionCache cache)
        {
            dialog.ProgressMessage = item.Text;
            dialog.ProgressValue = index;
            item.Action(dialog, cache);
        }

        protected virtual void OnSplashActionLoading(SplashActionLoadingEventArgs e)
        {
            var handler = Loading;
            if (handler != null)
                handler(this, e);
        }
        protected virtual void OnSplashActionExecuted(SplashActionExecutedEventArgs e)
        {
            var handler = Executed;
            if (handler != null)
                handler(this, e);
        }
        public class SplashActionItem
        {
            public SplashActionItem(string name, string text, SplashAction action, SplashCondition condition = null)
            {
                Name = name;
                Text = text;
                Action = action;
                Condition = condition;
            }
            public string Name { get; private set; }
            public string Text { get; private set; }
            public SplashAction Action { get; set; }
            public SplashCondition Condition { get; set; }

            public SplashActionItem Next { get; set; }
            public SplashActionItem Prev { get; set; }
            internal void AppendAfter(SplashActionItem item)
            {
                if (Next != null)
                {
                    Next.Prev = item;
                    item.Next = Next;
                }
                Next = item;
                item.Prev = this;
            }

            internal void AppendBefore(SplashActionItem item)
            {
                if (Prev != null)
                {
                    Prev.Next = item;
                    item.Prev = Prev;
                }
                Prev = item;
                item.Next = this;
            }

            public SplashActionItem GetNext()
            {
                return Next;
            }
            public SplashActionItem GetPrev()
            {
                return Prev;
            }
        }
        public class SplashActionItemCollection : IEnumerable<SplashActionItem>
        {
            private readonly Dictionary<string, SplashActionItem> _indexByName
                = new Dictionary<string, SplashActionItem>(StringComparer.OrdinalIgnoreCase);
            private SplashActionItem _first;
            private SplashActionItem _last;

            public int Count
            {
                get { return _indexByName.Count; }
            }
            public SplashActionItem GetByName(string name, bool throwOnError = false)
            {
                SplashActionItem item;
                if (_indexByName.TryGetValue(name, out item))
                    return item;
                else if (throwOnError)
                    throw new KeyNotFoundException("can not find splash action '" + name + "'");
                else
                    return null;
            }

            public SplashActionItemCollection Append(SplashActionItem item)
            {
                if (_indexByName.Count == 0)
                {
                    _first = _last = item;
                    _indexByName.Add(item.Name, item);
                }
                else
                    AppendToNext(_last, item);
                return this;
            }
            public SplashActionItemCollection AppendAfter(string refName, SplashActionItem item, bool throwOnError = false)
            {
                var refItem = GetByName(refName, throwOnError);
                if (refItem != null)
                    AppendToNext(refItem, item);
                return this;
            }
            public SplashActionItemCollection AppendBefore(string refName, SplashActionItem item, bool throwOnError = false)
            {
                var refItem = GetByName(refName, throwOnError);
                if (refItem != null)
                    AppendToPrev(refItem, item);
                return this;
            }
            public SplashActionItemCollection Remove(string refName, bool throwOnError = true)
            {
                var refItem = GetByName(refName);
                if (refItem != null)
                {
                    _indexByName.Remove(refName);
                    var next = refItem.Next;
                    var prev = refItem.Prev;
                    if (next != null)
                        next.Prev = prev;
                    if (prev != null)
                        prev.Next = next;
                }
                return this;
            }
            public SplashActionItemCollection Replace(SplashActionItem item, bool throwOnError = true)
            {
                var refItem = GetByName(item.Name, throwOnError);
                if (refItem != null)
                {
                    _indexByName[item.Name] = item;
                    var next = refItem.Next;
                    var prev = refItem.Prev;
                    if (next != null)
                        next.Prev = item;
                    if (prev != null)
                        prev.Next = item;
                }
                return this;
            }
            protected void AppendToNext(SplashActionItem refItem, SplashActionItem item)
            {
                _indexByName.Add(item.Name, item);
                refItem.AppendAfter(item);
                if (refItem == _last)
                    _last = item;
            }
            protected void AppendToPrev(SplashActionItem refItem, SplashActionItem item)
            {
                _indexByName.Add(item.Name, item);
                refItem.AppendBefore(item);
                if (refItem == _first)
                    _first = item;
            }



            public IEnumerator<SplashActionItem> GetEnumerator()
            {
                return new SplashActionItemEnumerator(_first);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            private class SplashActionItemEnumerator : IEnumerator<SplashActionItem>
            {
                private SplashActionItem _root;
                public SplashActionItemEnumerator(SplashActionItem item)
                {
                    _root = item;
                }
                public SplashActionItem Current { get; private set; }
                object IEnumerator.Current
                {
                    get { return Current; }
                }

                public void Dispose()
                {
                    // Do-Nothing
                }

                public bool MoveNext()
                {
                    if (Current == null)
                    {
                        if (_root == null)
                            return false;
                        Current = _root;
                    }
                    else
                        Current = Current.Next;
                    return Current != null;
                }

                public void Reset()
                {
                    Current = null;
                }
            }
        }
        public class SplashActionCache
        {
            private readonly Dictionary<string, object> _storage
                = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);


            public void Add(string key, object value)
            {
                if (_storage.ContainsKey(key))
                    _storage[key] = value;
                else
                    _storage.Add(key, value);
            }
            public object Get(string key)
            {
                if (_storage.ContainsKey(key))                
                    return _storage[key];
                return null;
            }
            public T Get<T>(string key, T defaultValue = default(T))
            {
                try
                {
                    if (_storage.ContainsKey(key))
                    {
                        var raw = _storage[key];
                        if (raw != null)
                        {
                            var type = raw.GetType();
                            if (typeof(string).IsAssignableFrom(type))
                            {
                                if (typeof(T) == typeof(string))
                                    return (T)raw;
                                else
                                {
                                    var converter = TypeDescriptor.GetConverter(typeof(T));
                                    return (T)converter.ConvertFromString(raw as string);
                                }
                            }
                        }
                        return (T)raw;
                    }
                }
                catch { }
                return defaultValue;
            }
            public string GetString(string key)
            {
                return Get<string>(key);
            }

            public bool GetBoolean(string key)
            {
                return Get<bool>(key);
            }
        }
        public delegate void SplashAction(ILoadingDialog dialog, SplashActionCache cache);
        public delegate bool SplashCondition(ILoadingDialog dialog, SplashActionCache cache);

        public delegate void SplashActionLoadingEventHandler(object sender, SplashActionLoadingEventArgs e);
        public delegate void SplashActionExecutedEventHandler(object sender, SplashActionExecutedEventArgs e);
        public class SplashActionLoadingEventArgs : CancelEventArgs
        {
            public SplashActionLoadingEventArgs(SplashActionItem item, ILoadingDialog dialog, SplashActionCache cache)
            {
                Item = item;
                Dialog = dialog;
                Cache = cache;
            }

            public SplashActionItem Item { get; private set; }
            public ILoadingDialog Dialog { get; private set; }
            public SplashActionCache Cache { get; private set; }
        }
        public class SplashActionExecutedEventArgs : EventArgs
        {
            public SplashActionExecutedEventArgs(int index, SplashActionItem item, ILoadingDialog dialog, SplashActionCache cache, Exception lastError = null)
            {
                Index = index;
                Item = item;
                Dialog = dialog;
                Cache = cache;
                LastError = lastError;
                Continue = false;
            }

            public int Index { get; private set; }
            public SplashActionItem Item { get; private set; }
            public ILoadingDialog Dialog { get; private set; }
            public SplashActionCache Cache { get; private set; }
            public Exception LastError { get; private set; }

            /// <summary>
            /// 繼續執行
            /// </summary>
            public bool Continue { get; set; }
        }
        [Serializable]
        public class SplashException : Exception
        {
            public SplashException()
            {
            }

            public SplashException(int index, SplashActionItem item) : base(GetMessage(item))
            {
                Index = index;
                Name = item.Name;
                Text = item.Text;
            }

            public SplashException(int index, SplashActionItem item, Exception innerException) : base(GetMessage(item, innerException), innerException)
            {
                Index = index;
                Name = item.Name;
                Text = item.Text;
            }

            protected SplashException(int index, SerializationInfo info, StreamingContext context) : base(info, context)
            {
                Index = info.GetInt32("index");
                Name = info.GetString("name");
                Text = info.GetString("text");
            }

            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                base.GetObjectData(info, context);
                info.AddValue("index", Index);
                info.AddValue("name", Name);
                info.AddValue("text", Text);
            }

            public string Name { get; private set; }
            public string Text { get; private set; }
            public int Index { get; private set; }

            private static string GetMessage(SplashActionItem item, Exception innerException = null)
            {
                var message = string.Format("execute splash action '{0}({1})' failed", item.Text, item.Name);
                if (innerException != null)
                    message += ": " + innerException.Message;
                return message;
            }

        }
    }
    #endregion
}

