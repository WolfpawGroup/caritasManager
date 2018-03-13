namespace CaritasManager
{
	partial class f_DeletedCustomers
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.btn_Cancel = new System.Windows.Forms.Button();
			this.btn_Restore = new System.Windows.Forms.Button();
			this.listView1 = new System.Windows.Forms.ListView();
			this.ch_IDentificationNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_CustomerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_Address = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_Birth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_MothersName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_LastAid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_PassedAway = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_WhoDeleted = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_WhenDeleted = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btn_Cancel);
			this.panel1.Controls.Add(this.btn_Restore);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 532);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1109, 37);
			this.panel1.TabIndex = 0;
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btn_Cancel.Location = new System.Drawing.Point(3, 2);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new System.Drawing.Size(114, 32);
			this.btn_Cancel.TabIndex = 1;
			this.btn_Cancel.Text = "Bezárás";
			this.btn_Cancel.UseVisualStyleBackColor = true;
			this.btn_Cancel.Click += new System.EventHandler(this.button2_Click);
			// 
			// btn_Restore
			// 
			this.btn_Restore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btn_Restore.Location = new System.Drawing.Point(840, 2);
			this.btn_Restore.Name = "btn_Restore";
			this.btn_Restore.Size = new System.Drawing.Size(266, 32);
			this.btn_Restore.TabIndex = 0;
			this.btn_Restore.Text = "Kijelölt Ügyfél visszaállítása";
			this.btn_Restore.UseVisualStyleBackColor = true;
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_IDentificationNumber,
            this.ch_CustomerName,
            this.ch_Address,
            this.ch_Birth,
            this.ch_MothersName,
            this.ch_LastAid,
            this.ch_PassedAway,
            this.ch_WhoDeleted,
            this.ch_WhenDeleted});
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.Location = new System.Drawing.Point(0, 0);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(1109, 532);
			this.listView1.TabIndex = 1;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// ch_IDentificationNumber
			// 
			this.ch_IDentificationNumber.Text = "Azonosító";
			// 
			// ch_CustomerName
			// 
			this.ch_CustomerName.Text = "Név";
			this.ch_CustomerName.Width = 196;
			// 
			// ch_Address
			// 
			this.ch_Address.Text = "Cím";
			this.ch_Address.Width = 165;
			// 
			// ch_Birth
			// 
			this.ch_Birth.Text = "Született";
			this.ch_Birth.Width = 196;
			// 
			// ch_MothersName
			// 
			this.ch_MothersName.Text = "Anyja Neve";
			this.ch_MothersName.Width = 109;
			// 
			// ch_LastAid
			// 
			this.ch_LastAid.Text = "Legutóbbi támogatás ideje";
			this.ch_LastAid.Width = 141;
			// 
			// ch_PassedAway
			// 
			this.ch_PassedAway.Text = "Elhunyt";
			// 
			// ch_WhoDeleted
			// 
			this.ch_WhoDeleted.Text = "Ki törölte";
			this.ch_WhoDeleted.Width = 93;
			// 
			// ch_WhenDeleted
			// 
			this.ch_WhenDeleted.Text = "Törlés dátuma";
			this.ch_WhenDeleted.Width = 84;
			// 
			// f_DeletedCustomers
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1109, 569);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.panel1);
			this.Name = "f_DeletedCustomers";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Törölt ügyfelek";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btn_Cancel;
		private System.Windows.Forms.Button btn_Restore;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader ch_CustomerName;
		private System.Windows.Forms.ColumnHeader ch_Address;
		private System.Windows.Forms.ColumnHeader ch_Birth;
		private System.Windows.Forms.ColumnHeader ch_MothersName;
		private System.Windows.Forms.ColumnHeader ch_IDentificationNumber;
		private System.Windows.Forms.ColumnHeader ch_LastAid;
		private System.Windows.Forms.ColumnHeader ch_PassedAway;
		private System.Windows.Forms.ColumnHeader ch_WhoDeleted;
		private System.Windows.Forms.ColumnHeader ch_WhenDeleted;
	}
}