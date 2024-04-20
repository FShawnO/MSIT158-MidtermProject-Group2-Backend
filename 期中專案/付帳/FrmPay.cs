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
using 後台;

namespace 後台.付帳
{
    public partial class FrmPay : Form
    {
        private string _ImagePath = "";
        private DialogResult _isOk;
        private tPayType _pay;

        public tPayType pay
        {
            get
            {
                if (_pay == null)
                    _pay = new tPayType();
                _pay.PayTypeID = Convert.ToInt32(fbId.fieldValue);
                _pay.PayTypeName = fbName.fieldValue;
                _pay.PayTypeImagePath = _ImagePath;
                return _pay;
            }
            set 
            {
                _pay = value;
                fbId.fieldValue = _pay.PayTypeID.ToString();
                fbName.fieldValue = _pay.PayTypeName;
                _ImagePath = _pay.PayTypeImagePath;
                if(!string.IsNullOrEmpty(_ImagePath))
                {
                    string path = Application.StartupPath + "\\payImages";
                    pictureBox1.Image= new Bitmap(path + "\\" + _ImagePath);
                }
            }
        }

        public DialogResult isOk //屬性
        { get { return _isOk; } }



        public FrmPay()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _isOk = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _isOk =DialogResult.Cancel;
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "支付照片|*.jpg|支付照片|*.png|支付照片|*.bmp";
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            _ImagePath = DateTime.Now.ToString("yyyyMMHHmmss") + ".jpg";
            string path = Application.StartupPath + "\\payImages";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            File.Copy(openFileDialog1.FileName, path + "\\" + _ImagePath);
            pictureBox1.Image=new Bitmap(openFileDialog1.FileName);
        }
    }
}
