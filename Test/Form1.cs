namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void StartDestination_TextChanged(object sender, EventArgs e)
        {

        }
        public BasePage basepage = new BasePage();
        public StatsForm thongso = new StatsForm();
        private void Form1_Load(object sender, EventArgs e)
        {
            ChuyenTrang(basepage);
            addItemtoComboBox(Dijkstra.EdgesName);
            thongso.Owner = this;
            thongso.Width = 200;
            thongso.Hide();
            StatsCloseButton.Hide();
        }
        private void UpdateXYStatsForm()
        {
            int doDayVien = SystemInformation.CaptionHeight + SystemInformation.FrameBorderSize.Height;
            thongso.Height = LoadPanel.Height - doDayVien;
            int fixX = StatsOpenButton.PointToScreen(Point.Empty).X - thongso.Width;
            int fixY = LoadPanel.PointToScreen(Point.Empty).Y;
            thongso.Location = new Point(fixX, fixY);
        }

        public void addItemtoComboBox(string[] diachi)
        {
            StartComboBox.Items.Clear();
            EndComboBox.Items.Clear();
            foreach (string location in diachi)
            {
                StartComboBox.Items.Add(location);
                EndComboBox.Items.Add(location);
            }
        }
        public void ChuyenTrang(UserControl UC)
        {
            UC.Dock = DockStyle.Fill;
            LoadPanel.Controls.Clear();
            LoadPanel.Controls.Add(UC);
            if (LoadPanel.Controls[0] is Dijkstra)
            {
                pictureBox1.Hide();
                pictureBox2.Show();
            }
            if (LoadPanel.Controls[0] is BasePage)
            {
                pictureBox2.Hide();
                pictureBox1.Show();
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            string start = StartComboBox.Text;
            if (StartComboBox.FindStringExact(start) == -1)
            {
                MessageBox.Show("Điểm bắt đầu này không tồn tại");
                return;
            }
            string end = EndComboBox.Text;
            if (EndComboBox.FindStringExact(end) == -1)
            {
                MessageBox.Show("Điểm đến này không tồn tại");
                return;
            }
            Dijkstra dijkstra = new Dijkstra();
            dijkstra.Start = start;
            dijkstra.End = end;
            basepage.Run(dijkstra);

        }

        private void Back_Click(object sender, EventArgs e)
        {

            ChuyenTrang(basepage);
        }

        private void LoadPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Title_Click(object sender, EventArgs e)
        {

        }

        private void StartComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Stat_Click(object sender, EventArgs e)
        {
            thongso.Show();
            UpdateXYStatsForm();
            StatsOpenButton.Hide();
            StatsCloseButton.Show();
        }

        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            if (thongso != null)
            {
                UpdateXYStatsForm();
            }
        }

        private void StatsCloseButton_Click(object sender, EventArgs e)
        {
            StatsCloseButton.Hide();
            StatsOpenButton.Show();
            thongso.Hide();
        }
    }
}
