namespace CaritasManager
{
	partial class f_AddRokon
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
			this.tb_Name = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cb_Rokon = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.num_Income = new System.Windows.Forms.NumericUpDown();
			this.btn_Save = new System.Windows.Forms.Button();
			this.btn_Cancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.num_Income)).BeginInit();
			this.SuspendLayout();
			// 
			// tb_Name
			// 
			this.tb_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tb_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.tb_Name.Location = new System.Drawing.Point(171, 9);
			this.tb_Name.Name = "tb_Name";
			this.tb_Name.Size = new System.Drawing.Size(398, 22);
			this.tb_Name.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(153, 20);
			this.label1.TabIndex = 4;
			this.label1.Text = "Hozzátartozó Neve: ";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label2.Location = new System.Drawing.Point(12, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(141, 20);
			this.label2.TabIndex = 6;
			this.label2.Text = "Rokoni Kapcsolat: ";
			// 
			// cb_Rokon
			// 
			this.cb_Rokon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_Rokon.FormattingEnabled = true;
			this.cb_Rokon.Location = new System.Drawing.Point(171, 45);
			this.cb_Rokon.Name = "cb_Rokon";
			this.cb_Rokon.Size = new System.Drawing.Size(133, 21);
			this.cb_Rokon.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label3.Location = new System.Drawing.Point(310, 44);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(128, 20);
			this.label3.TabIndex = 8;
			this.label3.Text = "Havi Jövedelem: ";
			// 
			// num_Income
			// 
			this.num_Income.Location = new System.Drawing.Point(444, 46);
			this.num_Income.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
			this.num_Income.Name = "num_Income";
			this.num_Income.Size = new System.Drawing.Size(125, 20);
			this.num_Income.TabIndex = 9;
			// 
			// btn_Save
			// 
			this.btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btn_Save.Location = new System.Drawing.Point(480, 85);
			this.btn_Save.Name = "btn_Save";
			this.btn_Save.Size = new System.Drawing.Size(89, 33);
			this.btn_Save.TabIndex = 11;
			this.btn_Save.Text = "Mentés";
			this.btn_Save.UseVisualStyleBackColor = true;
			this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btn_Cancel.Location = new System.Drawing.Point(16, 85);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new System.Drawing.Size(89, 33);
			this.btn_Cancel.TabIndex = 10;
			this.btn_Cancel.Text = "Mégse";
			this.btn_Cancel.UseVisualStyleBackColor = true;
			this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
			// 
			// f_AddRokon
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(586, 130);
			this.Controls.Add(this.btn_Save);
			this.Controls.Add(this.btn_Cancel);
			this.Controls.Add(this.num_Income);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cb_Rokon);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tb_Name);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "f_AddRokon";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Hozzátartozó Hozzáadása";
			((System.ComponentModel.ISupportInitialize)(this.num_Income)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tb_Name;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cb_Rokon;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown num_Income;
		private System.Windows.Forms.Button btn_Save;
		private System.Windows.Forms.Button btn_Cancel;
	}
}