using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 期中專案.付帳;

namespace 期中專案
{
	public partial class Frm消費紀錄 : Form
	{
		public Frm消費紀錄()
		{
			InitializeComponent();
			CusTransDetail();
			resetGridStyle();
		}

		SelectShopEntities db = new SelectShopEntities();

		private void CusTransDetail()
		{
			var q = (from m in db.tMembers
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
					 orderby o.OrderDate descending
					 select new
					 {
						 m.MemberID,
						 m.MemberName,
						 OrderDate = o.OrderDate,
						 OrderID = o == null ? "" : o.OrderID.ToString(),
						 ProductID = pu == null ? "" : pu.ProductID.ToString(),
						 ProductName = prod == null ? "" : prod.ProductName,
						 pu.Qty,
						 UnitPrice = prod.UnitPrice == null ? 0 : prod.UnitPrice,
						 Sum = pu.Qty * prod.UnitPrice,
						 //Package = pack.PackageWay == null ? "" : pack.PackageWay.ToString(),
						 PackageWay = pack.PackName,  //GiftPackageStyle.Cards.Select(x => x.CardID) != null ? pack.GiftPackageStyle.Cards.Select(x=>x.CardType) : (pack.GiftPackageStyle.Boxes.Select(y=>y.BoxID == null) ? pack.tPackageWayDetail.Bag.BagType : pack.tPackageWayDetail.Box.BoxType),
						 PackageMaterial = material.MaterialName,   // .tAllPackage. packageMaterial.MaterialName,
						 //PackageMaterial = (card.CardType != null) ? "(不適用)" : (box.BoxType == null ? bag.packageMaterial.MaterialName : box.packageMaterial.MaterialName),
						 //PackageMaterial = (o.tPackageWayDetail.tAllPackage.GiftPackageStyle.Cards.Count != 0) ? "(不適用)" : (o.tPackageWayDetail.tAllPackage.GiftPackageStyle.Boxes.Select(x=>x.MaterialID) == null ? o.tPackageWayDetail.tAllPackage.GiftPackageStyle.Bags.Select(x=>x.packageMaterial.MaterialName.ToString()) : o.tPackageWayDetail.tAllPackage.GiftPackageStyle.Boxes.Select(x => x.packageMaterial.MaterialName.ToString())),
						 PackagePrice = pack.Price,   //tPackageWayDetail.Card.CardID != 0 ? pack.tPackageWayDetail.Card.Price : (pack.tPackageWayDetail.Box.BoxID == 0 ? pack.tPackageWayDetail.Bag.Price : pack.tPackageWayDetail.Box.Price),
						 PackQty = packDet.PackQty,
						 o.tStatu.StatusName
					 });

			//var purchase = (from pu in db.tPurchases
			//				select new
			//				{
			//					pu.tOrder.MemberID,
			//					pu.tOrder.tMember.MemberName,
			//					pu.OrderID,
			//					pu.ProductID,
			//					pu.tProduct.ProductName,
			//					pu.Qty,
			//					pu.tProduct.UnitPrice,
			//					pu.tOrder.tStatu.StatusName
			//				})
			//				.GroupBy(o=>o.OrderID)
			//				.Select(o=>new {Sum = o.Sum(p=>p.UnitPrice)});

			this.dataGridView1.DataSource = q.ToList();
			//dataGridView1.DataSource = purchase.ToList();
			resetGridStyle();
		}

		private void resetGridStyle()
		{
			dataGridView1.Columns[0].HeaderText = "會員編號";
			dataGridView1.Columns[1].HeaderText = "會員姓名";
			dataGridView1.Columns[2].HeaderText = "訂購日期";
			dataGridView1.Columns[3].HeaderText = "訂單編號";
			dataGridView1.Columns[4].HeaderText = "產品編號";
			dataGridView1.Columns[5].HeaderText = "產品名稱";
			dataGridView1.Columns[6].HeaderText = "數量";
			dataGridView1.Columns[7].HeaderText = "單價";
			dataGridView1.Columns[8].HeaderText = "總金額";
			dataGridView1.Columns[9].HeaderText = "包裝方式";
			dataGridView1.Columns[10].HeaderText = "包裝材料";
			dataGridView1.Columns[11].HeaderText = "包裝價錢";
			dataGridView1.Columns[12].HeaderText = "包裝個數";
			dataGridView1.Columns[13].HeaderText = "訂單狀態";

			dataGridView1.Columns[0].Width = 100;
			dataGridView1.Columns[1].Width = 150;
			dataGridView1.Columns[2].Width = 220;
			dataGridView1.Columns[3].Width = 100;
			dataGridView1.Columns[4].Width = 100;
			dataGridView1.Columns[5].Width = 250;
			dataGridView1.Columns[7].Width = 150;
			dataGridView1.Columns[8].Width = 150;
			dataGridView1.Columns[9].Width = 150;

			this.dataGridView1.Columns["UnitPrice"].DefaultCellStyle.Format = "c0";
			this.dataGridView1.Columns["Sum"].DefaultCellStyle.Format = "c0";
			this.dataGridView1.Columns["PackagePrice"].DefaultCellStyle.Format = "c0";
			this.dataGridView1.Columns["OrderDate"].DefaultCellStyle.Format = "yyyy/MM/dd/ HH:mm:ss";

			bool isColorChanged = false;
			foreach (DataGridViewRow r in dataGridView1.Rows)
			{
				isColorChanged = !isColorChanged;
				r.DefaultCellStyle.BackColor = Color.FromArgb(229, 229, 229);
				if (isColorChanged)
				{
					r.DefaultCellStyle.BackColor = Color.White;
				}
				r.DefaultCellStyle.Font = new Font("微軟正黑體", 12);
			}
		}

		private void Frm消費紀錄_Load(object sender, EventArgs e)
		{
			resetGridStyle();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			CusTransDetail();
			resetGridStyle();
			string keyword = textBox1.Text;
			foreach (DataGridViewRow r in dataGridView1.Rows)
			{
				//r.DefaultCellStyle.BackColor = Color.White;
				bool isColor = false;

				foreach (DataGridViewCell c in r.Cells)
				{
					if (c.Value == null)
						continue;
					if (c.Value.ToString().ToLower().Contains(textBox1.Text))
					{
						r.DefaultCellStyle.BackColor = Color.Yellow;
						isColor = true;
						break;
					}
				}
			}
		}

		private void 消費紀錄圖表_Click(object sender, EventArgs e)
		{
			Frm消費紀錄圖表 chart = new Frm消費紀錄圖表();
			chart.Show();
		}

		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			int MemberID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["MemberID"].FormattedValue);
			SelectShopEntities db = new SelectShopEntities();
			tMember member = db.tMembers.FirstOrDefault(x => x.MemberID == MemberID);
			if (member != null)
			{
				//MessageBox.Show(member.MemberName);
				Credit_Card f = new Credit_Card();
				f.member = member;

				f.ShowDialog();

				if (f.isOk == DialogResult.OK)
				{
					CusTransDetail();
					resetGridStyle();
				}
			}
		}
	}
}
