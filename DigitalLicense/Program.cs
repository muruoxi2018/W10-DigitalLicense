using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalLicense
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            System.Security.Policy.Evidence evi = new System.Security.Policy.Evidence();
            evi.AddHost(new System.Security.Policy.Zone(System.Security.SecurityZone.Intranet));
            System.Security.PermissionSet ps = new System.Security.PermissionSet(System.Security.Permissions.PermissionState.None);
            ps.AddPermission(new System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityPermissionFlag.Assertion | System.Security.Permissions.SecurityPermissionFlag.Execution | System.Security.Permissions.SecurityPermissionFlag.BindingRedirects));
            ps.AddPermission(new System.Security.Permissions.FileIOPermission(System.Security.Permissions.PermissionState.Unrestricted));
            AppDomainSetup ads = new AppDomainSetup();
            ads.ApplicationBase = System.IO.Directory.GetCurrentDirectory();
            AppDomain app = AppDomain.CreateDomain("check", evi, ads, ps, null);
            try
            {
                string check = (string)app.CreateInstanceFromAndUnwrap(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName, typeof(string).FullName);
                AppDomain.Unload(app);
            }
            catch (Exception e)
            {
                AppDomain.Unload(app);
                if (e.Message.Contains("8013141A") || e.Message.Contains("8013141a"))
                {
                    MessageBox.Show("程序被修改过不允许执行！\r\nThe program has been modified to disallow execution!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, false);
                    return;
                }
            }



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(args));
        }
    }
}
