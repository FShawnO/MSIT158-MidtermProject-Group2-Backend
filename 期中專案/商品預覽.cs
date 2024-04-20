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
    public delegate void D();
    public partial class 商品預覽 : UserControl
    {
        public  D dd;
        public 商品預覽()
        {
            InitializeComponent();
        }
        public string 標題 { get { return label1.Text; } set { label1.Text = value; } }
        public int 價格 { get { return Convert.ToInt32(label2.Text); } set { label2.Text = value.ToString(); } }
        public Image 商品圖片 { get { return pictureBox2.Image; } set { pictureBox2.Image = value; } }
        public int 編號;
        商品資訊格式 a;

        private void button1_Click(object sender, EventArgs e)
        {
            
                a = new 商品資訊格式();
                a.商品名稱 = 標題;
                a.商品編號 = 編號;
                a.商品價格 = 價格;
                a.商品圖片 = 商品圖片;
            //if (購物車頁.加入購物車商品.Exists(t => t.商品編號 == a.商品編號))
            //{
            //    商品資訊格式 b = 購物車頁.加入購物車商品.FirstOrDefault(t => t.商品編號 == a.商品編號);
            //    b.加入購物車數量數量++;
            //    MessageBox.Show(標題 + "數量+1");
            //}
            //else
            { 購物車頁.加入購物車(a); MessageBox.Show("成功將「" + 標題 + " 」加入購物車");}         
            dd();
        }
    }
}
