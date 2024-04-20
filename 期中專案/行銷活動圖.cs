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
    public partial class 行銷活動圖 : UserControl
    {
        private DateTime _start;
        public DateTime end { get; set; }
        private tActive _active;

        public DateTime start
        {
            get { return _start; }
            set { _start = value;
                label1.Text = "1111購物節" + _start.ToString("yy/MM/dd");
            }
        }
        public tActive active 
        {
            get { return _active; }
            set { _active = value;
                label1.Text = _active.ActiveName;
                label2.Text = _active.ToString();
                label3.Text = _active.Discount.ToString();
            //要新增Image
                //if(!string.IsNullOrEmpty(_active.))
            
            }
        
        }
        public 行銷活動圖()
        {
            InitializeComponent();
        }
    }
}
