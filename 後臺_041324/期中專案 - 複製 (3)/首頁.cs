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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 期中專案
{
    public partial class 首頁 : Form
    {
        public 首頁()
        {
            InitializeComponent();
            載入();
        }
        public void 更新商品數() { label3.Text = 購物車頁.加入購物車商品.Count.ToString(); }
        private void 載入()
        {
            flowLayoutPanel1.Controls.Clear();
            SelectShopEntities db = new SelectShopEntities();
            var b = from r in db.tProduct select r;
            foreach (tProduct p in b)
            {
                商品預覽 a = new 商品預覽();
                a.編號 = p.ProductID;
                a.標題 = p.ProductName;
                if (p.Stocks == null) { a.價格 = 1; }
                else { a.價格 = (int)p.Stocks; }
                if (p.ProductPhoto != null)
                {
                    MemoryStream ms = new MemoryStream(Convert.ToInt32( p.ProductPhoto));
                    a.商品圖片 = Image.FromStream(ms);
                }
                a.dd = 更新商品數;
                flowLayoutPanel1.Controls.Add(a);
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            新增商品 a = new 新增商品();
            a.dd = 載入;
            a.ShowDialog();
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            購物車頁 a = new 購物車頁();
            a.ShowDialog();
            更新商品數();
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            消費紀錄 a = new 消費紀錄();
            a.ShowDialog();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
