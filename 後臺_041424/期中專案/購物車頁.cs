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

namespace 期中專案
{
    public partial class 購物車頁 : Form
    {
        static public List<商品資訊格式> 加入購物車商品 = new List<商品資訊格式>();
        static public void 加入購物車(商品資訊格式 商品) { 加入購物車商品.Add(商品); }
        static public List<int> 購物車已選取 = new List<int>();
        static public int 已選取總價 = 0;
        public 購物車頁()
        {
            InitializeComponent();
            載入();
        }
        private void 載入()
        {
            已選取總價 = 0;
            購物車已選取.Clear();
            flowLayoutPanel1.Controls.Clear();
            foreach (商品資訊格式 p in 加入購物車商品)
            {
                購物車預覽 a = new 購物車預覽();
                a.編號 = p.商品編號;
                a.標題 = p.商品名稱;
                a.價格 = p.商品價格;
                a.商品圖片 = p.商品圖片;
                a.數量 = p.加入購物車數量數量;
                flowLayoutPanel1.Controls.Add(a);
                a.選取事件();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {         
            SelectShopEntities db = new SelectShopEntities();
            for (int i =0; i<購物車已選取.Count;i++)
            {
                var room2 = 加入購物車商品.FirstOrDefault(x => x.商品編號 == 購物車已選取[i]);
                tPurchase a = new tPurchase();
                a.UnitPrice = room2.商品價格;
                a.ProductID = room2.商品編號;
                a.Qty = 1;
                db.tPurchase.Add(a); 
                db.SaveChanges();
                加入購物車商品.Remove(加入購物車商品.FirstOrDefault(x => x.商品編號 == 購物車已選取[i]));
            }       
            購物車已選取.Clear();
            MessageBox.Show("總共是" + 已選取總價 + "元");
            載入_不勾();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 購物車已選取.Count; i++)
            加入購物車商品.Remove(加入購物車商品.FirstOrDefault(x => x.商品編號 == 購物車已選取[i]));
            載入_不勾();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            載入();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            載入_不勾();
        }

        private void 載入_不勾()
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (商品資訊格式 p in 加入購物車商品)
            {
                購物車預覽 a = new 購物車預覽();
                a.編號 = p.商品編號;
                a.標題 = p.商品名稱;
                a.價格 = p.商品價格;
                a.商品圖片 = p.商品圖片;
                flowLayoutPanel1.Controls.Add(a);
                a.不選();
            }
            已選取總價 = 0;
        }
    }
}
