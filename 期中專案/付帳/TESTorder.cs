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
    public partial class TESTorder : Form
    {
        public TESTorder()
        {
            InitializeComponent();
        }

        private void TEST_Load(object sender, EventArgs e)
        {
            SelectShopEntities db = new SelectShopEntities();
            var orders = from r in db.tPurchases.AsEnumerable()
                         select new
                         {
                             A = r,
                             B = r.tOrder,
                             C = r.tProduct
                         };
            dataGridView1.DataSource = orders.ToList();
        }
    }
}
