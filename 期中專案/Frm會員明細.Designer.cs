namespace 後台
{
    partial class Frm會員明細
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
			this.button1 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.會員明細 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.會員資料編輯 = new System.Windows.Forms.Label();
			this.產品刪除 = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.產品新增 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.button1.Location = new System.Drawing.Point(700, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(97, 23);
			this.button1.TabIndex = 17;
			this.button1.Text = "會員搜尋";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(548, 6);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(146, 25);
			this.textBox1.TabIndex = 16;
			// 
			// 會員明細
			// 
			this.會員明細.AutoSize = true;
			this.會員明細.BackColor = System.Drawing.Color.Transparent;
			this.會員明細.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.會員明細.Location = new System.Drawing.Point(3, 7);
			this.會員明細.Name = "會員明細";
			this.會員明細.Size = new System.Drawing.Size(105, 29);
			this.會員明細.TabIndex = 13;
			this.會員明細.Text = "會員明細";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Beige;
			this.panel1.Controls.Add(this.會員資料編輯);
			this.panel1.Controls.Add(this.產品刪除);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Controls.Add(this.會員明細);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(800, 44);
			this.panel1.TabIndex = 28;
			// 
			// 會員資料編輯
			// 
			this.會員資料編輯.AutoSize = true;
			this.會員資料編輯.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.會員資料編輯.Location = new System.Drawing.Point(203, 17);
			this.會員資料編輯.Name = "會員資料編輯";
			this.會員資料編輯.Size = new System.Drawing.Size(39, 19);
			this.會員資料編輯.TabIndex = 22;
			this.會員資料編輯.Text = "編輯";
			this.會員資料編輯.Click += new System.EventHandler(this.會員資料編輯_Click);
			// 
			// 產品刪除
			// 
			this.產品刪除.AutoSize = true;
			this.產品刪除.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.產品刪除.Location = new System.Drawing.Point(158, 17);
			this.產品刪除.Name = "產品刪除";
			this.產品刪除.Size = new System.Drawing.Size(39, 19);
			this.產品刪除.TabIndex = 19;
			this.產品刪除.Text = "刪除";
			this.產品刪除.Click += new System.EventHandler(this.產品刪除_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(-7, 49);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidth = 51;
			this.dataGridView1.RowTemplate.Height = 27;
			this.dataGridView1.Size = new System.Drawing.Size(814, 402);
			this.dataGridView1.TabIndex = 29;
			// 
			// 產品新增
			// 
			this.產品新增.AutoSize = true;
			this.產品新增.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.產品新增.Location = new System.Drawing.Point(110, 17);
			this.產品新增.Name = "產品新增";
			this.產品新增.Size = new System.Drawing.Size(39, 19);
			this.產品新增.TabIndex = 30;
			this.產品新增.Text = "新增";
			this.產品新增.Click += new System.EventHandler(this.產品新增_Click);
			// 
			// Frm會員明細
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.產品新增);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.dataGridView1);
			this.Name = "Frm會員明細";
			this.Text = "Frm會員明細";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.Frm會員明細_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label 會員明細;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label 產品刪除;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label 會員資料編輯;
		private System.Windows.Forms.Label 產品新增;
	}
}