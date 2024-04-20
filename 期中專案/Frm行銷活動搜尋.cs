using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 後台
{
    public partial class Frm行銷活動搜尋 : Form
    {
        public Frm行銷活動搜尋()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectShopEntities db = new SelectShopEntities();
            var actives = from a in db.tActives
                          where a.ActiveName.Contains(textBox1.Text)
                          select a;
            TimeSpan dayrange = dateTimePicker2.Value - dateTimePicker1.Value;
            flowLayoutPanel1.Controls.Clear();

            foreach (var a in actives)
            {
                bool isSearch = false;
                for (int i = 0; i <= dayrange.TotalDays; i++)
                { 
                    string day = dateTimePicker1.Value.AddDays(i).ToString("yyyyMMdd");
                    var order = db.tActives.FirstOrDefault(o => o.ActiveID == a.ActiveID && o.StartDate.Equals(day));
                    if(order != null)
                    { 
                        isSearch = true;
                        break;
                    }
                }
                if (!isSearch)
                {
                    行銷活動圖 EV = new 行銷活動圖();
                    EV.start = dateTimePicker1.Value;
                    EV.end = dateTimePicker2.Value;
                    EV.Width = flowLayoutPanel1.Width;

                }
            
            }
        }

      
    }
}
