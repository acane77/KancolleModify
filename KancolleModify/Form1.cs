using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KancolleModify
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (TabPage page in tabResTypes.TabPages)
            {
                foreach (Control ctrl in page.Controls)
                {
                    if (!(ctrl is PictureBox))
                        continue;
                    RegisterPictureBoxClickEvent(ctrl, ctrl.Name);
                    PictureBox pic = (PictureBox)ctrl;
                    pic.BackgroundImageLayout = ImageLayout.Zoom;
                    pic.BackColor = SystemColors.Control;
                    pic.MouseEnter += (object s, EventArgs ee) => { pic.BackColor = Color.Pink; };
                    pic.MouseLeave += (object s, EventArgs ee) => { pic.BackColor = SystemColors.Control; };
                    //pic.MouseUp += (object s, MouseEventArgs ee) => { pic.BackColor = Color.Pink; };
                    //pic.MouseDown += (object s, MouseEventArgs ee) => { pic.BackColor = Color.HotPink; };
                }
            }
            cbTool.SelectedIndex = 0;

            InitCallbacks();

            //IniConfigLoader ini = new IniConfigLoader(@"C:\Users\Miyuki\Desktop\a.ini");
            LoadConfig();
            ShimakazeGoCachePath = LoadConfig(Config.Meta.ShimakazeGoCachePath);
            ACGPowerCachePath = LoadConfig(Config.Meta.ACGPowerCachePath);

            LocationChanged += (object s, EventArgs ee) =>
            {
                if (frmPreview != null && frmPreview.Visible && !frmPreview.IsDisposed)
                {
                    frmPreview.Location = new Point(this.Location.X + this.Size.Width - 5, this.Location.Y);
                }
            };

            txtKanmusuID.LostFocus += btnPreview_Click;
        }

        private string LoadConfig(string item)
        {
            string str = (Config.Configure.GetValue(item)) ;
            if (str == null)
                return "";
            return str;
        }

        private void LoadConfig()
        {
            Config.Configure = new IniConfigLoader("config.ini");
        }

        private void RegisterPictureBoxClickEvent(Control sender, string what)
        {
            if (!(sender is PictureBox))
            {
                return;
            }
            PictureBox ctrl = (PictureBox)sender;
            ctrl.Click += (object s, EventArgs e) => LoadImage(what, ctrl);
            ctrl.BackgroundImageChanged += (object o, EventArgs e) =>
            {
                PictureBox P = (PictureBox)o;
                if (P.BackgroundImage == null)
                {
                    try
                    {
                        Config.PicturePaths.Remove(P.Name);
                    }
                    catch { }
                    return;
                }
                Config.PicturePaths[P.Name] = (string)P.BackgroundImage.Tag;
            };
        }

        delegate void ActionHandler();
        delegate bool ValueChecker();

        ValueChecker[] ValueCheckers;
        ActionHandler[] CopyHandlers;
        ActionHandler[] ClearHandlers;

        private void InitCallbacks()
        {
            ValueCheckers = new ValueChecker[]
            {
                () => true,
                () => SupplyNormal.BackgroundImage != null,
                () => CardNormal.BackgroundImage != null,
                () => true,
                () => VertDrawingNormal.BackgroundImage != null,
                () => RemodelNormal.BackgroundImage != null,
                () => false,
            };
            CopyHandlers = new ActionHandler[]
            {
                () =>
                {
                    if (Fleet1NamePlateNormal.BackgroundImage != null)
                    {
                        Fleet1NamePlateLost.BackgroundImage = Fleet1NamePlateDmg.BackgroundImage = Fleet1NamePlateNormal.BackgroundImage;
                    }
                    if (Fleet2NamePlateNormal.BackgroundImage != null)
                    {
                        Fleet2NamePlateLost.BackgroundImage = Fleet2NamePlateDmg.BackgroundImage = Fleet2NamePlateNormal.BackgroundImage;
                    }
                },
                () => { SupplyDmg.BackgroundImage = SupplyNormal.BackgroundImage; },
                () => { CardDmg.BackgroundImage = CardNormal.BackgroundImage; },
                () => {
                    if (AlbumFull.BackgroundImage != null)
                    {
                        AlbumFullDmg.BackgroundImage = AlbumFull.BackgroundImage;
                    }
                    if (AlbumHalf.BackgroundImage != null)
                    {
                        AlbumHalfDmg.BackgroundImage = AlbumHalf.BackgroundImage;
                    }
                },
                () => { VertDrawingDmg.BackgroundImage = VertDrawingNormal.BackgroundImage; },
                () => { RemodelDmg.BackgroundImage = RemodelNormal.BackgroundImage; },
                () => { },
            };
            ClearHandlers = new ActionHandler[]
            {
                () => { Fleet1NamePlateNormal.BackgroundImage = Fleet1NamePlateDmg.BackgroundImage = Fleet1NamePlateLost.BackgroundImage = 
                    Fleet2NamePlateNormal.BackgroundImage = Fleet2NamePlateDmg.BackgroundImage = Fleet2NamePlateLost.BackgroundImage = null;  },
                () => { SupplyDmg.BackgroundImage = SupplyNormal.BackgroundImage = null; },
                () => { CardNormal.BackgroundImage = CardDmg.BackgroundImage = null; },
                () => { AlbumFullDmg.BackgroundImage = AlbumFull.BackgroundImage = AlbumHalfDmg.BackgroundImage = AlbumHalf.BackgroundImage = null; },
                () => { VertDrawingDmg.BackgroundImage = VertDrawingNormal.BackgroundImage = null; },
                () => { RemodelDmg.BackgroundImage = RemodelNormal.BackgroundImage = null; },
                () => { },
            };
        }

        private void LoadImage(string where, PictureBox pictureBox)
        {
            DialogResult result = openImage.ShowDialog();
            if (result != DialogResult.OK)
                return;
            try
            {
                Image image = Image.FromFile(openImage.FileName);
                image.Tag = openImage.FileName;
                if (pictureBox.BackgroundImage != null)
                    pictureBox.BackgroundImage.Dispose();
                pictureBox.BackgroundImage = image; 
                pictureBox.BackgroundImageLayout = ImageLayout.Zoom;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCopyFleet_Click(object sender, EventArgs e)
        {
            if (ValueCheckers[tabResTypes.SelectedIndex]())
            {
                CopyHandlers[tabResTypes.SelectedIndex]();
            }
            
        }

        private void btnClearFleet_Click(object sender, EventArgs e)
        {
            if (ValueCheckers[tabResTypes.SelectedIndex]())
            {
                ClearHandlers[tabResTypes.SelectedIndex]();
            }
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            string msg = "";
            foreach (string key in Config.PicturePaths.Keys)
            {
                msg += "[" + key + "] " + Config.PicturePaths[key] + "\r\n";
            }
            MessageBox.Show(msg);
        }

        private String openDirectory()
        {
            if (openDir.ShowDialog() == DialogResult.OK)
            {
                return openDir.SelectedPath;
            }
            return "";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string path = cbTool.SelectedIndex == 0 ? ShimakazeGoCachePath : ACGPowerCachePath;
            if (path == "")
            {
                MessageBox.Show("未选择缓存目录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtKanmusuID.Text == "")
            {
                MessageBox.Show("请输入舰娘ID。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            /// Check dicrectory avaible
            FrmStartModify frmStartModify = new FrmStartModify();
            frmStartModify.KanmusuID = txtKanmusuID.Text;
            frmStartModify.ShowDialog();
        }

        private bool CheckDirectory(string path)
        {
            const int FLAG_KANCOLLE_VER_1 = 1;
            const int FLAG_KANCOLLE_VER_2 = 1 << 1;
            const int FLAG_KANCOLLE_HD = 1 << 2;
            const string KANCOLLE_VER_1 = "kcs";
            const string KANCOLLE_VER_2 = "kcs2";
            const string KANCOLLE_HD = "kcs_hd";
            
            try
            {
                string[] files = Directory.GetDirectories(path);
                int flag = 0;
                foreach (string file in files)
                {
                    string _file = file.Replace(path + (path.EndsWith("\\") ? "" : "\\"), "");
                    switch (_file)
                    {
                        case KANCOLLE_HD: flag |= FLAG_KANCOLLE_HD; break;
                        case KANCOLLE_VER_1: flag |= FLAG_KANCOLLE_VER_1; break;
                        case KANCOLLE_VER_2: flag |= FLAG_KANCOLLE_VER_2; break;
                    }
                }
                return (flag & FLAG_KANCOLLE_VER_2) != 0;
            }
            catch
            {
                return false;
            }
        }

        public string ShimakazeGoCachePath {
            get {
                return Config.ShimakazeGoCachePath;
            }
            set
            {
                if (String.IsNullOrEmpty(value)) return;
                Config.ShimakazeGoCachePath = value;
                Config.Configure.SetValue(Config.Meta.ShimakazeGoCachePath, value);
                cbTool.Items[0] = ((string)cbTool.Items[0]).Split('(')[0] + " (" + value + ")";
            }
        }
        public string ACGPowerCachePath
        {
            get
            {
                return Config.ACGPowerCachePath;
            }
            set
            {
                if (String.IsNullOrEmpty(value)) return;
                Config.ACGPowerCachePath = value;
                Config.Configure.SetValue(Config.Meta.ACGPowerCachePath, value);
                cbTool.Items[1] = ((string)cbTool.Items[1]).Split('(')[0] + " (" + value + ")";
            }
        }

        private void btnCacheDir_Click(object sender, EventArgs e)
        {
            string path = openDirectory();
            if (String.IsNullOrEmpty(path))
                return; // 就当无事发生.jpg
            if (!CheckDirectory(path))
            {
                MessageBox.Show(path + "不是一个缓存目录，请选择其他目录。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                
            switch (cbTool.SelectedIndex) {
                case 0:
                    ShimakazeGoCachePath = path;
                    break;
                case 1:
                    ACGPowerCachePath = path;
                    break;
            }
        }

        private void btnCopySupply_Click(object sender, EventArgs e)
        {
            if (SupplyNormal.BackgroundImage == null)
            {
                SupplyDmg.BackgroundImage = SupplyNormal.BackgroundImage;
            }
        }

        private void btnSupplyClear_Click(object sender, EventArgs e)
        {
            SupplyDmg.BackgroundImage = SupplyNormal.BackgroundImage = null;
        }

        private void btnCardCopy_Click(object sender, EventArgs e)
        {

        }

        private void btnDisplayLost_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("确实想看到击沉的图鉴吗？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                panelLayOverLostPanel.Hide();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.Configure.Write("config.ini");
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            if (saveIni.ShowDialog() != DialogResult.OK)
                return;
            string fileName = saveIni.FileName;

            if (File.Exists(fileName))
                File.Delete(fileName);
            IniConfigLoader ShipConfig = new IniConfigLoader(fileName);
            foreach (var pair in Config.PicturePaths)
            {
                ShipConfig.SetValue("pictures." + pair.Key, pair.Value);
            }
            try
            {
                ShipConfig.Write(fileName);
                MessageBox.Show("已保存到：" + fileName);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            
        }

        private void btnLoadConfig_Click(object sender, EventArgs e)
        {
            if (openIni.ShowDialog() != DialogResult.OK)
                return;
            ClearAllPictureBoxes();
            string fileName = openIni.FileName;

            IniConfigLoader ShipConfig = new IniConfigLoader(fileName);
            Dictionary<string, string> conf = ShipConfig.GetConfigByGroupName("pictures");
            foreach (TabPage page in tabResTypes.TabPages)
            {
                foreach (Control ctrl in page.Controls)
                {
                    if (!(ctrl is PictureBox))
                        continue;
                    PictureBox pic = (PictureBox)ctrl;
                    string name = pic.Name;
                    if (conf.ContainsKey(name))
                    {
                        try
                        {
                            string pname = conf[name];
                            Image image = Image.FromFile(pname);
                            image.Tag = pname;
                            if (pic.BackgroundImage != null)
                                pic.BackgroundImage.Dispose();
                            pic.BackgroundImage = image;
                            pic.BackgroundImageLayout = ImageLayout.Zoom;
                        }
                        catch (Exception ee)
                        {
                            MessageBox.Show(ee.Message);
                        }
                    }
                }
            }
        }

        void ClearAllPictureBoxes()
        {
            foreach (TabPage page in tabResTypes.TabPages)
            {
                foreach (Control ctrl in page.Controls)
                {
                    if (!(ctrl is PictureBox))
                        continue;
                    PictureBox pic = (PictureBox)ctrl;
                    pic.BackgroundImage = null;
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearAllPictureBoxes();
        }

        private void cbTool_SelectedIndexChanged(object sender, EventArgs e)
        {
            Config.CachePath = new string[]
            {
                Config.ShimakazeGoCachePath, Config.ACGPowerCachePath
            }[cbTool.SelectedIndex];
        }

        FrmPreview frmPreview = null;

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (frmPreview == null || frmPreview.IsDisposed)
                frmPreview = new FrmPreview();
            frmPreview.LoadKanmusuCardPreview(txtKanmusuID.Text);
            frmPreview.StartPosition = FormStartPosition.Manual;
            if (!frmPreview.Visible)
            {
                frmPreview.Location = new Point(this.Location.X + this.Size.Width-5, this.Location.Y);
            }
            frmPreview.ConditionalShow();
            this.Focus();
        }
    }
}
