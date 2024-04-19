using 期中專案.付帳;
using 期中專案.會員;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 期中專案;

namespace 期中專案
{
    public delegate void DMember();

    public partial class FrmC_Second : Form
    {
        public static string str = "";
        public static int memberID = 0;
        public static int stateID = 0;
        public event DMember dmember;
        public tMember loginMember { get; set; }

        public FrmC_Second()
        {
            InitializeComponent();
            
            //Log_In f = new Log_In();            
            //this.loginMember = f.auth;
            //this.Text = "歡迎" + this.loginMember.fMemberName + "登入";
            //string dmember = this.loginMember.fMemberName;
        }

        private void 登入系統ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenLoginSystem();
        }

        private void OpenLoginSystem()
        {
            Log_In f = new Log_In();
            f.MdiParent = this; //this 是 FrmC_Second
            f.WindowState = FormWindowState.Maximized; //最大化視窗
            f.Show();
        }

        private void 結束ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 關閉視窗ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null) //null 記憶體沒有位置要去呼叫
                this.ActiveMdiChild.Close();
        }

        private void 關閉所有視窗ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            while (this.ActiveMdiChild != null) //null 記憶體沒有位置要去呼叫
                this.ActiveMdiChild.Close();
        }

        private void 水平排列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void 垂直排列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void 階梯式排列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenLoginSystem();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null) //null 記憶體沒有位置要去呼叫
                this.ActiveMdiChild.Close();
        }

        private void 會員ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenMember1System();
        }

        private void OpenMember1System()
        {
            Member1 f = new Member1();
            f.MdiParent = this; //this 是 FrmC_Second
            f.WindowState = FormWindowState.Maximized; //最大化視窗
            f.Show();
        }

        private void 註冊ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenMember2System();
        }

        private void OpenMember2System()
        {
            Member2 f = new Member2();
            f.MdiParent = this; //this 是 FrmC_Second
            f.WindowState = FormWindowState.Maximized; //最大化視窗
            f.Show();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            OpenMember1System();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            OpenMember2System();
        }

        private void 付帳一ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCreditCard1System();
        }

        private void OpenCreditCard1System()
        {
            FrmPayWay f = new FrmPayWay();
            f.MdiParent = this; //this 是 FrmC_Second
            f.WindowState = FormWindowState.Maximized; //最大化視窗
            f.Show();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            OpenCreditCard1System();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            FrmPaywayList f = new FrmPaywayList();
            f.MdiParent = this; //this 是 FrmC_Second
            f.WindowState = FormWindowState.Maximized; //最大化視窗
            f.Show();
        }

        private void FrmC_Second_Load(object sender, EventArgs e)
        {
            Log_In f = new Log_In();
            f.ShowDialog();
            this.loginMember = f.auth;
            this.Text = "歡迎" + this.loginMember.MemberName + "登入";
            str = this.loginMember.MemberName;
            memberID = this.loginMember.MemberID;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Credit_Card f = new Credit_Card();
            f.MdiParent = this; //this 是 FrmC_Second
            f.WindowState = FormWindowState.Maximized; //最大化視窗
            f.Show();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            FrmOrderList f = new FrmOrderList();
            f.MdiParent = this; //this 是 FrmC_Second
            f.WindowState = FormWindowState.Maximized; //最大化視窗
            f.Show();
        }
    }
}
