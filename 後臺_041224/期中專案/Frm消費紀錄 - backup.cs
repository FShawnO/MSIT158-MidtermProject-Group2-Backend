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

		private void CusTransDetail()
		{


			SelectShopEntities db = new SelectShopEntities();
			var member = (from m in db.tMembers
						  join o in db.tOrders
						  on m.MemberID equals o.MemberID into mo from o in mo.DefaultIfEmpty()
						  join pu in db.tPurchases
						  on o.OrderID equals pu.OrderID into op from pu in op.DefaultIfEmpty()
						  join prod in db.tProducts
						  on pu.ProductID equals prod.ProductID into pp from prod in pp.DefaultIfEmpty()
						  orderby o.OrderDate descending
						  select new
						  {
							  m.MemberID,
							  m.MemberName,
							  OrderID = o == null ? 0 : o.OrderID,
							  ProductID = pu == null ? 0 : pu.ProductID,
							  ProductName = prod == null ? "" : prod.ProductName,
							  pu.Qty,
							  UnitPrice = prod.UnitPrice == null ? 0 : (int)prod.UnitPrice,
							  o.tStatu.StatusName
						  });

			var purchase = (from pu in db.tPurchases
							select new
							{
								pu.tOrder.MemberID,
								pu.tOrder.tMember.MemberName,
								pu.OrderID,
								pu.ProductID,
								pu.tProduct.ProductName,
								pu.Qty,
								pu.tProduct.UnitPrice,
								pu.tOrder.tStatu.StatusName
							});

			//dataGridView1.DataSource = member.ToList();
			dataGridView1.DataSource = purchase.ToList();
		}

		private void Frm消費紀錄_Load(object sender, EventArgs e)
		{
			resetGridStyle();
		}

		private void resetGridStyle()
		{
			dataGridView1.Columns[0].HeaderText = "會員編號";
			dataGridView1.Columns[1].HeaderText = "會員姓名";
			dataGridView1.Columns[2].HeaderText = "訂單編號";
			dataGridView1.Columns[3].HeaderText = "產品編號";
			dataGridView1.Columns[4].HeaderText = "產品名稱";
			dataGridView1.Columns[5].HeaderText = "產品數量";
			dataGridView1.Columns[6].HeaderText = "產品單價";
			dataGridView1.Columns[7].HeaderText = "訂單狀態";
			//dataGridView1.Columns[8].HeaderText = "到職日";
			//dataGridView1.Columns[9].HeaderText = "部門ID";
			//dataGridView1.Columns[10].HeaderText = "部門名稱";
			
			dataGridView1.Columns[0].Width = 100;
			dataGridView1.Columns[1].Width = 200;
			dataGridView1.Columns[2].Width = 100;
			dataGridView1.Columns[3].Width = 100;
			dataGridView1.Columns[4].Width = 200;
			dataGridView1.Columns[5].Width = 100;
			dataGridView1.Columns[6].Width = 120;
			dataGridView1.Columns[7].Width = 100;
			//dataGridView1.Columns[8].Width = 100;
			//dataGridView1.Columns[9].Width = 100;
			//dataGridView1.Columns[10].Width = 100;
			
			bool isColorChanged = false;
			foreach (DataGridViewRow r in dataGridView1.Rows)
			{
				isColorChanged = !isColorChanged;
				r.DefaultCellStyle.BackColor = Color.FromArgb(229, 229, 229);
				if (isColorChanged)
					r.DefaultCellStyle.BackColor = Color.White;
				r.DefaultCellStyle.Font = new Font("微軟正黑體", 12);
			
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			CusTransDetail();
			resetGridStyle();

			//string keyword = textBox1.Text;
			foreach (DataGridViewRow r in dataGridView1.Rows)
			{

				bool isColor = false;

				foreach (DataGridViewCell c in r.Cells)
				{
					if (c.Value == null)
						continue;
					//if (c.Value.ToString().IndexOf(textBox1.Text, StringComparison.InvariantCultureIgnoreCase) >= 0)
					if (c.Value.ToString().ToLower().Contains(textBox1.Text))
					{
						r.DefaultCellStyle.BackColor = Color.Yellow;
						//c.Style.BackColor = Color.Yellow;
						isColor = true;
						break;
					}

				}
				if (!isColor)
				{
					foreach (DataGridViewCell c in r.Cells)
					{ c.Style.BackColor = DefaultBackColor; }
				}
			}
		}

		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			int MemberID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["MemberID"].FormattedValue);
			//MessageBox.Show(MemberID.ToString());
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
