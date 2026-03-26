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
        private void Form1_Load(object sender, EventArgs e)
        {
           
            ChuyenTrang(basepage);
           
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
            if (StartComboBox.Items.Contains(start)==false)
            {
                MessageBox.Show("Điểm bắt đầu này không tồn tại");
                return;
            }
            string end = EndComboBox.Text;
            if (!EndComboBox.Items.Contains(end)==false)
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
    }
}
