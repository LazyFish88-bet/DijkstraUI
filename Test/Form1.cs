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

        private void Form1_Load(object sender, EventArgs e)
        {
            BasePage basepage=new BasePage();
            ChuyenTrang(basepage);
        }
        public void ChuyenTrang(UserControl UC)
        {
            UC.Dock = DockStyle.Fill;
            LoadPanel.Controls.Clear();
            LoadPanel.Controls.Add(UC);

        }

        private void Start_Click(object sender, EventArgs e)
        {
            string start= StartDestination.Text;
            string end= EndDestination.Text;
            Dijkstra dijkstra = new Dijkstra();
            dijkstra.Start = start;
            dijkstra.End = end;
            ChuyenTrang(dijkstra);
        }
    }
}
