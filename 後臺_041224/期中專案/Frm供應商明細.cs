using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 期中專案.借放
{
    public partial class Frm供應商明細 : Form
    {
        public Frm供應商明細()
        {
            InitializeComponent();
            detail();
        }

        private void detail()
        {
            SelectShopEntities db = new SelectShopEntities();
            var b = from r in db.tLabels
                    select new { r.LabelID, r.LabelName, r.Address, r.Description, r.SupplierPhoto };
            dataGridView1.DataSource = b.ToList();
            resetGridStyle();
        }

        private void resetGridStyle()
        {
            dataGridView1.Columns[0].HeaderText = "供應商編號";
            dataGridView1.Columns[1].HeaderText = "供應商名稱";
            dataGridView1.Columns[2].HeaderText = "地址";
            dataGridView1.Columns[3].HeaderText = "描述";
            dataGridView1.Columns[4].HeaderText = "供應商照片";
            
            dataGridView1.Columns[1].Width = 400;
            dataGridView1.Columns[2].Width = 400;
            dataGridView1.Columns[3].Width = 400;

            //dataGridView1.Columns[0].HeaderText = "供應商名稱";
            //dataGridView1.Columns[1].HeaderText = "地址";
            //dataGridView1.Columns[2].HeaderText = "描述";
            //dataGridView1.Columns[3].HeaderText = "供應商照片";

            //dataGridView1.Columns[0].Width = 400;
            //dataGridView1.Columns[1].Width = 400;
            //dataGridView1.Columns[2].Width = 400;

            bool isColorChange = false;
            foreach(DataGridViewRow r in dataGridView1.Rows )
            {
                isColorChange = !isColorChange;
                r.DefaultCellStyle.BackColor = Color.FromArgb(229, 229, 229);
                if( isColorChange )
                    r.DefaultCellStyle.BackColor = Color.White;
                    r.DefaultCellStyle.Font = new Font("微軟正黑體", 12);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Frm供應商編輯 s = new Frm供應商編輯();
            s.ShowDialog();

            if (s.isOK != DialogResult.OK)
                return;
            tLabel x = s.label;

            SelectShopEntities select = new SelectShopEntities();
            select.tLabels.Add(x);
            select.SaveChanges();

            detail();
            resetGridStyle();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
                return;

            DataGridViewRow r = dataGridView1.SelectedRows[0];
            if (r.Cells.Count <= 0)
                return;
            DataGridViewCell c = r.Cells[0];
            int id = (int)c.Value;

            SelectShopEntities db = new SelectShopEntities();
			tLabel label = db.tLabels.FirstOrDefault(x => x.LabelID == id);
            if (label == null)
                return;
            db.tLabels.Remove(label);
            db.SaveChanges();

            detail();
            resetGridStyle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            detail();
            resetGridStyle();

            string keyword = textBox1.Text;
            foreach(DataGridViewRow r in dataGridView1.Rows)
            {
                r.DefaultCellStyle.BackColor = Color.White;
                bool isColor = false;

                foreach(DataGridViewCell c in r.Cells)
                {
                    if(c.Value == null)
                        continue;
                    if (c.Value.ToString().ToUpper().Contains(keyword.ToUpper()))
                    {
                        r.DefaultCellStyle.BackColor = Color.Yellow;
                        isColor = true;
                        break;
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Frm供應商明細_Load(object sender, EventArgs e)
        {
            resetGridStyle();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedCells.Count > 0) 
            {
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                int id = (int)dataGridView1.Rows[rowIndex].Cells[0].Value;
                editById(id);
            }
        }

        private void editById(int id)
        {
            SelectShopEntities db = new SelectShopEntities();
            tLabel label = db.tLabels.FirstOrDefault(x => x.LabelID == id);
            if (label == null)
                return;

            Frm供應商編輯 s = new Frm供應商編輯();
            s.label = label;
            s.ShowDialog();

            if (s.isOK != DialogResult.OK)
                return;

            label.LabelName = s.label.LabelName;
            label.Address = s.label.Address;
            label.Description = s.label.Description;
            label.SupplierPhoto = s.label.SupplierPhoto;

            db.SaveChanges();
            detail();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int dataColumnNo = dataGridView1.Rows[e.ColumnIndex].Index;
            if (dataColumnNo == 4) 
            {
                int LabelID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["LabelID"].FormattedValue);
                SelectShopEntities db = new SelectShopEntities();
                tLabel label = db.tLabels.FirstOrDefault(x => x.LabelID == LabelID);
                if (label != null)
                {
                    if (label.SupplierPhoto != null)
                    {
                        byte[] bytes = (byte[])(label.SupplierPhoto);
                        MemoryStream ms = new MemoryStream(bytes);

                        Frm供應商圖片 p = new Frm供應商圖片();
                        p.BackgroundImage = Image.FromStream(ms);
                        p.BackgroundImageLayout = ImageLayout.Zoom;

                        p.Show();
                    } else
                    {
						MessageBox.Show("尚未上傳照片！");
					}
                }
            }
        }
	}
}
