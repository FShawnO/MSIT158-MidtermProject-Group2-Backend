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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace 後台
{
    public partial class Frm產品明細 : Form
    {
        public Frm產品明細()
        {
            InitializeComponent();
            //label3.Text = 產品管理.Text.Substring(0, 4) + "列表";
            //button1.Text = 產品管理.Text.Substring(0, 2) + "搜尋";
            detail();
            resetGridStyle();
        }

        private void detail() 
        {
            SelectShopEntities db = new SelectShopEntities();
            var products = from p in db.tProducts
                           join s in db.tLabels on p.LabelID equals s.LabelID into ps
						   from s in ps.DefaultIfEmpty()
						   join c in db.tSubCategories on p.SubCategoryID equals c.SubCategoryID
                           join a in db.tActives on p.ActiveID equals a.ActiveID into pa
						   from a in pa.DefaultIfEmpty()
						   select new {p.ProductID, p.ProductName, p.ProductPhoto,p.UnitPrice, p.Stocks, s.LabelName, c.SubCategoryName, a.ActiveName};
            dataGridView1.DataSource = products.ToList();
            resetGridStyle();
        }

		//與 detail 相同
		//private void queryall()
		//{
		//    SelectShopEntities db = new SelectShopEntities();
		//    var products = from p in db.tProduct
		//                   select p;
		//    dataGridView1.DataSource = products.ToList();
		//    resetGridStyle();
		//}
		private void resetGridStyle()
        {
            dataGridView1.Columns[0].HeaderText = "商品編號";
            dataGridView1.Columns[1].HeaderText = "商品名稱";
            dataGridView1.Columns[2].HeaderText = "商品照片";
            dataGridView1.Columns[3].HeaderText = "產品單價";
            //dataGridView1.Columns[4].HeaderText = "單位成本";
            dataGridView1.Columns[4].HeaderText = "庫存數量";
            dataGridView1.Columns[5].HeaderText = "供應商名稱";
            dataGridView1.Columns[6].HeaderText = "產品分類名稱";
            dataGridView1.Columns[7].HeaderText = "活動名稱";
           

            dataGridView1.Columns[1].Width = 350;
			dataGridView1.Columns[3].Width = 200;
			dataGridView1.Columns[5].Width = 200;
            dataGridView1.Columns[6].Width = 350;
            dataGridView1.Columns[7].Width = 280;

			this.dataGridView1.Columns["UnitPrice"].DefaultCellStyle.Format = "c0";

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

        private void label1_Click(object sender, EventArgs e)
        {
            Frm新增商品 p = new Frm新增商品();
            p.ShowDialog();

            if (p.isOK != DialogResult.OK)
                return;
            //tProduct x = p.product;

            //SelectShopEntities demo = new SelectShopEntities();
            //demo.tProducts.Add(x);
            //demo.SaveChanges();


            //queryall();
            detail();
			resetGridStyle();
 
        }

        private void 產品刪除_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
                return;

            DataGridViewRow r = dataGridView1.SelectedRows[0];
            if (r.Cells.Count <= 0)
                return;
            DataGridViewCell c = r.Cells[0];
            int id = (int)c.Value;

            SelectShopEntities db = new SelectShopEntities();
            tProduct product = db.tProducts.FirstOrDefault(x => x.ProductID == id);
            if (product == null)
                return;
            db.tProducts.Remove(product);
            db.SaveChanges();

            //queryall();
			detail();
			resetGridStyle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            detail();
            resetGridStyle();

            //bool isColorChange = false;
            // foreach (DataGridViewRow r in dataGridView1.Rows)
            //{
            //    isColorChange = !isColorChange;
            //    r.DefaultCellStyle.BackColor = Color.FromArgb(229, 229, 229);
            //    if (isColorChange)
            //        r.DefaultCellStyle.BackColor = Color.White;
            //    r.DefaultCellStyle.Font = new Font("微軟正黑體", 12);
            //}
            bool isColorChange = false;
            string keyword = textBox1.Text;
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                //r.DefaultCellStyle.BackColor = Color.White;
                isColorChange = !isColorChange;
                r.DefaultCellStyle.BackColor = Color.FromArgb(229, 229, 229);
                if (isColorChange)
                    r.DefaultCellStyle.BackColor = Color.White;
                r.DefaultCellStyle.Font = new Font("微軟正黑體", 12);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Frm產品明細_Activated(object sender, EventArgs e)
        {
            
        }

        private void Frm產品明細_Load(object sender, EventArgs e)
        {
           resetGridStyle();
        }

        private void 產品個別detail_Click(object sender, EventArgs e)
        {
            Frm產品圖表 chart = new Frm產品圖表();
            chart.Show();
        }

		private void 產品編輯_Click(object sender, EventArgs e)
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
			tProduct product = db.tProducts.FirstOrDefault(x => x.ProductID == id);
			if (product == null)
				return;

			/// 檢查是否已經打開了 Frm新增商品 窗口
			Frm新增商品 p = new Frm新增商品();
			p.product = product;
			p.ShowDialog();

			if (p.isOK != DialogResult.OK)
				return;
			//後面的product是全域變數
			product.ProductName = p.product.ProductName;
			product.Stocks = p.product.Stocks;
			product.LabelID = p.product.LabelID;
			product.SubCategoryID = p.product.SubCategoryID;
			product.ProductPhoto = p.product.ProductPhoto;
			product.UnitPrice = p.product.UnitPrice;
			product.Description = p.product.Description;
			product.ActiveID = p.product.ActiveID;
			//product.PackageID = p.product.PackageID;
			product.LaunchTime = p.product.LaunchTime;
			product.Cost = p.product.Cost;
			product.tSubCategory.CategoryID = p.product.tSubCategory.CategoryID;

			db.SaveChanges();
			//queryall();
			detail();
		}

		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			int dataColumnNo = dataGridView1.Rows[e.ColumnIndex].Index;

			if (dataColumnNo == 2)
            {
				int ProductID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ProductID"].FormattedValue);
				SelectShopEntities db = new SelectShopEntities();
				tProduct product = db.tProducts.FirstOrDefault(x => x.ProductID == ProductID);
                if (product != null)
                {
                    if (product.ProductPhoto != null)
                    {
                        byte[] bytes = (byte[])(product.ProductPhoto);
                        MemoryStream ms = new MemoryStream(bytes);

                        Frm產品圖片 f = new Frm產品圖片();
                        f.BackgroundImage = Image.FromStream(ms);
                        f.BackgroundImageLayout = ImageLayout.Zoom;

                        f.Show();
                    } else {
						MessageBox.Show("尚未上傳圖片！");
					}
                }
			}
		}
	}
}
