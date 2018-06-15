using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using LanguageLibrary;
using System.Drawing;
using System.Threading.Tasks;
using System.Threading;

namespace DigitalLicense
{
    //[Obfuscation(Feature = "Apply to member * when method or constructor: virtualization", Exclude = false)]
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        #region 全局值
        public string[] Args { get; set; }
        public string OsName { get; set; }
        public string OsBuild { get; set; }
        public string OsDescription { get; set; }
        public string OsID { get; set; }
        public string OsPartialProductKey { get; set; }
        public string OsLicenseStatus { get; set; }
        public string ProductStatus { get; set; }
        public string WUStatus { get; set; }

        public string soft_ver = "v2.7.9";

        public string cmdout;

        public string TempPath = @Environment.GetEnvironmentVariable("TEMP");

        static Dictionary<string, string> LangsDic = new Dictionary<string, string>();

        static Dictionary<string, string> editionDic = new Dictionary<string, string>();
        #endregion        

        #region 密钥字典&语言字典初始
        public void EditionDic_init()
        {
            editionDic.Add("Cloud", "V3WVW-N2PV2-CGWC3-34QGF-VMJ2C");
            editionDic.Add("CloudN", "NH9J3-68WK7-6FB93-4K3DF-DJ4F6");
            editionDic.Add("Core", "YTMG3-N6DKC-DKB77-7M9GH-8HVX7");
            editionDic.Add("CoreCountrySpecific", "N2434-X9D7W-8PF6X-8DV9T-8TYMD");
            editionDic.Add("CoreN", "4CPRK-NM3K3-X6XXQ-RXX86-WXCHW");
            editionDic.Add("CoreSingleLanguage", "BT79Q-G7N6G-PGBYW-4YWX6-6F4BT");
            editionDic.Add("Education", "YNMGQ-8RYV3-4PGQ3-C8XTP-7CFBY");
            editionDic.Add("EducationN", "84NGF-MHBT6-FXBX8-QWJK7-DRR8H");
            editionDic.Add("Enterprise", "XGVPP-NMH47-7TTHJ-W3FW7-8HV2C");
            editionDic.Add("EnterpriseN", "3V6Q6-NQXCX-V8YXR-9QCYV-QPFCT");
            editionDic.Add("EnterpriseS", "NK96Y-D9CD8-W44CQ-R8YTK-DYJWX");
            editionDic.Add("EnterpriseSN", "2DBW3-N2PJG-MVHW3-G7TDK-9HKR4");
            editionDic.Add("Professional", "VK7JG-NPHTM-C97JM-9MPGT-3V66T");
            editionDic.Add("ProfessionalN", "2B87N-8KFHP-DKV6R-Y2C8J-PKCKT");
            editionDic.Add("ProfessionalEducation", "8PTT6-RNW4C-6V7J2-C2D3X-MHBPB");
            editionDic.Add("ProfessionalEducationN", "GJTYN-HDMQY-FRR76-HVGC7-QPF8P");
            editionDic.Add("ProfessionalWorkstation", "DXG7C-N36C4-C4HTG-X4T3X-2YV77");
            editionDic.Add("ProfessionalWorkstationN", "WYPNQ-8C467-V2W6J-TX4WX-WT2RQ");
            editionDic.Add("ServerRdsh", "NJCF7-PW8QT-3324D-688JX-2YV66");
        }
        public void LangsDic_init()
        {
            LangsDic.Add("简体中文", "zh_cn");
            LangsDic.Add("繁體中文", "zh_tw");
            LangsDic.Add("Bosanski", "bs_latn_ba");
            LangsDic.Add("Српски", "sr_cyrl_rs");
            LangsDic.Add("English", "en_us");
            LangsDic.Add("Español", "es_ec");
            LangsDic.Add("Español (es_es)", "es_es");
            LangsDic.Add("Français (France)", "fr_fr");
            LangsDic.Add("Italiano", "it_it");
            LangsDic.Add("Português", "pt_br");
            LangsDic.Add("Polish", "pl_pl");
            LangsDic.Add("Русский RU", "ru_ru");
            LangsDic.Add("Tiếng Việt", "vi_vn");
            LangsDic.Add("한국어", "ko_kr");
            LangsDic.Add("Ελληνικά", "el_gr");
            LangsDic.Add("العربية", "ar_ly");
            LangsDic.Add("Čeština", "cs_cz");
            LangsDic.Add("Română", "ro_ro");
            LangsDic.Add("Nederlands", "nl_nl");
            LangsDic.Add("Shqip", "sq_al");
            LangsDic.Add("Deutsch", "de_de");
            LangsDic.Add("Persian (Farsi)", "fa_ir");
        }
        #endregion

        public Form1(string[] args)
        {
            Args = args;
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
            InitializeComponent();
            var currentLang = CultureInfo.CurrentCulture.ToString().ToLower().Replace("-", "_");
            if (!Language.GetLangNames().ContainsValue(currentLang))
            {
                currentLang = "en_us";
            }
          
            Language.Init();

            Register register = new Register("Software\\", Register.RegDomain.CurrentUser);
            register.CreateSubKey("Software\\W10DigitalLicense", Register.RegDomain.CurrentUser);
            register.SubKey = "Software\\W10DigitalLicense";
            if (!register.IsRegeditKeyExist("LangSetting"))
            {
                Language.Set(currentLang);
                register.WriteRegeditKey("LangSetting", currentLang);
                //RunCMD("cmd.exe", " /c reg add \"HKCU\\SOFTWARE\\W10DigitalLicense\" /v " + "LangSetting" + " /d " + currentLang + " /f");
            }
            else
                Language.Set(register.ReadRegeditKey("LangSetting").ToString());

            //版本密钥字典初始
            EditionDic_init();

            IntPtr wow64Value = IntPtr.Zero;
            if (Environment.Is64BitOperatingSystem)
                Wow64DisableWow64FsRedirection(ref wow64Value);

        }

        #region 窗体加载事件
        private void Form1_Load(object sender, EventArgs e)
        {
            LangsDic_init();
            comboBox1.SelectedItem = Language.Default.语言名称;

            //添加鼠标右键事件
            AddMenuEvents(contextMenuStrip1);

            //如果是WIN10
            if (Environment.OSVersion.ToString().Contains("10.0."))
            {
                if (Args.Length != 0 && Args[0] == "/Q") //如果参数为/Q
                    DisplayResults();
            }
           else //如果不是WIN10
            {
                if (Args.Length != 0 && Args[0] == "/Q") //如果参数为/Q
                {
                    WriteLog(Language.Default.提示_不支持);
                    Close();
                }
                else
                {
                    MessageBox.Show(Language.Default.提示_不支持, Language.Default.标题_警告, MessageBoxButtons.OK,MessageBoxIcon.Stop,MessageBoxDefaultButton.Button1,MessageBoxOptions.DefaultDesktopOnly,false);
                    Close();
                }
            }
            

        }
        #endregion

        #region 窗体加载完成后事件
        private async void Form1_Shown(object sender, EventArgs e)
        {
            GUI_Refresh();
            await GetOSInfo();
            Refresh();
        }
        #endregion

        #region 重写窗体可见性
        protected override void OnVisibleChanged(EventArgs e)
        {
            if (Args.Length != 0 && Args[0] == "/Q")
            {
                base.OnVisibleChanged(e);
                this.Visible = false;
            }
        }
        #endregion

        #region 界面语言刷新
        public void GUI_Refresh()
        {
            //清空帮助说明
            if (textBox1.Text.Contains(Language.Default.read_1))
            {
                textBox1.Text = "";
                textBox1.AppendText("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
                textBox1.Text = "";
            }

            listView1.Items.Clear();
            listView1.Columns.Add("Name", 120, HorizontalAlignment.Left);
            listView1.Columns.Add("Value", 263, HorizontalAlignment.Left);
            listView1.BeginUpdate();
            for (int i = 0; i < 7; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = "";
                lvi.SubItems.Add("");
                listView1.Items.Add(lvi);
            }
            listView1.EndUpdate();
            groupBox1.Text = Language.Default.main_系统信息;
            listView1.Items[0].SubItems[0].Text = Language.Default.main_产品名称;
            listView1.Items[1].SubItems[0].Text = Language.Default.main_类型;
            listView1.Items[2].SubItems[0].Text = Language.Default.main_描述;
            listView1.Items[3].SubItems[0].Text = Language.Default.main_激活ID;
            listView1.Items[4].SubItems[0].Text = Language.Default.main_部份产品密钥;
            listView1.Items[5].SubItems[0].Text = Language.Default.main_许可证状态;
            listView1.Items[6].SubItems[0].Text = Language.Default.main_WU状态;
            install_KEY_Button1.Text = Language.Default.main_安装密钥;
            check_Button.Text = Language.Default.main_检测;
            lang_Label.Text = Language.Default.main_界面语言;
            saveTicketCheckBox.Text = Language.Default.main_保存门票;
            groupBox2.Text = Language.Default.main_进度详情;
            activeButton.Text = Language.Default.main_激活;
            exitButton.Text = Language.Default.main_退出;
            metroLink1.Text = Language.Default.main_link_text;
            contextMenuStrip1.Items[0].Text = Language.Default.右键_选择密钥;

            if (!(Args.Length != 0 && Args[0] == "/Q"))
            {
                textBox1.AppendText(Language.Default.read_0 + "\r\n\r\n"
                                  + Language.Default.read_1 + "\r\n\r\n"
                                  + Language.Default.read_2 + "\r\n\r\n"
                                  + Language.Default.read_3 + "\r\n\r\n"
                                  + Language.Default.read_4 + "\r\n\r\n"
                                  + Language.Default.read_5 + "\r\n\r\n"
                                  + Language.Default.read_6 + "\r\n" 
                                  );
            }


        }
        #endregion

        #region 获取系统信息
        public Task GetOSInfo()
        {
            return Task.Run(() => 
            {
                //网络是否连接
                int i = 0;
                if (InternetGetConnectedState(out i, 0))
                    this.Text = Language.Default.main_窗口名_在线 + " " + soft_ver;
                else
                    this.Text = Language.Default.main_窗口名_离线 + " " + soft_ver;

                Register register = new Register(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", Register.RegDomain.LocalMachine);

                ManagementScope scope = new ManagementScope(@"\\" + System.Environment.MachineName + @"\root\cimv2");
                scope.Connect();
                SelectQuery searchQuery = new SelectQuery("SELECT * FROM SoftwareLicensingProduct WHERE PartialProductKey <> null AND ApplicationID = '55c92734-d682-4d71-983e-d6ec3f16059f'");
                ManagementObjectSearcher searcherObj = new ManagementObjectSearcher(scope, searchQuery);
                foreach (ManagementBaseObject mo in searcherObj.Get())
                {
                    string[] nameArray = mo["Name"].ToString().Split(' ');
                    OsName = nameArray[1];//产品名称
                    string[] desArray = mo["Description"].ToString().Split(' ');
                    OsDescription = desArray[3];//描述
                    OsID = mo["ID"].ToString();//激活ID
                    OsPartialProductKey = mo["PartialProductKey"].ToString();//部份产品密钥
                    OsLicenseStatus = mo["LicenseStatus"].ToString();//许可状态
                }

                //版本号
                string ver = register.ReadRegeditKey("BuildLabEx").ToString();
                string[] verArray = ver.Split('.');
                OsBuild = verArray[0] + "." + verArray[1];

                //许可状态
                switch (OsLicenseStatus)
                {
                    case "0":
                        {
                            ProductStatus = Language.Default.info_未授权;
                            break;
                        }
                    case "1":
                        {
                            ProductStatus = Language.Default.info_已授权;
                            break;
                        }
                    case "2":
                        {
                            ProductStatus = Language.Default.info_初始宽限期;
                            break;
                        }
                    case "3":
                        {
                            ProductStatus = Language.Default.info_延长宽限期;
                            break;
                        }
                    case "4":
                        {
                            ProductStatus = Language.Default.info_非正版宽限期;
                            break;
                        }
                    case "5":
                        {
                            ProductStatus = Language.Default.info_通知状态;
                            break;
                        }
                    default:
                        {
                            ProductStatus = Language.Default.info_未知;
                            break;
                        }
                }

                //SKU值
                int SKU;
                GetProductInfo(
                    Environment.OSVersion.Version.Major,
                    Environment.OSVersion.Version.Minor,
                    0,
                    0,
                    out SKU);
                if (OsName == "ProfessionalEducation")
                    sku_textBox.Text = "164";
                else if (OsName == "ProfessionalEducationN")
                    sku_textBox.Text = "165";
                else
                    sku_textBox.Text = SKU.ToString();

                //将获取的值显示到listView1
                //1.产品
                listView1.Items[0].SubItems[1].Text =  OsName + " [" + OsBuild + "]";
                //2.类型
                if (Environment.Is64BitOperatingSystem)
                    listView1.Items[1].SubItems[1].Text = "x64";
                else
                    listView1.Items[1].SubItems[1].Text = "x86";
                //3.描述
                listView1.Items[2].SubItems[1].Text = OsDescription;
                //4.激活ID
                listView1.Items[3].SubItems[1].Text = OsID;
                //5.部份密钥
                listView1.Items[4].SubItems[1].Text = OsPartialProductKey;
                //6.许可状态
                listView1.Items[5].SubItems[1].Text = ProductStatus;
                //7.WindowsUpdate状态
                register.SubKey = @"SYSTEM\CurrentControlSet\Services\wuauserv";
                string WU  = register.ReadRegeditKey("Start").ToString();
                switch (WU)
                {
                    case "1":
                        {
                            WUStatus = Language.Default.info_WU_自动延迟;
                            break;
                        }
                    case "2":
                        {
                            WUStatus = Language.Default.info_WU_自动;
                            break;
                        }
                    case "3":
                        {
                            WUStatus = Language.Default.info_WU_手动;
                            break;
                        }
                    case "4":
                        {
                            WUStatus = Language.Default.info_WU_禁用;
                            break;
                        }
                }
                listView1.Items[6].SubItems[1].Text = WUStatus;

                //如果KEY文本框为空，显示内置KEY
                if (key_textBox.Text == "")
                {
                    if (editionDic.ContainsKey(OsName.ToString()))
                    {
                        if (OsName == "EnterpriseS" && OsBuild.Contains("10240"))
                            key_textBox.Text = "FWN7H-PF93Q-4GGP8-M8RF3-MDWWW";
                        else if (OsName == "EnterpriseSN" && OsBuild.Contains("10240"))
                            key_textBox.Text = "8V8WN-3GXBH-2TCMG-XHRX3-9766K";
                        else
                            key_textBox.Text = editionDic[OsName.ToString()];
                    }
                    else
                        key_textBox.Text = Language.Default.提示_无KEY;

                }
            });
        }
        #endregion

        #region 右键菜单事件
        private void AddMenuEvents(ContextMenuStrip m)
        {
            m.Opacity = 0.8;

            foreach (ToolStripItem items in m.Items)
            {

                if (items is ToolStripMenuItem)
                {
                    ChildMenu((ToolStripMenuItem)items);
                }
            }
        }
        private void ChildMenu(ToolStripMenuItem menu)
        {
            if (menu.HasDropDownItems)
            {
                //如果有子菜单
                foreach (ToolStripMenuItem m in menu.DropDownItems)
                {
                    ChildMenu(m);
                }
            }
            else
            {
                //如果没有子菜单就直接添加自定义事件 menuStrip1_event
                menu.Click += new EventHandler(MenuStrip1_Click);
            }
        }
        private void MenuStrip1_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ts = (sender as ToolStripMenuItem);
            switch (ts.Name)
            {
                case "Cloud":
                    key_textBox.Text = editionDic[ts.Name];
                    sku_textBox.Text = "178";
                    break;
                case "CloudN":
                    key_textBox.Text = editionDic[ts.Name];
                    sku_textBox.Text = "179";
                    break;
                case "Core":
                    key_textBox.Text = editionDic[ts.Name];
                    sku_textBox.Text = "101";
                    break;
                case "CoreCountrySpecific":
                    key_textBox.Text = editionDic[ts.Name];
                    sku_textBox.Text = "99";
                    break;
                case "CoreN":
                    key_textBox.Text = editionDic[ts.Name];
                    sku_textBox.Text = "98";
                    break;
                case "CoreSingleLanguage":
                    key_textBox.Text = editionDic[ts.Name];
                    sku_textBox.Text = "100";
                    break;
                case "Education":
                    key_textBox.Text = editionDic[ts.Name];
                    sku_textBox.Text = "121";
                    break;
                case "EducationN":
                    key_textBox.Text = editionDic[ts.Name];
                    sku_textBox.Text = "122";
                    break;
                case "Enterprise":
                    key_textBox.Text = editionDic[ts.Name];
                    sku_textBox.Text = "4";
                    break;
                case "EnterpriseN":
                    key_textBox.Text = editionDic[ts.Name];
                    sku_textBox.Text = "27";
                    break;
                case "EnterpriseS":
                    if(OsBuild.Contains("10240"))
                        key_textBox.Text = "FWN7H-PF93Q-4GGP8-M8RF3-MDWWW";
                    else
                        key_textBox.Text = editionDic[ts.Name];
                    sku_textBox.Text = "125";
                    break;
                case "EnterpriseSN":
                    if (OsBuild.Contains("10240"))
                        key_textBox.Text = "8V8WN-3GXBH-2TCMG-XHRX3-9766K";
                    else
                        key_textBox.Text = editionDic[ts.Name];
                    sku_textBox.Text = "126";
                    break;
                case "Professional":
                    key_textBox.Text = editionDic[ts.Name];
                    sku_textBox.Text = "48";
                    break;
                case "ProfessionalN":
                    key_textBox.Text = editionDic[ts.Name];
                    sku_textBox.Text = "49";
                    break;
                case "ProfessionalEducation":
                    key_textBox.Text = editionDic[ts.Name];
                    sku_textBox.Text = "164";
                    break;
                case "ProfessionalEducationN":
                    key_textBox.Text = editionDic[ts.Name];
                    sku_textBox.Text = "165";
                    break;
                case "ProfessionalWorkstation":
                    key_textBox.Text = editionDic[ts.Name];
                    sku_textBox.Text = "161";
                    break;
                case "ProfessionalWorkstationN":
                    key_textBox.Text = editionDic[ts.Name];
                    sku_textBox.Text = "162";
                    break;
                case "ServerRdsh":
                    key_textBox.Text = editionDic[ts.Name];
                    sku_textBox.Text = "175";
                    break;

                default:
                    break;
            }
        }
        #endregion

        #region CMD调用
        public Task<string> RunCMD(string arg1, string arg2)
        {
            return Task.Run(() =>
            {
                try
                {
                    Process p = new Process();
                    //设定程序名
                    p.StartInfo.FileName = arg1;
                    //关闭Shell的使用
                    p.StartInfo.UseShellExecute = false;

                    p.StartInfo.Arguments = (arg2);
                    //重定向标准输入
                    p.StartInfo.RedirectStandardInput = true;
                    //重定向标准输出
                    p.StartInfo.RedirectStandardOutput = true;
                    //重定向错误输出
                    p.StartInfo.RedirectStandardError = true;
                    //设置不显示窗口
                    p.StartInfo.CreateNoWindow = true;

                    //启动进程
                    p.Start();
                    string cmdout = p.StandardOutput.ReadToEnd();
                    p.WaitForExit();
                    p.Close();
                    return cmdout;
                }
                catch (Exception ex)
                {
                    return "error:" + ex.Message;
                }
            });
        }
        #endregion

        #region 提取嵌入的文件到%TEMP%目录
        public void Extractfile()
        {
            try
            {
                Stream exeStream = this.GetType().Assembly.GetManifestResourceStream("DigitalLicense.gatherosstate.exe");
                byte[] bs = new byte[exeStream.Length];
                exeStream.Read(bs, 0, bs.Length);

                if ((OsName == "EnterpriseS" && OsBuild.Contains("10240")) || (OsName == "EnterpriseSN" && OsBuild.Contains("10240")))
                {

                    bs.SetValue((Byte)0x31, 148350);
                    bs.SetValue((Byte)0x39, 148352);
                    bs.SetValue((Byte)0x39, 148356);
                    bs.SetValue((Byte)0x39, 148358);
                    bs.SetValue((Byte)0x36, 148360);
                    bs.SetValue((Byte)0x31, 148362);
                    bs.SetValue((Byte)0x37, 148364);
                    bs.SetValue((Byte)0x31, 160606);
                    bs.SetValue((Byte)0x39, 160608);
                    bs.SetValue((Byte)0x39, 160612);
                    bs.SetValue((Byte)0x38, 160614);
                    bs.SetValue((Byte)0x37, 160616);
                    bs.SetValue((Byte)0x37, 160618);
                    bs.SetValue((Byte)0x30, 160620);
                }

                Stream dllStream = this.GetType().Assembly.GetManifestResourceStream("DigitalLicense.slc.dll");
                byte[] bs1 = new byte[dllStream.Length];
                dllStream.Read(bs1, 0, bs1.Length);

                //Stream clipupStream = this.GetType().Assembly.GetManifestResourceStream("DigitalLicense.ClipUp.exe");
                //byte[] bs2 = new byte[clipupStream.Length];
                //clipupStream.Read(bs2, 0, bs2.Length);

                FileStream fs = new FileStream(TempPath + "\\gatherosstate.exe", FileMode.Create, FileAccess.ReadWrite);
                FileStream fs1 = new FileStream(TempPath + "\\slc.dll", FileMode.Create, FileAccess.ReadWrite);
                //FileStream fs2 = new FileStream(TempPath + "\\ClipUp.exe", FileMode.Create, FileAccess.ReadWrite);
                fs.Write(bs, 0, bs.Length);
                fs1.Write(bs1, 0, bs1.Length);
                //fs2.Write(bs2, 0, bs2.Length);

                fs.Flush();
                fs1.Flush();
                //fs2.Flush();
                fs.Close();
                fs1.Close();
                //fs2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.Default.提示_提取错误 + ex.Message);
            }
        }
        #endregion

        #region 写日志函数
        public static void WriteLog(string strLog)
        {
            string sFilePath = "C:";
            string sFileName = Language.Default.info_日志文件名;
            sFileName = sFilePath + "\\" + sFileName; //文件的绝对路径
            if (!Directory.Exists(sFilePath))//验证路径是否存在
            {
                Directory.CreateDirectory(sFilePath);
                //不存在则创建
            }
            FileStream fs;
            StreamWriter sw;
            if (File.Exists(sFileName))
            //验证文件是否存在，有则追加，无则创建
            {
                fs = new FileStream(sFileName, FileMode.Append, FileAccess.Write);
            }
            else
            {
                fs = new FileStream(sFileName, FileMode.Create, FileAccess.Write);
            }
            sw = new StreamWriter(fs);
            sw.Write(strLog);
            sw.Close();
            fs.Close();
        }
        #endregion

        #region 激活按钮点击事件
        private void activeButton_Click(object sender, EventArgs e)
        {
            DisplayResults();
        }

        public async void DisplayResults()
        {
            if (Args.Length != 0 && Args[0] == "/Q")
                await GetOSInfo();
            //清空帮助说明
            if (textBox1.Text.Contains(Language.Default.read_1))
            {
                textBox1.Text = "";
                textBox1.AppendText("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
                textBox1.Text = "";
            }
            activeButton.Enabled = false;
            install_KEY_Button1.Enabled = false;
            //提取嵌入的文件
            Extractfile();
            progressBar1.Value = 15;
            Register register = new Register(@"SYSTEM", Register.RegDomain.LocalMachine);
            string windir = Environment.GetFolderPath(Environment.SpecialFolder.System);
            textBox1.AppendText("+++++++++++++++++++++++++++++++++++++++++++++\r\n");
            textBox1.AppendText(listView1.Items[0].SubItems[0].Text + ": " + listView1.Items[0].SubItems[1].Text + "\r\n");
            textBox1.AppendText(TimeNow() + " " + Language.Default.info_准备 + "\r\n");
            progressBar1.Value = 25;
            //安装密钥
            textBox1.AppendText(TimeNow() + " " + Language.Default.info_安装密钥 + key_textBox.Text + "\r\n");
            cmdout = await RunCMD("cmd.exe", " /c cscript.exe /nologo " + windir + "\\slmgr.vbs /ipk " + key_textBox.Text);
            textBox1.AppendText(cmdout);
            progressBar1.Value = 35;
            //添加注册表项
            textBox1.AppendText(TimeNow() + " SKU: " + sku_textBox.Text + "\r\n");
            textBox1.AppendText(TimeNow() + " " + Language.Default.info_添加注册表 + "\r\n");
            register.CreateSubKey(@"SYSTEM\Tokens\Kernel");
            register.SubKey = @"SYSTEM\Tokens";
            register.WriteRegeditKey("Channel", "Retail", Register.RegValueKind.String);
            register.SubKey = @"SYSTEM\Tokens\Kernel";
            register.WriteRegeditKey("Kernel-ProductInfo", sku_textBox.Text, Register.RegValueKind.DWord);
            register.WriteRegeditKey("Security-SPP-GenuineLocalStatus", 1, Register.RegValueKind.DWord);

            if (Environment.Is64BitOperatingSystem)
                cmdout = await RunCMD("cmd.exe", " /c reg add \"HKCU\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers\" /v " + TempPath + "\\gatherosstate.exe" + " /d \"^ WIN7RTM\" /f /reg:64");
            else
                cmdout = await RunCMD("cmd.exe", " /c reg add \"HKCU\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers\" /v " + TempPath + "\\gatherosstate.exe" + " /d \"^ WIN7RTM\" /f");
            progressBar1.Value = 60;
            //获取门票
            textBox1.AppendText(TimeNow() + " " + Language.Default.info_获取门票 + "\r\n");
            cmdout = await RunCMD("cmd.exe", " /c " + TempPath + "\\gatherosstate.exe");
            progressBar1.Value = 75;
            await Sleep(3000);
            //保存门票
            if (saveTicketCheckBox.Checked == true)
            {
                textBox1.AppendText(TimeNow() + " " + Language.Default.info_保存门票 + "\r\n");
                if (File.Exists(Path.GetFullPath(TempPath + "\\GenuineTicket.xml")))
                    File.Copy(Path.GetFullPath(TempPath + "\\GenuineTicket.xml"), "C:\\GenuineTicket.xml", true);
            }
            //删除注册表项
            textBox1.AppendText(TimeNow() + " " + Language.Default.info_删除注册表 + "\r\n\r\n");
            cmdout = await RunCMD("cmd.exe", " /c reg delete \"HKLM\\SYSTEM\\Tokens\" /f");
            if (Environment.Is64BitOperatingSystem)
                cmdout = await RunCMD("cmd.exe", " /c reg delete \"HKCU\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers\" /v " + TempPath + "\\gatherosstate.exe" + " /f /reg:64");
            else
                cmdout = await RunCMD("cmd.exe", " /c reg delete \"HKCU\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers\" /v " + TempPath + "\\gatherosstate.exe" + " /f");
                //应用门票
                textBox1.AppendText(TimeNow() + " " + Language.Default.info_应用门票 + "\r\n");
            cmdout = await RunCMD("cmd.exe", " /c " + windir + "\\ClipUp.exe -v -o -altto " + TempPath);
            textBox1.AppendText(cmdout);
            textBox1.AppendText("+++++++++++++++++++++++++++++++++++++++++++++\r\n");
            progressBar1.Value = 85;
            //激活系统
            textBox1.AppendText(TimeNow() + " " + Language.Default.info_激活系统 + "\r\n");
            if (WUStatus == Language.Default.info_WU_禁用)
            {
                textBox1.AppendText(TimeNow() + " " + Language.Default.info_WU_设置手动 + "\r\n");
                register.SubKey = @"SYSTEM\CurrentControlSet\Services\wuauserv";
                try
                {
                    register.WriteRegeditKey("Start", 3, Register.RegValueKind.DWord);
                    textBox1.AppendText(TimeNow() + " " + Language.Default.info_WU_启动 + "\r\n");
                    cmdout =await RunCMD("cmd.exe", " /c net start wuauserv");
                    textBox1.AppendText(cmdout);
                }
                catch (Exception ex)
                {
                    textBox1.AppendText(TimeNow() + " " + Language.Default.info_WU_启动失败 + ex.Message); 
                }
            }
            cmdout = await RunCMD("cmd.exe", " /c cscript.exe /nologo " + windir + "\\slmgr.vbs /ato");
            textBox1.AppendText(cmdout);
            progressBar1.Value = 95;
            //刷新系统信息
            await GetOSInfo();
            textBox1.AppendText(TimeNow() + " " + Language.Default.info_删除临时文件 + "\r\n");
            if (File.Exists(Path.GetFullPath(TempPath + "\\gatherosstate.exe")))
                File.Delete(Path.GetFullPath(TempPath + "\\gatherosstate.exe"));
            if (File.Exists(Path.GetFullPath(TempPath + "\\slc.dll")))
                File.Delete(Path.GetFullPath(TempPath + "\\slc.dll"));
            //if (File.Exists(Path.GetFullPath(TempPath + "\\ClipUp.exe")))
            //    File.Delete(Path.GetFullPath(TempPath + "\\ClipUp.exe"));

            progressBar1.Value = 100;
            textBox1.AppendText(TimeNow() + " " + Language.Default.info_完成 + "\r\n");
            activeButton.Enabled = true;
            install_KEY_Button1.Enabled = true;
            //如果是静默运行，则退出程序
            if (Args.Length != 0 && Args[0] == "/Q")
            {
                WriteLog(textBox1.Text);
                this.Close();
            }
        }

        public Task Sleep(int time)

        {
            return Task.Run(() =>
            {
                Thread.Sleep(time);
            });
        }
        #endregion

        #region 点击安装KEY按钮
        private async void install_KEY_Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains(Language.Default.read_1))
            {
                textBox1.Text = "";
                textBox1.AppendText("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
                textBox1.Text = "";
            }
            string windir = Environment.GetFolderPath(Environment.SpecialFolder.System);
            activeButton.Enabled = false;
            install_KEY_Button1.Enabled = false;
            progressBar1.Value = 50;
            textBox1.AppendText("+++++++++++++++++++++++++++++++++++++++++++++\r\n");
            textBox1.AppendText(TimeNow()+ " " + Language.Default.info_安装密钥 + key_textBox.Text + "\r\n");
            cmdout = await RunCMD("cmd.exe", " /c cscript.exe /nologo " + windir + "\\slmgr.vbs /ipk " + key_textBox.Text);
            textBox1.AppendText(cmdout);
            progressBar1.Value = 80;
            await GetOSInfo();//刷新系统信息
            progressBar1.Value = 100;
            activeButton.Enabled = true;
            install_KEY_Button1.Enabled = true;
        }
        #endregion
        public string TimeNow()
        {
            return DateTime.Now.ToLongTimeString().ToString();
        }
        private void metroLink1_Click(object sender, EventArgs e)
        {
            Process.Start(Language.Default.main_link);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void check_Button_Click(object sender, EventArgs e)
        {
            await GetOSInfo();
            Refresh();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Environment.Is64BitOperatingSystem)
                Wow64RevertWow64FsRedirection(IntPtr.Zero);
        }

        private void key_textBox_MouseEnter(object sender, EventArgs e)
        {
            key_textBox.Focus();
            key_textBox.SelectAll();
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        { 
            //清空帮助说明
            if (textBox1.Text.Contains(Language.Default.read_1))
            {
                textBox1.Text = "";
                textBox1.AppendText("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
                textBox1.Text = "";
            }
            Language.Set(LangsDic[comboBox1.SelectedItem.ToString()]);
            Register register = new Register("Software\\W10DigitalLicense", Register.RegDomain.CurrentUser);
            register.WriteRegeditKey("LangSetting", LangsDic[comboBox1.SelectedItem.ToString()]);
            //RunCMD("cmd.exe", " /c reg add \"HKCU\\SOFTWARE\\W10DigitalLicense\" /v " + "LangSetting" + " /d " + LangsDic[comboBox1.SelectedItem.ToString()] + " /f");
            GUI_Refresh();
            await GetOSInfo();
            Refresh();
        }
        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            this.Focus();
        }

        #region DLL调用

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool Wow64DisableWow64FsRedirection(ref IntPtr ptr);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool Wow64RevertWow64FsRedirection(IntPtr ptr);
        [DllImport("wininet")]
        private extern static bool InternetGetConnectedState(out int connectionDescription, int reservedValue);

        [DllImport("kernel32.dll", SetLastError = false)]
        static extern bool GetProductInfo(
         int dwOSMajorVersion,
         int dwOSMinorVersion,
         int dwSpMajorVersion,
         int dwSpMinorVersion,
         out int pdwReturnedProductType);

        #endregion
    }
}
