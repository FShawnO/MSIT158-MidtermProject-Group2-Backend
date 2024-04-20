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

namespace 後台
{
	public partial class Frm行銷活動 : Form
	{
		public Frm行銷活動()
		{
			InitializeComponent();
			detail();
			resetGridStyle();
		}

		private void detail()
		{
			SelectShopEntities db = new SelectShopEntities();
			var tActives = from a in db.tActives
						   select a;
			dataGridView1.DataSource = tActives.ToList();
			resetGridStyle();
		}

		private void resetGridStyle()
		{
			dataGridView1.Columns[0].HeaderText = "活動編號";
			dataGridView1.Columns[1].HeaderText = "活動名稱";
			dataGridView1.Columns[2].HeaderText = "活動起始日期";
			dataGridView1.Columns[3].HeaderText = "活動結束日期";
			dataGridView1.Columns[4].HeaderText = "折扣";
			dataGridView1.Columns[5].HeaderText = "活動說明";
			dataGridView1.Columns[6].HeaderText = "活動圖片";

			dataGridView1.Columns[1].Width = 250;
			dataGridView1.Columns[2].Width = 200;
			dataGridView1.Columns[3].Width = 200;
			dataGridView1.Columns[5].Width = 600;

			bool isColorChange = false;
			foreach (DataGridViewRow r in dataGridView1.Rows)
			{
				isColorChange = !isColorChange;
				r.DefaultCellStyle.BackColor = Color.FromArgb(229, 229, 229);
				if (isColorChange)
					r.DefaultCellStyle.BackColor = Color.White;
				r.DefaultCellStyle.Font = new Font("微軟正黑體", 12);
			}



		}

		private void 活動新增_Click(object sender, EventArgs e)
		{
			Frm新增行銷活動 a = new Frm新增行銷活動();
			a.ShowDialog();

			if (a.isOK != DialogResult.OK)
				return;
			tActive x = a.active;

			SelectShopEntities db = new SelectShopEntities();
			db.tActives.Add(x);
			db.SaveChanges();


			detail();
			resetGridStyle();
		}

		private void 活動刪除_Click(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count <= 0)
				return;

			DataGridViewRow r = dataGridView1.SelectedRows[0];
			if (r.Cells.Count <= 0)
				return;
			DataGridViewCell c = r.Cells[0];
			int id = (int)c.Value;

			SelectShopEntities db = new SelectShopEntities();
			tActive active = db.tActives.FirstOrDefault(x => x.ActiveID == id);
			if (active == null)
				return;
			db.tActives.Remove(active);
			db.SaveChanges();

			detail();
			resetGridStyle();
		}

		private void 活動編輯_Click(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedCells.Count > 0)
			{
				int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
				int id = (int)dataGridView1.Rows[rowIndex].Cells[0].Value;
				editById(id);
			}
		}

		private void editById(int id)
		{
			SelectShopEntities db = new SelectShopEntities();
			tActive active = db.tActives.FirstOrDefault(x => x.ActiveID == id);
			if (active == null)
				return;

			/// 檢查是否已經打開了 Frm新增商品 窗口
			Frm新增行銷活動 a = new Frm新增行銷活動();
			a.active = active;
			a.ShowDialog();

			if (a.isOK != DialogResult.OK)
				return;
			//後面的product是全域變數
			active.ActiveName = a.active.ActiveName;
			active.Discount = a.active.Discount;
			active.StartDate = a.active.StartDate;
			active.EndDate = a.active.EndDate;
			active.Description = a.active.Description;
			active.ActiveImage = a.active.ActiveImage;

			db.SaveChanges();
			detail();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			detail();
			resetGridStyle();

			string keyword = textBox1.Text;
			foreach (DataGridViewRow r in dataGridView1.Rows)
			{
				r.DefaultCellStyle.BackColor = Color.White;
				bool isColor = false;

				foreach (DataGridViewCell c in r.Cells)
				{
					if (c.Value == null)
						continue;
					//if (c.Value.ToString().IndexOf(textBox1.Text, StringComparison.InvariantCultureIgnoreCase) >= 0)
					if (c.Value.ToString().ToUpper().Contains(keyword.ToUpper()))
					{

						r.DefaultCellStyle.BackColor = Color.Yellow;
						//c.Style.BackColor = Color.Yellow;
						isColor = true;
						break;
					}

				}

			}

		}

		private void 活動detail_Click(object sender, EventArgs e)
		{
			Frm活動圖表 chart = new Frm活動圖表();
			chart.Show();
		}

		private void Frm行銷活動_Load(object sender, EventArgs e)
		{
			resetGridStyle();
		}

		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			int dataColumnNo = dataGridView1.Columns[e.ColumnIndex].Index;
			if (dataColumnNo == 6)
			{
				int ActiveID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ActiveID"].FormattedValue);
				SelectShopEntities db = new SelectShopEntities();
				tActive active = db.tActives.FirstOrDefault(x => x.ActiveID == ActiveID);
				if (active != null)
				{
					if (active.ActiveImage != null)
					{
						byte[] bytes = (byte[])(active.ActiveImage);
						MemoryStream ms = new MemoryStream(bytes);

						Frm活動圖片 f = new Frm活動圖片();
						f.BackgroundImage = Image.FromStream(ms);
						f.BackgroundImageLayout = ImageLayout.Zoom;

						f.Show();
					} else
					{
						MessageBox.Show("尚未上傳圖片！");
					}
				}
			}
		}
	}


}
