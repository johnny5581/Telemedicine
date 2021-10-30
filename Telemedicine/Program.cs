using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telemedicine
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // 設定到當前目錄
            System.IO.Directory.SetCurrentDirectory(
                System.IO.Path.GetDirectoryName(
                    System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName));
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);



            try
            {
                var appContext = AppContext.GetContext(args);

                Exception lastError;
                if (!appContext.TryLoadSplashScreen(out lastError))
                {
                    Forms.MsgBoxHelper.Error(lastError.Message);
                    Environment.Exit(1);
                }
                Application.Run(appContext);
            }
            catch (Exception ex)
            {
                Forms.MsgBoxHelper.Error(ex.Message);
            }
        }
    }
}
