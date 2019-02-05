using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KancolleModify
{
    public partial class FrmPreview : Form
    {
        public FrmPreview()
        {
            InitializeComponent();
        }

        private void FrmPreview_Load(object sender, EventArgs e)
        {
            //List<string> files = Util
        }

        public void LoadKanmusuCardPreview(string KanmusuID)
        {
            Image image = Preview.Image;
            Preview.Image = null;
            image?.Dispose();
            if (string.IsNullOrEmpty(Config.CachePath) || KanmusuID.Length == 0)
                return;
            string path = Config.CachePath + Constants.ShipRelativePath + "card\\";
            List<string> files = Utils.GetSimilarFileList(path, KanmusuID);
            if (files.Count == 0)
                return;
            try
            {
                image = Image.FromFile(path + files[0]);
                Preview.Image = image;
                Preview.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch { }
        }

        public void ConditionalShow()
        {
            if (Preview.Image == null)
                this.Hide();
            else
                this.Show();
        }

        private void Preview_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
