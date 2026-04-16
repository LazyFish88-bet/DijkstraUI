using System.CodeDom.Compiler;

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
            //Luôn luôn cho form thông số đè lên form chính
            thongso.Owner = this;
            thongso.Width = 600;
            thongso.Hide();
            StatsCloseButton.Hide();
        }
        private void UpdateXYStatsForm()
        {
            int doDayVien = SystemInformation.CaptionHeight + SystemInformation.FrameBorderSize.Height;
            System.Diagnostics.Debug.WriteLine("Độ dày viền là: " + doDayVien);
            thongso.Height = LoadPanel.Height - doDayVien;
            int fixX = StatsOpenButton.PointToScreen(Point.Empty).X - thongso.Width;
            int fixY = LoadPanel.PointToScreen(Point.Empty).Y;
            thongso.Location = new Point(fixX, fixY);
        }
        public void SortComboBox(ComboBox comboBox)
        {
            int Length = comboBox.Items.Count;
            for (int i = 0; i < Length; i++)
            {
                for (int j = i + 1; j < Length; j++)
                {
                    string itemi = comboBox.Items[i].ToString();
                    string itemj = comboBox.Items[j].ToString();
                    if (string.Compare(itemi, itemj) > 0)
                    {
                        string temp = itemi;
                        comboBox.Items[i] = itemj;
                        comboBox.Items[j] = temp;
                    }
                }
            }
        }
        public void ComboBoxReverse(ComboBox comboBox)
        {
            int Length = comboBox.Items.Count;
            for (int i = 0; i < Length / 2; i++)
            {
                string temp = comboBox.Items[i].ToString();
                comboBox.Items[i] = comboBox.Items[Length - 1 - i].ToString();
                comboBox.Items[Length - 1 - i] = temp;
            }
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
        public void ComboBox_BackToDefault(ComboBox combox)
        {
            combox.Items.Clear();
            foreach (string location in Dijkstra.EdgesName)
            {
                combox.Items.Add(location);
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
            if (start==end)
            {
               MessageBox.Show("Điểm bắt đầu và điểm đến không được trùng nhau");
                return;
            }
            if (FuelPriceBox.Text=="")
            {
                MessageBox.Show("Hãy nhập giá xăng");
                return;
            }
            int fuelPrice = int.Parse(FuelPriceBox.Text);
            Dijkstra dijkstra = new Dijkstra();
            dijkstra.Start = start;
            dijkstra.End = end;
            dijkstra.FuelPrice = fuelPrice;
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
            if (LoadPanel.Controls[0] is BasePage)
            {
                thongso.LoadDataTable();
            }
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
        int countSortStart = 0;
        private void SortStartComboBox_Click(object sender, EventArgs e)
        {
            //Sort theo A-Z
            if (countSortStart == 0)
            {
                SortComboBox(StartComboBox);
                countSortStart++;
            }
            //Sort theo Z-A
            else if (countSortStart == 1)
            {
                ComboBoxReverse(StartComboBox);
                countSortStart++;
            }

            else if (countSortStart == 2)
            {
                countSortStart = 0;
                ComboBox_BackToDefault(StartComboBox);
            }
        }
        int countSortEnd = 0;
        private void SortEndButton_Click(object sender, EventArgs e)
        {
            //Sort theo A-Z
            if (countSortEnd == 0)
            {
                SortComboBox(EndComboBox);
                countSortEnd++;
            }
            //Sort theo Z-A
            else if (countSortEnd == 1)
            {
                ComboBoxReverse(EndComboBox);
                countSortEnd++;
            }
            //Trở về mặc định
            else if (countSortEnd == 2)
            {
                countSortEnd = 0;
               ComboBox_BackToDefault(EndComboBox);
            }
        }
    }
}
