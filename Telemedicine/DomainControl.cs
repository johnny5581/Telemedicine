using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using Telemedicine.Orgs;
using Hl7.Fhir.Model;
using Telemedicine.Controllers;
using System.Reflection;

namespace Telemedicine
{
    public class DomainControl : UserControlBase
    {
        private static readonly Dictionary<Type, Type> _domainTypes
            = new Dictionary<Type, Type>();
        protected Forms.CgLabelTextBox textId;
        private GroupBox groupBox1;
        private Panel panel1;
        protected Forms.CgIconButton buttonPicker;
        protected Panel panelExtra;
        private Panel panel2;
        protected Panel panelExtra2;

        public const string SystemId = "https://www.cgmh.org.tw";

        public static void Setup(object instance, Action<Type, object> controllerAction = null)
        {
            var instanceType = instance.GetType();

            var pControllers = instanceType.GetProperties().Where(r => r.Name.EndsWith("Controller"));
            foreach (var pController in pControllers)
            {
                object controller = null;
                if (pController.PropertyType.IsGenericType && typeof(Controller<>).IsAssignableFrom(pController.PropertyType.GetGenericTypeDefinition()))
                {
                    var genericType = pController.PropertyType.GetGenericArguments()[0];
                    if (genericType != null)
                        controller = typeof(ControllerBase).GetMethod("Create").MakeGenericMethod(genericType).Invoke(null, new object[] { instance });
                }
                else
                {
                    controller = Activator.CreateInstance(pController.PropertyType, instance);
                }
                pController.SetValue(instance, controller, null);
            }

            if (controllerAction != null)
            {
                var domainType = GetDomainType(instanceType);
                if (domainType != null)
                {
                    var ctrl = typeof(ControllerBase).GetMethod("Create").MakeGenericMethod(domainType).Invoke(null, new object[] { instance });
                    controllerAction(domainType, ctrl);
                }
            }
        }
        public static Type GetDomainType(Type sourceType)
        {
            return _domainTypes.GetOrCreate(sourceType, type =>
            {
                if (type.TryGetCustomAttribute(true, out DomainControlAttribute attr))
                    return attr.DomainType;
                return null;
            });
        }










        private string _prefix;
        private object _ctrlInstance;
        private MethodInfo _mGet;
        public DomainControl()
        {
            InitializeComponent();
            Setup(this, (domainType, r) =>
            {
                _ctrlInstance = r;
                _mGet = r.GetType().GetMethod("Get");
                Title = domainType.Name;
            });
        }
        [DefaultValue("")]
        public string Id
        {
            get { return IdValue; }
        }
        [DefaultValue("")]
        public string Title
        {
            get { return groupBox1.Text; }
            set { groupBox1.Text = value; }
        }
        [DefaultValue(null)]
        public virtual Type ListFormType { get; }
        [DefaultValue(null)]
        public object Selected { get; set; }
        [DefaultValue(true)]
        public bool PickerVisible
        {
            get { return buttonPicker.Visible; }
            set { buttonPicker.Visible = value; }
        }
        public event EventHandler ItemPicked;

        protected virtual string Prefix
        {
            get
            {
                var domainType = GetDomainType(GetType());
                if (_prefix == null && domainType != null)
                {
                    var p = domainType.GetProperty("TypeName");
                    _prefix = (string)(p?.GetValue(Activator.CreateInstance(domainType), null)) ?? "";
                }
                return _prefix;
            }
            set { _prefix = value; }
        }

        protected virtual string IdValue
        {
            get { return textId.Text; }
            set { textId.Text = value; }
        }



        public void Set(ResourceReference resRef)
        {
            Set(resRef?.Reference);
        }
        public void Set(string id)
        {
            if (id != null && Prefix != null && id.StartsWith(Prefix))
                id = id.Substring(Prefix.Length + 1);
            IdValue = id;
        }

        public void SetModel(object item)
        {
            Execute(() => ActionItemPicked(item));
        }

        public object GetModel()
        {
            if (Id.IsNullOrEmpty())
                throw new InvalidOperationException($"missing {Prefix} id");
            return _mGet.Invoke(_ctrlInstance, new object[] { Id });
        }

        public ResourceReference GetResourceReference()
        {
            return new ResourceReference(Prefix + "/" + Id);
        }

        private void InitializeComponent()
        {
            this.textId = new Telemedicine.Forms.CgLabelTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelExtra2 = new System.Windows.Forms.Panel();
            this.buttonPicker = new Telemedicine.Forms.CgIconButton();
            this.panelExtra = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textId
            // 
            this.textId.Dock = System.Windows.Forms.DockStyle.Top;
            this.textId.Header = "#";
            this.textId.Location = new System.Drawing.Point(0, 0);
            this.textId.Name = "textId";
            this.textId.Size = new System.Drawing.Size(38, 30);
            this.textId.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelExtra);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 150);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(144, 45);
            this.panel2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textId);
            this.panel1.Controls.Add(this.panelExtra2);
            this.panel1.Controls.Add(this.buttonPicker);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(144, 42);
            this.panel1.TabIndex = 1;
            // 
            // panelExtra2
            // 
            this.panelExtra2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelExtra2.Location = new System.Drawing.Point(0, 0);
            this.panelExtra2.Name = "panelExtra2";
            this.panelExtra2.Size = new System.Drawing.Size(38, 42);
            this.panelExtra2.TabIndex = 1;
            // 
            // buttonPicker
            // 
            this.buttonPicker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonPicker.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonPicker.Location = new System.Drawing.Point(38, 0);
            this.buttonPicker.Name = "buttonPicker";
            this.buttonPicker.Size = new System.Drawing.Size(106, 42);
            this.buttonPicker.TabIndex = 0;
            this.buttonPicker.Text = "選取";
            this.buttonPicker.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonPicker.UseVisualStyleBackColor = true;
            this.buttonPicker.Click += new System.EventHandler(this.buttonPicker_Click);
            // 
            // panelExtra
            // 
            this.panelExtra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelExtra.Location = new System.Drawing.Point(3, 63);
            this.panelExtra.Name = "panelExtra";
            this.panelExtra.Size = new System.Drawing.Size(144, 84);
            this.panelExtra.TabIndex = 2;
            // 
            // DomainControl
            // 
            this.Controls.Add(this.groupBox1);
            this.Name = "DomainControl";
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void buttonPicker_Click(object sender, EventArgs e)
        {
            if (RequireShowPickerDialog() && ListFormType != null)
            {
                var dialog = Activator.CreateInstance(ListFormType) as ListForm;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Execute(() => ActionItemPicked(dialog.Selected));
                }
            }
        }

        protected virtual void ActionItemPicked(object item)
        {            
            Selected = item;
            IdValue = GetResourceId(item);
            if (ItemPicked != null)
                ItemPicked(this, EventArgs.Empty);
        }
        protected virtual bool RequireShowPickerDialog()
        {
            return true;
        }

        public static string GetResourceId(object item)
        {
            var resource = item as Resource;
            if (resource != null)
                return resource.Id;
            return null;
        }
        public static string GetPeriod(DataType dataRes)
        {
            if(dataRes is Period)
            {
                var period = dataRes as Period;
                return $"{period.Start} ~ {period.End}";
            }
            else if(dataRes is CodeableConcept)
            {
                var codeableConcept = dataRes as CodeableConcept;
                return codeableConcept?.Coding?.FirstOrDefault()?.Code;
            }
            return null;
        }
    }
    public class DomainControlAttribute : Attribute
    {
        public DomainControlAttribute(Type domainType)
        {
            DomainType = domainType;
        }
        public Type DomainType { get; set; }
    }
}
