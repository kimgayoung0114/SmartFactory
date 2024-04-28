namespace MultiColoredModernUI.Forms
{
    partial class FormDashboard
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.DB_panel6 = new System.Windows.Forms.Panel();
            this.DB_label9 = new System.Windows.Forms.Label();
            this.DB_label8 = new System.Windows.Forms.Label();
            this.DB_panel3 = new System.Windows.Forms.Panel();
            this.DB_label3 = new System.Windows.Forms.Label();
            this.DB_label2 = new System.Windows.Forms.Label();
            this.DB_panel4 = new System.Windows.Forms.Panel();
            this.DB_label5 = new System.Windows.Forms.Label();
            this.DB_label4 = new System.Windows.Forms.Label();
            this.DB_timer1 = new System.Windows.Forms.Timer(this.components);
            this.DB_panel2 = new System.Windows.Forms.Panel();
            this.DB_tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DB_label1 = new System.Windows.Forms.Label();
            this.DB_panel1 = new System.Windows.Forms.Panel();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.DB_panel6.SuspendLayout();
            this.DB_panel3.SuspendLayout();
            this.DB_panel4.SuspendLayout();
            this.DB_panel2.SuspendLayout();
            this.DB_tableLayoutPanel1.SuspendLayout();
            this.DB_panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // DB_panel6
            // 
            this.DB_panel6.BackColor = System.Drawing.Color.Salmon;
            this.DB_panel6.Controls.Add(this.DB_label9);
            this.DB_panel6.Controls.Add(this.DB_label8);
            this.DB_panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DB_panel6.Location = new System.Drawing.Point(1025, 2);
            this.DB_panel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DB_panel6.Name = "DB_panel6";
            this.DB_panel6.Size = new System.Drawing.Size(506, 67);
            this.DB_panel6.TabIndex = 0;
            // 
            // DB_label9
            // 
            this.DB_label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DB_label9.AutoSize = true;
            this.DB_label9.Font = new System.Drawing.Font("굴림", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DB_label9.Location = new System.Drawing.Point(279, 25);
            this.DB_label9.Name = "DB_label9";
            this.DB_label9.Size = new System.Drawing.Size(112, 35);
            this.DB_label9.TabIndex = 0;
            this.DB_label9.Text = "label2";
            // 
            // DB_label8
            // 
            this.DB_label8.AutoSize = true;
            this.DB_label8.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DB_label8.Location = new System.Drawing.Point(12, 7);
            this.DB_label8.Name = "DB_label8";
            this.DB_label8.Size = new System.Drawing.Size(131, 16);
            this.DB_label8.TabIndex = 0;
            this.DB_label8.Text = "평균 불량률[%]";
            // 
            // DB_panel3
            // 
            this.DB_panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.DB_panel3.Controls.Add(this.DB_label3);
            this.DB_panel3.Controls.Add(this.DB_label2);
            this.DB_panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DB_panel3.Location = new System.Drawing.Point(3, 2);
            this.DB_panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DB_panel3.Name = "DB_panel3";
            this.DB_panel3.Size = new System.Drawing.Size(505, 67);
            this.DB_panel3.TabIndex = 0;
            // 
            // DB_label3
            // 
            this.DB_label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DB_label3.AutoSize = true;
            this.DB_label3.Font = new System.Drawing.Font("굴림", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DB_label3.Location = new System.Drawing.Point(278, 25);
            this.DB_label3.Name = "DB_label3";
            this.DB_label3.Size = new System.Drawing.Size(112, 35);
            this.DB_label3.TabIndex = 0;
            this.DB_label3.Text = "label2";
            // 
            // DB_label2
            // 
            this.DB_label2.AutoSize = true;
            this.DB_label2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DB_label2.Location = new System.Drawing.Point(10, 7);
            this.DB_label2.Name = "DB_label2";
            this.DB_label2.Size = new System.Drawing.Size(98, 16);
            this.DB_label2.TabIndex = 0;
            this.DB_label2.Text = "일일 생산량";
            // 
            // DB_panel4
            // 
            this.DB_panel4.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.DB_panel4.Controls.Add(this.DB_label5);
            this.DB_panel4.Controls.Add(this.DB_label4);
            this.DB_panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DB_panel4.Location = new System.Drawing.Point(514, 2);
            this.DB_panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DB_panel4.Name = "DB_panel4";
            this.DB_panel4.Size = new System.Drawing.Size(505, 67);
            this.DB_panel4.TabIndex = 0;
            // 
            // DB_label5
            // 
            this.DB_label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DB_label5.AutoSize = true;
            this.DB_label5.Font = new System.Drawing.Font("굴림", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DB_label5.Location = new System.Drawing.Point(277, 25);
            this.DB_label5.Name = "DB_label5";
            this.DB_label5.Size = new System.Drawing.Size(112, 35);
            this.DB_label5.TabIndex = 0;
            this.DB_label5.Text = "label2";
            // 
            // DB_label4
            // 
            this.DB_label4.AutoSize = true;
            this.DB_label4.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DB_label4.Location = new System.Drawing.Point(12, 7);
            this.DB_label4.Name = "DB_label4";
            this.DB_label4.Size = new System.Drawing.Size(115, 16);
            this.DB_label4.TabIndex = 0;
            this.DB_label4.Text = "주간 목표수량";
            // 
            // DB_panel2
            // 
            this.DB_panel2.Controls.Add(this.DB_tableLayoutPanel1);
            this.DB_panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.DB_panel2.Location = new System.Drawing.Point(0, 85);
            this.DB_panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DB_panel2.Name = "DB_panel2";
            this.DB_panel2.Size = new System.Drawing.Size(1534, 71);
            this.DB_panel2.TabIndex = 9;
            // 
            // DB_tableLayoutPanel1
            // 
            this.DB_tableLayoutPanel1.ColumnCount = 3;
            this.DB_tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.DB_tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.DB_tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.DB_tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.DB_tableLayoutPanel1.Controls.Add(this.DB_panel3, 0, 0);
            this.DB_tableLayoutPanel1.Controls.Add(this.DB_panel4, 1, 0);
            this.DB_tableLayoutPanel1.Controls.Add(this.DB_panel6, 2, 0);
            this.DB_tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DB_tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.DB_tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DB_tableLayoutPanel1.Name = "DB_tableLayoutPanel1";
            this.DB_tableLayoutPanel1.RowCount = 1;
            this.DB_tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DB_tableLayoutPanel1.Size = new System.Drawing.Size(1534, 71);
            this.DB_tableLayoutPanel1.TabIndex = 1;
            // 
            // DB_label1
            // 
            this.DB_label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DB_label1.AutoSize = true;
            this.DB_label1.Font = new System.Drawing.Font("굴림", 33F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DB_label1.Location = new System.Drawing.Point(647, 23);
            this.DB_label1.Name = "DB_label1";
            this.DB_label1.Size = new System.Drawing.Size(289, 44);
            this.DB_label1.TabIndex = 0;
            this.DB_label1.Text = "Dash  Board";
            // 
            // DB_panel1
            // 
            this.DB_panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DB_panel1.Controls.Add(this.DB_label1);
            this.DB_panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.DB_panel1.Location = new System.Drawing.Point(0, 0);
            this.DB_panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DB_panel1.Name = "DB_panel1";
            this.DB_panel1.Size = new System.Drawing.Size(1534, 85);
            this.DB_panel1.TabIndex = 8;
            // 
            // chart2
            // 
            chartArea5.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea5);
            this.chart2.Dock = System.Windows.Forms.DockStyle.Fill;
            legend5.Name = "Legend1";
            this.chart2.Legends.Add(legend5);
            this.chart2.Location = new System.Drawing.Point(0, 156);
            this.chart2.Name = "chart2";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chart2.Series.Add(series5);
            this.chart2.Size = new System.Drawing.Size(1534, 437);
            this.chart2.TabIndex = 11;
            this.chart2.Text = "chart1";
            // 
            // FormDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1534, 593);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.DB_panel2);
            this.Controls.Add(this.DB_panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDashboard";
            this.Text = "Dash board";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormDashboard_Load);
            this.DB_panel6.ResumeLayout(false);
            this.DB_panel6.PerformLayout();
            this.DB_panel3.ResumeLayout(false);
            this.DB_panel3.PerformLayout();
            this.DB_panel4.ResumeLayout(false);
            this.DB_panel4.PerformLayout();
            this.DB_panel2.ResumeLayout(false);
            this.DB_tableLayoutPanel1.ResumeLayout(false);
            this.DB_panel1.ResumeLayout(false);
            this.DB_panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel DB_panel6;
        private System.Windows.Forms.Label DB_label9;
        private System.Windows.Forms.Label DB_label8;
        private System.Windows.Forms.Panel DB_panel3;
        private System.Windows.Forms.Label DB_label3;
        private System.Windows.Forms.Label DB_label2;
        private System.Windows.Forms.Panel DB_panel4;
        private System.Windows.Forms.Label DB_label5;
        private System.Windows.Forms.Label DB_label4;
        private System.Windows.Forms.Timer DB_timer1;
        private System.Windows.Forms.Panel DB_panel2;
        private System.Windows.Forms.TableLayoutPanel DB_tableLayoutPanel1;
        private System.Windows.Forms.Label DB_label1;
        private System.Windows.Forms.Panel DB_panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}