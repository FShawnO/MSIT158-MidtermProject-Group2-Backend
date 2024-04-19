using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace 期中專案
{
    public partial class 購物車預覽 : UserControl
    {
        public 購物車預覽()
        {
            InitializeComponent();         
        }
        public string 標題 { get { return label1.Text; } set { label1.Text = value; } }
        public int 價格 { get { return Convert.ToInt32(label2.Text); } set { label2.Text = value.ToString(); } }
        public Image 商品圖片 { get { return pictureBox2.Image; } set { pictureBox2.Image = value; } }
        public int 數量 { get { return Convert.ToInt32(label5.Text); } set { label5.Text = value.ToString(); } }

        public int 編號;
        public bool 是否選取  = true;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            是否選取 = !是否選取;
            選取事件();
        }

        public void 不選()
        { checkBox1.Checked=false; }

        public void 選取事件()
        {
            if (是否選取) { 購物車頁.購物車已選取.Add(編號); 購物車頁.已選取總價 += Convert.ToInt32(價格); }
            else { 購物車頁.購物車已選取.Remove(編號); 購物車頁.已選取總價 -= Convert.ToInt32(價格) ; }
        }
    }
}
