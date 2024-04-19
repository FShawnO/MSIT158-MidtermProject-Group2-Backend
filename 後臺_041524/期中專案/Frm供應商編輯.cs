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
        private tLabel _label;

        public DialogResult isOK
        { 
            get { return _isOK; }
        }
            
        public Frm供應商編輯()
        {
            InitializeComponent();
        }

        public tLabel label
        {
            get
            {
                if (_label == null)
                {
                    _label = new tLabel();
                }
                _label.LabelName = textBox1.Text;
                _label.Address = textBox3.Text;
                _label.Description = textBox2.Text;
                if (!string.IsNullOrEmpty(_ImagePath))
                {
                    _label.SupplierPhoto = File.ReadAllBytes(_ImagePath);
                }
                return _label;
            }

            set
            {
                _label = value;
                textBox1 .Text = _label.LabelName;
                textBox3.Text = _label.Address;
                textBox2.Text = _label.Description;
                if (_label.SupplierPhoto != null)
                {
                    _Imagestored = _label.SupplierPhoto.ToString();
                    if (!string.IsNullOrEmpty(_Imagestored))
                    {
                        byte[] bytes = (byte[])(label.SupplierPhoto);
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
