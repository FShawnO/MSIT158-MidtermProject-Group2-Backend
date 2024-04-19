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
using static 期中專案.Frm新增商品;

namespace 期中專案
{
    public partial class Frm新增員工 : Form
    {
        List<int> departmentIndex = new List<int>();
        List<int> dep_pkIndex = new List<int>();
        
        public class ComboBoxItem
        {
            public string Value { get; set; }
            public string Text { get; set; }

            public ComboBoxItem(string value, string text)
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
                ComboBoxItem item = new ComboBoxItem("", "");
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
        private tEmployee _employee;
		public tEmployee employee
		{
			get
			{
				if (_employee == null)
				{
					_employee = new tEmployee();
				}
				_employee.EmployeeName = textBox1.Text;
				_employee.Cellphone = textBox2.Text;
				_employee.Address = textBox3.Text;
				_employee.Birthday = textBox4.Text;
				//_employee.Password = textBox5.Text;
				_employee.E_mail = textBox6.Text;
				_employee.OnBoardDate = textBox7.Text;
				//int DepIndex = this.comboBox1.SelectedIndex;
				//if (DepIndex > 0) _employee.DepID = Convert.ToInt32(ComboUtil.GetItem(this.comboBox1, Convert.ToInt32(departmentIndex)).Value); //未選擇時： index = -1
				//if (DepIndex > 0) _employee.DepID = Convert.ToInt32(ComboUtil.GetItem(this.comboBox1, DepIndex).Value); //未選擇時： index = -1
				//MessageBox.Show(this.cboDep.SelectedIndex.ToString());
				_employee.DepID = Convert.ToInt32(ComboUtil.GetItem(this.cboDep, this.cboDep.SelectedIndex).Value);
				if (!string.IsNullOrEmpty(__ImagePath))
				{
					_employee.EmployeePhoto = File.ReadAllBytes(__ImagePath);
				}
				return _employee;
			}


			set
			{
				_employee = value;
				textBox1.Text = _employee.EmployeeName;
				textBox2.Text = _employee.Cellphone;
				textBox3.Text = _employee.Address;
				textBox4.Text = _employee.Birthday;
				//textBox5.Text = _employee.Password;
				textBox6.Text = _employee.E_mail;
				textBox7.Text = _employee.OnBoardDate;
				///
				if (_employee.DepID != null) cboDep.SelectedIndex = dep_pkIndex.IndexOf((int)_employee.DepID);
                //  comboBox1.SelectedIndex = subCatpkIndex.IndexOf((int)_employee.DepID);
                ///
                if (_employee.EmployeePhoto != null)
                {
					_ImageStored = _employee.EmployeePhoto.ToString();
					if (!string.IsNullOrEmpty(_ImageStored))
                    {
						byte[] bytes = (byte[])(_employee.EmployeePhoto);
						MemoryStream ms = new MemoryStream(bytes);
						this.pictureBox1.Image = Image.FromStream(ms);

						//string path = Application.StartupPath + "\\orderImages";
                        //pictureBox1.Image = new Bitmap(path + "\\" + _ImageStored);
                    }
                    return;
                }

			}

		}

		public DialogResult isOK
        {
            get { return _isOK; }
        }

        public Frm新增員工()
        {
            InitializeComponent();

			try
			{
				SelectShopEntities db = new SelectShopEntities();
            var departments = (from d in db.tDepartments
                              join emp in db.tEmployees
                              on d.DepID equals emp.DepID //into ps from emp in ps.DefaultIfEmpty()
                              select new { d.DepID, d.DepName }).Distinct();

				foreach (var dep in departments) {
                    ComboBoxItem item = new ComboBoxItem(dep.DepID.ToString(), dep.DepName);
                    cboDep.Items.Add(item);
                    dep_pkIndex.Add(dep.DepID);
                }
			}
			catch (Exception ex)
			{
				// 在这里处理异常，例如记录错误日志或者显示错误消息给用户
				MessageBox.Show("发生错误：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
				// 可以选择关闭窗体或者进行其他适当的处理
				Close(); // 例如关闭窗体
			}
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            __ImagePath = openFileDialog1.FileName;
            pictureBox1.Image = new Bitmap(__ImagePath);

        }

		private void Frm新增員工_Load(object sender, EventArgs e)
		{
			//this.WindowState = FormWindowState.Maximized;
		}

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
