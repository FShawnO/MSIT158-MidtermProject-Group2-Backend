namespace 後台.會員
{
    partial class FrmInsertOrder
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
			this.fbProductId = new prjComponentDemo.usercontrol.FieldBox();
			this.fbId = new prjComponentDemo.usercontrol.FieldBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.fbPrice = new prjComponentDemo.usercontrol.FieldBox();
			this.fbProductName = new prjComponentDemo.usercontrol.FieldBox();
			this.fbMemberId = new prjComponentDemo.usercontrol.FieldBox();
			this.fbOrderId = new prjComponentDemo.usercontrol.FieldBox();
			this.fbSOrderId = new 後台.付帳.StatusBox();
			this.fbSProductId = new 後台.付帳.StatusBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.fbQty = new 後台.付帳.StatusBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// fbProductId
			// 
			this.fbProductId.fieldName = "產品編號";
			this.fbProductId.fieldValue = "";
			this.fbProductId.Location = new System.Drawing.Point(274, 12);
			this.fbProductId.Name = "fbProductId";
			this.fbProductId.Size = new System.Drawing.Size(195, 74);
			this.fbProductId.TabIndex = 18;
			this.fbProductId.Visible = false;
			// 
			// fbId
			// 
			this.fbId.fieldName = "購買流水號";
			this.fbId.fieldValue = "0";
			this.fbId.Location = new System.Drawing.Point(52, 110);
			this.fbId.Name = "fbId";
			this.fbId.Size = new System.Drawing.Size(195, 74);
			this.fbId.TabIndex = 17;
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.button2.Location = new System.Drawing.Point(206, 382);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(131, 43);
			this.button2.TabIndex = 16;
			this.button2.Text = "取消";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.button1.Location = new System.Drawing.Point(495, 382);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(131, 43);
			this.button1.TabIndex = 15;
			this.button1.Text = "確定";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label1.Location = new System.Drawing.Point(17, 373);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(766, 2);
			this.label1.TabIndex = 14;
			// 
			// fbPrice
			// 
			this.fbPrice.fieldName = "產品價格";
			this.fbPrice.fieldValue = "";
			this.fbPrice.Location = new System.Drawing.Point(528, 306);
			this.fbPrice.Name = "fbPrice";
			this.fbPrice.Size = new System.Drawing.Size(195, 74);
			this.fbPrice.TabIndex = 13;
			this.fbPrice.Visible = false;
			// 
			// fbProductName
			// 
			this.fbProductName.fieldName = "產品名稱";
			this.fbProductName.fieldValue = "";
			this.fbProductName.Location = new System.Drawing.Point(290, 306);
			this.fbProductName.Name = "fbProductName";
			this.fbProductName.Size = new System.Drawing.Size(195, 74);
			this.fbProductName.TabIndex = 12;
			this.fbProductName.Visible = false;
			// 
			// fbMemberId
			// 
			this.fbMemberId.fieldName = "會員編號";
			this.fbMemberId.fieldValue = "";
			this.fbMemberId.Location = new System.Drawing.Point(52, 306);
			this.fbMemberId.Name = "fbMemberId";
			this.fbMemberId.Size = new System.Drawing.Size(195, 74);
			this.fbMemberId.TabIndex = 11;
			this.fbMemberId.Visible = false;
			// 
			// fbOrderId
			// 
			this.fbOrderId.fieldName = "訂單編號";
			this.fbOrderId.fieldValue = "";
			this.fbOrderId.Location = new System.Drawing.Point(36, 12);
			this.fbOrderId.Name = "fbOrderId";
			this.fbOrderId.Size = new System.Drawing.Size(195, 74);
			this.fbOrderId.TabIndex = 10;
			this.fbOrderId.Visible = false;
			// 
			// fbSOrderId
			// 
			this.fbSOrderId.Location = new System.Drawing.Point(298, 110);
			this.fbSOrderId.Name = "fbSOrderId";
			this.fbSOrderId.Size = new System.Drawing.Size(150, 71);
			this.fbSOrderId.statusName = "訂單編號";
			this.fbSOrderId.statusValue = "";
			this.fbSOrderId.TabIndex = 19;
			// 
			// fbSProductId
			// 
			this.fbSProductId.Location = new System.Drawing.Point(573, 12);
			this.fbSProductId.Name = "fbSProductId";
			this.fbSProductId.Size = new System.Drawing.Size(150, 71);
			this.fbSProductId.statusName = "產品編號";
			this.fbSProductId.statusValue = "";
			this.fbSProductId.TabIndex = 20;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Location = new System.Drawing.Point(495, 91);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(228, 209);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 22;
			this.pictureBox1.TabStop = false;
			// 
			// fbQty
			// 
			this.fbQty.Location = new System.Drawing.Point(741, 12);
			this.fbQty.Name = "fbQty";
			this.fbQty.Size = new System.Drawing.Size(73, 71);
			this.fbQty.statusName = "數量";
			this.fbQty.statusValue = "";
			this.fbQty.TabIndex = 24;
			// 
			// comboBox1
			// 
			this.comboBox1.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(298, 228);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 37);
			this.comboBox1.TabIndex = 25;
			this.comboBox1.Visible = false;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// FrmInsertOrder
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(841, 450);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.fbQty);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.fbSProductId);
			this.Controls.Add(this.fbSOrderId);
			this.Controls.Add(this.fbProductId);
			this.Controls.Add(this.fbId);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.fbPrice);
			this.Controls.Add(this.fbProductName);
			this.Controls.Add(this.fbMemberId);
			this.Controls.Add(this.fbOrderId);
			this.Name = "FrmInsertOrder";
			this.Text = "FrmInsertOrder";
			this.Load += new System.EventHandler(this.FrmInsertOrder_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private prjComponentDemo.usercontrol.FieldBox fbProductId;
        private prjComponentDemo.usercontrol.FieldBox fbId;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private prjComponentDemo.usercontrol.FieldBox fbPrice;
        private prjComponentDemo.usercontrol.FieldBox fbProductName;
        private prjComponentDemo.usercontrol.FieldBox fbMemberId;
        private prjComponentDemo.usercontrol.FieldBox fbOrderId;
        private 付帳.StatusBox fbSOrderId;
        private 付帳.StatusBox fbSProductId;
        private System.Windows.Forms.PictureBox pictureBox1;
        private 付帳.StatusBox fbQty;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}