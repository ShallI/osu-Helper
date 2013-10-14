using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;
namespace OSUHelperLib
{
    public delegate void QQListGetEventHandler(object sender, Dictionary<int, string> e);
    public class OSUHelper
    {
        public event QQListGetEventHandler QQListGet;
        WebBrowser wb;
        Dictionary<int, string> dic;
        public Dictionary<int, string> QQList
        {
            get { return dic; }
        }
        public OSUHelper()
        {
            wb = new WebBrowser();
            wb.DocumentCompleted+=new WebBrowserDocumentCompletedEventHandler(wb_DocumentCompleted);
        }
        public void RequestOnlineQQList()
        {
            wb.Navigate(@"http://xui.ptlogin2.qq.com/cgi-bin/qlogin?domain=qq.com&lang=2052&qtarget=0&jumpname=&appid=549000912");
        }

        void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (wb.ReadyState == WebBrowserReadyState.Complete && wb.IsBusy == false)
            {
                dic = new Dictionary<int, string>();
                HtmlDocument doc = wb.Document;
                HtmlElement element = doc.GetElementById("list_uin");
                for (int i = 0; i < element.Children.Count; i++)
                {
                    string strTarget=element.Children[i].InnerText;
                    int spaceCharIndex = strTarget.LastIndexOf(' ');
                    string strNickname = strTarget.Substring(0, spaceCharIndex);
                    string strUin = strTarget.Substring(spaceCharIndex + 2, strTarget.Length-spaceCharIndex-3);
                    dic.Add(int.Parse(strUin), strNickname);
                }
                if (QQListGet != null) QQListGet(this, dic);
            }
        }
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "GetWindowText")]
        public static extern int GetWindowText(int hwnd, string lpString, int cch);

        public string GetOsuTitleInfo()
        {
            Process[] ps = Process.GetProcessesByName("osu!"); 
            foreach (Process p in ps)
            {
                if (p.MainWindowTitle.StartsWith("osu!")) return p.MainWindowTitle;
            }
            return null;
        }
    }
}
