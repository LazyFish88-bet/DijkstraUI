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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            LoadPanel = new Panel();
            Title = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            StartComboBox = new ComboBox();
            EndComboBox = new ComboBox();
            StatsOpenButton = new PictureBox();
            StatsCloseButton = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            FuelPriceBox = new TextBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)StatsOpenButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)StatsCloseButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // LoadPanel
            // 
            LoadPanel.Location = new Point(91, 9);
            LoadPanel.Margin = new Padding(2, 2, 2, 2);
            LoadPanel.Name = "LoadPanel";
            LoadPanel.Size = new Size(862, 630);
            LoadPanel.TabIndex = 0;
            LoadPanel.Paint += LoadPanel_Paint;
            // 
            // Title
            // 
            Title.AutoSize = true;
            Title.Font = new Font("Times New Roman", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Title.Location = new Point(957, 9);
            Title.Margin = new Padding(2, 0, 2, 0);
            Title.Name = "Title";
            Title.Size = new Size(183, 57);
            Title.TabIndex = 1;
            Title.Text = "Dijkstra";
            Title.Click += Title_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Image = Properties.Resources._279c187529c8ea8f2ef918b9778c9c02;
            pictureBox1.Location = new Point(968, 509);
            pictureBox1.Margin = new Padding(2, 2, 2, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(141, 78);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Click += Start_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Back_free_icons_designed_by_Freepik_removebg_preview;
            pictureBox2.Location = new Point(966, 505);
            pictureBox2.Margin = new Padding(2, 2, 2, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(143, 82);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            pictureBox2.Click += Back_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(968, 83);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(57, 27);
            label1.TabIndex = 4;
            label1.Text = "Start";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(968, 174);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(51, 27);
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
            StartComboBox.Location = new Point(951, 111);
            StartComboBox.Margin = new Padding(2, 2, 2, 2);
            StartComboBox.Name = "StartComboBox";
            StartComboBox.Size = new Size(159, 45);
            StartComboBox.TabIndex = 6;
            StartComboBox.SelectedIndexChanged += StartComboBox_SelectedIndexChanged;
            // 
            // EndComboBox
            // 
            EndComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            EndComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            EndComboBox.Font = new Font("Times New Roman", 19.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EndComboBox.FormattingEnabled = true;
            EndComboBox.Location = new Point(951, 212);
            EndComboBox.Margin = new Padding(2, 2, 2, 2);
            EndComboBox.Name = "EndComboBox";
            EndComboBox.Size = new Size(159, 45);
            EndComboBox.TabIndex = 7;
            // 
            // StatsOpenButton
            // 
            StatsOpenButton.BackgroundImageLayout = ImageLayout.Zoom;
            StatsOpenButton.Image = Properties.Resources.Arrow_Ui_Game__Logo_Ui_Vector_Illustration_Free_Logo_Design_Template__Arrow__Arrows_PNG_and_Vector_with_Transparent_Background_for_Free_Download;
            StatsOpenButton.Location = new Point(44, 307);
            StatsOpenButton.Name = "StatsOpenButton";
            StatsOpenButton.Size = new Size(42, 49);
            StatsOpenButton.SizeMode = PictureBoxSizeMode.Zoom;
            StatsOpenButton.TabIndex = 8;
            StatsOpenButton.TabStop = false;
            StatsOpenButton.Click += Stat_Click;
            // 
            // StatsCloseButton
            // 
            StatsCloseButton.BackgroundImage = (Image)resources.GetObject("StatsCloseButton.BackgroundImage");
            StatsCloseButton.Image = Properties.Resources.Arrow_Ui_Game__Logo_Ui_Vector_Illustration_Free_Logo_Design_Template__Arrow__Arrows_PNG_and_Vector_with_Transparent_Background_for_Free_Download_1_;
            StatsCloseButton.Location = new Point(44, 307);
            StatsCloseButton.Name = "StatsCloseButton";
            StatsCloseButton.Size = new Size(42, 49);
            StatsCloseButton.SizeMode = PictureBoxSizeMode.Zoom;
            StatsCloseButton.TabIndex = 9;
            StatsCloseButton.TabStop = false;
            StatsCloseButton.Click += StatsCloseButton_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.sortbutton;
            pictureBox3.Location = new Point(1119, 111);
            pictureBox3.Margin = new Padding(2, 2, 2, 2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(39, 43);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 10;
            pictureBox3.TabStop = false;
            pictureBox3.Click += SortStartComboBox_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.sortbutton;
            pictureBox4.Location = new Point(1119, 212);
            pictureBox4.Margin = new Padding(2, 2, 2, 2);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(39, 43);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 11;
            pictureBox4.TabStop = false;
            // 
            // FuelPriceBox
            // 
            FuelPriceBox.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FuelPriceBox.Location = new Point(957, 314);
            FuelPriceBox.Margin = new Padding(2, 2, 2, 2);
            FuelPriceBox.Name = "FuelPriceBox";
            FuelPriceBox.Size = new Size(125, 42);
            FuelPriceBox.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(957, 278);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(98, 27);
            label3.TabIndex = 13;
            label3.Text = "Giá xăng";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1166, 631);
            Controls.Add(label3);
            Controls.Add(FuelPriceBox);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(StatsCloseButton);
            Controls.Add(StatsOpenButton);
            Controls.Add(EndComboBox);
            Controls.Add(StartComboBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(Title);
            Controls.Add(LoadPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2, 2, 2, 2);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            LocationChanged += Form1_LocationChanged;
            Click += SortEndButton_Click;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)StatsOpenButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)StatsCloseButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
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
        private PictureBox StatsOpenButton;
        private PictureBox StatsCloseButton;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private TextBox FuelPriceBox;
        private Label label3;
    }
}
