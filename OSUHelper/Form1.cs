using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using OSUHelperLib;
using QQStatusLib;
namespace OSUHelperApp
{
    public partial class Form1 : Form
    {
        const string CF = "config.ini";
        
        NotifyIcon notify;
        OSUHelper helper;
        QQStatus status;

        MenuItem mItemShowHide;
        MenuItem mItemStart;
        MenuItem mItemStop;
        MenuItem mItemQuit;
        
        ContextMenu contextMenu;
        CustomClassWindow customWindow;
        Timer timer;
        Timer delayTimer;
        Config config;
        
        public class Config{
            public bool IsRunning = true;
            public bool IsAutoPush = true;//自动添加在线qq到列表
            public List<object> QQList=new List<object>();
        }
        public Form1()
        {
            InitializeComponent();
            this.components = this.components = new System.ComponentModel.Container();
            notify = new NotifyIcon(this.components);
            notify.Visible = true;
            notify.Icon = this.Icon;

            notify.MouseDoubleClick += new MouseEventHandler(notify_MouseDoubleClick);

            contextMenu = new ContextMenu();

            mItemShowHide = new MenuItem("显示/隐藏");
            mItemShowHide.Click += new EventHandler(mItemShowHide_Click);
            contextMenu.MenuItems.Add(mItemShowHide);
            mItemStart= new MenuItem("开始推送");
            mItemStart.Click += new EventHandler(mItemStart_Click);
            contextMenu.MenuItems.Add(mItemStart);
            mItemStop = new MenuItem("停止推送");
            mItemStop.Click += new EventHandler(mItemStop_Click);
            contextMenu.MenuItems.Add(mItemStop);
            mItemQuit = new MenuItem("退出程序");
            mItemQuit.Click += new EventHandler(mItemQuit_Click);
            contextMenu.MenuItems.Add(mItemQuit);

            notify.ContextMenu = contextMenu;

            status = new QQStatus();
            config = new Config();

            helper = new OSUHelper();
            helper.QQListGet += new QQListGetEventHandler(helper_QQListGet);

            customWindow = new CustomClassWindow("MsnMsgrUIManager");
            customWindow.OnPush += new CustomClassWindow.OnPushEventHandler(customWindow_OnPush);

            timer = new Timer();
            timer.Interval =5000;
            timer.Tick += new EventHandler(timer_Tick);

            delayTimer = new Timer();
            delayTimer.Interval = 200;
            delayTimer.Tick += new EventHandler(delayTimer_Tick);

        }


        void delayTimer_Tick(object sender, EventArgs e)
        {
            timer_Tick(sender, e);
            delayTimer.Stop();
        }
        string tempTitle;
        void timer_Tick(object sender, EventArgs e)
        {
            string title = helper.GetOsuTitleInfo();
            if (title == null)
            {
                //其他播放器消息
                Push(); 
                return;
            }
            
            if (title == "osu!")
            { 
                if (tempTitle == title) return;
                title = textBoxPush.Text;
            }
            else
            {
                if (tempTitle == title) return;
            }
            Push(title);
            tempTitle = title;
        }

        private void StartPush()
        {
            mItemStart.Enabled = false;
            config.IsRunning = true;
            buttonRun.ForeColor = Color.Red;
            buttonRun.Text = "停止";
        }
        private void StopPush()
        {
            mItemStart.Enabled = true;
            config.IsRunning = false;
            buttonRun.ForeColor = Color.Blue;
            buttonRun.Text ="开始";
        }
        private void AddToPushList(string str)
        {
            if (!listPush.Items.Contains(str)) listPush.Items.Add(str);
        }
        private void Push()
        {
            Push(textBoxPush.Text);
        }
        private void Push(string msg)
        {
            if (!config.IsRunning) return;
            int uin;
            if (msg != "")
            {
                if (msg.StartsWith("osu! "))
                    msg = msg.Replace("osu! ", "[osu!] Playing");
                else
                    msg = "[osu!] " + msg;
            }
            try
            {
                foreach (object item in listPush.Items)
                {
                    uin = int.Parse(item.ToString());
                    status.PushMusic(uin, msg,msg);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }
        private void LoadConfig()
        {
            FileStream fs = new FileStream(CF, FileMode.Open);
            XmlSerializer xs = new XmlSerializer(typeof(Config));

            Config cfg =null;
            try
            {
                cfg = (Config)xs.Deserialize(fs);
            }
            catch
            {
                //bad
                throw;
            }
            finally
            {
                fs.Dispose();
            }
            if (cfg != null) config = cfg;

            if (config.IsAutoPush)
            {
                checkBoxAutoPush.Checked = true;
                checkBoxAutoPush_CheckedChanged(null, null);
            }
            else
            {
                checkBoxAutoPush.Checked = false;
                checkBoxAutoPush_CheckedChanged(null, null);
            }

            if (config.IsRunning)
            {
                StartPush();
            }
            else
            {
                StopPush();
            }
        }
        private void SaveConfig()
        {
            Stream fs = new FileStream(CF, FileMode.Create);
            XmlSerializer xs = new XmlSerializer(typeof(Config));
            xs.Serialize(fs, config);
            fs.Dispose();
        }
        void notify_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.Visible != true)
            {
                this.Visible = true;
                this.Activate();
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.Close();
            }
        }

        void mItemShowHide_Click(object sender, EventArgs e)
        {
            notify_MouseDoubleClick(sender, null);
        }
        void mItemStop_Click(object sender, EventArgs e)
        {
            StopPush();
        }

        void mItemStart_Click(object sender, EventArgs e)
        {
            StartPush();
        }

        void mItemQuit_Click(object sender, EventArgs e)
        {
            Push("");
            config.QQList.Clear();
            foreach (object item in listPush.Items)
            {
                config.QQList.Add(item);
            }
            SaveConfig();
            Environment.Exit(0);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadConfig();

            listOnline.Items.Clear();
            listPush.Items.Clear();
            foreach (int i in config.QQList)
            {
                listPush.Items.Add(i);
            }
            helper.RequestOnlineQQList();
            timer.Start();

            this.Hide();
        }
        void customWindow_OnPush(object sender, string data)
        {
            /*
             * \0Music\01\0Listening to {0} - {1} ({2})\0Aimai Elegy\0DECO*27 feat. marina\0osu!\0\0 播放
             * \0Music\00\0 {0} - {1} ({2})\0\0\0osu!\0\0  停止
             * Player: Name of your Music Player
                Type: Type of media, here: "Music"
                Playing: 1 for playing, 0 for stopped
                Format: The string next to "Now Playing", e.g: A3FPlayer: {1} - {0}
                Artist, Title & Album are self-explanatory
                GUID: WMCONTENTID
             * */
            string[] ss = data.Split(new string[] { @"\0" }, StringSplitOptions.None);
            if (ss[2] == "1")
                textBoxPush.Text = string.Format(ss[3], ss[4], ss[5], ss[6]);
            else
                textBoxPush.Text = "";
            delayTimer.Start();
            //textBoxPush.Text += data;
        }

        void helper_QQListGet(object sender, Dictionary<int, string> e)
        {
            listOnline.Items.Clear();
            listPush.Items.Clear();

            foreach (KeyValuePair<int, string> kv in e)
            {
                listOnline.Items.Add(new ListViewItem(new string[] { kv.Key.ToString(), kv.Value }));
                if(config.IsAutoPush)AddToPushList(kv.Key.ToString());
            }

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
                AddToPushList(item.SubItems[0].Text);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            while (listPush.SelectedItems.Count > 0) listPush.Items.Remove(listPush.SelectedItem);   
        }

        private void listOnline_DoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listOnline.SelectedItems)
            {
                if(listPush.Items.Contains(item.SubItems[0].Text))continue;
                AddToPushList(item.SubItems[0].Text);
            }
        }

        private void checkBoxAutoPush_CheckedChanged(object sender, EventArgs e)
        {
            config.IsAutoPush = checkBoxAutoPush.Checked;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            config.IsRunning = !config.IsRunning;
            if(config.IsRunning)StartPush();
            else StopPush();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            listPush.Items.Clear();
        }

        private void buttonPush_Click(object sender, EventArgs e)
        {
            Push(textBoxPush.Text);
        }

        private void buttonMAdd_Click(object sender, EventArgs e)
        {
            AddToPushList(textBoxQQ.Text);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) this.Hide();
        }
    }
}
