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
            StartDestination = new TextBox();
            Title = new Label();
            EndDestination = new TextBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // LoadPanel
            // 
            LoadPanel.Location = new Point(0, 0);
            LoadPanel.Name = "LoadPanel";
            LoadPanel.Size = new Size(1400, 1008);
            LoadPanel.TabIndex = 0;
            // 
            // StartDestination
            // 
            StartDestination.Font = new Font("Times New Roman", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StartDestination.Location = new Point(1539, 212);
            StartDestination.Name = "StartDestination";
            StartDestination.RightToLeft = RightToLeft.No;
            StartDestination.Size = new Size(200, 69);
            StartDestination.TabIndex = 0;
            StartDestination.TextAlign = HorizontalAlignment.Center;
            StartDestination.TextChanged += StartDestination_TextChanged;
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
            // EndDestination
            // 
            EndDestination.Font = new Font("Times New Roman", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EndDestination.Location = new Point(1539, 498);
            EndDestination.Name = "EndDestination";
            EndDestination.Size = new Size(200, 69);
            EndDestination.TabIndex = 2;
            EndDestination.TextAlign = HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Image = Properties.Resources._279c187529c8ea8f2ef918b9778c9c02;
            pictureBox1.Location = new Point(1539, 724);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(229, 124);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Click += Start_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1894, 1009);
            Controls.Add(pictureBox1);
            Controls.Add(EndDestination);
            Controls.Add(Title);
            Controls.Add(StartDestination);
            Controls.Add(LoadPanel);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel LoadPanel;
        private TextBox StartDestination;
        private Label Title;
        private TextBox EndDestination;
        private PictureBox pictureBox1;
    }
}
