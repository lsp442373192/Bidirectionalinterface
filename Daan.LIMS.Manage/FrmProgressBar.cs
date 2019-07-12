using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Daan.LIMS.Manage
{
    public partial class FrmProgressBar : Form
    {
        public FrmProgressBar()
        {
            InitializeComponent();

        }

        public FrmProgressBar(BackgroundWorker worker)
        {
            InitializeComponent();
            worker.ProgressChanged +=new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerCompleted +=new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //lblStatus.Text = "";
        }

        //工作完成后执行的事件  
        public void OnProcessCompleted(object sender, EventArgs e)
        {
            this.Close();
        } 
    }
}
