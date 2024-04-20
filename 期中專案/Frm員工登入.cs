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
    public partial class Frm員工登入 : Form
    {
        private bool _isClosed =  true;

        public tEmployee auth { get; set; }

        SelectShopEntities db = new SelectShopEntities();
        public Frm員工登入()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var employees = from emp in db.tEmployees
                            select emp;

            tEmployee employee = db.tEmployees.FirstOrDefault(x => x.E_mail.Equals(textBox1.Text) && x.Password.Equals(textBox2.Text));
            if (employee != null)
            {
                this.auth = employee;
                _isClosed = false;
                Close();
                return;
            }
            MessageBox.Show("帳號與密碼不符");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _isClosed = false;
            Application.Exit();
        }

        private void Frm員工登入_FormClosing(object sender, FormClosingEventArgs e)
        {
            //讓視窗無法關閉
            e.Cancel = _isClosed;
        }
    }
}
