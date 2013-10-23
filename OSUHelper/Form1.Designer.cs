namespace OSUHelperApp
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "12345678901",
            "狂拽酷炫吊炸天空穴来风卷"}, -1);
            this.listOnline = new System.Windows.Forms.ListView();
            this.QQ号码 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.昵称 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listPush = new System.Windows.Forms.ListBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonPush = new System.Windows.Forms.Button();
            this.buttonMAdd = new System.Windows.Forms.Button();
            this.textBoxQQ = new System.Windows.Forms.TextBox();
            this.textBoxPush = new System.Windows.Forms.TextBox();
            this.checkBoxAutoPush = new System.Windows.Forms.CheckBox();
            this.buttonRun = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // listOnline
            // 
            this.listOnline.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.QQ号码,
            this.昵称});
            this.listOnline.FullRowSelect = true;
            this.listOnline.GridLines = true;
            this.listOnline.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listOnline.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listOnline.Location = new System.Drawing.Point(6, 20);
            this.listOnline.Name = "listOnline";
            this.listOnline.ShowGroups = false;
            this.listOnline.Size = new System.Drawing.Size(197, 124);
            this.listOnline.TabIndex = 0;
            this.listOnline.UseCompatibleStateImageBehavior = false;
            this.listOnline.View = System.Windows.Forms.View.Details;
            this.listOnline.DoubleClick += new System.EventHandler(this.listOnline_DoubleClick);
            // 
            // QQ号码
            // 
            this.QQ号码.Text = "QQ号码";
            this.QQ号码.Width = 77;
            // 
            // 昵称
            // 
            this.昵称.Text = "昵称";
            this.昵称.Width = 116;
            // 
            // listPush
            // 
            this.listPush.FormattingEnabled = true;
            this.listPush.ItemHeight = 12;
            this.listPush.Items.AddRange(new object[] {
            "12345678901"});
            this.listPush.Location = new System.Drawing.Point(18, 20);
            this.listPush.Name = "listPush";
            this.listPush.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listPush.Size = new System.Drawing.Size(121, 124);
            this.listPush.TabIndex = 3;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(128, 148);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 28);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "添加->";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(83, 148);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(56, 28);
            this.buttonDelete.TabIndex = 5;
            this.buttonDelete.Text = "删除";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonRefresh);
            this.groupBox1.Controls.Add(this.listOnline);
            this.groupBox1.Controls.Add(this.buttonAdd);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 182);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "在线QQ列表";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(6, 148);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 28);
            this.buttonRefresh.TabIndex = 1;
            this.buttonRefresh.Text = "刷新";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonClear);
            this.groupBox2.Controls.Add(this.listPush);
            this.groupBox2.Controls.Add(this.buttonDelete);
            this.groupBox2.Location = new System.Drawing.Point(230, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(155, 182);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "推送QQ列表";
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(18, 148);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(56, 28);
            this.buttonClear.TabIndex = 4;
            this.buttonClear.Text = "清空";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.buttonPush);
            this.groupBox3.Controls.Add(this.buttonMAdd);
            this.groupBox3.Controls.Add(this.textBoxQQ);
            this.groupBox3.Controls.Add(this.textBoxPush);
            this.groupBox3.Location = new System.Drawing.Point(12, 200);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(373, 121);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "手动添加QQ和推送信息";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "QQ号码：";
            // 
            // buttonPush
            // 
            this.buttonPush.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonPush.Location = new System.Drawing.Point(282, 46);
            this.buttonPush.Name = "buttonPush";
            this.buttonPush.Size = new System.Drawing.Size(75, 67);
            this.buttonPush.TabIndex = 9;
            this.buttonPush.Text = "推";
            this.buttonPush.UseVisualStyleBackColor = true;
            this.buttonPush.Click += new System.EventHandler(this.buttonPush_Click);
            // 
            // buttonMAdd
            // 
            this.buttonMAdd.Location = new System.Drawing.Point(282, 17);
            this.buttonMAdd.Name = "buttonMAdd";
            this.buttonMAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonMAdd.TabIndex = 7;
            this.buttonMAdd.Text = "添加到列表";
            this.buttonMAdd.UseVisualStyleBackColor = true;
            this.buttonMAdd.Click += new System.EventHandler(this.buttonMAdd_Click);
            // 
            // textBoxQQ
            // 
            this.textBoxQQ.Location = new System.Drawing.Point(160, 19);
            this.textBoxQQ.Name = "textBoxQQ";
            this.textBoxQQ.Size = new System.Drawing.Size(116, 21);
            this.textBoxQQ.TabIndex = 6;
            // 
            // textBoxPush
            // 
            this.textBoxPush.Location = new System.Drawing.Point(6, 46);
            this.textBoxPush.Multiline = true;
            this.textBoxPush.Name = "textBoxPush";
            this.textBoxPush.Size = new System.Drawing.Size(270, 67);
            this.textBoxPush.TabIndex = 8;
            // 
            // checkBoxAutoPush
            // 
            this.checkBoxAutoPush.AutoSize = true;
            this.checkBoxAutoPush.Location = new System.Drawing.Point(391, 32);
            this.checkBoxAutoPush.Name = "checkBoxAutoPush";
            this.checkBoxAutoPush.Size = new System.Drawing.Size(108, 16);
            this.checkBoxAutoPush.TabIndex = 10;
            this.checkBoxAutoPush.Text = "自动添加在线QQ";
            this.checkBoxAutoPush.UseVisualStyleBackColor = true;
            this.checkBoxAutoPush.CheckedChanged += new System.EventHandler(this.checkBoxAutoPush_CheckedChanged);
            // 
            // buttonRun
            // 
            this.buttonRun.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonRun.Location = new System.Drawing.Point(391, 217);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(108, 96);
            this.buttonRun.TabIndex = 11;
            this.buttonRun.Text = "停止";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 325);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.checkBoxAutoPush);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OSU!Helper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listOnline;
        private System.Windows.Forms.ColumnHeader QQ号码;
        private System.Windows.Forms.ColumnHeader 昵称;
        private System.Windows.Forms.ListBox listPush;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonPush;
        private System.Windows.Forms.Button buttonMAdd;
        private System.Windows.Forms.TextBox textBoxQQ;
        private System.Windows.Forms.TextBox textBoxPush;
        private System.Windows.Forms.CheckBox checkBoxAutoPush;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Button buttonClear;


    }
}

