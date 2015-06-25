using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FRCVideoSplitter2
{
    public partial class ProgressDialog : Form
    {
        long chunkSize;
        int chunks;
        private Button buttonCancel;
        private ProgressBar progressBar1;
        private Label labelMessage;
        int completedChunks;

        #region PROPERTIES

        public string Message
        {
            set { labelMessage.Text = value; }
        }

        public int Chunks
        {
            set { chunks = value; }
        }

        public long ChunkSize
        {
            set { chunkSize = value; }
        }
        #endregion

        public ProgressDialog()
        {
            InitializeComponent();
        }

        private void ProgressDialog_Load(object sender, EventArgs e)
        {

        }

        delegate void SetTextCallback(string text);

        public void SetText(string text)
        {
            if (this.labelMessage.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.labelMessage.Text = text;
            }
        }

        delegate void SetProgressCallback(int progress);

        public void SetCompletedChunks(int completed)
        {
            completedChunks = completed;
            SetProgress((int)(100*((double)completedChunks / (double)chunks)));
            
        }

        public void SetChunkProgress(long progress)
        {
            SetProgress((int)(100*((double)completedChunks + ((double)progress / (double)chunkSize)) / (double)chunks));
        }

        public void SetProgress(int progress)
        {
            if (this.progressBar1.InvokeRequired)
            {
                SetProgressCallback d = new SetProgressCallback(SetProgress);
                this.Invoke(d, new object[] { progress });
            }
            else
            {
                this.progressBar1.Value = progress;
            }
        }

        public event EventHandler<EventArgs> Canceled;

        private void InitializeComponent()
        {
            this.buttonCancel = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(163, 103);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click_1);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 59);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(373, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // labelMessage
            // 
            this.labelMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelMessage.Location = new System.Drawing.Point(0, 0);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(399, 56);
            this.labelMessage.TabIndex = 3;
            this.labelMessage.Text = "Uploading";
            this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProgressDialog
            // 
            this.ClientSize = new System.Drawing.Size(399, 148);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.labelMessage);
            this.Name = "ProgressDialog";
            this.ResumeLayout(false);

        }

        private void buttonCancel_Click_1(object sender, EventArgs e)
        {
            EventHandler<EventArgs> ea = Canceled;
            if (ea != null)
                ea(this, e);
        }

    }
}
