using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KancolleModify
{
    public partial class FrmStartModify : Form
    {
        public FrmStartModify()
        {
            InitializeComponent();
        }

        class FileDetail
        {
            public string FileName;
            public string Path;
            public string Usage;
            public string ReplaceAsFileName;

            public override string ToString()
            {
                return "[" + Usage + "] " + FileName;
            }
        }

        class PathDetail
        {
            public string PathName;
            public string Usage;

            public PathDetail(string PathName, string Usage)
            {
                this.PathName = PathName;
                this.Usage = Usage;
            }
        }

        static Dictionary<string, PathDetail> PathDetailMap = null;

        public string CachePath = Config.ShimakazeGoCachePath;
        public string ShipCachePath
        {
            get => CachePath + @"\kcs2\resources\ship\";
        }
        string Ext = ".png";
        string ExtReplaceAs = ".hack.png";
        public string KanmusuID = null;
        List<FileDetail> Files = new List<FileDetail>();
        Dictionary<string, string> Usages = new Dictionary<string, string>();

        private void FrmStartModify_Load(object sender, EventArgs e)
        {
            RetriveFileList();
            Text = Text + " (ID: " + KanmusuID + ")";
            if (lstFileList.Items.Count > 0)
                lstFileList.SelectedIndex = 0;
        }

        private void RetriveFileList()
        {
            lstFileList.Items.Clear();
            if (PathDetailMap == null)
            {
                PathDetailMap = new Dictionary<string, PathDetail>();
                PathDetailMap.Add(ConfigMeta.Fleet1NamePlateNormal, new PathDetail("banner", "铭牌（第一舰队/普通）"));
                PathDetailMap.Add(ConfigMeta.Fleet1NamePlateDmg, new PathDetail("banner_dmg", "铭牌（第一舰队/受伤）"));
                PathDetailMap.Add(ConfigMeta.Fleet1NamePlateLost, new PathDetail("banner_g_dmg", "铭牌（第一舰队/击沉）"));
                PathDetailMap.Add(ConfigMeta.Fleet2NamePlateNormal, new PathDetail("banner2", "铭牌（第二舰队/普通）"));
                PathDetailMap.Add(ConfigMeta.Fleet2NamePlateDmg, new PathDetail("banner2_dmg", "铭牌（第二舰队/受伤）"));
                PathDetailMap.Add(ConfigMeta.Fleet2NamePlateLost, new PathDetail("banner2_g_dmg", "铭牌（第二舰队/击沉）"));
                PathDetailMap.Add(ConfigMeta.SupplyNormal, new PathDetail("supply_character", "补给条(普通)"));
                PathDetailMap.Add(ConfigMeta.SupplyDmg, new PathDetail("supply_character", "补给条(受伤)"));
                PathDetailMap.Add(ConfigMeta.CardNormal, new PathDetail("card", "卡牌(普通)"));
                PathDetailMap.Add(ConfigMeta.CardDmg, new PathDetail("card", "卡牌(受伤)"));
                PathDetailMap.Add(ConfigMeta.AlbumTitle, new PathDetail("album_status", "图鉴标题"));
                PathDetailMap.Add(ConfigMeta.AlbumFull, new PathDetail("character_full", "图鉴全身"));
                PathDetailMap.Add(ConfigMeta.AlbumFullDmg, new PathDetail("character_full_dmg", "图鉴全身(受伤)"));
                PathDetailMap.Add(ConfigMeta.AlbumHalf, new PathDetail("character_up", "图鉴半身(受伤)"));
                PathDetailMap.Add(ConfigMeta.AlbumHalfDmg, new PathDetail("character_up_dmg", "图鉴半身(受伤)"));
                PathDetailMap.Add(ConfigMeta.VertDrawingNormal, new PathDetail("full", "立绘"));
                PathDetailMap.Add(ConfigMeta.VertDeawingDmg, new PathDetail("full_dmg", "立绘(受伤)"));
                PathDetailMap.Add(ConfigMeta.RemodelNormal, new PathDetail("card_dmg", "改造(普通)"));
                PathDetailMap.Add(ConfigMeta.RemodelDmg, new PathDetail("card_dmg", "改造(受伤)"));
            }
            

            foreach (var pair in Config.PicturePaths)
            {
                PathDetail detail = PathDetailMap[pair.Key];
                RetriveFileList(detail.PathName, detail.Usage, pair.Key);
            }
        }

        private void RetriveFileList(string path, string usage, string usageName)
        {
            List<string> fileList = Utils.GetSimilarFileList(ShipCachePath + path, KanmusuID);
            foreach (string file in fileList)
            {
                if (file.EndsWith(ExtReplaceAs))
                    continue;
                lstFileList.Items.Add(new FileDetail()
                {
                    FileName = Path.GetFileName(file),
                    Path = ShipCachePath + path + "\\" + file,
                    Usage = usage,
                    ReplaceAsFileName = Config.PicturePaths[usageName],
                });
                lstFileList.SetItemCheckState(lstFileList.Items.Count - 1, CheckState.Checked);
            }
        }

        private string GetHackFileName(string filename)
        {
            return filename.Replace(Ext, ExtReplaceAs);
        }

        Image OriginalImage = null;
        Image DstImage = null;
        Image ReplaceAsImage = null;

        private void lstFileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelDetail.Enabled = lstFileList.SelectedIndex >= 0;
            if (lstFileList.SelectedIndex < 0)
            {
                return;
            }
            FileDetail file = (FileDetail)lstFileList.SelectedItem;
            txtModType.Text = file.Usage;
            txtDstFile.Text = GetHackFileName(file.Path);
            txtOriginalFile.Text = file.Path;
            txtFileName.Text = file.FileName;
            txtReplaceAs.Text = file.ReplaceAsFileName;
            OpenDstFile.Enabled = File.Exists(GetHackFileName(file.Path));
            OriginalImage = Image.FromFile(file.Path);
            lblOriginalFile.Text = "原始文件 (尺寸: " + OriginalImage.Width + "*" + OriginalImage.Height + ")";
            try
            {
                DstImage = Image.FromFile(GetHackFileName(file.Path));
                if (OriginalImage.Size != DstImage.Size)
                    lblDstFile.Text = "目标文件 (尺寸: " + DstImage.Width + "*" + DstImage.Height + ")";
                else
                    lblDstFile.Text = "目标文件 (尺寸同原始文件)";
            }
            catch {
                lblDstFile.Text = "目标文件 (尺寸同原始文件)";
            }
            ReplaceAsImage = Image.FromFile(file.ReplaceAsFileName);
            if (OriginalImage.Size != ReplaceAsImage.Size)
            {
                lblReplaceAs.Text = "替换为 (尺寸: " + ReplaceAsImage.Width + "*" + ReplaceAsImage.Height + ")";
                lblWarning.Show();
            }
            else
            {
                lblReplaceAs.Text = "替换为 (尺寸同原始文件)";
                lblWarning.Hide();
            }
            OriginalImage.Dispose();
            ReplaceAsImage.Dispose();
            if (DstImage != null)
                DstImage.Dispose();
            OriginalImage = ReplaceAsImage = DstImage = null;
        }

        private void btnOpenOriginalFile_Click(object sender, EventArgs e)
        {
            FileDetail file = (FileDetail)lstFileList.SelectedItem;
            try
            {
                Process.Start(file.Path);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenDstFile_Click(object sender, EventArgs e)
        {
            FileDetail file = (FileDetail)lstFileList.SelectedItem;
            try
            {
                Process.Start(GetHackFileName(file.Path));
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFileName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (lstFileList.CheckedIndices.Count == 0)
            {
                MessageBox.Show("请选择你要修改的文件", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FrmProcessing frm = new FrmProcessing();
            frm.OnComplete = (FrmProcessing self) =>
            {
                MessageBox.Show(self, "操作成功完成。");
                self.Close();
            };
            frm.WorkHandler = (FrmProcessing self) =>
            {
                int fileCount = lstFileList.CheckedItems.Count, fileCopied = 0;
                foreach (var item in lstFileList.CheckedItems)
                {
                    FileDetail file = (FileDetail)item;
                    string hack = GetHackFileName(file.Path);
                    string replace = file.ReplaceAsFileName;
                    try
                    {
                        if (File.Exists(hack))
                        {
                            File.Delete(hack);
                        }
                        self.Status = "复制文件：" + replace + " => " + hack;
                        File.Copy(replace, hack);
                        fileCopied++;
                        self.Progress = (int)((double)fileCopied / fileCount * 100);
                        
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show(self, ee.Message);
                    }
                    if (self.ShouldStopProcessingSignal)
                        return;
                }
            };
            //this.Hide();
            frm.ShowDialog();
            if (!frm.Completed)
                this.Show();
            else
                this.Close();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstFileList.Items.Count; i++)
                lstFileList.SetItemChecked(i, true);
        }

        private void btnUnselectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstFileList.Items.Count; i++)
                lstFileList.SetItemChecked(i, false);
        }

        private void btnOpenReplaceAs_Click(object sender, EventArgs e)
        {
            FileDetail file = (FileDetail)lstFileList.SelectedItem;
            try
            {
                Process.Start(file.ReplaceAsFileName);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
