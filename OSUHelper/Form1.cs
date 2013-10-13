using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OSUHelperLib;
using QQStatusLib;
namespace OSUHelperApp
{
    public partial class Form1 : Form
    {
        NotifyIcon notify;
        OSUHelper helper;
        QQStatus status;
        MenuItem mItemStart;
        MenuItem mItemStop;
        ContextMenu contextMenu;
        CustomClassWindow customWindow;
        public Form1()
        {
            InitializeComponent();
            this.components = this.components = new System.ComponentModel.Container();
            notify = new NotifyIcon(this.components);
            notify.Visible = true;
            notify.Icon = this.Icon;

            notify.MouseUp += new MouseEventHandler(notify_MouseUp);
            notify.MouseDoubleClick += new MouseEventHandler(notify_MouseDoubleClick);

            contextMenu = new ContextMenu();
            mItemStart= new MenuItem("开始推送");
            mItemStop = new MenuItem("停止推送");
            contextMenu.MenuItems.Add(mItemStart);
            contextMenu.MenuItems.Add(mItemStop);

            notify.ContextMenu = contextMenu;
        }

        void notify_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Visible = !this.Visible;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listOnline.Items.Clear();
            listPush.Items.Clear();
            helper =new OSUHelper();
            helper.QQListGet += new QQListGetEventHandler(helper_QQListGet);
            helper.RequestOnlineQQList();
            status = new QQStatus();

            customWindow = new CustomClassWindow("MsnMsgrUIManager");
            customWindow.OnPush += new CustomClassWindow.OnPushEventHandler(customWindow_OnPush);
        }

        void customWindow_OnPush(object sender, string data)
        {
            textBox1.Text = data;
        }

        void helper_QQListGet(object sender, Dictionary<int, string> e)
        {
            listOnline.Items.Clear();
            listPush.Items.Clear();
            foreach(KeyValuePair<int,string> kv in e){
                listOnline.Items.Add(new ListViewItem(new string[] { kv.Key.ToString(), kv.Value }));
                }
        }

        void notify_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            helper.RequestOnlineQQList();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listOnline.SelectedItems)
            {
                if (listPush.Items.Contains(item.SubItems[0].Text)) continue;
                listPush.Items.Add(item.SubItems[0].Text);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            while (listPush.SelectedItems.Count > 0) listPush.Items.Remove(listPush.SelectedItem);   
        }
    }
}
