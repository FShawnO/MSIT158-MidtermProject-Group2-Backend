using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using 期中專案;

namespace 期中專案.會員
{
    public partial class Log_In : Form
    {
        private bool _isClosed = true;        
        public tMember auth { get; set; }



        public Log_In()
        {
            InitializeComponent();
        }

        SelectShopEntities db = new SelectShopEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            var members = from r in db.tMembers
                          select r;


            tMember member = db.tMembers.FirstOrDefault(x => x.E_mail.Equals(fieldBox1.fieldValue) && x.Password.Equals(fieldBox2.fieldValue));

            if (member != null)
            {
                this.auth = member;
                _isClosed = false; //因為 e.Cancel                
                Close();
                return;
            }

            MessageBox.Show("帳號與密碼不符");
        }

        private void Log_In_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = _isClosed; //在e.Cancel 中 true => 讓視窗無法被關閉
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _isClosed = false;
            Application.Exit(); //所有視窗關閉
        }
    }
}
