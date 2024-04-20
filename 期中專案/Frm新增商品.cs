using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 後台
{
    public partial class Frm新增商品 : Form
    {
		List<int> SuppkIndex = new List<int>();
		List<int> CatpkIndex = new List<int>();
		List<int> subCatpkIndex = new List<int>();
		List<int> ActpkIndex = new List<int>();
		List<int> PackpkIndex = new List<int>();
		public class ComboBoxItem
        {
            public string Value { get; set; }
            public string Text { get; set; }

            public ComboBoxItem(string value, string text)
            {
                Value = value;
                Text = text;
            }

            public override string ToString()
            {
                return Text;
            }
        }

		public class ComboUtil
		{
			// <summary>
			// 設定下拉值
			// </summary>
			public static void SetItemValue(System.Windows.Forms.ComboBox cbo, string value)
			{
				var selectedObject = cbo.Items.Cast<ComboBoxItem>().SingleOrDefault(i => i.Value.Equals(value));
				if (selectedObject != null)
					cbo.SelectedIndex = cbo.FindStringExact(selectedObject.Text.ToString());
				else
					cbo.SelectedIndex = -1;
			}

			// <summary>
			// 取得下拉項目
			// </summary>
			public static ComboBoxItem GetItem(System.Windows.Forms.ComboBox cbo)
			{
				ComboBoxItem item = new ComboBoxItem("", "");
				if (cbo.SelectedIndex > -1)
				{
					item = cbo.Items[cbo.SelectedIndex] as ComboBoxItem;
				}
				return item;
			}

			// <summary>
			// 取得索引下拉項目
			// </summary>
			public static ComboBoxItem GetItem(System.Windows.Forms.ComboBox cbo, int index)
			{
				ComboBoxItem item = null;
				if (index > -1)
				{
					item = cbo.Items[index] as ComboBoxItem;
				}
				return item;
			}
		}

        public int notice = 0;
        public string noticeText = "";
		private string _ImagePath = "";
        private string _ImageStored = "";
		private DialogResult _isOK;

        private tProduct _product;
        public tProduct product
        {
            get 
            {
                if (_product == null)
                { 
                    _product = new tProduct(); 
                }

                _product.ProductName = textBox2.Text;
                if (this.comboBox1.SelectedIndex == -1 && this.comboBox1.Text == "")
                {
                    notice++;
                    noticeText += "請選擇供應商";
				}
                else
                {
                    _product.LabelID = Convert.ToInt32(ComboUtil.GetItem(this.comboBox1, this.comboBox1.SelectedIndex).Value);
                }
                if (this.comboBox5.SelectedIndex == -1 && this.comboBox5.Text == "")
                {
                    if (notice > 0)
                    {
                        noticeText += "、";
                    } else
                    {
						noticeText += "請選擇";
					}
					noticeText += "次類別！";
                    MessageBox.Show(noticeText);
					notice++;
                }
                else
                {
					if (notice > 0) MessageBox.Show(noticeText);
					_product.SubCategoryID = Convert.ToInt32(ComboUtil.GetItem(this.comboBox5, this.comboBox5.SelectedIndex).Value);
                }
                string Stocks = textBox3.Text == "" ? "0" : textBox3.Text;
				_product.Stocks = Convert.ToInt32(Stocks);
                string UnitPrice = textBox4.Text == "" ? "0" : textBox4.Text;
				_product.UnitPrice = Convert.ToInt32(UnitPrice);
                _product.Description = textBox5.Text;
                int ActiveIndex = this.comboBox3.SelectedIndex;
                if (ActiveIndex >= 0)
                {
                    int ActiveID = Convert.ToInt32(ComboUtil.GetItem(this.comboBox3, ActiveIndex).Value);

					if (_product.ActiveID == ActiveID) {//未更動員選擇;
                        _product.ActiveID = ActiveID; //未選擇時： index = -1
                    } else {
                        _product.ActiveID = Convert.ToInt32(ComboUtil.GetItem(this.comboBox3, this.comboBox3.SelectedIndex).Value);
                    }
                } else
                {
                    _product.ActiveID = null;

				}
				//int PackageIndex = this.comboBox4.SelectedIndex;
    //            if (PackageIndex >= 0)
    //            {
    //                int PackageID = Convert.ToInt32(ComboUtil.GetItem(this.comboBox4, PackageIndex).Value);

				//	if (_product.PackageID == PackageID) { //未更動員選擇;
    //                    _product.ActiveID = PackageID; //未選擇時： index = -1
    //                } else {
    //                    _product.PackageID = Convert.ToInt32(ComboUtil.GetItem(this.comboBox4, this.comboBox4.SelectedIndex).Value);
    //                }
    //            } else
    //            {
    //                _product.PackageID = null;

				//}

				if (!string.IsNullOrEmpty(_ImagePath))
                    {
                        _product.ProductPhoto = File.ReadAllBytes(_ImagePath);
                    }
                    return _product;
            }
            set 
            {
                _product = value;

				textBox2.Text = _product.ProductName;
				textBox3.Text = _product.Stocks.ToString();
                textBox4.Text = ((int)_product.UnitPrice).ToString();
                textBox5.Text = _product.Description;
				comboBox1.SelectedIndex = SuppkIndex.IndexOf((int)_product.LabelID);
				comboBox2.SelectedIndex = CatpkIndex.IndexOf((int)_product.tSubCategory.CategoryID);
                if (_product.ActiveID != null)  comboBox3.SelectedIndex = ActpkIndex.IndexOf((int)_product.ActiveID);
				comboBox5.SelectedIndex = subCatpkIndex.IndexOf((int)_product.SubCategoryID);
				//if (_product.PackageID != null) comboBox4.SelectedIndex = PackpkIndex.IndexOf((int)_product.PackageID);

				if (_product.ProductPhoto !=null)
                {
					_ImageStored = _product.ProductPhoto.ToString();
                    if (!string.IsNullOrEmpty(_ImageStored))
                    {
						byte[] bytes = (byte[])(_product.ProductPhoto);
						MemoryStream ms = new MemoryStream(bytes);
						this.pictureBox1.Image = Image.FromStream(ms);
					}
                    return ;
                }
            }
        }

		public DialogResult isOK
        {
            get { return _isOK; }
        }

        public Frm新增商品()
        {
            InitializeComponent();

           try
            {
                textBox1.Text = DateTime.Now.ToString();
            

            SelectShopEntities db = new SelectShopEntities();
            var v = (from o in db.tLabels
                    join p in db.tProducts
                    on o.LabelID equals p.LabelID
                    select new {o.LabelID, o.LabelName }).Distinct();

            //p和前述p沒有關係
            foreach (var label in v) {
                
                ComboBoxItem item = new ComboBoxItem(label.LabelID.ToString(), label.LabelName);
                comboBox1.Items.Add(item);
				SuppkIndex.Add(label.LabelID);
				}
               
                //主類別
                var g = (from s in db.tCategories
                         join p in db.tSubCategories
                         on s.CategoryID equals p.CategoryID
                         select new { s.CategoryID, s.CategoryCName}).Distinct();
                foreach(var connect in g) 
                {
                    ComboBoxItem item = new ComboBoxItem(connect.CategoryID.ToString(), connect.CategoryCName);
                    comboBox2.Items.Add(item);
                    CatpkIndex.Add(connect.CategoryID);
				}


				// 次類別
				var h = (from s in db.tSubCategories
                         join p in db.tCategories
                         on s.CategoryID equals p.CategoryID
                         where p.CategoryName == comboBox2.Text
                         select new { s.SubCategoryID, s.SubCategoryName });//.Distinct();

                foreach (var connect in h)
                {
                    ComboBoxItem item2 = new ComboBoxItem(connect.SubCategoryID.ToString(), connect.SubCategoryName);
                    comboBox5.Items.Add(item2);
                }

				//活動選單
				var q = (from o in db.tActives
                    join p in db.tProducts
                    on o.ActiveID equals p.ActiveID into ps from p in ps.DefaultIfEmpty()
                    select new { o.ActiveID , o.ActiveName}).Distinct();

            foreach (var active in q)
            {
                ComboBoxItem item = new ComboBoxItem(active.ActiveID.ToString(), active.ActiveName);
                comboBox3.Items.Add(item);
				ActpkIndex.Add(active.ActiveID); 
            }
                

            //var package = (from o in db.tPackages
            //          join p in db.tProducts
            //          on o.PackageID equals p.PackageID
            //          select new {o.PackageID, o.PackageWay }).Distinct();

            //foreach (var pack in package) 
            //{
            //    ComboBoxItem item = new ComboBoxItem(pack.PackageID.ToString(), pack.PackageWay.ToString());
            //    comboBox4.Items.Add(item);
            //    PackpkIndex.Add(pack.PackageID); 
            //}

            }
            catch (Exception ex)
            {
                // 在这里处理异常，例如记录错误日志或者显示错误消息给用户
               MessageBox.Show("发生错误：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // 可以选择关闭窗体或者进行其他适当的处理
                Close(); // 例如关闭窗体
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _isOK = DialogResult.OK;

			SelectShopEntities db = new SelectShopEntities();
			var products= from p in db.tProducts
                          where p.ActiveID == product.ProductID select p;
            if (products == null)
			db.tProducts.Add(product);

            if (notice == 0)
            {
                db.SaveChanges();
                Close();
            } else
            {
                notice = 0;
                noticeText = "";

			}

        }

    

        private void button2_Click(object sender, EventArgs e)
        {
            _isOK = DialogResult.Cancel;
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //openFileDialog1.Filter = "商品照片| *jpg |商品照片 |*.png |商品照片 |*.bmp ";
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            _ImagePath = openFileDialog1.FileName;
            pictureBox1.Image = new Bitmap(_ImagePath);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void Frm新增商品_Load(object sender, EventArgs e)
        {
           
           //this.WindowState = FormWindowState.Maximized;   
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //每次點選都需要再觸發一次

            SelectShopEntities db = new SelectShopEntities();

            var h = (from s in db.tSubCategories
                     join p in db.tCategories
                     on s.CategoryID equals p.CategoryID
                     where p.CategoryCName == comboBox2.Text
                     select new { s.SubCategoryID, s.SubCategoryCName });//.Distinct();
			
            comboBox5.Items.Clear();
			foreach (var connect in h)
            {
                //ComboBoxItem item2 = new ComboBoxItem(connect.SubCategoryID.ToString(), connect.SubCategoryName);
                //comboBox5.Items.Add(connect.SubCategoryCName);
				comboBox5.Items.Add(new ComboBoxItem(connect.SubCategoryID.ToString(), connect.SubCategoryCName));
				subCatpkIndex.Add(connect.SubCategoryID);
			}
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
