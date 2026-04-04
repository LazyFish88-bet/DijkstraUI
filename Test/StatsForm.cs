using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class StatsForm : Form
    {
        public StatsForm()
        {
            InitializeComponent();
        }
        UCDataGridView UCData = new UCDataGridView();
        public void ChuyenTrang(UserControl UC)
        {
            UC.Dock = DockStyle.Fill;
            LoadDataGridView.Controls.Clear();
            LoadDataGridView.Controls.Add(UCData);
        }
        private void StatsForm_Load(object sender, EventArgs e)
        {
            ChuyenTrang(UCData);
        }

        private void LoadDataGridView_Paint(object sender, PaintEventArgs e)
        {

        }

       
    }
}
