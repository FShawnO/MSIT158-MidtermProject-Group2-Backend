namespace 期中專案
{
	partial class Frm行銷活動
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
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.產品個別detail = new System.Windows.Forms.Label();
			this.產品刪除 = new System.Windows.Forms.Label();
			this.產品新增 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(0, 50);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidth = 51;
			this.dataGridView1.RowTemplate.Height = 27;
			this.dataGridView1.Size = new System.Drawing.Size(800, 400);
			this.dataGridView1.TabIndex = 27;
			this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.button1.Location = new System.Drawing.Point(700, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(97, 23);
			this.button1.TabIndex = 17;
			this.button1.Text = "活動搜尋";
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
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label3.Location = new System.Drawing.Point(3, 7);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(151, 29);
			this.label3.TabIndex = 13;
			this.label3.Text = "行銷活動列表";
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BackColor = System.Drawing.Color.Beige;
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.產品個別detail);
			this.panel1.Controls.Add(this.產品刪除);
			this.panel1.Controls.Add(this.產品新增);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(800, 44);
			this.panel1.TabIndex = 26;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label1.Location = new System.Drawing.Point(250, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 19);
			this.label1.TabIndex = 21;
			this.label1.Text = "編輯";
			this.label1.Click += new System.EventHandler(this.活動編輯_Click);
			// 
			// 產品個別detail
			// 
			this.產品個別detail.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.產品個別detail.AutoSize = true;
			this.產品個別detail.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.產品個別detail.Location = new System.Drawing.Point(464, 12);
			this.產品個別detail.Name = "產品個別detail";
			this.產品個別detail.Size = new System.Drawing.Size(78, 19);
			this.產品個別detail.TabIndex = 20;
			this.產品個別detail.Text = "活動detail";
			this.產品個別detail.Click += new System.EventHandler(this.活動detail_Click);
			// 
			// 產品刪除
			// 
			this.產品刪除.AutoSize = true;
			this.產品刪除.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.產品刪除.Location = new System.Drawing.Point(206, 16);
			this.產品刪除.Name = "產品刪除";
			this.產品刪除.Size = new System.Drawing.Size(39, 19);
			this.產品刪除.TabIndex = 19;
			this.產品刪除.Text = "刪除";
			this.產品刪除.Click += new System.EventHandler(this.活動刪除_Click);
			// 
			// 產品新增
			// 
			this.產品新增.AutoSize = true;
			this.產品新增.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.產品新增.Location = new System.Drawing.Point(161, 16);
			this.產品新增.Name = "產品新增";
			this.產品新增.Size = new System.Drawing.Size(39, 19);
			this.產品新增.TabIndex = 18;
			this.產品新增.Text = "新增";
			this.產品新增.Click += new System.EventHandler(this.活動新增_Click);
			// 
			// Frm行銷活動
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.panel1);
			this.Name = "Frm行銷活動";
			this.Text = "Frm行銷活動";
			this.Load += new System.EventHandler(this.Frm行銷活動_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label 產品個別detail;
		private System.Windows.Forms.Label 產品刪除;
		private System.Windows.Forms.Label 產品新增;
	}
}