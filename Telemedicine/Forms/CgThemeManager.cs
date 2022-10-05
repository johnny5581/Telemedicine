using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Telemedicine.Forms
{
    ///// <summary>
    ///// 主題樣式
    ///// </summary>
    //[ProvideProperty("FontAppearance", typeof(Control))]
    //[ProvideProperty("FontBold", typeof(Control))]
    //[ProvideProperty("StyleName", typeof(Control))]
    //public class CgThemeManager : Component, ICgComponent, IExtenderProvider
    //{
    //    public CgThemeManager()
    //    {
    //        Register(this);
    //    }
    //    public CgThemeManager(IContainer container)
    //        : this()
    //    {
    //        container.Add(this);
    //    }
    //    /// <summary>
    //    /// 樣式改變事件
    //    /// </summary>
    //    public event ThemeChangedEventHandler ThemeChanged;



    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing)
    //        {
    //            Unregister(this);
    //        }
    //        base.Dispose(disposing);
    //    }

    //    #region IExtenderProvider
    //    public bool CanExtend(object extendee)
    //    {
    //        return extendee != null && extendee is Control;
    //    }
    //    #endregion

    //    #region ICgComponent
    //    public void RuntimeBootstrap()
    //    {
    //        throw new NotImplementedException();
    //    }
    //    #endregion


    //    #region 靜態域
    //    private static CgThemeManager _globalManager;
    //    private static HashSet<CgThemeManager> _managers;
    //    static CgThemeManager()
    //    {
    //        _managers = new HashSet<CgThemeManager>();
    //        _globalManager = new CgThemeManager();
    //    }

    //    public static CgThemeManager GlobalManager
    //    {
    //        get { return _globalManager; }
    //        private set
    //        {
    //            _globalManager = value;
    //        }
    //    }



    //    public static void Register(CgThemeManager manager)
    //    {
    //        if (!_managers.Contains(manager))
    //        {
    //            _managers.Add(manager);
    //        }
    //    }
    //    public static void Unregister(CgThemeManager manager)
    //    {
    //        if (_managers.Contains(manager))
    //        {
    //            _managers.Remove(manager);
    //        }
    //    }


    //    #endregion

    //    public delegate void ThemeChangedEventHandler(object sender, ThemeChangedEventArgs e);
    //    public class ThemeChangedEventArgs : EventArgs
    //    {

    //    }
    //}
}

