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
	public partial class Frm活動圖表 : Form
	{
		public Frm活動圖表()
		{
			InitializeComponent();
		}
		        SelectShopEntities db = new SelectShopEntities();

        private void button1_Click(object sender, EventArgs e)
        {
			var ActiveName = from p in db.tProducts
							  join a in db.tActives
							  on p.ActiveID equals a.ActiveID into ps from a in ps.DefaultIfEmpty()
							  group p by a.ActiveName into g
							  select new { ActiveName = g.Key, 庫存數量 = g.Sum(p => p.Stocks) };
			this.dataGridView1.DataSource = ActiveName.ToList();
			dataGridView1.Columns[0].Width = 200;

			this.chart1.DataSource = ActiveName.ToList();
			this.chart1.Series[0].XValueMember = "ActiveName";
			this.chart1.Series[0].YValueMembers = "庫存數量";
			this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
		}

		private void Btn_ListPrice_Click(object sender, EventArgs e)
		{
			var ActiveName = from p in db.tProducts
							 join a in db.tActives
							 on p.ActiveID equals a.ActiveID into ps
							 from a in ps.DefaultIfEmpty()
							 group p by a.ActiveName into g
							 select new { ActiveName = g.Key, 營業額 = g.Sum(p => p.UnitPrice) };
			this.dataGridView1.DataSource = ActiveName.ToList();
			dataGridView1.Columns[0].Width = 200;

			this.chart1.DataSource = ActiveName.ToList();
			this.chart1.Series[0].XValueMember = "ActiveName";
			this.chart1.Series[0].YValueMembers = "營業額";
			this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
		}
	}
}
