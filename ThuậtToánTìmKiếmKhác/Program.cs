using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace SoSanhDoThi
{
    class Program
    {
        static void Main(string[] args)
        {
            // Khởi tạo đồ thị
            Graph g = new Graph();
            int soDinh = 600;
            int soCanh = 15000;
            Random ngauNhien = new Random();
            Console.WriteLine("════════════════════════════════════════════════════════════");
            Console.WriteLine("  MÔ PHỎNG VÀ ĐO LƯỜNG THUẬT TOÁN ĐỒ THỊ");
            Console.WriteLine("════════════════════════════════════════════════════════════");
            Console.WriteLine($"- Số đỉnh: {soDinh}");
            Console.WriteLine($"- Số cạnh: {soCanh}");
            Console.WriteLine();
            Console.WriteLine("  KẾT QUẢ ĐO THỜI GIAN THỰC THI TRUNG BÌNH");
            Console.WriteLine("════════════════════════════════════════════════════════════");


            // Tạo dữ liệu đồ thị
            for (int i = 0; i < soDinh; i++) g.AddVertex(i.ToString());
            HashSet<(int, int)> usedEdges = new HashSet<(int, int)>();
            int added = 0;
            while (added < soCanh)
            {
                int u = ngauNhien.Next(0, soDinh);
                int v = ngauNhien.Next(0, soDinh);
                int w = ngauNhien.Next(1, 26);
                if (u != v && !usedEdges.Contains((u, v)))
                {
                    g.AddEdge(u, v, w);
                    usedEdges.Add((u, v));
                    usedEdges.Add((v, u));
                    added++;
                }
            }
            for (int i = 0; i < soDinh; i++) g.SetHeuristic(i, ngauNhien.Next(1, 101));


            // --- GỌI CÁC HÀM ĐO VÀ IN KẾT QUẢ ---
            g.MeasureDijkstra(0, 7);
            Console.WriteLine("------------------------------------------------------------");

            g.MeasureAStar(0, soDinh - 1, 7);
            Console.WriteLine("------------------------------------------------------------");

            g.MeasureFloydWarshall(1);
            Console.WriteLine("------------------------------------------------------------");


        }
    }


    public class Graph
    {
        private const int MAX_VERTICES = 1200;
        private Vertex[] vertices;
        private int[,] adjMatrix;
        private int numVerts;


        public Graph()
        {
            vertices = new Vertex[MAX_VERTICES];
            adjMatrix = new int[MAX_VERTICES, MAX_VERTICES];
            numVerts = 0;
        }


        public void AddVertex(string label) { vertices[numVerts++] = new Vertex(label); }
        public void AddEdge(int start, int end, int weight) { adjMatrix[start, end] = weight; adjMatrix[end, start] = weight; }
        public void SetHeuristic(int vertexIndex, int value) { vertices[vertexIndex].Heuristic = value; }


        private void ResetVisited()
        {
            for (int i = 0; i < numVerts; i++) { vertices[i].WasVisited = false; vertices[i].Distance = int.MaxValue; }
        }


        // Cập nhật các hàm measure để in ra đúng định dạng
        public void MeasureDijkstra(int start, int iterations)
        {
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++) Dijkstra(start);
            sw.Stop();
            double result = sw.ElapsedMilliseconds / (double)iterations;
            Console.WriteLine($"-> Thời gian trung bình Dijkstra:       {result,10:F2} ms");
        }


        public void MeasureAStar(int start, int goal, int iterations)
        {
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++) AStar(start, goal);
            sw.Stop();
            double result = sw.ElapsedMilliseconds / (double)iterations;
            Console.WriteLine($"-> Thời gian trung bình A*:              {result,10:F2} ms");
        }


        public void MeasureFloydWarshall(int iterations)
        {
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++) FloydWarshall();
            sw.Stop();
            double result = sw.ElapsedMilliseconds / (double)iterations;
            Console.WriteLine($"-> Thời gian trung bình Floyd-Warshall:  {result,10:F2} ms");
        }


        // Dijkstra
        public void Dijkstra(int start)
        {
            ResetVisited();
            vertices[start].Distance = 0;
            var list = new List<(int dist, int v)>();
            list.Add((0, start));
            while (list.Count > 0)
            {
                list.Sort((a, b) => a.dist.CompareTo(b.dist));
                var current = list[0]; list.RemoveAt(0);
                int u = current.v;
                if (vertices[u].WasVisited) continue;
                vertices[u].WasVisited = true;
                for (int v = 0; v < numVerts; v++)
                {
                    if (adjMatrix[u, v] > 0 && !vertices[v].WasVisited)
                    {
                        int newDist = vertices[u].Distance + adjMatrix[u, v];
                        if (newDist < vertices[v].Distance) { vertices[v].Distance = newDist; list.Add((newDist, v)); }
                    }
                }
            }
        }


        // A*
        public void AStar(int start, int goal)
        {
            ResetVisited();
            int[] gScore = new int[numVerts];
            for (int i = 0; i < numVerts; i++) gScore[i] = int.MaxValue;
            gScore[start] = 0;
            var openSet = new List<(int fScore, int v)>();
            openSet.Add((vertices[start].Heuristic, start));
            while (openSet.Count > 0)
            {
                openSet.Sort((a, b) => a.fScore.CompareTo(b.fScore));
                var current = openSet[0]; openSet.RemoveAt(0);
                int u = current.v;
                if (u == goal) break;
                if (vertices[u].WasVisited) continue;
                vertices[u].WasVisited = true;
                for (int v = 0; v < numVerts; v++)
                {
                    if (adjMatrix[u, v] > 0 && !vertices[v].WasVisited)
                    {
                        int tentativeG = gScore[u] + adjMatrix[u, v];
                        if (tentativeG < gScore[v])
                        {
                            gScore[v] = tentativeG;
                            openSet.Add((tentativeG + vertices[v].Heuristic, v));
                        }
                    }
                }
            }
        }


        // Floyd-Warshall
        public void FloydWarshall()
        {
            int[,] dist = new int[numVerts, numVerts];
            for (int i = 0; i < numVerts; i++)
                for (int j = 0; j < numVerts; j++)
                    dist[i, j] = (i == j) ? 0 : (adjMatrix[i, j] > 0 ? adjMatrix[i, j] : 1000000);
            for (int k = 0; k < numVerts; k++)
                for (int i = 0; i < numVerts; i++)
                    for (int j = 0; j < numVerts; j++)
                        if (dist[i, k] + dist[k, j] < dist[i, j]) dist[i, j] = dist[i, k] + dist[k, j];
        }
    }


    public class Vertex
    {
        public string Label; public bool WasVisited; public int Distance; public int Heuristic;
        public Vertex(string label) { Label = label; WasVisited = false; Distance = int.MaxValue; Heuristic = 0; }
    }
}

