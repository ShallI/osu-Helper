﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
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
                    string[] ss = element.Children[i].InnerText.Split(" ()".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    dic.Add(int.Parse(ss[1]), ss[0]);
                }
                if (QQListGet != null) QQListGet(this, dic);
            }
        }
    }
}
