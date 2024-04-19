namespace 期中專案
{
    partial class Frm編輯會員
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
			this.確認 = new System.Windows.Forms.Button();
			this.取消 = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.cboVIP = new System.Windows.Forms.ComboBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.label9 = new System.Windows.Forms.Label();
			this.cboSex = new System.Windows.Forms.ComboBox();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// 確認
			// 
			this.確認.AutoSize = true;
			this.確認.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.確認.Location = new System.Drawing.Point(689, 366);
			this.確認.Name = "確認";
			this.確認.Size = new System.Drawing.Size(83, 45);
			this.確認.TabIndex = 41;
			this.確認.Text = "確認";
			this.確認.UseVisualStyleBackColor = true;
			this.確認.Click += new System.EventHandler(this.確認_Click);
			// 
			// 取消
			// 
			this.取消.AutoSize = true;
			this.取消.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.取消.Location = new System.Drawing.Point(589, 366);
			this.取消.Name = "取消";
			this.取消.Size = new System.Drawing.Size(80, 45);
			this.取消.TabIndex = 40;
			this.取消.Text = "取消";
			this.取消.UseVisualStyleBackColor = true;
			this.取消.Click += new System.EventHandler(this.取消_Click);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label10.Location = new System.Drawing.Point(28, 289);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(52, 25);
			this.label10.TabIndex = 38;
			this.label10.Text = "生日";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label8.Location = new System.Drawing.Point(28, 168);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(52, 25);
			this.label8.TabIndex = 36;
			this.label8.Text = "地址";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label6.Location = new System.Drawing.Point(28, 119);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(52, 25);
			this.label6.TabIndex = 34;
			this.label6.Text = "手機";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label4.Location = new System.Drawing.Point(28, 71);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(92, 25);
			this.label4.TabIndex = 32;
			this.label4.Text = "電子信箱";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label1.Location = new System.Drawing.Point(28, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 25);
			this.label1.TabIndex = 30;
			this.label1.Text = "會員名稱";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Location = new System.Drawing.Point(513, 86);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(259, 243);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 29;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(168, 23);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(301, 25);
			this.textBox1.TabIndex = 42;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(168, 76);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(301, 25);
			this.textBox2.TabIndex = 43;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(168, 124);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(301, 25);
			this.textBox3.TabIndex = 44;
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(168, 173);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(301, 25);
			this.textBox4.TabIndex = 45;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label2.Location = new System.Drawing.Point(28, 342);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 25);
			this.label2.TabIndex = 47;
			this.label2.Text = "點數";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label3.Location = new System.Drawing.Point(28, 394);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(43, 25);
			this.label3.TabIndex = 48;
			this.label3.Text = "VIP";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label5.Location = new System.Drawing.Point(28, 444);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(92, 25);
			this.label5.TabIndex = 49;
			this.label5.Text = "會員錢包";
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(168, 342);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(301, 25);
			this.textBox6.TabIndex = 50;
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(168, 449);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(301, 25);
			this.textBox8.TabIndex = 52;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label7.Location = new System.Drawing.Point(508, 23);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(92, 25);
			this.label7.TabIndex = 53;
			this.label7.Text = "會員照片";
			// 
			// cboVIP
			// 
			this.cboVIP.FormattingEnabled = true;
			this.cboVIP.Location = new System.Drawing.Point(168, 399);
			this.cboVIP.Name = "cboVIP";
			this.cboVIP.Size = new System.Drawing.Size(301, 23);
			this.cboVIP.TabIndex = 54;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label9.Location = new System.Drawing.Point(28, 233);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(52, 25);
			this.label9.TabIndex = 55;
			this.label9.Text = "性別";
			// 
			// cboSex
			// 
			this.cboSex.FormattingEnabled = true;
			this.cboSex.Location = new System.Drawing.Point(168, 235);
			this.cboSex.Name = "cboSex";
			this.cboSex.Size = new System.Drawing.Size(301, 23);
			this.cboSex.TabIndex = 57;
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(168, 290);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(301, 25);
			this.dateTimePicker1.TabIndex = 58;
			// 
			// Frm編輯會員
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 515);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.cboSex);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.cboVIP);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.textBox8);
			this.Controls.Add(this.textBox6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.確認);
			this.Controls.Add(this.取消);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Name = "Frm編輯會員";
			this.Text = "Frm編輯會員";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button 確認;
        private System.Windows.Forms.Button 取消;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cboVIP;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox cboSex;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
	}
}