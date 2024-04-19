using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 期中專案;
using static Package2.Models.ClassA;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Package2
{
    public partial class FrmAddPackage : Form
    {
        private CImageCopy ImageCopy;

        public FrmAddPackage()
        {
            InitializeComponent();
			ImageCopy = new CImageCopy();  // 初始化執行個體;
            //new colorItem();

			CoBoxItem();
            //CoMaterial();
        }

        private List<StyleItem> styleItems;
		private Box _tBox;
        public Box tBox
        {
            get
            {
                if (_tBox == null)
                {
                    _tBox = new Box();
                }

                _tBox.BoxType = titleTextBox1.fieldValue.ToString();
                if (richTextBox1 != null) _tBox.Description = richTextBox1.Text;
                if (ImageCopy.ImagePath != null) _tBox.Picture = ImageCopy.ImagePath;
                StyleItem selectedStyle = (StyleItem)comboBox1.SelectedItem;
                if (selectedStyle != null) _tBox.PStlyeID = selectedStyle.PStyleID;
                if (comboBox2 != null) _tBox.MaterialID = GetMaID();
                if (titleTextBox5 != null) _tBox.Price = Int32.Parse(titleTextBox5.fieldValue);


                return _tBox;
            }
        }

        private Bag _tBag;
        public Bag tBag
        {
            get
            {
                if (_tBag == null)
                {
                    _tBag = new Bag();
                }

                _tBag.BagType = titleTextBox1.fieldValue.ToString();
                if (richTextBox1 != null) _tBag.Description = richTextBox1.Text;
                if (ImageCopy.ImagePath != null) _tBag.Picture = ImageCopy.ImagePath;
                StyleItem selectedStyle = (StyleItem)comboBox1.SelectedItem;
                if (selectedStyle != null) _tBag.PStlyeID = selectedStyle.PStyleID;
                if (comboBox2 != null) _tBag.MaterialID = GetMaID();
                if (titleTextBox5 != null) _tBag.Price = Int32.Parse(titleTextBox5.fieldValue);

                return _tBag;
            }
        }

        private Card _tCard;
        public Card tCard
        {
            get
            {
                if (_tCard == null)
                {
                    _tCard = new Card();
                }

                _tCard.CardType = titleTextBox1.fieldValue.ToString();
                if (richTextBox1 != null) _tCard.Description = richTextBox1.Text;
                if (ImageCopy.ImagePath != null) _tCard.Picture = ImageCopy.ImagePath;
                StyleItem selectedStyle = (StyleItem)comboBox1.SelectedItem;
                if (selectedStyle != null) _tCard.PStlyeID = selectedStyle.PStyleID;
                if (titleTextBox5 != null) _tCard.Price = Int32.Parse(titleTextBox5.fieldValue);

                return _tCard;
            }
        }

        private void CoBoxItem()
        {
            SelectShopEntities DB = new SelectShopEntities();
            var styleItems =( from s in DB.GiftPackageStyles
                             //select s.StyleName;
                select new StyleItem { StyleName = s.StyleName, PStyleID = s.PStlyeID }).ToList();

            foreach (var item in styleItems)
            {
				comboBox1.Items.Add(item);
            }

        }

        private void CoMaterial()
        {

            SelectShopEntities DB = new SelectShopEntities();
            var materialItems = (from m in DB.packageMaterials
                                select m.MaterialName).Distinct();

            
            foreach (var item in materialItems)
                {
                    comboBox2.Items.Add(item);
                }
     
        }

        private void CoMaColor()
        {
           
            SelectShopEntities DB = new SelectShopEntities();
            comboBox3.Items.Clear();

            string maName = this.comboBox2.SelectedItem.ToString();

            var colorItems = (from m in DB.packageMaterials
                              join c in DB.MaterialColors on m.ColorID equals c.ColorID
                              where m.MaterialName == maName
                              select new colorItem { colorName = c.ColorName, colorID = c.ColorID }).Distinct();

            //var colorItems = (from m in DB.packageMaterial
            //                  join c in DB.MaterialColor on m.ColorID equals c.ColorID
            //                  where m.MaterialName == maName
            //                  select c.ColorName).Distinct();

            foreach (var item in colorItems)
            {
                comboBox3.Items.Add(item);
            }
        }

        private int? GetMaID() 
        {
            string maName= this.comboBox2.SelectedItem.ToString();
            
            SelectShopEntities DB = new SelectShopEntities();
            colorItem selectcolor = (colorItem)comboBox3.SelectedItem;
            var maID = (from i in DB.packageMaterials
                     where i.MaterialName == maName && i.ColorID == selectcolor.colorID
                     select i.MaterialID).FirstOrDefault();

            return maID;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ImageCopy = new CImageCopy();
            pictureBox1.Image = ImageCopy.SelectImage();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectShopEntities DB = new SelectShopEntities();

            if (comboBox1.SelectedIndex == 0)
            {
                var images = from i in DB.Boxes
                             select i;

                this.dataGridView1.DataSource = images.ToList();
                comboBox2.Items.Clear();
                comboBox2.Text = null;

				comboBox3.Items.Clear();
				comboBox3.Text = null;
				CoMaterial();

            }else if (comboBox1.SelectedIndex == 1)
            {
                var images = from i in DB.Bags
                             select i;

                this.dataGridView1.DataSource = images.ToList();
                comboBox2.Items.Clear();
				comboBox2.Text = null;
				comboBox3.Items.Clear();
				comboBox3.Text = null;
				CoMaterial();
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                var images = from i in DB.Cards
                             select i;
                this.dataGridView1.DataSource = images.ToList();
                //comboBox2.Text.Clear();
                comboBox2.Items.Clear();
				comboBox2.Text = null;
				comboBox3.Items.Clear();
				comboBox3.Text = null;
			}
        }

        private void button1_Click(object sender, EventArgs e)
        {
          //  MessageBox.Show(comboBox1.SelectedIndex.ToString());
            if (titleTextBox1.fieldValue == "") MessageBox.Show("樣式名稱為必填欄位");

            if (comboBox1.SelectedIndex == 0 && titleTextBox1.fieldValue != "")
            {
                Box b = tBox;

                SelectShopEntities DB = new SelectShopEntities();
                DB.Boxes.Add(b);
                DB.SaveChanges();

				comboBox1_SelectedIndexChanged(sender, e);
				// Close();
			}
            else if (comboBox1.SelectedIndex == 1 && titleTextBox1.fieldValue != "")
            {
                Bag bg = tBag;

                SelectShopEntities DB = new SelectShopEntities();
                DB.Bags.Add(bg);
                DB.SaveChanges();

				comboBox1_SelectedIndexChanged(sender, e);
				// Close();
			}
            else if (comboBox1.SelectedIndex == 2 && titleTextBox1.fieldValue != "")
            {
                Card c = tCard;

                SelectShopEntities DB = new SelectShopEntities();
                DB.Cards.Add(c);
                DB.SaveChanges();

				comboBox1_SelectedIndexChanged(sender, e);
				// Close();
			}
            else MessageBox.Show("沒有此分類");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                CoMaColor();
                comboBox3.Text = null;
            }
        }

		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			int dataColumnNo = dataGridView1.Rows[e.ColumnIndex].Index;
            if (dataColumnNo == 3)
            {

                SelectShopEntities db = new SelectShopEntities();
                if (comboBox1.SelectedIndex == 0)
                {
                    int BoxID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["BoxID"].FormattedValue);

                    Box box = db.Boxes.FirstOrDefault(x => x.BoxID == BoxID);
                    if (box != null)
                    {
                        if (!string.IsNullOrEmpty(box.Picture))
                        {
                            string path = Application.StartupPath + "\\packageImages";
                            Frm包裝圖片 f = new Frm包裝圖片();
                            f.BackgroundImage = Image.FromFile(Path.Combine(path, @box.Picture));
                            f.BackgroundImageLayout = ImageLayout.Zoom;

                            f.Show();
                        } else
                        {
							MessageBox.Show("尚未上傳圖片！");
						}
                    }
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    int BagID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["BagID"].FormattedValue);

                    Bag bag = db.Bags.FirstOrDefault(x => x.BagID == BagID);
                    if (bag != null)
                    {
                        if (!string.IsNullOrEmpty(bag.Picture))
                        {
                            string path = Application.StartupPath + "\\packageImages";
                            Frm包裝圖片 f = new Frm包裝圖片();
                            f.BackgroundImage = Image.FromFile(Path.Combine(path, @bag.Picture));
                            f.BackgroundImageLayout = ImageLayout.Zoom;

                            f.Show();
                        } else
                        {
							MessageBox.Show("尚未上傳圖片！");
						}
                    }
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    int CardID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["CardID"].FormattedValue);

                    Card card = db.Cards.FirstOrDefault(x => x.CardID == CardID);
                    if (card != null)
                    {
                        if (!string.IsNullOrEmpty(card.Picture))
                        {
                            string path = Application.StartupPath + "\\packageImages";
                            Frm包裝圖片 f = new Frm包裝圖片();
                            f.BackgroundImage = Image.FromFile(Path.Combine(path, @card.Picture));
                            f.BackgroundImageLayout = ImageLayout.Zoom;

                            f.Show();
                        } else
                        {
							MessageBox.Show("尚未上傳圖片！");
						}
                    }
                }
            }
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count <= 0)
				return;

			if (MessageBox.Show("確定要將包裝刪除嗎？", "刪除確認！", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes) {

				DataGridViewRow r = dataGridView1.SelectedRows[0];
				if (r.Cells.Count <= 0)
					return;
				DataGridViewCell c = r.Cells[0];
				int id = (int)c.Value;

				SelectShopEntities db = new SelectShopEntities();
				string path = Path.Combine(Application.StartupPath, "packageImages");

				if (comboBox1.SelectedIndex == 0)
                {
					Box box = db.Boxes.FirstOrDefault(x => x.BoxID == id);
					if (box == null)
						return;
					db.Boxes.Remove(box);
					db.SaveChanges();
					
					path = Path.Combine(path, box.Picture);
					if (File.Exists(path))
					{
						File.Delete(path);
					}
					comboBox1_SelectedIndexChanged(sender, e);
                    // Close();
                }
                else if (comboBox1.SelectedIndex == 1)
                {
					Bag bag = db.Bags.FirstOrDefault(x => x.BagID == id);
					if (bag == null)
						return;
					db.Bags.Remove(bag);
					db.SaveChanges();

					path = Path.Combine(path, bag.Picture);
					if (File.Exists(path))
					{
						File.Delete(path);
					}
					comboBox1_SelectedIndexChanged(sender, e);
                    // Close();
                }
                else if (comboBox1.SelectedIndex == 2)
                {
					Card card = db.Cards.FirstOrDefault(x => x.CardID == id);
					if (card == null)
						return;
					db.Cards.Remove(card);
					db.SaveChanges();

					path = Path.Combine(path, card.Picture);
					if (File.Exists(path))
					{
						File.Delete(path);
					}

					comboBox1_SelectedIndexChanged(sender, e);
                    // Close();
                }
            }
		}
	}
}
