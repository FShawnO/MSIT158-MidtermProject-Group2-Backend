using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 期中專案.付帳
{
    public partial class StatusBox : UserControl
    {
        public string statusName //設定屬性
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        public string statusValue //設定屬性
        {
            get { return comboBox1.Text; }
            set { comboBox1.Text = value; }
        }

        public StatusBox()
        {
            InitializeComponent();
        }
    }
}
