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
        public class Diagram
        {
            private List<string> CityList = new List<string>();
            public void AddCity(string c)
            {
                CityList.Add(c);
            }
            public int FindIndex(string v)
            {
                for (int i = 0; i < CityList.Count; i++)
                {
                    if (CityList[i].ToLower() == v.ToLower()) return i;
                }
                return -1;
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
                 result="Path:\n";
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
            string[] EdgesName = { "a", "b", "c", "d", "e", "f" };
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
            int[,] EdgesData = {
                { diagram.FindIndex("a"), diagram.FindIndex("b"), 3 },
                { diagram.FindIndex("a"), diagram.FindIndex("c"), 2 },
                { diagram.FindIndex("a"), diagram.FindIndex("e"), 7 },
                { diagram.FindIndex("b"), diagram.FindIndex("d"), 2 },
                { diagram.FindIndex("b"), diagram.FindIndex("e"), 4 },
                { diagram.FindIndex("b"), diagram.FindIndex("f"), 4 },
                { diagram.FindIndex("c"), diagram.FindIndex("e"), 5 },
                { diagram.FindIndex("d"), diagram.FindIndex("e"), 1 },
                { diagram.FindIndex("d"), diagram.FindIndex("f"), 4 },
                { diagram.FindIndex("e"), diagram.FindIndex("f"), 1 }
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
            ResultLabel.Text = Result;
            Result = "";
        }

        private void ResultLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
