namespace Test
{
    partial class StatsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LoadDataGridView = new Panel();
            SuspendLayout();
            // 
            // LoadDataGridView
            // 
            LoadDataGridView.Dock = DockStyle.Fill;
            LoadDataGridView.Location = new Point(0, 0);
            LoadDataGridView.Name = "LoadDataGridView";
            LoadDataGridView.Size = new Size(1200, 958);
            LoadDataGridView.TabIndex = 0;
            LoadDataGridView.Paint += LoadDataGridView_Paint;
            // 
            // StatsForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.Info;
            ClientSize = new Size(1200, 958);
            Controls.Add(LoadDataGridView);
            FormBorderStyle = FormBorderStyle.None;
            Name = "StatsForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "StatsForm";
            Load += StatsForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Panel LoadDataGridView;
    }
}