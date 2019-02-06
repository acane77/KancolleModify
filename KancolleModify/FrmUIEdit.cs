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
    public partial class FrmUIEdit : Form
    {
        public FrmUIEdit()
        {
            InitializeComponent();

            if (VDInfo == null)
            {
                VDInfo = new Dictionary<VertialDrawingSenses, VDAttributes>();
                VDInfo.Add(VertialDrawingSenses.Port, new VDAttributes(KancolleModify.Properties.Resources.port.GetHbitmap(), "boko", new Point(491, -88), (2.0 / 3.0)));
                VDInfo.Add(VertialDrawingSenses.InBattle, new VDAttributes(KancolleModify.Properties.Resources.battle.GetHbitmap(), "battle", Point.Empty, (2.0 / 3.0)));
                VDInfo.Add(VertialDrawingSenses.Map, new VDAttributes(KancolleModify.Properties.Resources.map_main.GetHbitmap(), "map", Point.Empty, (2.0 / 3.0)));
                //ImageResources.Add(VertialDrawingSenses.Exercise, new VDAttributes(KancolleModify.Properties.Resources.port.GetHbitmap(), "ensyuf", Point.Empty));
                VDInfo.Add(VertialDrawingSenses.Modernization, new VDAttributes(KancolleModify.Properties.Resources.remodel.GetHbitmap(), "kaisyu", Point.Empty, (2.0 / 3.0)));
                VDInfo.Add(VertialDrawingSenses.Remodel, new VDAttributes(KancolleModify.Properties.Resources.remodel.GetHbitmap(), "kaizo", Point.Empty, (2.0 / 3.0)));
            }

            numPosLeft.ValueChanged += (s, ee) =>
            {
                var P = VertialDrawingLocation;
                P.X = (int)numPosLeft.Value;
                VertialDrawingLocation = P;
                panelEdit.Invalidate();
            };

            numPosTop.ValueChanged += (s, ee) =>
            {
                var P = VertialDrawingLocation;
                P.Y = (int)numPosTop.Value;
                VertialDrawingLocation = P;
                panelEdit.Invalidate();
            };

            panelEdit.MouseDown += PanelEdit_MouseDown;
            panelEdit.MouseUp += PanelEdit_MouseUp;
            panelEdit.MouseMove += PanelEdit_MouseMove;

        }

        private bool IsMouseDown = false;
        Point LastMouseMovePoint;
        int DeltaX = 0, DeltaY = 0;

        private void PanelEdit_MouseMove(object sender, MouseEventArgs e)
        {
            if (RendereedVD == null) return;
            if (IsMouseDown)
            {
                DeltaX = LastMouseMovePoint.X - VertialDrawingLocation.X - CurrentVD.BasePosition.X;
                DeltaY = LastMouseMovePoint.Y - VertialDrawingLocation.Y - CurrentVD.BasePosition.Y;
                LastMouseMovePoint = e.Location;
                //Text = "Mouse down & move (DeltaX=" + DeltaX + ",DeltaY=" + DeltaY + ")";
                //VertialDrawingLocation = new Point(LastMouseMovePoint.X - DeltaX, LastMouseMovePoint.Y - DeltaY);
                //Invalidate();
                numPosLeft.Value = LastMouseMovePoint.X - DeltaX - CurrentVD.BasePosition.X;
                numPosTop.Value = LastMouseMovePoint.Y - DeltaY - CurrentVD.BasePosition.Y;

            }
        }

        private void PanelEdit_MouseUp(object sender, MouseEventArgs e)
        {
            //Text = "Mouse up";
            IsMouseDown = false;
        }

        //int x = 0;
        private void PanelEdit_MouseDown(object sender, MouseEventArgs e)
        {
            //Text = "Mouse down " + (x++);
            LastMouseMovePoint = e.Location;
            DeltaX = LastMouseMovePoint.X - VertialDrawingLocation.X - CurrentVD.BasePosition.X;
            DeltaY = LastMouseMovePoint.Y - VertialDrawingLocation.Y - CurrentVD.BasePosition.Y;
            IsMouseDown = true;
        }

        public class VDAttributes
        {
            public IntPtr BackgroundImage;
            public string ConfigStringPrefix;
            public Point BasePosition;
            public double ZoomScale;

            public VDAttributes(IntPtr backgroundImage, string configStringPrefix, Point basePosition, double zoomScale)
            {
                BackgroundImage = backgroundImage;
                ConfigStringPrefix = configStringPrefix;
                BasePosition = new Point((int)(basePosition.X * zoomScale), (int)(basePosition.Y * zoomScale));
                ZoomScale = zoomScale;
            }
        }

        class AddtionalImage
        {
            public Image Image;
            public Point Position;
            public Size  Size;

            public AddtionalImage(Image image, Point position, Size size)
            {
                Image = image;
                Position = position;
                Size = size;
            }
        }

        private List<AddtionalImage> AdditionalImages = new List<AddtionalImage>();
        private List<AddtionalImage> AdditionalImagesOver = new List<AddtionalImage>();

        private static Dictionary<VertialDrawingSenses, VDAttributes> VDInfo = null;

        //public string CurrentEdit

        private void FrmUIEdit_Load(object sender, EventArgs e)
        {
            txtCurrentEdit.Text = VertialDrawingSense.ToString() + " (" + CurrentVD.ConfigStringPrefix + ")";
            cbIniPosEditContent.SelectedIndex = (int)VertialDrawingSense;

            LoadPositionFromConfig();
        }

        Image _BackgroudImage = null;

        public void CheckArguments()
        {
            if (_BackgroudImage == null)
            {
                throw new ArgumentException("BackgroundImage = null");
            }

            if (NormalVD == null && DamageVD == null)
                throw new ArgumentException("需要选择至少一个立绘，才能使用此功能。");
        }

        public void AddAdditionalImage(Image image, Point location, Size size)
        {
            AdditionalImages.Add(new AddtionalImage(image, location, size));
        }

        public void AddAdditionalImageOver(Image image, Point location, Size size)
        {
            AdditionalImagesOver.Add(new AddtionalImage(image, location, size));
        }

        Point AddPoints(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }

        private void panelEdit_Paint(object sender, PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            if (_BackgroudImage != null)
                G.DrawImage(_BackgroudImage, new Point(0, 0));

            foreach (AddtionalImage image in AdditionalImages)
                G.DrawImage(image.Image, image.Position.X, image.Position.Y, image.Size.Width, image.Size.Height);

            if (RendereedVD != null)
                G.DrawImage(RendereedVD,
                    CurrentVD.BasePosition.X + VertialDrawingLocation.X,
                    CurrentVD.BasePosition.Y + VertialDrawingLocation.Y,
                    (int)(RendereedVD.Width * CurrentVD.ZoomScale),
                    (int)(RendereedVD.Height * CurrentVD.ZoomScale)
                    );

            foreach (AddtionalImage image in AdditionalImagesOver)
                G.DrawImage(image.Image, image.Position.X, image.Position.Y, image.Size.Width, image.Size.Height);
        }

        /// <summary>
        /// 立绘类型
        /// </summary>
        private VertialDrawingSenses _VertialDrawingSense;

        /// <summary>
        /// 通常立绘
        /// </summary>
        public Image NormalVD = null;

        /// <summary>
        /// 受伤立绘
        /// </summary>
        public Image DamageVD = null;

        /// <summary>
        /// 被渲染的立绘
        /// </summary>
        private Image _RenderredVD = null;
        private Image RendereedVD
        {
            get => _RenderredVD;
            set {
                _RenderredVD = value;
                panelEdit.Invalidate();
            }
        }

        /// <summary>
        /// 立绘位置(通常)
        /// </summary>
        private Point _VD_Location_N = new Point(0, 0);

        /// <summary>
        /// 立绘位置(受伤)
        /// </summary>
        private Point _VD_Location_D = new Point(0, 0);

        /// <summary>
        /// 立绘位置
        /// </summary>
        private Point VertialDrawingLocation
        {
            get => IsEditingNormalVD ? _VD_Location_N : _VD_Location_D;
            set
            {
                if (IsEditingNormalVD)
                    _VD_Location_N = value;
                else
                    _VD_Location_D = value;
            }
        }
            
        private bool IsEditingNormalVD
        {
            get => cbVDStatus.SelectedIndex == 0;
        }

        private VDAttributes CurrentVD
        {
            get => VDInfo[_VertialDrawingSense];
        }

        /// <summary>
        /// 立绘使用场景
        /// </summary>
        public VertialDrawingSenses VertialDrawingSense
        {
            get => _VertialDrawingSense;
            set {
                if (!VDInfo.ContainsKey(value))
                    throw new Exception("no such value in ImageResource, cannot set. " + value.ToString());
                if (_BackgroudImage != null)
                {
                    Image t = _BackgroudImage;
                    _BackgroudImage = null;
                    t.Dispose();
                }
                _BackgroudImage = Image.FromHbitmap(VDInfo[value].BackgroundImage);
                _VertialDrawingSense = value;
            }
        }

        private void cbVDStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelAxis.Enabled = true;
            numPosLeft.Value = VertialDrawingLocation.X;
            numPosTop.Value = VertialDrawingLocation.Y;

            if (IsEditingNormalVD)
            {
                if (NormalVD == null)
                    cbVDStatus.SelectedIndex = 1;
                else
                    RendereedVD = NormalVD;
            }
            else
            {
                if (DamageVD == null)
                    cbVDStatus.SelectedIndex = 0;
                else
                    RendereedVD = DamageVD;
            }
        }

        int RestoreScale(int x)
        {
            return (int)(x / CurrentVD.ZoomScale);
        }

        private void btnIniText_Click(object sender, EventArgs e)
        {
            string ini = "";
            ini += CurrentVD.ConfigStringPrefix + "_d_left=" + RestoreScale(_VD_Location_D.X) + "\r\n";
            ini += CurrentVD.ConfigStringPrefix + "_d_top=" + RestoreScale(_VD_Location_D.Y) + "\r\n";
            ini += CurrentVD.ConfigStringPrefix + "_n_left=" + RestoreScale(_VD_Location_N.X) + "\r\n";
            ini += CurrentVD.ConfigStringPrefix + "_n_top=" + RestoreScale(_VD_Location_N.Y) + "\r\n";

            MessageBox.Show(ini);

        }

        private void cbIniPosEditContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbIniPosEditContent.SelectedIndex = (int)VertialDrawingSense;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        bool ConfirmBeforeClose(object sender)
        {
            if (SavedDamagedPosition != _VD_Location_D || SavedNormalPosition != _VD_Location_N)
            {
                DialogResult result = MessageBox.Show("编辑的内容尚未保存，是否保存？", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (result)
                {
                    case DialogResult.Yes:
                        btnSave_Click(sender, null);
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                        return false;
                }
            }
            return true;
        }

        public Point SavedNormalPosition;
        public Point SavedDamagedPosition;
        private void btnSave_Click(object sender, EventArgs e)
        {
            SavedDamagedPosition = _VD_Location_D;
            SavedNormalPosition = _VD_Location_N;
            Config.ConfigIni[CurrentVD.ConfigStringPrefix + "_d_left"] = _VD_Location_D.X.ToString();
            Config.ConfigIni[CurrentVD.ConfigStringPrefix + "_d_top"] = _VD_Location_D.Y.ToString();
            Config.ConfigIni[CurrentVD.ConfigStringPrefix + "_n_left"] = _VD_Location_N.X.ToString();
            Config.ConfigIni[CurrentVD.ConfigStringPrefix + "_n_top"] = _VD_Location_N.Y.ToString();
            //MessageBox.Show("已保存。", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            numPosLeft.Value = 0;
            numPosTop.Value = 0;
            Invalidate();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (IsEditingNormalVD)
            {
                numPosLeft.Value = SavedNormalPosition.X;
                numPosTop.Value = SavedNormalPosition.Y;
                Invalidate();
            }
            else
            {
                numPosLeft.Value = SavedDamagedPosition.X;
                numPosTop.Value = SavedDamagedPosition.Y;
                Invalidate();
            }
        }

        private void FrmUIEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !ConfirmBeforeClose(sender);
        }

        private void LoadPositionFromConfig()
        {
            if (Config.ConfigIni.ContainsKey(CurrentVD.ConfigStringPrefix + "_d_left") &&
                Config.ConfigIni.ContainsKey(CurrentVD.ConfigStringPrefix + "_d_top"))
            {
                try
                {
                    SavedDamagedPosition = new Point(
                        Int32.Parse(Config.ConfigIni[CurrentVD.ConfigStringPrefix + "_d_left"]),
                        Int32.Parse(Config.ConfigIni[CurrentVD.ConfigStringPrefix + "_d_top"])
                        );
                    _VD_Location_D = SavedDamagedPosition;
                }
                catch (Exception) { }
            }

            if (Config.ConfigIni.ContainsKey(CurrentVD.ConfigStringPrefix + "_n_left") &&
                Config.ConfigIni.ContainsKey(CurrentVD.ConfigStringPrefix + "_n_top"))
            {
                try
                {
                    SavedNormalPosition = new Point(
                        Int32.Parse(Config.ConfigIni[CurrentVD.ConfigStringPrefix + "_n_left"]),
                        Int32.Parse(Config.ConfigIni[CurrentVD.ConfigStringPrefix + "_n_top"])
                        );
                    _VD_Location_N = SavedNormalPosition;
                }
                catch (Exception) { }
            }
        }
    }
}
