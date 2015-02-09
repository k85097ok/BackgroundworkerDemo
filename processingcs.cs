using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace BackgroundworkerDemo
{
    public partial class processingcs : Form
    {
        public processingcs()
        {
            InitializeComponent();
        }
        private void processingcs_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
        private void DoWork() {
            backgroundWorker1.WorkerReportsProgress = true;
            for (int i = progressBar1.Minimum; i <= progressBar1.Maximum; i++)
            {
                backgroundWorker1.ReportProgress(i);
                Thread.Sleep(50);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            DoWork();
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
