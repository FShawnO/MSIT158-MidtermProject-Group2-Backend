using 期中專案.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using 期中專案;

namespace 期中專案.會員
{
    public partial class FrmOrder : Form
    {
        private DialogResult _isOk;
        private tPurchase _purchase;
        private tOrder _order;
        private tProduct _product;
        private tStatu _statu;
        private tMember _member;

        public tOrder order
        {
            get
            {
                if (_order == null)
                    _order = new tOrder();
                _order.OrderID = Convert.ToInt32(fbOrderId.fieldValue);
                //_order.MemberID = Convert.ToInt32(fbMemberId.fieldValue);

                //_order.fOrderProductName = fbProductName.fieldValue;
                //_order.fOrderPrice = Convert.ToDecimal(fbPrice.fieldValue);
                _order.StatusID = CBStatusId.SelectedIndex + 1;

                _order.StatusID = fbStatusId.comboBox1.SelectedIndex + 1;
                return _order;
            }
            set
            {
                _order = value;
                fbOrderId.fieldValue = _order.OrderID.ToString();
                fbMemberId.fieldValue = _order.MemberID.ToString();

                //fbProductName.fieldValue = _order.fOrderProductName;
                //fbPrice.fieldValue = _order.fOrderPrice.ToString();
                CBStatusId.SelectedIndex = (int)_order.StatusID - 1;

                fbStatusId.comboBox1.SelectedIndex = (int)_order.StatusID - 1;
            }
        }

        public tProduct product
        {
            get
            {
                if (_product == null)
                    _product = new tProduct();
                _product.ProductID = Convert.ToInt32(fbProductId.fieldValue);
                _product.ProductName = fbProductName.fieldValue;
                _product.UnitPrice = Convert.ToDecimal(fbPrice.fieldValue);
                return _product;
            }
            set
            {
                _product = value;
                fbProductId.fieldValue = _product.ProductID.ToString();
                fbProductName.fieldValue = _product.ProductName;
                fbPrice.fieldValue = _product.UnitPrice.ToString();
            }
        }

        public tPurchase purchase
        {
            get
            {
                if (_purchase == null)
                    _purchase = new tPurchase();
                _purchase.PurchaseID = Convert.ToInt32(fbId.fieldValue);
                _purchase.Qty = fbQty.comboBox1.SelectedIndex + 1;
                return _purchase;
            }
            set
            {
                _purchase = value;
                fbId.fieldValue = _purchase.PurchaseID.ToString();
                fbQty.comboBox1.Text = _purchase.Qty.ToString();
            }
        }

        public tStatu statu
        {
            get
            {
                if (_statu == null)
                    _statu = new tStatu();
                _statu.StatusID = Convert.ToInt32(fbStatusId.statusValue);
                //_statu.StatusID = Convert.ToInt32(CBStatusId.SelectedIndex);
                return _statu;
            }
            set
            {
                _statu = value;
                fbStatusId.statusValue = _statu.StatusName;
            }
        }

        public tMember member
        {
            get
            {
                if (_member == null)
                    _member = new tMember();
                _member.MemberID = fbMemberName.comboBox1.SelectedIndex + 2;
                return _member;
            }
            set
            {
                _member = value;
                fbMemberName.statusValue = _member.MemberName;
            }
        }

        public DialogResult isOk //屬性
        { get { return _isOk; } }

        public FrmOrder()
        {
            InitializeComponent();
            LoadStatusToComboBox();
            LoadQtyToComboBox();
            LoadMemberToComboBox();
        }

        private void LoadMemberToComboBox()
        {
            try
            {
                SelectShopEntities db = new SelectShopEntities();
                var ms = from r in db.tMembers
                         select r;

                foreach (var x in ms)
                {
                    this.fbMemberName.comboBox1.Items.Add(x.MemberName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadQtyToComboBox()
        {
            for (int i = 1; i <= 20; i++) { fbQty.comboBox1.Items.Add(i); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _isOk = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _isOk = DialogResult.Cancel;
            this.Close();
        }

        private void FrmOrder_Load(object sender, EventArgs e)
        {
           // LoadStatusToComboBox();
        }

        private void LoadStatusToComboBox()
        {
            try
            {
                SelectShopEntities db = new SelectShopEntities();
                var ops = from r in db.tStatus
                                   select r;

                foreach (var x in ops)
                {
                    //this.fbStatusId.statusValue.Clear();
                    this.fbStatusId.comboBox1.Items.Add(x.StatusName);
                    //this.fbStatusId.statusValue.SelectedIndex = 0;
                    //this.CBStatusId.DataSource = x.StatusID.ToString();
                    this.CBStatusId.Items.Add(x.StatusName);
                }
                //this.CBStatusId.SelectedIndex = _statu.StatusID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //CBStatusId.SelectedIndex = (int)order.StatusID - 1;
        }
    }
}
