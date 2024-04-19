using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 期中專案
{
    public delegate void DD();

    public partial class 新增商品 : Form
    {
        public DD dd;
        public 新增商品()
        {
            InitializeComponent();
        }
        public string 商品名;
        public string 商品價格;
        public Image 商品圖片;
        private tProduct _商品資料輸入;
        public tProduct 商品資料輸入
        { 
            get 
            {
                if (_商品資料輸入 == null) { _商品資料輸入 = new tProduct(); }
                _商品資料輸入.ProductName = textBox1.Text; 
                _商品資料輸入.Stocks= Convert.ToInt32(textBox2.Text);//(暫時用stocks替代)
                if (bt!=null)_商品資料輸入.ProductPhoto = bt.ToString();
                return _商品資料輸入;
            }         
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SelectShopEntities db = new SelectShopEntities();
            tProduct x = 商品資料輸入;
            db.tProduct.Add(x);
            db.SaveChanges();
            dd();
            MessageBox.Show("加入「"+x.ProductName+"」成功!");
        }
   
        byte[] bt;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            bt = ms.GetBuffer();
        }
    }
}
