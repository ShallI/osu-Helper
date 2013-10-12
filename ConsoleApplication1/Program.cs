using System;
using System.Collections.Generic;
using System.Text;
using QQStatusLib;
using OSUHelperLib;
using System.Windows.Forms;
namespace ConsoleApplication1
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            QQStatus status = new QQStatus();
            OSUHelper helper = new OSUHelper();
            helper.QQListGet +=new QQListGetEventHandler(helper_QQListGet);
            Console.WriteLine("读取qq列表...");
            WebBrowser wb = new WebBrowser();
            wb.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(wb_DocumentCompleted);
            wb.Navigate("http://www.baidu.com");
            helper.RequestOnlineQQList();
            while (true)
            {
                string str=Console.ReadLine();
                if (str == "exit") { status.PushMusic(10000, "", ""); return; }
                status.PushMusic(10000, str, "param");
            }
            
        }

        static void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Console.WriteLine("badiu");
        }

        static void helper_QQListGet(object sender, Dictionary<int,string> e)
        {
            foreach (KeyValuePair<int, string> kv in e)
            {
                Console.WriteLine(kv.Key + kv.Value);
            }
        }
    }
}
