using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KancolleModify
{
    public partial class FrmProcessing : Form
    {
        public FrmProcessing()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        public delegate void WorkHandle(FrmProcessing self);

        public WorkHandle WorkHandler = null;
        public WorkHandle OnComplete = null;
        public bool Completed = false;
        public bool ShouldStopProcessingSignal = false;

        public int Progress
        {
            get => progressBar.Value;
            set {
                progressBar.Value = value;
                this.Text = "正在处理 (" + value + "%)";
                if (value == 100)
                {
                    btnCancel.Text = "关闭";
                }
            }
        }

        public string Status
        {
            get => lblStatus.Text;
            set => lblStatus.Text = value;
        }

        Thread workingThread;

        private void FrmProcessing_Load(object sender, EventArgs e)
        {
            if (WorkHandler == null)
            {
                throw new ArgumentException("需要WorkHandle");
            }
            workingThread = new Thread(() =>
            {
                WorkHandler(this);
                Completed = true;
                if (OnComplete != null)
                {
                    OnComplete(this);
                }
            });
            workingThread.Start();
        }

        private void progressBar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!Completed)
            {
                ShouldStopProcessingSignal = true;
            }
            else
            {
                Close();
            }
        }
    }
}
