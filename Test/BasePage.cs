using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class BasePage : UserControl
    {
        public UserControl UCDestination;
        public BasePage()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
        public void Run(UserControl UC)
        {
            ProgressBarTimer.Start();
            UCDestination = UC;
        }

        private void ProgressBarTimer_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 2;
            if (progressBar1.Value == 100)
            {
                progressBar1.Value = 0;
                ProgressBarTimer.Stop();
                Form1 form1 = (Form1)this.ParentForm;
                form1.ChuyenTrang(UCDestination);
            }
        }

        private void BasePage_Load(object sender, EventArgs e)
        {

        }
    }
}
