namespace K_means
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.PaintPanel = new System.Windows.Forms.Panel();
            this.RandomButton = new System.Windows.Forms.Button();
            this.ResultButton = new System.Windows.Forms.Button();
            this.PointsLabel = new System.Windows.Forms.Label();
            this.PointsTrackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.PointsTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // PaintPanel
            // 
            this.PaintPanel.Location = new System.Drawing.Point(12, 49);
            this.PaintPanel.Name = "PaintPanel";
            this.PaintPanel.Size = new System.Drawing.Size(208, 324);
            this.PaintPanel.TabIndex = 0;
            // 
            // RandomButton
            // 
            this.RandomButton.Location = new System.Drawing.Point(226, 51);
            this.RandomButton.Name = "RandomButton";
            this.RandomButton.Size = new System.Drawing.Size(104, 23);
            this.RandomButton.TabIndex = 1;
            this.RandomButton.Text = "Random";
            this.RandomButton.UseVisualStyleBackColor = true;
            this.RandomButton.Click += new System.EventHandler(this.RandomButton_Click);
            // 
            // ResultButton
            // 
            this.ResultButton.Location = new System.Drawing.Point(226, 89);
            this.ResultButton.Name = "ResultButton";
            this.ResultButton.Size = new System.Drawing.Size(104, 23);
            this.ResultButton.TabIndex = 2;
            this.ResultButton.Text = "Result";
            this.ResultButton.UseVisualStyleBackColor = true;
            this.ResultButton.Click += new System.EventHandler(this.ResultButton_Click);
            // 
            // PointsLabel
            // 
            this.PointsLabel.AutoSize = true;
            this.PointsLabel.Location = new System.Drawing.Point(257, 166);
            this.PointsLabel.Name = "PointsLabel";
            this.PointsLabel.Size = new System.Drawing.Size(13, 13);
            this.PointsLabel.TabIndex = 3;
            this.PointsLabel.Text = "1";
            // 
            // PointsTrackBar
            // 
            this.PointsTrackBar.Location = new System.Drawing.Point(226, 118);
            this.PointsTrackBar.Maximum = 30000;
            this.PointsTrackBar.Minimum = 1;
            this.PointsTrackBar.Name = "PointsTrackBar";
            this.PointsTrackBar.Size = new System.Drawing.Size(104, 45);
            this.PointsTrackBar.TabIndex = 5;
            this.PointsTrackBar.Value = 1;
            this.PointsTrackBar.ValueChanged += new System.EventHandler(this.PointsTrackBar_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 385);
            this.Controls.Add(this.PointsTrackBar);
            this.Controls.Add(this.PointsLabel);
            this.Controls.Add(this.ResultButton);
            this.Controls.Add(this.RandomButton);
            this.Controls.Add(this.PaintPanel);
            this.MaximumSize = new System.Drawing.Size(361, 424);
            this.MinimumSize = new System.Drawing.Size(361, 424);
            this.Name = "Form1";
            this.Text = "K-means";
            ((System.ComponentModel.ISupportInitialize)(this.PointsTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PaintPanel;
        private System.Windows.Forms.Button RandomButton;
        private System.Windows.Forms.Button ResultButton;
        private System.Windows.Forms.Label PointsLabel;
        private System.Windows.Forms.TrackBar PointsTrackBar;
    }
}

