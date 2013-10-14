using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
namespace OSUHelperApp
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.AboveNormal;
            Application.Run(new Form1());
        }
    }
}
