using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjComponentDemo.usercontrol
{
    public partial class FieldBox : UserControl
    {
        public FieldBox()
        {
            InitializeComponent();
        }

        public string fieldName //設定屬性
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        public string fieldValue //設定屬性
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

    }
}
