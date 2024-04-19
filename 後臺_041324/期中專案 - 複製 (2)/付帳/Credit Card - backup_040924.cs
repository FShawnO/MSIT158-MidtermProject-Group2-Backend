using 期中專案.會員;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 期中專案;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 期中專案.付帳
{
    public delegate void DMemberConfirm(Credit_Card p);

    public partial class Credit_Card : Form
    {
        public event DMemberConfirm memberConfirm;
        private DialogResult _isOk;
        private tOrder _order;
        public tOrder order { get { return _order; } }
        private tMember _member;
        public tMember member {
            get { return _member; }
			set
			{
				_member = value;
			}
        }

		private tStatu _state;
        public tStatu state { get { return _state; } }

        public DialogResult isOk { get { return _isOk; } }

        public Credit_Card()
        {
            InitializeComponent();
        }

        private void Credit_Card_Load(object sender, EventArgs e)
        {
            string str = "";
            string str2 = "";
            int total = 0;
            int points = 0;
            int moneys = 0;
            int stateid = 0;
            this.label1.Text = FrmC_Second.str;

            SelectShopEntities db = new SelectShopEntities();
            var orders = from r in db.tPurchases
                         where r.tOrder.MemberID == _member.MemberID
                         select new
                         {
                             R = r.tOrder,
                             P = r.tOrder.tMember,
                             K = r.tOrder.tStatu,
                             L = r.tProduct
                         };
            foreach (var x in orders)
            {
                total += (int)x.L.UnitPrice;
                str += x.L.ProductName + ",";
                points = x.P.Points ==  null ? 0 : (int)x.P.Points;
                moneys = x.P.Wallet == null ? 0 : (int)x.P.Wallet;
                str2 = x.K.StatusName;
                stateid = (int)x.R.StatusID;
            }
            fbTotalPrice.fieldValue = total.ToString();
            fbPoint.fieldValue = (total / 10).ToString();
            fbUsePoint.fieldValue = (total / 10 + 10).ToString();
            fbName.fieldValue = str;
            fbAllPoint.fieldValue = points.ToString();
            fbExpectedPoint.fieldValue = ((total / 10) + points - (total / 10 + 10)).ToString();
            fbPrice.fieldValue = (total - (total / 10 + 10)).ToString();
            fbDeposit.fieldValue = (moneys - (total - (total / 10 + 10))).ToString();
            fbState.fieldValue = str2;
            fbStateId.fieldValue = stateid.ToString();       
            
            if (stateid == 2) { button1.Enabled = false; }
            //=====================新增資料語法


        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            int j = 0;
            int m = 0;
            int n = 0;
            try
            {
                if (this.memberConfirm != null)
                    this.memberConfirm(this);
                _isOk = DialogResult.OK;

                SelectShopEntities db = new SelectShopEntities();
                var orders = from r in db.tPurchases
                             select new
                             {
                                 R = r.tOrder,
                                 P = r.tOrder.tMember,
                                 K = r.tOrder.tStatu,
                                 L = r.tProduct
                             };

                bool aa = int.TryParse(fbExpectedPoint.fieldValue, out i);
                bool bb = int.TryParse(fbDeposit.fieldValue, out j);
                bool cc = int.TryParse(fbStateId.fieldValue, out m);
                foreach (var x in orders)
                {
                    if (!aa && bb && cc) return;
                    x.P.Points = i;
                    x.P.Wallet = j;
                    if (m >= 2)
                        return;
                    x.R.StatusID = m + 1;
                }
                //要修改的(確認) 1.預計消費後點數(fbExpectedPoint) 2.存款(De) 3.狀態(St)

                //_member.fMemberPrice = moneys - (total - (total / 10 + 10));
                //_member.fMemberPoint = (total / 10) + points - (total / 10 + 10);
                //_order.fOrderStateID = state + 1;

                //tMember member = db.tMember.FirstOrDefault(x => x.fMemberID == FrmC_Second.memberID);
                //if (member == null)
                //    return;

                //member.fMemberID = _member.fMemberID;
                //member.fMemberPrice= _member.fMemberPrice;
                //member.fMemberPoint = _member.fMemberPoint;
                //tOrder2 order = db.tOrder2.FirstOrDefault(x => x.fMemberID == FrmC_Second.memberID && x.fOrderStateID== state);
                //if(order == null) return;
                //order.fOrderStateID= _order.fOrderStateID;

                db.SaveChanges();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _isOk = DialogResult.Cancel;
            this.Close();
        }
    }
}
