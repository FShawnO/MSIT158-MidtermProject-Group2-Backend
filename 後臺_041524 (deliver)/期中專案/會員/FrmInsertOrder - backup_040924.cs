using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 期中專案;

namespace 期中專案.會員
{
    public partial class FrmInsertOrder : Form
    {
        private DialogResult _isOk;
        private tPurchase _purchase;

        public tPurchase purchase
        {
            get
            {
                if (_purchase == null)
                    _purchase = new tPurchase();
                _purchase.PurchaseID = Convert.ToInt32(fbId.fieldValue);
                //_purchase.OrderID = Convert.ToInt32(fbOrderId.fieldValue);
                //_purchase.ProductID = Convert.ToInt32(fbProductId.fieldValue);
                _purchase.OrderID = fbSOrderId.comboBox1.SelectedIndex + 1;
                _purchase.ProductID = fbSProductId.comboBox1.SelectedIndex + 1;

                return _purchase;
            }
            set
            {
                _purchase = value;
                fbId.fieldValue = _purchase.PurchaseID.ToString();
                fbOrderId.fieldValue = _purchase.OrderID.ToString();
                fbProductId.fieldValue= _purchase.ProductID.ToString();
            }
        }

        public DialogResult isOk //屬性
        { get { return _isOk; } }

        public FrmInsertOrder()
        {
            InitializeComponent();

            LoadtOrderToComboBox();
            LoadtProductToComboBox();
        }

        private void LoadtProductToComboBox()
        {
            try
            {
                SelectShopEntities db = new SelectShopEntities();
                var ps = from r in db.tProducts
                         select r;

                foreach (var x in ps)
                {
                    this.fbSProductId.comboBox1.Items.Add(x.ProductName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //CBStatusId.SelectedIndex = (int)order.StatusID - 1;
        }

        private void LoadtOrderToComboBox()
        {
            try
            {
                SelectShopEntities db = new SelectShopEntities();
                var os = from r in db.tOrders
                          select r;

                foreach (var x in os)
                {
                    this.fbSOrderId.comboBox1.Items.Add(x.OrderID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //CBStatusId.SelectedIndex = (int)order.StatusID - 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _isOk = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _isOk &= DialogResult.Cancel;
            this.Close();
        }

        private void FrmInsertOrder_Load(object sender, EventArgs e)
        {

        }
    }
}
