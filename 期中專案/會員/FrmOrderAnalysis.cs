using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace 後台.會員
{
    public partial class FrmOrderAnalysis : Form
    {
        public FrmOrderAnalysis()
        {
            InitializeComponent();
        }
        SelectShopEntities db = new SelectShopEntities();
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var orders = from r in db.tPurchases
                         //orderby r.tOrder.tMember.MemberID
                         select new
                         {
                             r.PurchaseID,
                             r.tOrder.OrderID,
                             r.tOrder.MemberID,
                             r.tOrder.tMember.MemberName,
                             r.tProduct.ProductID,
                             r.tProduct.ProductName,
                             r.tProduct.UnitPrice,
                             r.Qty,

							 //r.tOrder.tPackageWayDetail.tAllPackage.PackageID, ID出問題
							 PackName = r.tOrder.tPackageWayDetails.Select(x => x.tAllPackage.PackName),
							 Picture = r.tOrder.tPackageWayDetails.Select(x => x.tAllPackage.Picture),
							 //r.tOrder.tPackageWayDetail.tAllPackage.packageMaterial.MaterialID, ID出問題
							 MaterialName = r.tOrder.tPackageWayDetails.Select(x => x.tAllPackage.packageMaterial.MaterialName),
							 //r.tOrder.tPackageWayDetail.tAllPackage.packageMaterial.Picture, Picture不能重複使用(C#語法)
							 ColorName = r.tOrder.tPackageWayDetails.Select(x => x.tAllPackage.packageMaterial.MaterialColor.ColorName),
							 RGB = r.tOrder.tPackageWayDetails.Select(x => x.tAllPackage.packageMaterial.MaterialColor.RGB),
							 StyleName = r.tOrder.tPackageWayDetails.Select(x => x.tAllPackage.GiftPackageStyle.StyleName),
							 //r.tOrder.tPackageWayDetail.tAllPackage.GiftPackageStyle.Picture, Picture不能重複使用(C#語法)
							 Price = r.tOrder.tPackageWayDetails.Select(x => x.tAllPackage.Price),
							 PackQty = r.tOrder.tPackageWayDetails.Select(x => x.PackQty),
							 r.tOrder.tStatu.StatusName,
                             Total = r.tProduct.UnitPrice * r.Qty
                         };

            var qtys = orders.GroupBy(p => new { p.MemberID, p.MemberName })
                .OrderBy(g=>g.Key.MemberID)
                .Select(q => new
                {
                    會員編號 = q.Key.MemberID,
                    會員姓名 = q.Key.MemberName,
                    總購買產品數量 = q.Sum(s => s.Qty),  // 計算每個會員的總購買產品數量
                    總金額 = q.Sum(s => s.Total)  // 計算每個會員的總金額}
                });

            this.dataGridView1.DataSource = qtys.ToList();
                        
            this.chart1.DataSource = qtys.ToList();
            this.chart1.Series[0].XValueMember = "會員姓名";
            this.chart1.Series[0].YValueMembers = "總購買產品數量";
            this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            this.chart2.DataSource = qtys.ToList();
            this.chart2.Series[0].XValueMember = "會員姓名";
            this.chart2.Series[0].YValueMembers = "總金額";
            this.chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var orders = from r in db.tPurchases
                         select new
                         {
                             r.PurchaseID,
                             r.tOrder.OrderID,
                             r.tOrder.MemberID,
                             r.tOrder.tMember.MemberName,
                             r.tProduct.ProductID,
                             r.tProduct.ProductName,
                             r.tProduct.UnitPrice,
                             r.Qty,

							 //r.tOrder.tPackageWayDetail.tAllPackage.PackageID, ID出問題
							 PackName = r.tOrder.tPackageWayDetails.Select(x => x.tAllPackage.PackName),
							 Picture = r.tOrder.tPackageWayDetails.Select(x => x.tAllPackage.Picture),
							 //r.tOrder.tPackageWayDetail.tAllPackage.packageMaterial.MaterialID, ID出問題
							 MaterialName = r.tOrder.tPackageWayDetails.Select(x => x.tAllPackage.packageMaterial.MaterialName),
							 //r.tOrder.tPackageWayDetail.tAllPackage.packageMaterial.Picture, Picture不能重複使用(C#語法)
							 ColorName = r.tOrder.tPackageWayDetails.Select(x => x.tAllPackage.packageMaterial.MaterialColor.ColorName),
							 RGB = r.tOrder.tPackageWayDetails.Select(x => x.tAllPackage.packageMaterial.MaterialColor.RGB),
							 StyleName = r.tOrder.tPackageWayDetails.Select(x => x.tAllPackage.GiftPackageStyle.StyleName).ToList(),
							 //r.tOrder.tPackageWayDetail.tAllPackage.GiftPackageStyle.Picture, Picture不能重複使用(C#語法)
							 Price = r.tOrder.tPackageWayDetails.Select(x => x.tAllPackage.Price),
							 PackQty = r.tOrder.tPackageWayDetails.Select(x => ((long)x.PackQty.Value)),
							 r.tOrder.tStatu.StatusName,
							 PriceDummy = r.tOrder.tPackageWayDetails.Select(x=>x.tAllPackage.Price), // * y=>y.   //* (dValue) => dValue.PackQty)
                             PackQtyDummy = r.tOrder.tPackageWayDetails.Select(y=>y.PackQty)
						 };

            //var qtys = orders.GroupBy(p => new {  p.StyleName })
            //    .OrderBy(g => g.Key.StyleName)
            //    .Select(q => new
            //    {
            //        //包裝編號 = q.Key.PStlyeID,
            //        包裝名稱 = q.Key.StyleName,
            //        包裝數量 = q.Sum(s => (Convert.ToDecimal(s.PackQty))),  // 計算每個會員的總購買產品數量
            //        包裝總金額 = q.Sum(s => (Convert.ToDecimal(s.Price))* Convert.ToDecimal(s.PackQtyDummy))  // 計算每個會員的總金額}
            //    });
            //
            //this.dataGridView1.DataSource = qtys.ToList();

            chart1.Legends.Clear();
            chart1.Legends.Add("");
            chart1.Legends[0].LegendStyle = LegendStyle.Table;
            chart1.Legends[0].Docking = Docking.Right;
            chart1.Legends[0].Alignment = StringAlignment.Center;
            chart1.Legends[0].Title = "不同包裝方式比例";
            chart1.Legends[0].BorderColor = Color.Black;

            //this.chart1.DataSource = qtys.ToList();
            //this.chart1.Series[0].XValueMember = "包裝名稱";
            //this.chart1.Series[0].YValueMembers = "包裝數量";
            //this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            //this.chart2.DataSource = qtys.ToList();
            //this.chart2.Series[0].XValueMember = "包裝名稱";
            //this.chart2.Series[0].YValueMembers = "包裝總金額";
            //this.chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var orders = from r in db.tPurchases
                         select new
                         {
                             r.PurchaseID,
                             r.tOrder.OrderID,
                             r.tOrder.MemberID,
                             r.tOrder.tMember.MemberName,
                             r.tProduct.ProductID,
                             r.tProduct.ProductName,
                             r.tProduct.UnitPrice,
                             r.Qty,

							 //r.tOrder.tPackageWayDetail.tAllPackage.PackageID, ID出問題
							 PackName = r.tOrder.tPackageWayDetails.Select(x => x.tAllPackage.PackName),
							 Picture = r.tOrder.tPackageWayDetails.Select(x => x.tAllPackage.Picture),
							 //r.tOrder.tPackageWayDetail.tAllPackage.packageMaterial.MaterialID, ID出問題
							 MaterialName = r.tOrder.tPackageWayDetails.Select(x => x.tAllPackage.packageMaterial.MaterialName),
							 //r.tOrder.tPackageWayDetail.tAllPackage.packageMaterial.Picture, Picture不能重複使用(C#語法)
							 ColorName = r.tOrder.tPackageWayDetails.Select(x => x.tAllPackage.packageMaterial.MaterialColor.ColorName),
							 RGB = r.tOrder.tPackageWayDetails.Select(x => x.tAllPackage.packageMaterial.MaterialColor.RGB),
							 StyleName = r.tOrder.tPackageWayDetails.Select(x => x.tAllPackage.GiftPackageStyle.StyleName),
							 //r.tOrder.tPackageWayDetail.tAllPackage.GiftPackageStyle.Picture, Picture不能重複使用(C#語法)
							 Price = r.tOrder.tPackageWayDetails.Select(x => x.tAllPackage.Price),
							 PackQty = r.tOrder.tPackageWayDetails.Select(x => x.PackQty),
							 r.tOrder.tStatu.StatusName,
                             Total = r.tProduct.UnitPrice * r.Qty
                         };

            var qtys = orders.GroupBy(p => new { p.ProductID, p.ProductName })
                .OrderBy(g => g.Key.ProductID)
                .Select(q => new
                {
                    產品編號 = q.Key.ProductID,
                    產品名稱 = q.Key.ProductName,
                    總購買產品數量 = q.Sum(s => s.Qty),  // 計算每個會員的總購買產品數量
                    總金額 = q.Sum(s => s.Total)  // 計算每個會員的總金額}
                });

            this.dataGridView1.DataSource = qtys.ToList();

            this.chart1.DataSource = qtys.ToList();
            this.chart1.Series[0].XValueMember = "產品名稱";
            this.chart1.Series[0].YValueMembers = "總購買產品數量";
            this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            this.chart2.DataSource = qtys.ToList();
            this.chart2.Series[0].XValueMember = "產品名稱";
            this.chart2.Series[0].YValueMembers = "總金額";
            this.chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
        }
    }
}
