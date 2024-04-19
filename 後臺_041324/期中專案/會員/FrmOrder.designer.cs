namespace 期中專案.會員
{
    partial class FrmOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CBStatusId = new System.Windows.Forms.ComboBox();
            this.fbStatusId = new 期中專案.付帳.StatusBox();
            this.fbProductId = new prjComponentDemo.usercontrol.FieldBox();
            this.fbId = new prjComponentDemo.usercontrol.FieldBox();
            this.fbPrice = new prjComponentDemo.usercontrol.FieldBox();
            this.fbProductName = new prjComponentDemo.usercontrol.FieldBox();
            this.fbMemberId = new prjComponentDemo.usercontrol.FieldBox();
            this.fbOrderId = new prjComponentDemo.usercontrol.FieldBox();
            this.fbQty = new 期中專案.付帳.StatusBox();
            this.fbMemberName = new 期中專案.付帳.StatusBox();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button2.Location = new System.Drawing.Point(206, 395);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 43);
            this.button2.TabIndex = 7;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(495, 395);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 43);
            this.button1.TabIndex = 6;
            this.button1.Text = "確定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(17, 386);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(766, 2);
            this.label1.TabIndex = 5;
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(365, 305);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 29);
            this.label2.TabIndex = 11;
            this.label2.Text = "狀態編號";
            this.label2.Visible = false;
            // 
            // CBStatusId
            // 
            this.CBStatusId.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CBStatusId.FormattingEnabled = true;
            this.CBStatusId.Location = new System.Drawing.Point(358, 337);
            this.CBStatusId.Name = "CBStatusId";
            this.CBStatusId.Size = new System.Drawing.Size(121, 37);
            this.CBStatusId.TabIndex = 12;
            this.CBStatusId.Visible = false;
            // 
            // fbStatusId
            // 
            this.fbStatusId.Location = new System.Drawing.Point(529, 305);
            this.fbStatusId.Name = "fbStatusId";
            this.fbStatusId.Size = new System.Drawing.Size(195, 71);
            this.fbStatusId.statusName = "出售狀態編號";
            this.fbStatusId.statusValue = "1.2.3.";
            this.fbStatusId.TabIndex = 10;
            // 
            // fbProductId
            // 
            this.fbProductId.fieldName = "產品編號";
            this.fbProductId.fieldValue = "";
            this.fbProductId.Location = new System.Drawing.Point(529, 58);
            this.fbProductId.Name = "fbProductId";
            this.fbProductId.Size = new System.Drawing.Size(195, 74);
            this.fbProductId.TabIndex = 9;
            // 
            // fbId
            // 
            this.fbId.fieldName = "編號";
            this.fbId.fieldValue = "0";
            this.fbId.Location = new System.Drawing.Point(52, 39);
            this.fbId.Name = "fbId";
            this.fbId.Size = new System.Drawing.Size(195, 74);
            this.fbId.TabIndex = 8;
            // 
            // fbPrice
            // 
            this.fbPrice.fieldName = "產品價格";
            this.fbPrice.fieldValue = "";
            this.fbPrice.Location = new System.Drawing.Point(529, 225);
            this.fbPrice.Name = "fbPrice";
            this.fbPrice.Size = new System.Drawing.Size(145, 74);
            this.fbPrice.TabIndex = 3;
            // 
            // fbProductName
            // 
            this.fbProductName.fieldName = "產品名稱";
            this.fbProductName.fieldValue = "";
            this.fbProductName.Location = new System.Drawing.Point(529, 128);
            this.fbProductName.Name = "fbProductName";
            this.fbProductName.Size = new System.Drawing.Size(195, 74);
            this.fbProductName.TabIndex = 2;
            // 
            // fbMemberId
            // 
            this.fbMemberId.fieldName = "會員編號";
            this.fbMemberId.fieldValue = "";
            this.fbMemberId.Location = new System.Drawing.Point(52, 220);
            this.fbMemberId.Name = "fbMemberId";
            this.fbMemberId.Size = new System.Drawing.Size(195, 74);
            this.fbMemberId.TabIndex = 1;
            // 
            // fbOrderId
            // 
            this.fbOrderId.fieldName = "訂單編號";
            this.fbOrderId.fieldValue = "";
            this.fbOrderId.Location = new System.Drawing.Point(52, 128);
            this.fbOrderId.Name = "fbOrderId";
            this.fbOrderId.Size = new System.Drawing.Size(195, 74);
            this.fbOrderId.TabIndex = 0;
            // 
            // fbQty
            // 
            this.fbQty.Location = new System.Drawing.Point(680, 225);
            this.fbQty.Name = "fbQty";
            this.fbQty.Size = new System.Drawing.Size(73, 74);
            this.fbQty.statusName = "數量";
            this.fbQty.statusValue = "";
            this.fbQty.TabIndex = 25;
            // 
            // fbMemberName
            // 
            this.fbMemberName.Location = new System.Drawing.Point(52, 300);
            this.fbMemberName.Name = "fbMemberName";
            this.fbMemberName.Size = new System.Drawing.Size(150, 71);
            this.fbMemberName.statusName = "會員名字";
            this.fbMemberName.statusValue = "";
            this.fbMemberName.TabIndex = 26;
            // 
            // FrmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.fbMemberName);
            this.Controls.Add(this.fbQty);
            this.Controls.Add(this.CBStatusId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fbStatusId);
            this.Controls.Add(this.fbProductId);
            this.Controls.Add(this.fbId);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fbPrice);
            this.Controls.Add(this.fbProductName);
            this.Controls.Add(this.fbMemberId);
            this.Controls.Add(this.fbOrderId);
            this.Name = "FrmOrder";
            this.Text = "FrmOrder";
            this.Load += new System.EventHandler(this.FrmOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private prjComponentDemo.usercontrol.FieldBox fbOrderId;
        private prjComponentDemo.usercontrol.FieldBox fbMemberId;
        private prjComponentDemo.usercontrol.FieldBox fbProductName;
        private prjComponentDemo.usercontrol.FieldBox fbPrice;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private prjComponentDemo.usercontrol.FieldBox fbId;
        private prjComponentDemo.usercontrol.FieldBox fbProductId;
        private 付帳.StatusBox fbStatusId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CBStatusId;
        private 付帳.StatusBox fbQty;
        private 付帳.StatusBox fbMemberName;
    }
}