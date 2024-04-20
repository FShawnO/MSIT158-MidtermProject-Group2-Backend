using Package2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 後台.借放;
using 後台.付帳;
using 後台.會員;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 後台
{
    
    public partial class Frm後台訂單系統 : Form
    {
		public static string str = "";
		public static int employeeID = 0;
		public tEmployee loginMember { get; set; }
		public Frm後台訂單系統()
        {
            InitializeComponent();
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;
            //this.TopMost = true;    
        }

		private void 登入系統ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenLoginSystem();
		}

		private void OpenLoginSystem()
		{
			Log_In f = new Log_In();
			//f.MdiParent = this; //this 是 FrmC_Second
			f.WindowState = FormWindowState.Maximized; //最大化視窗
			f.Show();
		}

		private void queryall()
        {
            SelectShopEntities db = new SelectShopEntities();
            var orders = from o in db.tProducts
                         select o;
        }

        private void ProductUI() 
        {}

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {        }

        //商品
        private void 服飾ToolStripMenuItem_Click(object sender, EventArgs e)
        {
 
        }

        private void 訂單資料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
 
        }

       

        private void 新增商品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
 
        }

        private void 刪除產品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void 開始日期ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 行銷資料ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Frm後台訂單系統_Activated(object sender, EventArgs e)
        {
        }

        private void 新增產品ToolStripMenuItem_Click(object sender, EventArgs e)
        {

           
        }

        private void 刪除產品ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

 

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void 員工資料ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void editById(int id)
        {
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

       

        private void 顯示產品明細() 
        {
            //foreach(Control control in flowLayoutPanel1.Controls) 
            foreach(Control control in splitContainer3.Panel2.Controls) 
            {control.Dispose(); }
			splitContainer3.Panel2.Controls.Clear();

			//flowLayoutPanel1.Controls.Clear();

            Frm產品明細 x = new Frm產品明細();
            x.TopLevel = false;
            x.FormBorderStyle = FormBorderStyle.None; // 設置無邊框樣式
			splitContainer3.Panel2.Controls.Add(x); // 將表單添加至 FlowLayoutPanel 中
			//flowLayoutPanel1.Controls.Add(x); // 將表單添加至 FlowLayoutPanel 中
            //x.Size = flowLayoutPanel1.ClientSize; // 設定表單大小為 FlowLayoutPanel 的大小
            x.Show();
        }

        private void 產品管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            顯示產品明細();
        }

        private void 新增產品ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
 
        }

        private void 刪除產品ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        

        private void 顯示員工明細() 
        {
			//foreach (Control control in flowLayoutPanel1.Controls)
			foreach (Control control in splitContainer3.Panel2.Controls)
			{ control.Dispose(); }
			splitContainer3.Panel2.Controls.Clear();
			//flowLayoutPanel1.Controls.Clear();

			Frm員工明細 x = new Frm員工明細();
			x.TopLevel = false;
			x.FormBorderStyle = FormBorderStyle.None; // 設置無邊框樣式
			splitContainer3.Panel2.Controls.Add(x); // 將表單添加至 FlowLayoutPanel 中
            //flowLayoutPanel1.Controls.Add(x); // 將表單添加至 FlowLayoutPanel 中
			//x.Size = flowLayoutPanel1.ClientSize; // 設定表單大小為 FlowLayoutPanel 的大小
			x.Show();

		}

        private void 員工資料ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            顯示員工明細();
        }

		private void 訂單管理toolStripMenuItem2_Click(object sender, EventArgs e)
		{
            顯示訂單管理();
		}

		private void 顯示訂單管理()
		{
			//foreach (Control control in flowLayoutPanel1.Controls)
			foreach (Control control in splitContainer3.Panel2.Controls)
			{ control.Dispose(); }
			splitContainer3.Panel2.Controls.Clear();
			//flowLayoutPanel1.Controls.Clear();

			FrmOrderList x = new FrmOrderList();
			x.TopLevel = false;
			x.FormBorderStyle = FormBorderStyle.None; // 設置無邊框樣式
			splitContainer3.Panel2.Controls.Add(x); // 將表單添加至 FlowLayoutPanel 中
													//flowLayoutPanel1.Controls.Add(x); // 將表單添加至 FlowLayoutPanel 中
													//x.Size = flowLayoutPanel1.ClientSize; // 設定表單大小為 FlowLayoutPanel 的大小
			x.Show();

		}

		private void 消費紀錄ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			顯示消費紀錄();
		}

		private void 顯示消費紀錄()
		{
			//foreach (Control control in flowLayoutPanel1.Controls)
			foreach (Control control in splitContainer3.Panel2.Controls)
			{ control.Dispose(); }
			splitContainer3.Panel2.Controls.Clear();
			//flowLayoutPanel1.Controls.Clear();

			Frm消費紀錄 x = new Frm消費紀錄();
			x.TopLevel = false;
			x.FormBorderStyle = FormBorderStyle.None; // 設置無邊框樣式
			splitContainer3.Panel2.Controls.Add(x); // 將表單添加至 FlowLayoutPanel 中
													//flowLayoutPanel1.Controls.Add(x); // 將表單添加至 FlowLayoutPanel 中
													//x.Size = flowLayoutPanel1.ClientSize; // 設定表單大小為 FlowLayoutPanel 的大小
			x.Show();

		}

		private void 支付清單ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			顯示支付清單();
		}

		private void 顯示支付清單()
		{
			//foreach (Control control in flowLayoutPanel1.Controls)
			foreach (Control control in splitContainer3.Panel2.Controls)
			{ control.Dispose(); }
			splitContainer3.Panel2.Controls.Clear();
			//flowLayoutPanel1.Controls.Clear();

			FrmPaywayList x = new FrmPaywayList();
			x.TopLevel = false;
			x.FormBorderStyle = FormBorderStyle.None; // 設置無邊框樣式
			splitContainer3.Panel2.Controls.Add(x); // 將表單添加至 FlowLayoutPanel 中
													//flowLayoutPanel1.Controls.Add(x); // 將表單添加至 FlowLayoutPanel 中
													//x.Size = flowLayoutPanel1.ClientSize; // 設定表單大小為 FlowLayoutPanel 的大小
			x.Show();

		}

		private void 新增員工ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void 刪除員工ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void Frm後台訂單系統_SizeChanged(object sender, EventArgs e)
        {
        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Frm後台訂單系統_Deactivate(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Minimized;
        }

		private void 行銷活動toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			顯示活動列表();
		}

		private void 顯示活動列表()
		{
			//foreach (Control control in flowLayoutPanel1.Controls)
			foreach (Control control in splitContainer3.Panel2.Controls)
			{ control.Dispose(); }
			splitContainer3.Panel2.Controls.Clear();

			Frm行銷活動 x = new Frm行銷活動();
			x.TopLevel = false;
			x.FormBorderStyle = FormBorderStyle.None; // 設置無邊框樣式
			splitContainer3.Panel2.Controls.Add(x); // 將表單添加至 FlowLayoutPanel 中
			x.Size = splitContainer3.Panel2.ClientSize; // 設定表單大小為 FlowLayoutPanel 的大小
			x.Show();
		}

        private void 新增包裝盒_Click(object sender, EventArgs e)
        {
            foreach (Control control in splitContainer3.Panel2.Controls)
            { control.Dispose(); }
            splitContainer3.Panel2.Controls.Clear();

            FrmAddPackage addP = new FrmAddPackage();
            addP.TopLevel = false;
            addP.FormBorderStyle = FormBorderStyle.None; // 設置無邊框樣式
            splitContainer3.Panel2.Controls.Add(addP); // 將表單添加至 FlowLayoutPanel 中
            addP.Size = splitContainer3.Panel2.ClientSize; // 設定表單大小為 FlowLayoutPanel 的大小
            addP.Show();
        }

        private void 供應商管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Control control in splitContainer3.Panel2.Controls)
            { control.Dispose(); }
            splitContainer3.Panel2.Controls.Clear();

            Frm供應商明細 x= new Frm供應商明細();
            x.TopLevel = false;
            x.FormBorderStyle = FormBorderStyle.None; // 設置無邊框樣式
            splitContainer3.Panel2.Controls.Add(x); // 將表單添加至 FlowLayoutPanel 中
            x.Size = splitContainer3.Panel2.ClientSize; // 設定表單大小為 FlowLayoutPanel 的大小
            x.Show();
        }

		private void Frm後台訂單系統_Load(object sender, EventArgs e)
		{
			Log_In f = new Log_In();
			f.ShowDialog();
			this.loginMember = f.auth;
			this.Text = "歡迎" + this.loginMember.EmployeeName + "登入";
			str = this.loginMember.EmployeeName;
			employeeID = this.loginMember.EmployeeID;
		}

		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

		private void 會員資料ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			顯示會員明細();
		}

		private void 顯示會員明細()
		{
			//foreach (Control control in flowLayoutPanel1.Controls)
			foreach (Control control in splitContainer3.Panel2.Controls)
			{ control.Dispose(); }
			splitContainer3.Panel2.Controls.Clear();
			//flowLayoutPanel1.Controls.Clear();

			Frm會員明細 x = new Frm會員明細();
			x.TopLevel = false;
			x.FormBorderStyle = FormBorderStyle.None; // 設置無邊框樣式
			splitContainer3.Panel2.Controls.Add(x); // 將表單添加至 FlowLayoutPanel 中
													//flowLayoutPanel1.Controls.Add(x); // 將表單添加至 FlowLayoutPanel 中
													//x.Size = flowLayoutPanel1.ClientSize; // 設定表單大小為 FlowLayoutPanel 的大小
			x.Show();

		}
	}
}
