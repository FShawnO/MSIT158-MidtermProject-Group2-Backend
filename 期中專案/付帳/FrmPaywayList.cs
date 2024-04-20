using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 後台.付帳
{
    public partial class FrmPaywayList : Form
    {
        public FrmPaywayList()
        {
            InitializeComponent();
        }

        private void FrmPaywayList_Load(object sender, EventArgs e)
        {
            queryAll();
        }

        private void queryAll()
        {
            SelectShopEntities db = new SelectShopEntities();
            var pays = from r in db.tPayTypes
                       select r;
            dataGridView1.DataSource = pays.ToList();
            resetGridStyle();
        }

        private void resetGridStyle()
        {
            dataGridView1.Columns[0].HeaderText = "別號";
            dataGridView1.Columns[1].HeaderText = "支付類別";
            dataGridView1.Columns[2].HeaderText = "支付圖示";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 100;

            bool isColorChanged = false;
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                isColorChanged = !isColorChanged;
                r.DefaultCellStyle.BackColor = Color.FromArgb(229, 229, 229);
                if (isColorChanged)
                    r.DefaultCellStyle.BackColor = Color.White;
                r.DefaultCellStyle.Font = new Font("微軟正黑體", 12); // new Font 設字形
            }
        }

        private void FrmPaywayList_Activated(object sender, EventArgs e)
        {
            resetGridStyle();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FrmPay f = new FrmPay();
            f.ShowDialog();
            if (f.isOk != DialogResult.OK)
                return;
            tPayType x = f.pay;

            //======================== 加入資料表
            SelectShopEntities db = new SelectShopEntities();
            db.tPayTypes.Add(x);
            db.SaveChanges();
            queryAll();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
                return;
            DataGridViewRow r = dataGridView1.SelectedRows[0];
            if (r.Cells.Count <= 0)
                return;
            DataGridViewCell c = r.Cells[0];
            int id = (int)c.Value;

            //============刪除
            SelectShopEntities db = new SelectShopEntities();
            tPayType pay = db.tPayTypes.FirstOrDefault(x => x.PayTypeID == id);
            if (pay == null)
                return;
            db.tPayTypes.Remove(pay);
            db.SaveChanges();
            //=============要顯示更新資料
            queryAll();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            editById(id);
        }

        private void editById(int id)
        {
            SelectShopEntities db = new SelectShopEntities();
            tPayType pay = db.tPayTypes.FirstOrDefault(x => x.PayTypeID == id);
            if (pay == null)
                return;

            FrmPay f = new FrmPay();
            f.pay = pay;
            f.ShowDialog();

            if (f.isOk != DialogResult.OK)
                return;
            pay.PayTypeName = f.pay.PayTypeName;
            db.SaveChanges();
            queryAll();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            bool isColorChanged = false;
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                isColorChanged = !isColorChanged;
                r.DefaultCellStyle.BackColor = Color.FromArgb(229, 229, 229);
                if (isColorChanged)
                    r.DefaultCellStyle.BackColor = Color.White;
                r.DefaultCellStyle.Font = new Font("微軟正黑體", 12); // new Font 設字形

                foreach (DataGridViewCell c in r.Cells)
                {
                    if (c.Value == null)
                        continue; //因為資料表中有null，程式會出現錯誤
                    if (c.Value.ToString().Contains(txtKeyword.Text))
                    {
                        r.DefaultCellStyle.BackColor = Color.Yellow;
                        break;
                    }
                }
            }
        }
    }
}
