namespace 後台
{
    partial class Frm消費紀錄圖表
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.Btn_ListPrice = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// Btn_ListPrice
			// 
			this.Btn_ListPrice.Font = new System.Drawing.Font("微軟正黑體", 9F);
			this.Btn_ListPrice.Location = new System.Drawing.Point(599, 87);
			this.Btn_ListPrice.Name = "Btn_ListPrice";
			this.Btn_ListPrice.Size = new System.Drawing.Size(259, 27);
			this.Btn_ListPrice.TabIndex = 7;
			this.Btn_ListPrice.Text = "包裝方式比例分布 / 以包裝方式分群統計";
			this.Btn_ListPrice.UseVisualStyleBackColor = true;
			this.Btn_ListPrice.Click += new System.EventHandler(this.Btn_PackageWayPie_Click);
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.button1.Location = new System.Drawing.Point(633, 43);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(225, 25);
			this.button1.TabIndex = 6;
			this.button1.Text = "購買總數量 / 以會員分群統計";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// chart1
			// 
			chartArea1.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chart1.Legends.Add(legend1);
			this.chart1.Location = new System.Drawing.Point(479, 158);
			this.chart1.Name = "chart1";
			series1.ChartArea = "ChartArea1";
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			this.chart1.Series.Add(series1);
			this.chart1.Size = new System.Drawing.Size(379, 265);
			this.chart1.TabIndex = 5;
			this.chart1.Text = "chart1";
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(20, 9);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidth = 51;
			this.dataGridView1.RowTemplate.Height = 27;
			this.dataGridView1.Size = new System.Drawing.Size(435, 433);
			this.dataGridView1.TabIndex = 4;
			// 
			// Frm消費紀錄圖表
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(878, 450);
			this.Controls.Add(this.Btn_ListPrice);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.chart1);
			this.Controls.Add(this.dataGridView1);
			this.Name = "Frm消費紀錄圖表";
			this.Text = "Frm消費紀錄圖表";
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_ListPrice;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataGridView dataGridView1;
	}
}