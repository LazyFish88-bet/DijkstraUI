namespace Test
{
    partial class Dijkstra
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
            ResultLabel = new Label();
            SuspendLayout();
            // 
            // ResultLabel
            // 
            ResultLabel.BackColor = Color.Transparent;
            ResultLabel.Font = new Font("Times New Roman", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ResultLabel.ForeColor = Color.Black;
            ResultLabel.Location = new Point(0, 0);
            ResultLabel.Name = "ResultLabel";
            ResultLabel.Size = new Size(1400, 1005);
            ResultLabel.TabIndex = 0;
            ResultLabel.Text = "label1";
            ResultLabel.TextAlign = ContentAlignment.MiddleCenter;
            ResultLabel.Click += ResultLabel_Click;
            // 
            // Dijkstra
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(ResultLabel);
            Name = "Dijkstra";
            Size = new Size(1400, 1008);
            Load += Dijkstra_Load;
            ResumeLayout(false);
        }

        #endregion

        public Label ResultLabel;
    }
}
