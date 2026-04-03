using System;
using System.Collections;
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
     public static string Result=""; 
        public string Start;
        public string End;
        public Dijkstra()
        {
            InitializeComponent();
        }
        public class Edge
        {
            public int v;
            public long w;
            public Edge(int v, long w)
            {
                this.v = v;
                this.w = w;
            }
        };
        public static string[] EdgesName = { "Lai Châu", "Điện Biên", "Sơn La", "Lào Cai", "Phú Thọ", "Tuyên Quang", "Hà Nội", "Ninh Bình", "Thái Nguyên", "Bắc Ninh", "Hải Phòng", "Hưng Yên", "Cao Bằng", "Lạng Sơn", "Quảng Ninh" };
        public class Diagram
        {
            private List<string> CityList = new List<string>();
            private Dictionary<string, int> CityIndexMap = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            public void AddCity(string c)
            {
                if (!CityIndexMap.ContainsKey(c))
                {
                    CityIndexMap[c] = CityList.Count;
                    CityList.Add(c);
                }
            }

            public int FindIndex(string v)
            {
                return CityIndexMap.TryGetValue(v, out int index) ? index : -1;
            }

            public string FindName(int u)
            {
                return CityList[u];
            }
        }
        static Diagram diagram = new Diagram();
        static void Dijsktra(int n, int s, List<List<Edge>> E, long[] D)
        {
            //khởi tạo D
            for (int i = 0; i < n; i++)
            {
                D[i] = long.MaxValue;
            }
            D[s] = 0;
            //Khởi tạo P[] = false 
            bool[] P = new bool[n];

            //Khởi tạo priority queue và thêm đỉnh đầu tiên
            PriorityQueue<int, long> pq = new PriorityQueue<int, long>();
            pq.Enqueue(s, 0);

            while (pq.Count > 0)
            {
                int index = pq.Dequeue();

                //Gán biến và đánh dấu
                int u = index;
                P[u] = true;
                foreach (Edge x in E[u])
                {
                    int v = x.v;
                    long w = x.w;
                    if (D[v] > D[u] + w)
                    {
                        D[v] = D[u] + w;
                        pq.Enqueue(v, D[v]);
                    }
                }
            }
        }

        static void FindAllPath(int s, int e, long[] D, List<List<Edge>> E, List<int> currentPath)
        {
            //xét từ điểm cuối
            List<int> newPath = new List<int>(currentPath);
            newPath.Add(e);
            string result = "";
            if (s == e)
            {
                //in ra kết quả
                int n = newPath.Count;
                 result="Path: ";
                for (int i = 0; i < n; i++)
                {
                    if (i != n - 1)
                    {
                        result+=diagram.FindName(newPath[n - i - 1]) + " -> ";
                    }
                    else
                    { result+=diagram.FindName(newPath[n - i - 1])+"\n"; }
                }
            }
            else
            {
                //dùng DFS đệ quy backtracking
                foreach (Edge x in E[e])
                {
                    int v = x.v;
                    long w = x.w;
                    if (D[e] == D[v] + w)
                    {
                        FindAllPath(s, v, D, E, newPath);
                    }
                }
            }
            Result+=result;
        }


        private void Dijkstra_Load(object sender, EventArgs e)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //khởi tạo các đỉnh
            //Form1 form1 = (Form1)this.ParentForm;
            //form1.addItemtoComboBox(EdgesName);
            for (int i = 0; i < EdgesName.Length; i++) diagram.AddCity(EdgesName[i]);

            //khởi tạo số điểm, điểm bắt đầu và kết thúc
            int n = EdgesName.Length;
            int start=diagram.FindIndex(Start);
            int end=diagram.FindIndex(End);

            // Tạo từng danh sách các điếm đến 
            List<List<Edge>> E = new List<List<Edge>>();
            for (int i = 0; i < n; i++)
            {
                E.Add(new List<Edge>());
            }

            //Khởi tạo đường đi
            int[,] EdgesData = 
            {
                //Tuyến Tây Bắc - Việt Bắc
                { diagram.FindIndex("Lai Châu"), diagram.FindIndex("Điện Biên"), 105 },
                { diagram.FindIndex("Lai Châu"), diagram.FindIndex("Lào Cai"), 160 },
                { diagram.FindIndex("Điện Biên"), diagram.FindIndex("Sơn La"), 155 },
                { diagram.FindIndex("Lào Cai"), diagram.FindIndex("Sơn La"), 215 },
                { diagram.FindIndex("Lào Cai"), diagram.FindIndex("Tuyên Quang"), 155 },
                { diagram.FindIndex("Lào Cai"), diagram.FindIndex("Phú Thọ"), 200 },
                //Tuyết trung tâm và Đông Bắc
                { diagram.FindIndex("Sơn La"), diagram.FindIndex("Phú Thọ"), 210 },
                { diagram.FindIndex("Tuyên Quang"), diagram.FindIndex("Phú Thọ"), 65 },
                { diagram.FindIndex("Tuyên Quang"), diagram.FindIndex("Thái Nguyên"), 85 },
                { diagram.FindIndex("Tuyên Quang"), diagram.FindIndex("Cao Bằng"), 220  },
                {diagram.FindIndex("Cao Bằng"), diagram.FindIndex("Lạng Sơn"), 125 },
                {diagram.FindIndex("Lạng Sơn"),diagram.FindIndex("Thái Nguyên"), 135 },
                {diagram.FindIndex("Lạng Sơn"),diagram.FindIndex("Quảng Ninh"),180 },
                {diagram.FindIndex("Lạng Sơn"),diagram.FindIndex("Bắc Ninh"),110 },
                //Tuyến xoay quanh Thủ đô Hà Nội
                {diagram.FindIndex("Thái Nguyên"), diagram.FindIndex("Hà Nội"),80 },
                {diagram.FindIndex("Phú Thọ"),diagram.FindIndex("Hà Nội"),90 },
                { diagram.FindIndex("Sơn La"),diagram.FindIndex("Hà Nội"),300},
                {diagram.FindIndex("Hà Nội"), diagram.FindIndex("Ninh Bình"), 95 },
                {diagram.FindIndex("Hà Nội"), diagram.FindIndex("Bắc Ninh"), 30 },
                {diagram.FindIndex("Hà Nội"), diagram.FindIndex("Hưng Yên"), 60 },
                //Tuyến đường duyên hải và lân cận
                {diagram.FindIndex("Bắc Ninh"), diagram.FindIndex("Hưng Yên"),40},
                {diagram.FindIndex("Bắc Ninh"), diagram.FindIndex("Hải Phòng"), 90 },
                {diagram.FindIndex("Hưng Yên"), diagram.FindIndex("Hải Phòng"), 75 },
                {diagram.FindIndex("Hưng Yên"),diagram.FindIndex("Ninh Bình"),80 },
                {diagram.FindIndex("Hải Phòng"),diagram.FindIndex("Quảng Ninh"),45 }
            };
            //Gán các đường đi
            for (int i = 0; i < EdgesData.GetLength(0); i++)
            {
                int u = EdgesData[i, 0];
                int v = EdgesData[i, 1];
                long w = EdgesData[i, 2];
                if (u < n)
                {
                    //2 chiều
                    E[u].Add(new Edge(v, w));
                    E[v].Add(new Edge(u, w));
                }
            }

            //khởi tạo D: khoảng cách min từ điểm đầu đến vị trí đó
            long[] D = new long[n];

            Dijsktra(n, start, E, D);


            FindAllPath(start, end, D, E, new List<int>());
            ResultLabel.Text = Result+"chiều dài quãng đường là=" + D[end]+"km";
            Result = "";
        }

        private void ResultLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
