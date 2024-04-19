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

namespace 期中專案
{
    public partial class Frm員工明細 : Form
    {
        public Frm員工明細()
        {
            InitializeComponent();
            EmpDetail();
            resetGridStyle();
        }
        private void EmpDetail() 
        {
            SelectShopEntities db = new SelectShopEntities();
            var employees = from emp in db.tEmployees
                            join dep in db.tDepartments on emp.DepID equals dep.DepID
                            select new {dep.DepName, emp.EmployeeID, emp.EmployeeName, emp.E_mail, emp.EmployeePhoto,emp.Address, emp.Cellphone,emp.Birthday, emp.OnBoardDate};
            dataGridView1.DataSource = employees.ToList();
        }

        private void queryall()
        {
			SelectShopEntities db = new SelectShopEntities();
			var employees = from emp in db.tEmployees
							join dep in db.tDepartments on emp.DepID equals dep.DepID
							select new { dep.DepName, emp.EmployeeID, emp.EmployeeName, emp.E_mail, emp.EmployeePhoto, emp.Address, emp.Cellphone, emp.Birthday, emp.OnBoardDate };
			dataGridView1.DataSource = employees.ToList();

			resetGridStyle();
        }

        private void resetGridStyle()
        {
            dataGridView1.Columns[0].HeaderText = "部門名稱";
            dataGridView1.Columns[1].HeaderText = "員工編號"; 
            dataGridView1.Columns[2].HeaderText = "員工姓名"; 
            dataGridView1.Columns[3].HeaderText = "電子郵件"; 
            dataGridView1.Columns[4].HeaderText = "員工照片"; 
            dataGridView1.Columns[5].HeaderText = "地址"; 
            dataGridView1.Columns[6].HeaderText = "電話";
            dataGridView1.Columns[7].HeaderText = "生日"; 
            dataGridView1.Columns[8].HeaderText = "到職日";
           

            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 300;
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.Columns[5].Width = 500;
            dataGridView1.Columns[6].Width = 180;
            dataGridView1.Columns[7].Width = 170;
            dataGridView1.Columns[8].Width = 170;
         

            bool isColorChanged = false;
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                isColorChanged = !isColorChanged;
                r.DefaultCellStyle.BackColor = Color.FromArgb(229, 229, 229);
                if (isColorChanged)
                    r.DefaultCellStyle.BackColor = Color.White;
                r.DefaultCellStyle.Font = new Font("微軟正黑體", 12);

            }
        }

        private void 產品新增_Click(object sender, EventArgs e)
        {
            Frm新增員工 p = new Frm新增員工();
            p.ShowDialog();

            if (p.isOK != DialogResult.OK)
                return;
            tEmployee x = p.employee;

            SelectShopEntities db = new SelectShopEntities();
            db.tEmployees.Add(x);
            db.SaveChanges();


            var employees = from s in db.tEmployees
                            select s;
            dataGridView1.DataSource = employees.ToList();
            queryall();
            resetGridStyle();
        }

        private void 產品刪除_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
                return;

            DataGridViewRow r = dataGridView1.SelectedRows[0];

            DataGridViewCell c = r.Cells[1];
            int id = (int)c.Value;
            MessageBox.Show(id + "");

            SelectShopEntities db = new SelectShopEntities();
            tEmployee employee = db.tEmployees.FirstOrDefault(x => x.EmployeeID == id);
            if (employee == null)
                return;

            db.tEmployees.Remove(employee);
            db.SaveChanges();
            queryall();
            resetGridStyle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmpDetail();
            resetGridStyle();

            //string keyword = textBox1.Text;
            bool isColorChange = false;
            
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                isColorChange = !isColorChange;
                r.DefaultCellStyle.BackColor = Color.FromArgb(229, 229, 229);
                if (isColorChange)
                    r.DefaultCellStyle.BackColor = Color.White;
                r.DefaultCellStyle.Font = new Font("微軟正黑體", 12);

                bool isColor = false;

                foreach (DataGridViewCell c in r.Cells)
                {
                    if (c.Value == null)
                        continue;
                    //if (c.Value.ToString().IndexOf(textBox1.Text, StringComparison.InvariantCultureIgnoreCase) >= 0)
                    if (c.Value.ToString().ToLower().Contains(textBox1.Text))
                    {
                        r.DefaultCellStyle.BackColor = Color.Yellow;
                        //c.Style.BackColor = Color.Yellow;
                        isColor = true;
                        break;
                    }

                }
                //if (!isColor)
                //{
                //    foreach (DataGridViewCell c in r.Cells)
                //    { c.Style.BackColor = DefaultBackColor; }
                //}
            }
            
        }

        private void Frm員工明細_Load(object sender, EventArgs e)
        {
            resetGridStyle();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void editBy(int id)
        {
            SelectShopEntities db = new SelectShopEntities();
            tEmployee employee = db.tEmployees.FirstOrDefault(x => x.EmployeeID == id);
            if (employee == null)
                return;

            Frm新增員工 s = new Frm新增員工();
            s.employee = employee;
            s.ShowDialog();

            employee.EmployeeName = s.employee.EmployeeName;
            employee.Cellphone = s.employee.Cellphone;
            employee.Address = s.employee.Address;
            employee.Birthday = s.employee.Birthday;
            employee.Password = s.employee.Password;
            employee.E_mail = s.employee.E_mail;
            employee.EmployeePhoto = s.employee.EmployeePhoto;
            employee.OnBoardDate = s.employee.OnBoardDate;
            employee.DepID = s.employee.DepID;

            db.SaveChanges();
            EmpDetail();
			resetGridStyle();
		}


        private void 員工資料編輯_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                int id = (int)dataGridView1.Rows[rowIndex].Cells[1].Value;
                editBy(id);
            }
        }

		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			int dataColumnNo = dataGridView1.Rows[e.ColumnIndex].Index;

			if (dataColumnNo == 4)
			{
				int EmployeeID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["EmployeeID"].FormattedValue);
				SelectShopEntities db = new SelectShopEntities();
				tEmployee employee = db.tEmployees.FirstOrDefault(x => x.EmployeeID == EmployeeID);
				if (employee != null)
				{
                    if (employee.EmployeePhoto != null)
                    {
                        byte[] bytes = (byte[])(employee.EmployeePhoto);
                        MemoryStream ms = new MemoryStream(bytes);

                        Frm員工照片 f = new Frm員工照片();
                        f.BackgroundImage = Image.FromStream(ms);
                        f.BackgroundImageLayout = ImageLayout.Zoom;

                        f.Show();
                    } else
                    {
                        MessageBox.Show("尚未上傳照片！");
                    }
				}
			}
		}
	}
}
