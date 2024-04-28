namespace MultiColoredModernUI.Forms
{
    partial class FormWokrMaster
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboWorkID = new System.Windows.Forms.ComboBox();
            this.cboWorkName = new System.Windows.Forms.ComboBox();
            this.cboWorkIng = new System.Windows.Forms.ComboBox();
            this.cboPlantCode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Grid10 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid10)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboWorkID);
            this.groupBox1.Controls.Add(this.cboWorkName);
            this.groupBox1.Controls.Add(this.cboWorkIng);
            this.groupBox1.Controls.Add(this.cboPlantCode);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(984, 123);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.Grid10);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(984, 438);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // cboWorkID
            // 
            this.cboWorkID.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboWorkID.FormattingEnabled = true;
            this.cboWorkID.Location = new System.Drawing.Point(401, 25);
            this.cboWorkID.Name = "cboWorkID";
            this.cboWorkID.Size = new System.Drawing.Size(156, 24);
            this.cboWorkID.TabIndex = 171;
            // 
            // cboWorkName
            // 
            this.cboWorkName.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboWorkName.FormattingEnabled = true;
            this.cboWorkName.Location = new System.Drawing.Point(680, 25);
            this.cboWorkName.Name = "cboWorkName";
            this.cboWorkName.Size = new System.Drawing.Size(156, 24);
            this.cboWorkName.TabIndex = 170;
            // 
            // cboWorkIng
            // 
            this.cboWorkIng.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboWorkIng.FormattingEnabled = true;
            this.cboWorkIng.Location = new System.Drawing.Point(133, 75);
            this.cboWorkIng.Name = "cboWorkIng";
            this.cboWorkIng.Size = new System.Drawing.Size(156, 24);
            this.cboWorkIng.TabIndex = 169;
            // 
            // cboPlantCode
            // 
            this.cboPlantCode.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboPlantCode.FormattingEnabled = true;
            this.cboPlantCode.Location = new System.Drawing.Point(133, 26);
            this.cboPlantCode.Name = "cboPlantCode";
            this.cboPlantCode.Size = new System.Drawing.Size(156, 24);
            this.cboPlantCode.TabIndex = 167;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("굴림", 12F);
            this.label5.Location = new System.Drawing.Point(72, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 20);
            this.label5.TabIndex = 166;
            this.label5.Text = "공장";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("굴림", 12F);
            this.label4.Location = new System.Drawing.Point(38, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 165;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("굴림", 12F);
            this.label3.Location = new System.Drawing.Point(326, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 164;
            this.label3.Text = "작업자 ID";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("굴림", 12F);
            this.label2.Location = new System.Drawing.Point(604, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 163;
            this.label2.Text = "작업자명";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("굴림", 12F);
            this.label1.Location = new System.Drawing.Point(73, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 172;
            this.label1.Text = "작업반";
            // 
            // Grid10
            // 
            this.Grid10.BackgroundColor = System.Drawing.Color.White;
            this.Grid10.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid10.Location = new System.Drawing.Point(3, 17);
            this.Grid10.Name = "Grid10";
            this.Grid10.RowTemplate.Height = 23;
            this.Grid10.Size = new System.Drawing.Size(978, 418);
            this.Grid10.TabIndex = 0;
            // 
            // FormInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormInformation";
            this.Text = "작업자 마스터";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormInformation_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid10)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboWorkID;
        private System.Windows.Forms.ComboBox cboWorkName;
        private System.Windows.Forms.ComboBox cboWorkIng;
        private System.Windows.Forms.ComboBox cboPlantCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView Grid10;
    }
}