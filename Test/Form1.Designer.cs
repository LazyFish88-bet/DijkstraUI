namespace Test
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LoadPanel = new Panel();
            Title = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            StartComboBox = new ComboBox();
            EndComboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // LoadPanel
            // 
            LoadPanel.Location = new Point(0, 0);
            LoadPanel.Name = "LoadPanel";
            LoadPanel.Size = new Size(1400, 1008);
            LoadPanel.TabIndex = 0;
            LoadPanel.Paint += LoadPanel_Paint;
            // 
            // Title
            // 
            Title.AutoSize = true;
            Title.Font = new Font("Times New Roman", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Title.Location = new Point(1490, 36);
            Title.Name = "Title";
            Title.Size = new Size(296, 90);
            Title.TabIndex = 1;
            Title.Text = "Dijkstra";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Image = Properties.Resources._279c187529c8ea8f2ef918b9778c9c02;
            pictureBox1.Location = new Point(1406, 646);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(229, 124);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Click += Start_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Back_free_icons_designed_by_Freepik_removebg_preview;
            pictureBox2.Location = new Point(1661, 646);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(233, 131);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            pictureBox2.Click += Back_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(1490, 190);
            label1.Name = "label1";
            label1.Size = new Size(86, 42);
            label1.TabIndex = 4;
            label1.Text = "Start";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(1498, 307);
            label2.Name = "label2";
            label2.Size = new Size(78, 42);
            label2.TabIndex = 5;
            label2.Text = "End";
            label2.Click += label2_Click;
            // 
            // StartComboBox
            // 
            StartComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            StartComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            StartComboBox.Font = new Font("Times New Roman", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StartComboBox.FormattingEnabled = true;
            StartComboBox.Location = new Point(1406, 235);
            StartComboBox.Name = "StartComboBox";
            StartComboBox.Size = new Size(256, 69);
            StartComboBox.TabIndex = 6;
            // 
            // EndComboBox
            // 
            EndComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            EndComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            EndComboBox.Font = new Font("Times New Roman", 19.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EndComboBox.FormattingEnabled = true;
            EndComboBox.Location = new Point(1406, 352);
            EndComboBox.Name = "EndComboBox";
            EndComboBox.Size = new Size(256, 69);
            EndComboBox.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1894, 1009);
            Controls.Add(EndComboBox);
            Controls.Add(StartComboBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(Title);
            Controls.Add(LoadPanel);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel LoadPanel;
        private Label Title;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label1;
        private Label label2;
        private ComboBox StartComboBox;
        private ComboBox EndComboBox;
    }
}
