namespace CaritasManager
{
	partial class f_DeleteCustomer
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
			this.label1 = new System.Windows.Forms.Label();
			this.lbl_CustName = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btn_Cancel = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.btn_AllSeeingEye = new System.Windows.Forms.Button();
			this.tb_Password = new System.Windows.Forms.TextBox();
			this.btn_DeleteCustomer = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(315, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Éppen törölni készül a következő ügyfelet: ";
			// 
			// lbl_CustName
			// 
			this.lbl_CustName.AutoSize = true;
			this.lbl_CustName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbl_CustName.Location = new System.Drawing.Point(333, 6);
			this.lbl_CustName.Name = "lbl_CustName";
			this.lbl_CustName.Size = new System.Drawing.Size(118, 20);
			this.lbl_CustName.TabIndex = 1;
			this.lbl_CustName.Text = "[CUSTOMER]";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.label3.Location = new System.Drawing.Point(12, 37);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(490, 26);
			this.label3.TabIndex = 2;
			this.label3.Text = "Amennyiben tényleg törölni szeretné az ügyfelet kérem írja be a jelszót és kattin" +
    "tson a [ Törlés ] gombra\r\nHa meggondolta magát, a [ Mégse ] gomb segítségével me" +
    "gszakíthatja a műveletet.";
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.Location = new System.Drawing.Point(15, 139);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_Cancel.TabIndex = 3;
			this.btn_Cancel.Text = "Mégse";
			this.btn_Cancel.UseVisualStyleBackColor = true;
			this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 90);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(178, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Törléshez kérem adja meg a jelszót: ";
			// 
			// btn_AllSeeingEye
			// 
			this.btn_AllSeeingEye.BackgroundImage = global::CaritasManager.Properties.Resources.eye;
			this.btn_AllSeeingEye.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btn_AllSeeingEye.Location = new System.Drawing.Point(340, 82);
			this.btn_AllSeeingEye.Name = "btn_AllSeeingEye";
			this.btn_AllSeeingEye.Size = new System.Drawing.Size(32, 26);
			this.btn_AllSeeingEye.TabIndex = 9;
			this.btn_AllSeeingEye.UseVisualStyleBackColor = true;
			this.btn_AllSeeingEye.Click += new System.EventHandler(this.btn_AllSeeingEye_Click);
			// 
			// tb_Password
			// 
			this.tb_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
			this.tb_Password.Location = new System.Drawing.Point(196, 83);
			this.tb_Password.Name = "tb_Password";
			this.tb_Password.PasswordChar = '•';
			this.tb_Password.Size = new System.Drawing.Size(146, 24);
			this.tb_Password.TabIndex = 8;
			// 
			// btn_DeleteCustomer
			// 
			this.btn_DeleteCustomer.Location = new System.Drawing.Point(517, 139);
			this.btn_DeleteCustomer.Name = "btn_DeleteCustomer";
			this.btn_DeleteCustomer.Size = new System.Drawing.Size(75, 23);
			this.btn_DeleteCustomer.TabIndex = 10;
			this.btn_DeleteCustomer.Text = "Törlés";
			this.btn_DeleteCustomer.UseVisualStyleBackColor = true;
			this.btn_DeleteCustomer.Click += new System.EventHandler(this.btn_DeleteCustomer_Click);
			// 
			// f_DeleteCustomer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(604, 174);
			this.Controls.Add(this.btn_DeleteCustomer);
			this.Controls.Add(this.btn_AllSeeingEye);
			this.Controls.Add(this.tb_Password);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btn_Cancel);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lbl_CustName);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "f_DeleteCustomer";
			this.Text = "Ügyfél Törlése - ";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lbl_CustName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btn_Cancel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btn_AllSeeingEye;
		private System.Windows.Forms.TextBox tb_Password;
		private System.Windows.Forms.Button btn_DeleteCustomer;
	}
}