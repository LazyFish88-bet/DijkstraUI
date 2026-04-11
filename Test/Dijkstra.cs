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
        public static string Result = "";
        public string Start = "Hà Nội"; // Giá trị mặc định test
        public string End = "Lạng Sơn"; // Giá trị mặc định test
        public int FuelPrice = 0;

        public Dijkstra()
        {
            InitializeComponent();
        }

        // ==========================================
        // CÁC CLASS MÔ HÌNH DỮ LIỆU TỪ FILE MỚI
        // ==========================================

        public class MyPriorityQueue
        {
            private class Node
            {
                public int CityIndex { get; set; }
                public double Cost { get; set; }
            }
            private List<Node> _heap = new List<Node>();
            public int Count => _heap.Count;

            public void Enqueue(int cityIndex, double cost)
            {
                _heap.Add(new Node { CityIndex = cityIndex, Cost = cost });
                HeapifyUp(_heap.Count - 1);
            }

            public int Dequeue()
            {
                if (_heap.Count == 0) throw new InvalidOperationException("Hàng đợi rỗng!");
                int bestCity = _heap[0].CityIndex;
                _heap[0] = _heap[_heap.Count - 1];
                _heap.RemoveAt(_heap.Count - 1);
                if (_heap.Count > 0) HeapifyDown(0);
                return bestCity;
            }

            private void HeapifyUp(int index)
            {
                while (index > 0)
                {
                    int parent = (index - 1) / 2;
                    if (_heap[index].Cost >= _heap[parent].Cost) break;
                    Swap(index, parent);
                    index = parent;
                }
            }

            private void HeapifyDown(int index)
            {
                while (true)
                {
                    int smallest = index;
                    int left = 2 * index + 1;
                    int right = 2 * index + 2;
                    if (left < _heap.Count && _heap[left].Cost < _heap[smallest].Cost) smallest = left;
                    if (right < _heap.Count && _heap[right].Cost < _heap[smallest].Cost) smallest = right;
                    if (smallest == index) break;
                    Swap(index, smallest);
                    index = smallest;
                }
            }

            private void Swap(int i, int j)
            {
                var temp = _heap[i];
                _heap[i] = _heap[j];
                _heap[j] = temp;
            }
        }

        public class Route
        {
            public int TargetCityIndex { get; set; }
            public double Distance { get; set; }
            public double TollFee { get; set; }
            public Route(int targetIndex, double distance, double tollFee)
            {
                this.TargetCityIndex = targetIndex;
                this.Distance = distance;
                this.TollFee = tollFee;
            }
        }

        public class RouteDiagram
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

        public class Vehicles
        {
            public string Name { get; set; }
            public double FuelEmpty { get; set; }
            public double PLoad { get; set; }

            public Vehicles(string name, double fe, double pl)
            {
                Name = name;
                FuelEmpty = fe;
                PLoad = pl;
            }
        }

        public class CityNode
        {
            public double MinCost { get; set; } = double.MaxValue;
            public int ParentIndex { get; set; } = -1;
            public bool IsVisited { get; set; } = false;
        }

        public class Graph
        {
            public List<CityNode> nodes;
            public List<List<Route>> adjList;

            public Graph()
            {
                nodes = new List<CityNode>();
                adjList = new List<List<Route>>();
            }

            public void AddCity()
            {
                nodes.Add(new CityNode());
                adjList.Add(new List<Route>());
            }

            public void AddRoute(int u, int v, double distance, double toll)
            {
                if (u < adjList.Count && v < adjList.Count)
                {
                    adjList[u].Add(new Route(v, distance, toll));
                    adjList[v].Add(new Route(u, distance, toll));
                }
            }

            public double CalculateCost(Route route, Vehicles car, double cargoWeight, double fuelPrice)
            {
                const long stableCost = 3000;
                double fuelCost = (route.Distance / 100) * (car.FuelEmpty + (cargoWeight * car.PLoad)) * fuelPrice;
                double distanceCost = route.Distance * cargoWeight * stableCost;
                return fuelCost + distanceCost + route.TollFee;
            }

            public void RunDijkstra(int startCityIndex, Vehicles car, double cargoWeight, double fuelPrice)
            {
                foreach (var node in nodes)
                {
                    node.MinCost = double.MaxValue;
                    node.IsVisited = false;
                    node.ParentIndex = -1;
                }
                nodes[startCityIndex].MinCost = 0;

                MyPriorityQueue pq = new MyPriorityQueue();
                pq.Enqueue(startCityIndex, 0);

                while (pq.Count > 0)
                {
                    int u = pq.Dequeue();
                    if (nodes[u].IsVisited) continue;
                    nodes[u].IsVisited = true;

                    foreach (var route in adjList[u])
                    {
                        int v = route.TargetCityIndex;
                        if (nodes[v].IsVisited) continue;

                        double weight = CalculateCost(route, car, cargoWeight, fuelPrice);
                        if (nodes[v].MinCost > nodes[u].MinCost + weight)
                        {
                            nodes[v].MinCost = nodes[u].MinCost + weight;
                            nodes[v].ParentIndex = u;
                            pq.Enqueue(v, nodes[v].MinCost);
                        }
                    }
                }
            }

            // Đã chuyển đổi từ Console.Write sang cộng chuỗi để hiển thị trên UI WinForms
            public void GetTripSummary(int startIndex, int targetIndex, RouteDiagram diagram, List<int> currentPath, Vehicles car, double cargoWeight, double fuelPrice, ref string output)
            {
                
                List<int> path = new List<int>(currentPath);
                path.Add(targetIndex);

                if (startIndex == targetIndex)
                {
                    int n = path.Count;
                    output += "Lộ trình: ";
                    for (int i = n - 1; i >= 0; i--)
                    {
                        output += diagram.FindName(path[i]);
                        if (i != 0) output += " -> ";
                    }
                    output += "\r\n";
                }
                else
                {
                    foreach (Route x in adjList[targetIndex])
                    {
                        int v = x.TargetCityIndex;
                        double w = CalculateCost(x, car, cargoWeight, fuelPrice);

                        // Cho phép các con đường có cost nhỉnh hơn 5%
                        if ((nodes[v].MinCost + w) <= nodes[targetIndex].MinCost * 1.05)
                        {
                            GetTripSummary(startIndex, v, diagram, path, car, cargoWeight, fuelPrice, ref output);
                        }
                    }
                }
            }
        }

        // ==========================================
        // KHỞI TẠO VÀ THỰC THI TRÊN UI
        // ==========================================

        public static string[] EdgesName = { "Lai Châu", "Điện Biên", "Sơn La", "Lào Cai", "Phú Thọ", "Tuyên Quang", "Hà Nội", "Ninh Bình", "Thái Nguyên", "Bắc Ninh", "Hải Phòng", "Hưng Yên", "Cao Bằng", "Lạng Sơn", "Quảng Ninh" };

        private void Dijkstra_Load(object sender, EventArgs e)
        {
            // Các thông số giả định (Sau này bạn có thể gán bằng các TextBox/ComboBox trên Form)
            Vehicles currentVehicle = new Vehicles("Xe tải trung", 18.0, 1.5);
            double currentCargoWeight = 5.0; // Tấn
            double currentFuelPrice = FuelPrice ; // VNĐ/lít

            RouteDiagram diagram = new RouteDiagram();
            Graph graph = new Graph();

            // Nạp thành phố
            for (int i = 0; i < EdgesName.Length; i++)
            {
                diagram.AddCity(EdgesName[i]);
                graph.AddCity();
            }

            int start = diagram.FindIndex(Start);
            int end = diagram.FindIndex(End);

            if (start == -1 || end == -1)
            {
                ResultLabel.Text = "Lỗi: Không tìm thấy điểm đi hoặc điểm đến trong danh sách.";
                return;
            }

            // Khởi tạo đường đi { Index_U, Index_V, Distance, TollFee }
            // Lưu ý: Cột thứ 4 (TollFee) đang để 0, bạn có thể điền phí trạm thu giá thực tế.
            double[,] EdgesData =
            {
                { diagram.FindIndex("Lai Châu"), diagram.FindIndex("Điện Biên"), 105, 0 },
                { diagram.FindIndex("Lai Châu"), diagram.FindIndex("Lào Cai"), 160, 0 },
                { diagram.FindIndex("Điện Biên"), diagram.FindIndex("Sơn La"), 155, 0 },
                { diagram.FindIndex("Lào Cai"), diagram.FindIndex("Sơn La"), 215, 0 },
                { diagram.FindIndex("Lào Cai"), diagram.FindIndex("Tuyên Quang"), 155, 0 },
                { diagram.FindIndex("Lào Cai"), diagram.FindIndex("Phú Thọ"), 200, 0 },
                { diagram.FindIndex("Sơn La"), diagram.FindIndex("Phú Thọ"), 210, 0 },
                { diagram.FindIndex("Tuyên Quang"), diagram.FindIndex("Phú Thọ"), 65, 0 },
                { diagram.FindIndex("Tuyên Quang"), diagram.FindIndex("Thái Nguyên"), 85, 0 },
                { diagram.FindIndex("Tuyên Quang"), diagram.FindIndex("Cao Bằng"), 220, 0 },
                { diagram.FindIndex("Cao Bằng"), diagram.FindIndex("Lạng Sơn"), 125, 0 },
                { diagram.FindIndex("Lạng Sơn"), diagram.FindIndex("Thái Nguyên"), 135, 0 },
                { diagram.FindIndex("Lạng Sơn"), diagram.FindIndex("Quảng Ninh"), 180, 0 },
                { diagram.FindIndex("Lạng Sơn"), diagram.FindIndex("Bắc Ninh"), 110, 0 },
                { diagram.FindIndex("Thái Nguyên"), diagram.FindIndex("Hà Nội"), 80, 0 },
                { diagram.FindIndex("Phú Thọ"), diagram.FindIndex("Hà Nội"), 90, 0 },
                { diagram.FindIndex("Sơn La"), diagram.FindIndex("Hà Nội"), 300, 0 },
                { diagram.FindIndex("Hà Nội"), diagram.FindIndex("Ninh Bình"), 95, 0 },
                { diagram.FindIndex("Hà Nội"), diagram.FindIndex("Bắc Ninh"), 30, 0 },
                { diagram.FindIndex("Hà Nội"), diagram.FindIndex("Hưng Yên"), 60, 0 },
                { diagram.FindIndex("Bắc Ninh"), diagram.FindIndex("Hưng Yên"), 40, 0 },
                { diagram.FindIndex("Bắc Ninh"), diagram.FindIndex("Hải Phòng"), 90, 0 },
                { diagram.FindIndex("Hưng Yên"), diagram.FindIndex("Hải Phòng"), 75, 0 },
                { diagram.FindIndex("Hưng Yên"), diagram.FindIndex("Ninh Bình"), 80, 0 },
                { diagram.FindIndex("Hải Phòng"), diagram.FindIndex("Quảng Ninh"), 45, 0 }
            };

            // Nạp dữ liệu vào Graph
            for (int i = 0; i < EdgesData.GetLength(0); i++)
            {
                int u = (int)EdgesData[i, 0];
                int v = (int)EdgesData[i, 1];
                double dist = EdgesData[i, 2];
                double toll = EdgesData[i, 3];

                if (u < graph.nodes.Count && v < graph.nodes.Count)
                {
                    graph.AddRoute(u, v, dist, toll);
                }
            }

            // Chạy Dijkstra
            graph.RunDijkstra(start, currentVehicle, currentCargoWeight, currentFuelPrice);

            // In kết quả
            string outputPaths = "";
            graph.GetTripSummary(start, end, diagram, new List<int>(), currentVehicle, currentCargoWeight, currentFuelPrice, ref outputPaths);

            // Truy ngược lộ trình tối ưu nhất từ điểm đích về điểm đầu để tính tổng quãng đường (km)
            double totalDistance = 0;
            int currNode = end;
            while (graph.nodes[currNode].ParentIndex != -1)
            {
                int parentNode = graph.nodes[currNode].ParentIndex;

                // Tìm thông tin tuyến đường nối giữa parentNode và currNode để lấy Distance
                foreach (var route in graph.adjList[parentNode])
                {
                    if (route.TargetCityIndex == currNode)
                    {
                        totalDistance += route.Distance;
                        break; // Thoát vòng lặp khi đã tìm thấy tuyến nối
                    }
                }
                currNode = parentNode; // Lùi về trạm trước đó
            }
            double totalCost = graph.nodes[end].MinCost;

            ResultLabel.Text = $"--- KẾT QUẢ HÀNH TRÌNH ---\r\n" +
                               $"{outputPaths}\r\n" + $"Chiều dài quãng đường là:" + totalDistance + " km\n" +
                               $"Tổng chi phí tối ưu: {totalCost:N0} VNĐ";
        }

        private void ResultLabel_Click(object sender, EventArgs e)
        {
            // Xử lý event click nếu cần
        }

    }
}
