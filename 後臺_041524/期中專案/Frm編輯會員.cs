using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Net.Mime.MediaTypeNames;

namespace 期中專案
{
    public partial class Frm編輯會員 : Form
    {
		List<int> vip_pkIndex = new List<int>();
		List<int> sex_pkIndex = new List<int>();

		public class ComboBoxItem
		{
			public int Value { get; set; }
			public string Text { get; set; }

			public ComboBoxItem(int value, string text)
			{
				Value = value;
				Text = text;
			}

			public override string ToString()
			{
				return Text;
			}
		}

		public class ComboUtil
		{
			public static void SetItemValue(System.Windows.Forms.ComboBox cbo, string value)
			{
				var selectedObject = cbo.Items.Cast<ComboBoxItem>().SingleOrDefault(i => i.Value.Equals(value));
				if (selectedObject != null)
					cbo.SelectedIndex = cbo.FindStringExact(selectedObject.Text.ToString());
				else
					cbo.SelectedIndex = -1;
			}

			public static ComboBoxItem GetItem(System.Windows.Forms.ComboBox cbo)
			{
				ComboBoxItem item = new ComboBoxItem(0, "");
				if (cbo.SelectedIndex > -1)
				{
					item = cbo.Items[cbo.SelectedIndex] as ComboBoxItem;
				}
				return item;
			}
			public static ComboBoxItem GetItem(System.Windows.Forms.ComboBox cbo, int index)
			{
				ComboBoxItem item = null;
				if (index > -1)
				{
					item = cbo.Items[index] as ComboBoxItem;
				}
				return item;
			}

		}

		private string __ImagePath = "";
		private string _ImageStored = "";
		private DialogResult _isOK;
        private tMember _memeber;
        public tMember memeber
        {
            get 
            {
                if (_memeber == null)
                { 
                    _memeber = new tMember();
                }

                _memeber.MemberName = textBox1.Text; //memeber.MemberName;
                _memeber.E_mail = textBox2.Text;  //memeber.E_mail;
                _memeber.Cellphone = textBox3.Text; //memeber.Cellphone;
                _memeber.Address = textBox4.Text; // memeber.Address;
                _memeber.Birthday = dateTimePicker1.Value; //memeber.Birthday;
				_memeber.Sex = ComboUtil.GetItem(this.cboSex, this.cboSex.SelectedIndex).Value; //memeber.Sex;
				string point = textBox6.Text == "" ? "0" : textBox6.Text;
				_memeber.Points = Convert.ToInt32(point); //memeber.Points;   
				_memeber.VIP = Convert.ToBoolean(ComboUtil.GetItem(this.cboVIP, this.cboVIP.SelectedIndex).Value);
				//_memeber.VIP = textBox7.Text; //memeber.VIP;
				string Wallet = textBox8.Text == "" ? "0" : textBox8.Text;
				_memeber.Wallet = Convert.ToDecimal(Wallet); //memeber.Wallet;
				if (!string.IsNullOrEmpty(__ImagePath))
				{
					_memeber.MemberPhoto = File.ReadAllBytes(__ImagePath);
				}
				return _memeber; }


            set { 
                _memeber = value;
                textBox1.Text = _memeber.MemberName;
                textBox2.Text = _memeber.E_mail;
                textBox3.Text = _memeber.Cellphone;
                textBox4.Text = _memeber.Address;
				dateTimePicker1.Value = Convert.ToDateTime(_memeber.Birthday);
				if (_memeber.Sex != null)
				{
					cboSex.SelectedIndex = sex_pkIndex.IndexOf(Convert.ToInt32(_memeber.Sex));
				}
				else
				{
					cboSex.SelectedIndex = 0;
				}
				textBox6.Text = _memeber.Points == null ? "0" : _memeber.Points.ToString();
				if (_memeber.VIP != null)
				{
					cboVIP.SelectedIndex = vip_pkIndex.IndexOf(Convert.ToInt32(_memeber.VIP));
				} else
				{
					cboVIP.SelectedIndex = 0;
				}
				//textBox7.Text = memeber.VIP.ToString();
                textBox8.Text = _memeber.Wallet == null ? "0" : _memeber.Wallet.ToString();
				if (!string.IsNullOrEmpty(_ImageStored))
				{
					string path = Application.StartupPath + "\\orderImages";
					pictureBox1.Image = new Bitmap(path + "\\" + _ImageStored);
				}
				return;
			}
        }

		public DialogResult isOK
		{ 
            get { return _isOK; }
        }

		public Frm編輯會員()
        {
            InitializeComponent();

			try
			{
				for (int i = 0; i <= 1; i++)
				{
					string text = "否";
					if (i == 1) { text = "是"; }
					//if (member.VIP == null) { text = "否"; }
					//ComboBoxItem item = new ComboBoxItem(1, "是");
					ComboBoxItem itemVip = new ComboBoxItem(i, text);
					cboVIP.Items.Add(itemVip);
					vip_pkIndex.Add(i);
				}

				for (int i = 0; i <= 2; i++)
				{
					//string text = "否";
					string text = "";
					if (i == 0) { text = "未選擇"; } else if (i == 1) { text = "男"; } else { text = "女"; }
					ComboBoxItem itemSex = new ComboBoxItem(i, text);
					cboSex.Items.Add(itemSex);
					sex_pkIndex.Add(i);
				}

				//SelectShopEntities db = new SelectShopEntities();
				//var members = (from m in db.tMembers
				//				   //join emp in db.tEmployees
				//				   //on d.DepID equals emp.DepID //into ps from emp in ps.DefaultIfEmpty()
				//				   select new { m.VIP }).Distinct();

				//foreach (var member in members)
				//{
				//	if ((bool)member.VIP) { cboVIP.SelectedIndex = 1; } else {
				cboVIP.SelectedIndex = 0; 
				//}
			}
			catch (Exception ex)
			{
				// 在这里处理异常，例如记录错误日志或者显示错误消息给用户
				MessageBox.Show("发生错误：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
				// 可以选择关闭窗体或者进行其他适当的处理
				Close(); // 例如关闭窗体
			}
		}

        private void 確認_Click(object sender, EventArgs e)
        {
            _isOK = DialogResult.OK;
            Close();
        }

        private void 取消_Click(object sender, EventArgs e)
        {
            _isOK = DialogResult.Cancel;
            Close();
        }

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() != DialogResult.OK)
				return;
			__ImagePath = openFileDialog1.FileName;
			pictureBox1.Image = new Bitmap(__ImagePath);

		}
	}
}
