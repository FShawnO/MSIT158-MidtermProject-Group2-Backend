using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace 期中專案
{
    public partial class Frm消費紀錄圖表 : Form
    {
        public Frm消費紀錄圖表()
        {
            InitializeComponent();
        }

        SelectShopEntities db = new SelectShopEntities();

        private void button1_Click(object sender, EventArgs e)
        {
            var sheets = (from m in db.tMembers
					 join o in db.tOrders
					 on m.MemberID equals o.MemberID into mo
					 from o in mo.DefaultIfEmpty()
					 join pu in db.tPurchases
					 on o.OrderID equals pu.OrderID into op
					 from pu in op.DefaultIfEmpty()
					 join prod in db.tProducts
					 on pu.ProductID equals prod.ProductID //into pp
														   //from prod in pp.DefaultIfEmpty()
					 join packDet in db.tPackageWayDetails
					 on o.OrderID equals packDet.OrderID //into opd
														 //from packDet in opd.DefaultIfEmpty()
					 join pack in db.tAllPackages
					 on packDet.PackageID equals pack.PackageID //into pa
																//from pack in pa.DefaultIfEmpty()
					 join style in db.GiftPackageStyles
					 on pack.PackageStyleID equals style.PStlyeID
					 //join box in db.Boxes
					 //on style.PStlyeID equals box.PStlyeID into pbo
					 //from box in pbo.DefaultIfEmpty()
					 //join bag in db.Bags
					 //on style.PStlyeID equals bag.PStlyeID into pba
					 //from bag in pbo.DefaultIfEmpty()
					 //join card in db.Cards
					 //on style.PStlyeID equals card.PStlyeID into sc
					 //from card in sc.DefaultIfEmpty()
					 join material in db.packageMaterials
					 on pack.MaterialID equals material.MaterialID
					 //orderby o.OrderDate descending
					 select new
                          {
                              m.MemberID,
                              m.MemberName,
                              OrderDate = o.OrderDate.ToString(),
                              OrderID = o == null ? "" : o.OrderID.ToString(),
                              ProductID = pu == null ? "" : pu.ProductID.ToString(),
                              ProductName = prod == null ? "" : prod.ProductName,
                              pu.Qty,
                              UnitPrice = prod.UnitPrice == null ? "" : prod.UnitPrice.ToString(),
                              Total = pu.Qty * prod.UnitPrice,
							  PackageWay = pack.PackName, 
                              //Package = pack.PackageWay == null ? "" : pack.PackageWay.ToString(),
                              o.tStatu.StatusName
                          });

            var memberTotals = sheets.GroupBy(s => new { s.MemberID, s.MemberName })  ////s.OrderDate, 
                              .Select(g => new
                              {
                                  會員編號 = g.Key.MemberID,
                                  //訂購日期 = g.Key.OrderDate,
                                  會員姓名 = g.Key.MemberName,
                                  總購買產品數量 = g.Sum(s=>s.Qty),
                                  總金額 = g.Sum(s => s.Total)
                              });

            dataGridView1.DataSource = memberTotals.ToList();
            this.chart1.Legends.Clear();
            this.chart1.DataSource = memberTotals.ToList();
            this.chart1.Series[0].XValueMember = "會員編號";
            this.chart1.Series[0].YValueMembers = "總金額";
            this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
        }

		private void Btn_PackageWayPie_Click(object sender, EventArgs e)
		{
			var boxNoList = (from o in db.tPackageWayDetails
						  join pack in db.tAllPackages
							on o.PackageID equals pack.PackageID

						  join style in db.GiftPackageStyles
							on pack.PackageStyleID equals style.PStlyeID
						  join box in db.Boxes
							on style.PStlyeID equals box.PStlyeID //into pbo
			//			  from box in pbo.DefaultIfEmpty()
			//			  join bag in db.Bags
			//				on style.PStlyeID equals bag.PStlyeID into pba
			//		   	  from bag in pbo.DefaultIfEmpty()
			//			  join card in db.Cards
			//				on style.PStlyeID equals card.PStlyeID into sc
			//			  from card in sc.DefaultIfEmpty()
						  select new
						  { PackageStyleID = pack.PackageID, o.OrderID, o.PackQty }).Distinct();   //.Count();
						  //{ PackageStyleID = pack.PackageID }).Distinct().Count();
			//{ PackageStyleID = pack.PackageID }).Distinct().Count();
			//
			//
			//var boxNo_test = db.tPackageWayDetails.Join(tAllPackage, p => p. 

			//var boxNo = db.tPackageWayDetails.Select(o => o.tAllPackage.GiftPackageStyle.Boxes.Select(x => x.BoxID / (x.BoxID == 0 ? 1 : x.BoxID)).Sum()).ToList();
			//var bagNo = db.tPackageWayDetails.Select(o => o.tAllPackage.GiftPackageStyle.Bags.Select(x => x.BagID / (x.BagID == 0 ? 1 : x.BagID)).Sum()).ToList();
			//var cardNo = db.tPackageWayDetails.Select(o => o.tAllPackage.GiftPackageStyle.Cards.Select(x => x.CardID / (x.CardID == 0 ? 1 : x.CardID)).Sum()).ToList();

			int boxNo = (int)boxNoList.Sum(o => o.PackQty);
			//dataGridView1.DataSource = boxNoList.ToList();
			var bagNoList = (from o in db.tPackageWayDetails
							 join pack in db.tAllPackages
							   on o.PackageID equals pack.PackageID

							 join style in db.GiftPackageStyles
							   on pack.PackageStyleID equals style.PStlyeID
							 join bag in db.Bags
							   on style.PStlyeID equals bag.PStlyeID //into pbo
																	 //			  from box in pbo.DefaultIfEmpty()
																	 //			  join bag in db.Bags
																	 //				on style.PStlyeID equals bag.PStlyeID into pba
																	 //		   	  from bag in pbo.DefaultIfEmpty()
																	 //			  join card in db.Cards
																	 //				on style.PStlyeID equals card.PStlyeID into sc
																	 //			  from card in sc.DefaultIfEmpty()
							 select new
							 { PackageStyleID = pack.PackageID, o.OrderID, o.PackQty }).Distinct();   //.Count();
			int bagNo = (int)bagNoList.Sum(o => o.PackQty);
			//dataGridView1.DataSource = bagNoList.ToList();
			var cardNoList = (from o in db.tPackageWayDetails
						  join pack in db.tAllPackages
							on o.PackageID equals pack.PackageID

						  join style in db.GiftPackageStyles
							on pack.PackageStyleID equals style.PStlyeID
						  join card in db.Cards
							on style.PStlyeID equals card.PStlyeID //into pbo
																   //			  from box in pbo.DefaultIfEmpty()
																   //			  join bag in db.Bags
																   //				on style.PStlyeID equals bag.PStlyeID into pba
																   //		   	  from bag in pbo.DefaultIfEmpty()
																   //			  join card in db.Cards
																   //				on style.PStlyeID equals card.PStlyeID into sc
																   //			  from card in sc.DefaultIfEmpty()
						  select new
						  { PackageStyleID = pack.PackageID, o.OrderID, o.PackQty }).Distinct(); //.Count();
			int cardNo = (int)cardNoList.Sum(o => o.PackQty);
			//dataGridView1.DataSource = cardNoList.ToList();
			chart1.Series.Clear();
			chart1.Legends.Clear();
            dataGridView1.DataSource = null;

			//Add a new Legend(if needed) and do some formating
			chart1.Legends.Add("");
			chart1.Legends[0].LegendStyle = LegendStyle.Table;
			chart1.Legends[0].Docking = Docking.Bottom;
			chart1.Legends[0].Alignment = StringAlignment.Center;
			chart1.Legends[0].Title = "不同包裝方式比例";
			chart1.Legends[0].BorderColor = Color.Black;

			//Add a new chart-series
			string seriesname = "MySeriesName";
			chart1.Series.Add(seriesname);
			//set the chart-type to "Pie"
			chart1.Series[seriesname].ChartType = SeriesChartType.Pie;

			//Add some datapoints so the series. in this case you can pass the values to this method
			chart1.Series[seriesname].Points.AddXY("包裝盒包裝", boxNo);
			chart1.Series[seriesname].Points.AddXY("手提袋", bagNo);
			chart1.Series[seriesname].Points.AddXY("卡片", cardNo);
		}
	}
}
