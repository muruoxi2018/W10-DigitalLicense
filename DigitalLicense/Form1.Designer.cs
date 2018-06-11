namespace DigitalLicense
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lang_Label = new MetroFramework.Controls.MetroLabel();
            this.comboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLink1 = new MetroFramework.Controls.MetroLink();
            this.key_textBox = new MetroFramework.Controls.MetroTextBox();
            this.install_KEY_Button1 = new MetroFramework.Controls.MetroButton();
            this.check_Button = new MetroFramework.Controls.MetroButton();
            this.sku_textBox = new MetroFramework.Controls.MetroTextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new MetroFramework.Controls.MetroTextBox();
            this.activeButton = new MetroFramework.Controls.MetroButton();
            this.exitButton = new MetroFramework.Controls.MetroButton();
            this.progressBar1 = new MetroFramework.Controls.MetroProgressBar();
            this.contextMenuStrip1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.Select_Product_KEY = new System.Windows.Forms.ToolStripMenuItem();
            this.Cloud = new System.Windows.Forms.ToolStripMenuItem();
            this.CloudN = new System.Windows.Forms.ToolStripMenuItem();
            this.Core = new System.Windows.Forms.ToolStripMenuItem();
            this.CoreN = new System.Windows.Forms.ToolStripMenuItem();
            this.CoreCountrySpecific = new System.Windows.Forms.ToolStripMenuItem();
            this.CoreSingleLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.Education = new System.Windows.Forms.ToolStripMenuItem();
            this.EducationN = new System.Windows.Forms.ToolStripMenuItem();
            this.Enterprise = new System.Windows.Forms.ToolStripMenuItem();
            this.EnterpriseN = new System.Windows.Forms.ToolStripMenuItem();
            this.EnterpriseS = new System.Windows.Forms.ToolStripMenuItem();
            this.EnterpriseSN = new System.Windows.Forms.ToolStripMenuItem();
            this.Professional = new System.Windows.Forms.ToolStripMenuItem();
            this.ProfessionalN = new System.Windows.Forms.ToolStripMenuItem();
            this.ProfessionalEducation = new System.Windows.Forms.ToolStripMenuItem();
            this.ProfessionalEducationN = new System.Windows.Forms.ToolStripMenuItem();
            this.ProfessionalWorkstation = new System.Windows.Forms.ToolStripMenuItem();
            this.ProfessionalWorkstationN = new System.Windows.Forms.ToolStripMenuItem();
            this.ServerRdsh = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lang_Label);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Controls.Add(this.metroLabel1);
            this.groupBox1.Controls.Add(this.metroLink1);
            this.groupBox1.Controls.Add(this.key_textBox);
            this.groupBox1.Controls.Add(this.install_KEY_Button1);
            this.groupBox1.Controls.Add(this.check_Button);
            this.groupBox1.Controls.Add(this.sku_textBox);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.groupBox1.Location = new System.Drawing.Point(23, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 242);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "系统信息";
            // 
            // lang_Label
            // 
            this.lang_Label.AutoSize = true;
            this.lang_Label.Location = new System.Drawing.Point(6, 209);
            this.lang_Label.Name = "lang_Label";
            this.lang_Label.Size = new System.Drawing.Size(65, 19);
            this.lang_Label.TabIndex = 7;
            this.lang_Label.Text = "界面语言";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 23;
            this.comboBox1.Items.AddRange(new object[] {
            "简体中文",
            "繁體中文",
            "Arabic",
            "Bosanski",
            "Српски",
            "Čeština",
            "English",
            "Español (es_es)",
            "Español (es_ec)",
            "Ελληνικά",
            "Français",
            "Italiano",
            "Nederlands",
            "Português",
            "Polish",
            "Русский RU",
            "Română",
            "Tiếng Việt",
            "한국어"});
            this.comboBox1.Location = new System.Drawing.Point(94, 205);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(134, 29);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.UseSelectable = true;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.LemonChiffon;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView1.Location = new System.Drawing.Point(6, 22);
            this.listView1.Name = "listView1";
            this.listView1.Scrollable = false;
            this.listView1.Size = new System.Drawing.Size(397, 150);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel1.Location = new System.Drawing.Point(234, 212);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(27, 15);
            this.metroLabel1.TabIndex = 8;
            this.metroLabel1.Text = "SKU";
            // 
            // metroLink1
            // 
            this.metroLink1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroLink1.ForeColor = System.Drawing.Color.DarkOrange;
            this.metroLink1.Location = new System.Drawing.Point(256, -8);
            this.metroLink1.Name = "metroLink1";
            this.metroLink1.Size = new System.Drawing.Size(153, 24);
            this.metroLink1.TabIndex = 7;
            this.metroLink1.Text = "52pojie.cn";
            this.metroLink1.UseCustomBackColor = true;
            this.metroLink1.UseCustomForeColor = true;
            this.metroLink1.UseSelectable = true;
            this.metroLink1.Click += new System.EventHandler(this.metroLink1_Click);
            // 
            // key_textBox
            // 
            // 
            // 
            // 
            this.key_textBox.CustomButton.Image = null;
            this.key_textBox.CustomButton.Location = new System.Drawing.Point(282, 1);
            this.key_textBox.CustomButton.Name = "";
            this.key_textBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.key_textBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.key_textBox.CustomButton.TabIndex = 1;
            this.key_textBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.key_textBox.CustomButton.UseSelectable = true;
            this.key_textBox.CustomButton.Visible = false;
            this.key_textBox.Lines = new string[0];
            this.key_textBox.Location = new System.Drawing.Point(6, 178);
            this.key_textBox.MaxLength = 32767;
            this.key_textBox.Name = "key_textBox";
            this.key_textBox.PasswordChar = '\0';
            this.key_textBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.key_textBox.SelectedText = "";
            this.key_textBox.SelectionLength = 0;
            this.key_textBox.SelectionStart = 0;
            this.key_textBox.ShortcutsEnabled = true;
            this.key_textBox.Size = new System.Drawing.Size(304, 23);
            this.key_textBox.TabIndex = 2;
            this.key_textBox.UseSelectable = true;
            this.key_textBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.key_textBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.key_textBox.MouseEnter += new System.EventHandler(this.key_textBox_MouseEnter);
            // 
            // install_KEY_Button1
            // 
            this.install_KEY_Button1.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.install_KEY_Button1.Location = new System.Drawing.Point(316, 178);
            this.install_KEY_Button1.Name = "install_KEY_Button1";
            this.install_KEY_Button1.Size = new System.Drawing.Size(87, 22);
            this.install_KEY_Button1.TabIndex = 3;
            this.install_KEY_Button1.Text = "安装 KEY";
            this.install_KEY_Button1.UseSelectable = true;
            this.install_KEY_Button1.Click += new System.EventHandler(this.install_KEY_Button1_Click);
            // 
            // check_Button
            // 
            this.check_Button.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.check_Button.Location = new System.Drawing.Point(316, 209);
            this.check_Button.Name = "check_Button";
            this.check_Button.Size = new System.Drawing.Size(87, 22);
            this.check_Button.TabIndex = 6;
            this.check_Button.Text = "检测";
            this.check_Button.UseSelectable = true;
            this.check_Button.Click += new System.EventHandler(this.check_Button_Click);
            // 
            // sku_textBox
            // 
            // 
            // 
            // 
            this.sku_textBox.CustomButton.Image = null;
            this.sku_textBox.CustomButton.Location = new System.Drawing.Point(21, 1);
            this.sku_textBox.CustomButton.Name = "";
            this.sku_textBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.sku_textBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.sku_textBox.CustomButton.TabIndex = 1;
            this.sku_textBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.sku_textBox.CustomButton.UseSelectable = true;
            this.sku_textBox.CustomButton.Visible = false;
            this.sku_textBox.Lines = new string[0];
            this.sku_textBox.Location = new System.Drawing.Point(267, 208);
            this.sku_textBox.MaxLength = 32767;
            this.sku_textBox.Name = "sku_textBox";
            this.sku_textBox.PasswordChar = '\0';
            this.sku_textBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.sku_textBox.SelectedText = "";
            this.sku_textBox.SelectionLength = 0;
            this.sku_textBox.SelectionStart = 0;
            this.sku_textBox.ShortcutsEnabled = true;
            this.sku_textBox.Size = new System.Drawing.Size(43, 23);
            this.sku_textBox.TabIndex = 5;
            this.sku_textBox.UseSelectable = true;
            this.sku_textBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.sku_textBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(14, 14);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(23, 311);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(409, 234);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "进度详情";
            // 
            // textBox1
            // 
            this.textBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.textBox1.BackColor = System.Drawing.Color.LemonChiffon;
            // 
            // 
            // 
            this.textBox1.CustomButton.Image = null;
            this.textBox1.CustomButton.Location = new System.Drawing.Point(199, 1);
            this.textBox1.CustomButton.Name = "";
            this.textBox1.CustomButton.Size = new System.Drawing.Size(197, 197);
            this.textBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBox1.CustomButton.TabIndex = 1;
            this.textBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBox1.CustomButton.UseSelectable = true;
            this.textBox1.CustomButton.Visible = false;
            this.textBox1.Lines = new string[0];
            this.textBox1.Location = new System.Drawing.Point(6, 22);
            this.textBox1.MaxLength = 99999999;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.SelectedText = "";
            this.textBox1.SelectionLength = 0;
            this.textBox1.SelectionStart = 0;
            this.textBox1.ShortcutsEnabled = true;
            this.textBox1.Size = new System.Drawing.Size(397, 199);
            this.textBox1.Style = MetroFramework.MetroColorStyle.Orange;
            this.textBox1.TabIndex = 0;
            this.textBox1.UseCustomBackColor = true;
            this.textBox1.UseSelectable = true;
            this.textBox1.UseStyleColors = true;
            this.textBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // activeButton
            // 
            this.activeButton.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.activeButton.Location = new System.Drawing.Point(23, 551);
            this.activeButton.Name = "activeButton";
            this.activeButton.Size = new System.Drawing.Size(75, 23);
            this.activeButton.TabIndex = 6;
            this.activeButton.Text = "激活";
            this.activeButton.UseSelectable = true;
            this.activeButton.Click += new System.EventHandler(this.activeButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.exitButton.Location = new System.Drawing.Point(357, 551);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 0;
            this.exitButton.Text = "退出";
            this.exitButton.UseSelectable = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(104, 551);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(247, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Select_Product_KEY});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            // 
            // Select_Product_KEY
            // 
            this.Select_Product_KEY.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Cloud,
            this.CloudN,
            this.Core,
            this.CoreN,
            this.CoreCountrySpecific,
            this.CoreSingleLanguage,
            this.Education,
            this.EducationN,
            this.Enterprise,
            this.EnterpriseN,
            this.EnterpriseS,
            this.EnterpriseSN,
            this.Professional,
            this.ProfessionalN,
            this.ProfessionalEducation,
            this.ProfessionalEducationN,
            this.ProfessionalWorkstation,
            this.ProfessionalWorkstationN,
            this.ServerRdsh});
            this.Select_Product_KEY.Name = "Select_Product_KEY";
            this.Select_Product_KEY.Size = new System.Drawing.Size(124, 22);
            this.Select_Product_KEY.Text = "选择密钥";
            // 
            // Cloud
            // 
            this.Cloud.Name = "Cloud";
            this.Cloud.Size = new System.Drawing.Size(228, 22);
            this.Cloud.Text = "Cloud";
            // 
            // CloudN
            // 
            this.CloudN.Name = "CloudN";
            this.CloudN.Size = new System.Drawing.Size(228, 22);
            this.CloudN.Text = "CloudN";
            // 
            // Core
            // 
            this.Core.Name = "Core";
            this.Core.Size = new System.Drawing.Size(228, 22);
            this.Core.Text = "Core";
            // 
            // CoreN
            // 
            this.CoreN.Name = "CoreN";
            this.CoreN.Size = new System.Drawing.Size(228, 22);
            this.CoreN.Text = "CoreN";
            // 
            // CoreCountrySpecific
            // 
            this.CoreCountrySpecific.Name = "CoreCountrySpecific";
            this.CoreCountrySpecific.Size = new System.Drawing.Size(228, 22);
            this.CoreCountrySpecific.Text = "CoreCountrySpecific";
            // 
            // CoreSingleLanguage
            // 
            this.CoreSingleLanguage.Name = "CoreSingleLanguage";
            this.CoreSingleLanguage.Size = new System.Drawing.Size(228, 22);
            this.CoreSingleLanguage.Text = "CoreSingleLanguage";
            // 
            // Education
            // 
            this.Education.Name = "Education";
            this.Education.Size = new System.Drawing.Size(228, 22);
            this.Education.Text = "Education";
            // 
            // EducationN
            // 
            this.EducationN.Name = "EducationN";
            this.EducationN.Size = new System.Drawing.Size(228, 22);
            this.EducationN.Text = "EducationN";
            // 
            // Enterprise
            // 
            this.Enterprise.Name = "Enterprise";
            this.Enterprise.Size = new System.Drawing.Size(228, 22);
            this.Enterprise.Text = "Enterprise";
            // 
            // EnterpriseN
            // 
            this.EnterpriseN.Name = "EnterpriseN";
            this.EnterpriseN.Size = new System.Drawing.Size(228, 22);
            this.EnterpriseN.Text = "EnterpriseN";
            // 
            // EnterpriseS
            // 
            this.EnterpriseS.Name = "EnterpriseS";
            this.EnterpriseS.Size = new System.Drawing.Size(228, 22);
            this.EnterpriseS.Text = "EnterpriseS";
            // 
            // EnterpriseSN
            // 
            this.EnterpriseSN.Name = "EnterpriseSN";
            this.EnterpriseSN.Size = new System.Drawing.Size(228, 22);
            this.EnterpriseSN.Text = "EnterpriseSN";
            // 
            // Professional
            // 
            this.Professional.Name = "Professional";
            this.Professional.Size = new System.Drawing.Size(228, 22);
            this.Professional.Text = "Professional";
            // 
            // ProfessionalN
            // 
            this.ProfessionalN.Name = "ProfessionalN";
            this.ProfessionalN.Size = new System.Drawing.Size(228, 22);
            this.ProfessionalN.Text = "ProfessionalN";
            // 
            // ProfessionalEducation
            // 
            this.ProfessionalEducation.Name = "ProfessionalEducation";
            this.ProfessionalEducation.Size = new System.Drawing.Size(228, 22);
            this.ProfessionalEducation.Text = "ProfessionalEducation";
            // 
            // ProfessionalEducationN
            // 
            this.ProfessionalEducationN.Name = "ProfessionalEducationN";
            this.ProfessionalEducationN.Size = new System.Drawing.Size(228, 22);
            this.ProfessionalEducationN.Text = "ProfessionalEducationN";
            // 
            // ProfessionalWorkstation
            // 
            this.ProfessionalWorkstation.Name = "ProfessionalWorkstation";
            this.ProfessionalWorkstation.Size = new System.Drawing.Size(228, 22);
            this.ProfessionalWorkstation.Text = "ProfessionalWorkstation";
            // 
            // ProfessionalWorkstationN
            // 
            this.ProfessionalWorkstationN.Name = "ProfessionalWorkstationN";
            this.ProfessionalWorkstationN.Size = new System.Drawing.Size(228, 22);
            this.ProfessionalWorkstationN.Text = "ProfessionalWorkstationN";
            // 
            // ServerRdsh
            // 
            this.ServerRdsh.Name = "ServerRdsh";
            this.ServerRdsh.Size = new System.Drawing.Size(228, 22);
            this.ServerRdsh.Text = "ServerRdsh";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(455, 587);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.activeButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0.9D;
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "W10 数字许可 C# [在线]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ImageList imageList1;
        private MetroFramework.Controls.MetroTextBox key_textBox;
        private MetroFramework.Controls.MetroButton install_KEY_Button1;
        private MetroFramework.Controls.MetroTextBox sku_textBox;
        private MetroFramework.Controls.MetroButton check_Button;
        private MetroFramework.Controls.MetroLink metroLink1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private MetroFramework.Controls.MetroButton activeButton;
        private MetroFramework.Controls.MetroButton exitButton;
        private MetroFramework.Controls.MetroProgressBar progressBar1;
        private MetroFramework.Controls.MetroTextBox textBox1;
        private MetroFramework.Controls.MetroContextMenu contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Select_Product_KEY;
        private System.Windows.Forms.ToolStripMenuItem Cloud;
        private System.Windows.Forms.ToolStripMenuItem CloudN;
        private System.Windows.Forms.ToolStripMenuItem Core;
        private System.Windows.Forms.ToolStripMenuItem CoreN;
        private System.Windows.Forms.ToolStripMenuItem CoreCountrySpecific;
        private System.Windows.Forms.ToolStripMenuItem CoreSingleLanguage;
        private System.Windows.Forms.ToolStripMenuItem Education;
        private System.Windows.Forms.ToolStripMenuItem EducationN;
        private System.Windows.Forms.ToolStripMenuItem Enterprise;
        private System.Windows.Forms.ToolStripMenuItem EnterpriseN;
        private System.Windows.Forms.ToolStripMenuItem EnterpriseS;
        private System.Windows.Forms.ToolStripMenuItem EnterpriseSN;
        private System.Windows.Forms.ToolStripMenuItem Professional;
        private System.Windows.Forms.ToolStripMenuItem ProfessionalN;
        private System.Windows.Forms.ToolStripMenuItem ProfessionalEducation;
        private System.Windows.Forms.ToolStripMenuItem ProfessionalEducationN;
        private System.Windows.Forms.ToolStripMenuItem ProfessionalWorkstation;
        private System.Windows.Forms.ToolStripMenuItem ProfessionalWorkstationN;
        private MetroFramework.Controls.MetroComboBox comboBox1;
        private MetroFramework.Controls.MetroLabel lang_Label;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ToolStripMenuItem ServerRdsh;
    }
}

