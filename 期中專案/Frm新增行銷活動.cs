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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static 後台.Frm新增商品;

namespace 後台
{
	public partial class Frm新增行銷活動 : Form
	{
		private string _ImagePath = "";
		private string _ImageStored = "";
		private DialogResult _isOK;

		private tActive _active;
		public tActive active
		{
			get
			{
				if (_active == null)
				{
					_active = new tActive();
				}

				_active.ActiveName = tboActiveName.Text;
				_active.Discount = Convert.ToDecimal(tboDiscount.Text);
				_active.StartDate = startDateTimePicker.Value;
				_active.EndDate = endDateTimePicker.Value;
				_active.Description = rtbDescription.Text;

					if (!string.IsNullOrEmpty(_ImagePath))
					{
						_active.ActiveImage = File.ReadAllBytes(_ImagePath);
					}
				return _active;
			}
			set
			{
				_active = value;
				tboActiveName.Text = _active.ActiveName;
				//startDateTimePicker.Value = DateTime.Parse(_active.StartDate);
				startDateTimePicker.Value = Convert.ToDateTime(_active.StartDate);
				endDateTimePicker.Value = Convert.ToDateTime(_active.EndDate);
				tboDiscount.Text = _active.Discount.ToString();
				rtbDescription.Text = _active.Description;

				if (_active.ActiveImage != null)
				{
					_ImageStored = _active.ActiveImage.ToString();
					if (!string.IsNullOrEmpty(_ImageStored))
					{
						byte[] bytes = (byte[])(_active.ActiveImage);
						MemoryStream ms = new MemoryStream(bytes);
						this.pictureBox1.Image = Image.FromStream(ms);
					}
					return;
				}
			}
		}

		public DialogResult isOK
		{
			get { return _isOK; }
		}

		public Frm新增行銷活動()
		{
			InitializeComponent();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() != DialogResult.OK)
				return;
			//_ImagePath = DateTime.Now.ToString("yyyyMMddHHmmss")+".jpg";
			_ImagePath = openFileDialog1.FileName;

			string path = Application.StartupPath + "\\productImages";
			if (!Directory.Exists(path))
				Directory.CreateDirectory(path);
			//File.Copy(openFileDialog1.FileName, path + "\\" + _ImagePath);
			//pictureBox1.Image = new Bitmap(path + "\\"+_ImagePath);
			pictureBox1.Image = Image.FromFile(this.openFileDialog1.FileName);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			_isOK = DialogResult.OK;
			Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			_isOK = DialogResult.Cancel;
			Close();
		}
	}
}
