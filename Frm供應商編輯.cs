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

namespace 期中專案.借放
{
    public partial class Frm供應商編輯 : Form
    {
        private string _ImagePath = "";
        private string _Imagestored = "";
        private DialogResult _isOK;
        private tSupplier _supplier;

        public DialogResult isOK
        { 
            get { return _isOK; }
        }
            
        public Frm供應商編輯()
        {
            InitializeComponent();
        }

        public tSupplier supplier
        {
            get
            {
                if (_supplier == null)
                {
                    _supplier = new tSupplier();
                }
                _supplier.SupplierName = textBox1.Text;
                _supplier.Address = textBox3.Text;
                _supplier.Description = textBox2.Text;
                if (!string.IsNullOrEmpty(_ImagePath))
                {
                    _supplier.SupplierPhoto = File.ReadAllBytes(_ImagePath);
                }
                return _supplier;
            }

            set
            {
                _supplier = value;
                textBox1 .Text = _supplier.SupplierName;
                textBox3.Text = _supplier.Address;
                textBox2.Text = _supplier.Description;
                if (_supplier.SupplierPhoto != null)
                {
                    _Imagestored = _supplier.SupplierPhoto.ToString();
                    if (!string.IsNullOrEmpty(_Imagestored))
                    {
                        byte[] bytes = (byte[])(supplier.SupplierPhoto);
                        MemoryStream ms = new MemoryStream(bytes);
                        this.pictureBox1.Image = Image.FromStream(ms);
                    }
                    //        if (!string.IsNullOrEmpty(_ImagePath))
                    //{
                    //    string path = Application.StartupPath + "\\orderImages";
                    //    pictureBox1.Image = new Bitmap(path + "\\" + _ImagePath);
                    //}
                    return;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _isOK = DialogResult.OK;
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _isOK = DialogResult.Cancel;
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            _ImagePath = openFileDialog1.FileName;
            pictureBox1.Image = new Bitmap(_ImagePath);
        }
    }
}
