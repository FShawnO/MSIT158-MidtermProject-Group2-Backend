using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 後台
{
    public partial class Frm產品圖表 : Form
    {
        public Frm產品圖表()
        {
            InitializeComponent();
        }
        SelectShopEntities db = new SelectShopEntities();

        private void button1_Click(object sender, EventArgs e)
        {
            var productName = from p in db.tProducts
                              group p by p.ProductName into g
							  orderby g.Sum(p =>p.Stocks) descending
                              select new { 產品名稱 = g.Key, 庫存數量 =g.Sum(p => p.Stocks) };
            this.dataGridView1.DataSource = productName.ToList();
			dataGridView1.Columns[0].Width = 200;

			this.chart1.DataSource = productName.ToList();
            this.chart1.Series[0].XValueMember = "產品名稱";
			this.chart1.Series[0].YValueMembers = "庫存數量";
            this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
		}

		private void Btn_ListPrice_Click(object sender, EventArgs e)
		{
			var productName = from p in db.tProducts
							  group p by p.ProductName into g
							  orderby g.Sum(p => p.UnitPrice) descending
							  select new { 產品名稱 = g.Key, 建議售價 = g.Sum(p => p.UnitPrice) };
			this.dataGridView1.DataSource = productName.ToList();
			dataGridView1.Columns[0].Width = 200;
			this.dataGridView1.Columns["建議售價"].DefaultCellStyle.Format = "c0";

			this.chart1.DataSource = productName.ToList();
			this.chart1.Series[0].XValueMember = "產品名稱";
			this.chart1.Series[0].YValueMembers = "建議售價";
			this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
		}
	}
}
