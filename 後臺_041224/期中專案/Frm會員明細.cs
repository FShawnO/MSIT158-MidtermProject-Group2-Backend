using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 期中專案
{
    public partial class Frm會員明細 : Form
    {
        public Frm會員明細()
        {
            InitializeComponent();
            memberdetail();
            resetGridStyle();
        }
        private void memberdetail() 
        {
            SelectShopEntities db = new SelectShopEntities();
            var memebers = from m in db.tMembers
                           select new { m.MemberID, m.MemberName, m.E_mail, m.Points, m.VIP, m.Wallet };
            dataGridView1.DataSource = memebers.ToList();
        
        }

        //private void queryall() 
        //{
        //    SelectShopEntities db = new SelectShopEntities();
        //    var memeber = from m in db.tMembers
        //                   select new { m.MemberID, m.MemberName, m.E_mail, m.Points, m.VIP, m.Wallet };
        //    dataGridView1.DataSource = memeber.ToList();

        //}

        private void resetGridStyle() 
        {
            dataGridView1.Columns[0].HeaderText = "會員編號";
            dataGridView1.Columns[1].HeaderText = "會員姓名";
            dataGridView1.Columns[2].HeaderText = "會員電子郵件";
            dataGridView1.Columns[3].HeaderText = "會員點數";
            dataGridView1.Columns[4].HeaderText = "VIP";
            dataGridView1.Columns[5].HeaderText = "會員錢包";

            dataGridView1.Columns[2].Width = 230;

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

        private void Frm會員明細_Load(object sender, EventArgs e)
        {
            resetGridStyle();
        }

        private void 產品刪除_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
                return;

            DataGridViewRow r = dataGridView1.SelectedRows[0];

            DataGridViewCell c = r.Cells[0];
            int id = (int)c.Value;
            MessageBox.Show(id + "");

            SelectShopEntities db = new SelectShopEntities();
            tMember member = db.tMembers.FirstOrDefault(x => x.MemberID == id);
            if (member == null)
                return;

            db.tMembers.Remove(member);
            db.SaveChanges();
            memberdetail();
            resetGridStyle();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            memberdetail();
            resetGridStyle();

       
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
          
            }
        }
        private void 會員資料編輯_Click(object sender, EventArgs e)
        {
          
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
				int id = (int)dataGridView1.Rows[rowIndex].Cells[0].Value;
				editBy(id);
				// int id;
				//if (dataGridView1.Rows[rowIndex].Cells[0].Value != null && int.TryParse(dataGridView1.Rows[rowIndex].Cells[1].Value.ToString(), out id))
				//{ edit(id); }
				//else
				//{
				//    // 如果無法將值轉換為int，則顯示錯誤或採取其他適當的操作
				//    MessageBox.Show("無效的ID值。");
				//}
			}
        }

        private void editBy(int id)
        {
            SelectShopEntities db = new SelectShopEntities();
            tMember member = db.tMembers.FirstOrDefault(x => x.MemberID == id);
            if (member == null)
                return;

            Frm編輯會員 s = new Frm編輯會員();
            s.memeber = member;
            s.ShowDialog();

            

            member.MemberName = s.memeber.MemberName;
            member.E_mail = s.memeber.E_mail;
            member.Cellphone = s.memeber.Cellphone;
            member.Address = s.memeber.Address;
            member.Birthday = s.memeber.Birthday;
            member.Points = s.memeber.Points;
            member.VIP = s.memeber.VIP;
            member.Wallet = s.memeber.Wallet;


            db.SaveChanges();
            memberdetail();
            resetGridStyle();
           
        }

		private void 產品新增_Click(object sender, EventArgs e)
		{
			Frm編輯會員 m = new Frm編輯會員();
			m.ShowDialog();

			if (m.isOK != DialogResult.OK)
				return;
			tMember x = m.memeber;

			SelectShopEntities db = new SelectShopEntities();
			db.tMembers.Add(x);
			db.SaveChanges();
		}
	}
    }
