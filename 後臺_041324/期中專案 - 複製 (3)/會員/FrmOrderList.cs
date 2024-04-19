using 期中專案.付帳;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 期中專案.會員
{
    public partial class FrmOrderList : Form
    {
        public FrmOrderList()
        {
            InitializeComponent();

            queryAll();
        }

        private void FrmOrderList_Load(object sender, EventArgs e)
        {
            //queryAll();

            resetGridStyle();
        }

        private void queryAll()
        {
            try
            {
                SelectShopEntities db = new SelectShopEntities();
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
								 PackName = r.tOrder.tPackageWayDetails.Select(x=>x.tAllPackage.PackName),
								 Picture = r.tOrder.tPackageWayDetails.Select(x=>x.tAllPackage.Picture),
								 //r.tOrder.tPackageWayDetail.tAllPackage.packageMaterial.MaterialID, ID出問題
								 MaterialName = r.tOrder.tPackageWayDetails.Select(x => x.tAllPackage.packageMaterial.MaterialName),
								 //r.tOrder.tPackageWayDetail.tAllPackage.packageMaterial.Picture, Picture不能重複使用(C#語法)
								 ColorName = r.tOrder.tPackageWayDetails.Select(x => x.tAllPackage.packageMaterial.MaterialColor.ColorName),
								 RGB = r.tOrder.tPackageWayDetails.Select(x => x.tAllPackage.packageMaterial.MaterialColor.RGB),
								 StyleName = r.tOrder.tPackageWayDetails.Select(x => x.tAllPackage.GiftPackageStyle.StyleName),
								 //r.tOrder.tPackageWayDetail.tAllPackage.GiftPackageStyle.Picture, Picture不能重複使用(C#語法)
								 Price = r.tOrder.tPackageWayDetails.Select(x => x.tAllPackage.Price),
								 PackQty = r.tOrder.tPackageWayDetails.Select(x => x.PackQty),
                                 r.tOrder.tStatu.StatusName
                             };
                dataGridView1.DataSource = orders.ToList();
                resetGridStyle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void resetGridStyle()
        {
            dataGridView1.Columns[0].HeaderText = "編號";
            dataGridView1.Columns[1].HeaderText = "訂編";
            dataGridView1.Columns[2].HeaderText = "會編";
            dataGridView1.Columns[3].HeaderText = "會員名字";
            dataGridView1.Columns[4].HeaderText = "產編";
            dataGridView1.Columns[5].HeaderText = "產品名稱";
            dataGridView1.Columns[6].HeaderText = "產品價格";
            dataGridView1.Columns[7].HeaderText = "數量";
            dataGridView1.Columns[8].HeaderText = "包裝名字";
            dataGridView1.Columns[9].HeaderText = "包裝照片";
            dataGridView1.Columns[10].HeaderText = "材質";
            dataGridView1.Columns[11].HeaderText = "顏色名字";
            dataGridView1.Columns[12].HeaderText = "顏色";
            dataGridView1.Columns[13].HeaderText = "禮物包裝類型";
            dataGridView1.Columns[14].HeaderText = "包裝價格";
            dataGridView1.Columns[15].HeaderText = "包裝數量";
            dataGridView1.Columns[16].HeaderText = "售出狀態";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 50;
            dataGridView1.Columns[2].Width = 50;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 50;
            dataGridView1.Columns[5].Width = 200;
            dataGridView1.Columns[6].Width = 150;
            dataGridView1.Columns[7].Width = 50;
            dataGridView1.Columns[8].Width = 100;
            dataGridView1.Columns[9].Width = 100;
            dataGridView1.Columns[10].Width = 100;
            dataGridView1.Columns[11].Width = 100;
            dataGridView1.Columns[12].Width = 100;
            dataGridView1.Columns[13].Width = 100;
            dataGridView1.Columns[14].Width = 100;
            dataGridView1.Columns[15].Width = 50;
            dataGridView1.Columns[16].Width = 150;


            bool isColorChanged = false;
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                isColorChanged = !isColorChanged;
                r.DefaultCellStyle.BackColor = Color.FromArgb(229, 229, 229);
                if (isColorChanged)
                    r.DefaultCellStyle.BackColor = Color.White;
                r.DefaultCellStyle.Font = new Font("微軟正黑體", 12); // new Font 設字形
            }
        }

        private void FrmOrderList_Activated(object sender, EventArgs e)
        {
            resetGridStyle();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FrmInsertOrder f = new FrmInsertOrder();
            f.ShowDialog();
            if (f.isOk != DialogResult.OK)
                return;
            //tOrder x = f.order;
            //tProduct y = f.product;
            tPurchase z = f.purchase;

            //======================== 加入資料表
            SelectShopEntities db = new SelectShopEntities();
            //var o = db.tOrders.Add(x);
            //var p = db.tProducts.Add(y);
            //pp = (tPurchases)o.MemberID;
            //db.tPurchases.Add();
            //db.tPurchases.Add(y);
            db.tPurchases.Add(z);

            db.SaveChanges();

            queryAll();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
                return;
            DataGridViewRow r = dataGridView1.SelectedRows[0];
            if (r.Cells.Count <= 0)
                return;
            DataGridViewCell c = r.Cells[0];
            int id = (int)c.Value;

            //============刪除
            SelectShopEntities db = new SelectShopEntities();
            tPurchase purchase = db.tPurchases.FirstOrDefault(x => x.PurchaseID == id);
            if (purchase == null)
                return;
            db.tPurchases.Remove(purchase);
            db.SaveChanges();
            //=============要顯示更新資料
            queryAll();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            bool isColorChanged = false;
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                isColorChanged = !isColorChanged;
                r.DefaultCellStyle.BackColor = Color.FromArgb(229, 229, 229);
                if (isColorChanged)
                    r.DefaultCellStyle.BackColor = Color.White;
                r.DefaultCellStyle.Font = new Font("微軟正黑體", 12); // new Font 設字形

                foreach (DataGridViewCell c in r.Cells)
                {
                    if (c.Value == null)
                        continue; //因為資料表中有null，程式會出現錯誤
                    if (c.Value.ToString().Contains(txtKeyword.Text))
                    {
                        r.DefaultCellStyle.BackColor = Color.Yellow;
                        break;
                    }
                }
            }
            queryAll2();
        }

        private void queryAll2()
        {
            SelectShopEntities db = new SelectShopEntities();
            var orders = from r in db.tPurchases
                         where r.OrderID.ToString().ToUpper().Contains(txtKeyword.Text.ToUpper())
                         || r.ProductID.ToString().ToUpper().Contains(txtKeyword.Text.ToUpper())
                         || r.tOrder.MemberID.ToString().ToUpper().Contains(txtKeyword.Text.ToUpper())
                         || r.tProduct.ProductName.ToString().ToUpper().Contains(txtKeyword.Text.ToUpper())
                         || r.tProduct.UnitPrice.ToString().ToUpper().Contains(txtKeyword.Text.ToUpper())
                         || r.tOrder.tStatu.StatusName.ToString().ToUpper().Contains(txtKeyword.Text.ToUpper())
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
							 PackName = r.tOrder.tPackageWayDetails.Select(x=>x.tAllPackage.PackName),
                             Picture = r.tOrder.tPackageWayDetails.Select(x => x.tAllPackage.Picture),
							 //r.tOrder.tPackageWayDetail.tAllPackage.packageMaterial.MaterialID, ID出問題
							 MaterialName = r.tOrder.tPackageWayDetails.Select(x=>x.tAllPackage.packageMaterial.MaterialName),
							 //r.tOrder.tPackageWayDetail.tAllPackage.packageMaterial.Picture, Picture不能重複使用(C#語法)
							 ColorName = r.tOrder.tPackageWayDetails.Select(x=>x.tAllPackage.packageMaterial.MaterialColor.ColorName),
							 RGB = r.tOrder.tPackageWayDetails.Select(x=>x.tAllPackage.packageMaterial.MaterialColor.RGB),
							 StyleName = r.tOrder.tPackageWayDetails.Select(x=>x.tAllPackage.GiftPackageStyle.StyleName),
							 //r.tOrder.tPackageWayDetail.tAllPackage.GiftPackageStyle.Picture, Picture不能重複使用(C#語法)
							 Price = r.tOrder.tPackageWayDetails.Select(x=>x.tAllPackage.Price),
							 PackQty = r.tOrder.tPackageWayDetails.Select(x=>x.PackQty),
                             r.tOrder.tStatu.StatusName
                         };
            dataGridView1.DataSource = orders.ToList();
            resetGridStyle2();
        }

        private void resetGridStyle2()
        {
            dataGridView1.Columns[0].HeaderText = "編號";
            dataGridView1.Columns[1].HeaderText = "訂編";
            dataGridView1.Columns[2].HeaderText = "會編";
            dataGridView1.Columns[3].HeaderText = "會員名字";
            dataGridView1.Columns[4].HeaderText = "產編";
            dataGridView1.Columns[5].HeaderText = "產品名稱";
            dataGridView1.Columns[6].HeaderText = "產品價格";
            dataGridView1.Columns[7].HeaderText = "數量";
            dataGridView1.Columns[8].HeaderText = "包裝名字";
            dataGridView1.Columns[9].HeaderText = "包裝照片";
            dataGridView1.Columns[10].HeaderText = "材質";
            dataGridView1.Columns[11].HeaderText = "顏色名字";
            dataGridView1.Columns[12].HeaderText = "顏色";
            dataGridView1.Columns[13].HeaderText = "禮物包裝類型";
            dataGridView1.Columns[14].HeaderText = "包裝價格";
            dataGridView1.Columns[15].HeaderText = "包裝數量";
            dataGridView1.Columns[16].HeaderText = "售出狀態";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 50;
            dataGridView1.Columns[2].Width = 50;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 50;
            dataGridView1.Columns[5].Width = 200;
            dataGridView1.Columns[6].Width = 150;
            dataGridView1.Columns[7].Width = 50;
            dataGridView1.Columns[8].Width = 100;
            dataGridView1.Columns[9].Width = 100;
            dataGridView1.Columns[10].Width = 100;
            dataGridView1.Columns[11].Width = 100;
            dataGridView1.Columns[12].Width = 100;
            dataGridView1.Columns[13].Width = 100;
            dataGridView1.Columns[14].Width = 100;
            dataGridView1.Columns[15].Width = 50;
            dataGridView1.Columns[16].Width = 150;

            bool isColorChanged = false;
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                isColorChanged = !isColorChanged;
                r.DefaultCellStyle.BackColor = Color.BlueViolet;
                r.DefaultCellStyle.ForeColor = Color.White;
                if (isColorChanged)
                { r.DefaultCellStyle.BackColor = Color.Yellow; r.DefaultCellStyle.ForeColor = Color.Black; }

                r.DefaultCellStyle.Font = new Font("微軟正黑體", 12); // new Font 設字形
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            editById(id);
        }

        private void editById(int id)
        {
            SelectShopEntities db = new SelectShopEntities();
            var orderproduct = from r in db.tPurchases
                               select new
                               {
                                   R = r.tOrder,
                                   L = r.tProduct
                               };
            tPurchase purchase = db.tPurchases.FirstOrDefault(x => x.PurchaseID == id);
            int oo = (int)purchase.OrderID;
            tOrder order = db.tOrders.FirstOrDefault(x => x.OrderID == oo);
            int pp = (int)purchase.ProductID;
            tProduct product = db.tProducts.FirstOrDefault(x => x.ProductID == pp);
            int qq = (int)order.StatusID;
            tStatu statu = db.tStatus.FirstOrDefault(x => x.StatusID == qq);
            int ww = (int)order.MemberID;
            tMember member = db.tMembers.FirstOrDefault(x => x.MemberID == ww);

            var op = db.tPurchases.Join(db.tOrders, o => o.OrderID, p => p.OrderID, (p, o) => new { o.OrderID, p.ProductID }).Join(db.tProducts, m => m.ProductID, n => n.ProductID, (m, n) => new { m.OrderID, n.ProductID });
            if (purchase == null)
                return;

            FrmOrder f = new FrmOrder();

            f.purchase = purchase;
            f.order = order;
            f.product = product;
            f.statu = statu;
            f.member = member;
            f.ShowDialog();

            if (f.isOk != DialogResult.OK)
                return;
            purchase.Qty = f.purchase.Qty;
            //order.MemberID = f.order.MemberID;
            order.MemberID = f.member.MemberID;
            product.ProductName = f.product.ProductName;
            db.SaveChanges();
            queryAll();
        }
    }
}
