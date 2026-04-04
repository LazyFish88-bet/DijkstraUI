using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static Test.Dijkstra;

namespace Test
{
    public partial class UCDataGridView : UserControl
    {
        public UCDataGridView()
        {
            InitializeComponent();
        }
        private void AddToDataGridView(object[,] data)
        {
            RouteGridVỉew.Rows.Clear();
            for (int i = 0; i < data.GetLength(0); i++)
            {
                RouteGridVỉew.Rows.Add(data[i, 0], data[i, 1], data[i, 2]);
            }
        }
        object[,] EdgesData =
            {
                //Tuyến Tây Bắc - Việt Bắc
                { "Lai Châu", "Điện Biên", 105 },
                { "Lai Châu", "Lào Cai", 160 },
                { "Điện Biên", "Sơn La", 155 },
                { "Lào Cai", "Sơn La", 215 },
                { "Lào Cai", "Tuyên Quang", 155 },
                { "Lào Cai", "Phú Thọ", 200 },
                //Tuyết trung tâm và Đông Bắc
                { "Sơn La", "Phú Thọ", 210 },
                { "Tuyên Quang", "Phú Thọ", 65 },
                { "Tuyên Quang", "Thái Nguyên", 85 },
                { "Tuyên Quang", "Cao Bằng", 220  },
                {"Cao Bằng", "Lạng Sơn", 125 },
                {"Lạng Sơn","Thái Nguyên", 135 },
                {"Lạng Sơn","Quảng Ninh",180 },
                {"Lạng Sơn","Bắc Ninh",110 },
                //Tuyến xoay quanh Thủ đô Hà Nội
                {"Thái Nguyên", "Hà Nội",80 },
                {"Phú Thọ","Hà Nội",90 },
                { "Sơn La","Hà Nội",300},
                {"Hà Nội", "Ninh Bình", 95 },
                {"Hà Nội", "Bắc Ninh", 30 },
                {"Hà Nội", "Hưng Yên", 60 },
                //Tuyến đường duyên hải và lân cận
                {"Bắc Ninh", "Hưng Yên",40},
                {"Bắc Ninh", "Hải Phòng", 90 },
                {"Hưng Yên", "Hải Phòng", 75 },
                {"Hưng Yên","Ninh Bình",80 },
                {"Hải Phòng","Quảng Ninh",45 }
            };
        private void UCDataGridView_Load(object sender, EventArgs e)
        {
            AddToDataGridView(EdgesData);
        }
        private void BubbleSort(Object[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j=i+1;j<arr.GetLength(0);j++)
                {
                    if (Convert.ToInt32(arr[i,2])>Convert.ToInt32(arr[j,2]))
                    {
                        string temptStart = Convert.ToString(arr[i, 0]);
                        string temptEnd = Convert.ToString(arr[i, 1]);
                        int temptDistance = Convert.ToInt32(arr[i, 2]);
                        arr[i, 0]= Convert.ToString(arr[j, 0]);
                        arr[i, 1] = Convert.ToString(arr[j, 1]);
                        arr[i, 2] = Convert.ToInt32(arr[j, 2]);
                        arr[j,0] = temptStart;
                        arr[j,1] = temptEnd;
                        arr[j,2] = temptDistance;
                    }
             
                }
            }
        }

        private void RouteGridVỉew_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void BubbleSort_Click(object sender, EventArgs e)
        {
            BubbleSort(EdgesData);
            AddToDataGridView(EdgesData);
        }
    }
}
