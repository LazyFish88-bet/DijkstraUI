using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class Dijkstra : UserControl
    {
        public string Start;
        public string End;
        public Dijkstra()
        {
            InitializeComponent();
        }

        private void Dijkstra_Load(object sender, EventArgs e)
        {
            string Result = "";
            ResultLabel.Text = "Con đường ngắn nhất từ" + " " + Start + " " + "đến" + " " + End + " " + "là:\n" + Result;
        }

        private void ResultLabel_Click(object sender, EventArgs e)
        {

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            BasePage basePage= new BasePage();
            Form1 form1=(Form1)this.ParentForm;
            form1.ChuyenTrang(basePage);
        }
    }
}
