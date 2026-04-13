namespace Test
{
    partial class UCDataGridView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            RouteGridVỉew = new DataGridView();
            Start = new DataGridViewTextBoxColumn();
            End = new DataGridViewTextBoxColumn();
            Length = new DataGridViewTextBoxColumn();
            Sort = new Button();
            SortStart = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)RouteGridVỉew).BeginInit();
            SuspendLayout();
            // 
            // RouteGridVỉew
            // 
            RouteGridVỉew.AllowUserToAddRows = false;
            RouteGridVỉew.AllowUserToDeleteRows = false;
            RouteGridVỉew.AllowUserToResizeColumns = false;
            RouteGridVỉew.AllowUserToResizeRows = false;
            RouteGridVỉew.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            RouteGridVỉew.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            RouteGridVỉew.Columns.AddRange(new DataGridViewColumn[] { Start, End, Length });
            RouteGridVỉew.Location = new Point(0, 0);
            RouteGridVỉew.Name = "RouteGridVỉew";
            RouteGridVỉew.ReadOnly = true;
            RouteGridVỉew.RowHeadersWidth = 82;
            RouteGridVỉew.Size = new Size(444, 958);
            RouteGridVỉew.TabIndex = 0;
            RouteGridVỉew.CellContentClick += RouteGridVỉew_CellContentClick;
            // 
            // Start
            // 
            Start.HeaderText = "Điểm đi";
            Start.MinimumWidth = 10;
            Start.Name = "Start";
            Start.ReadOnly = true;
            // 
            // End
            // 
            End.HeaderText = "Điểm đến";
            End.MinimumWidth = 10;
            End.Name = "End";
            End.ReadOnly = true;
            // 
            // Length
            // 
            Length.HeaderText = "Khoảng cách";
            Length.MinimumWidth = 10;
            Length.Name = "Length";
            Length.ReadOnly = true;
            // 
            // Sort
            // 
            Sort.Location = new Point(450, 59);
            Sort.Name = "Sort";
            Sort.Size = new Size(150, 50);
            Sort.TabIndex = 1;
            Sort.Text = "Sort Length";
            Sort.UseVisualStyleBackColor = true;
            Sort.Click += BubbleSortLength_Click;
            // 
            // SortStart
            // 
            SortStart.Location = new Point(450, 154);
            SortStart.Name = "SortStart";
            SortStart.Size = new Size(150, 46);
            SortStart.TabIndex = 2;
            SortStart.Text = "Sort Start";
            SortStart.UseVisualStyleBackColor = true;
            SortStart.Click += SortStart_Click;
            // 
            // button1
            // 
            button1.Location = new Point(450, 253);
            button1.Name = "button1";
            button1.Size = new Size(150, 46);
            button1.TabIndex = 3;
            button1.Text = "Sort End";
            button1.UseVisualStyleBackColor = true;
            button1.Click += SortEnd_Click;
            // 
            // UCDataGridView
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(button1);
            Controls.Add(SortStart);
            Controls.Add(Sort);
            Controls.Add(RouteGridVỉew);
            Name = "UCDataGridView";
            Size = new Size(600, 958);
            Load += UCDataGridView_Load;
            ((System.ComponentModel.ISupportInitialize)RouteGridVỉew).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView RouteGridVỉew;
        private DataGridViewTextBoxColumn Start;
        private DataGridViewTextBoxColumn End;
        private DataGridViewTextBoxColumn Length;
        private Button Sort;
        private Button SortStart;
        private Button button1;
    }
}
