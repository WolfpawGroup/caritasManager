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
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.listView1 = new System.Windows.Forms.ListView();
			this.ch_CustomerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_Address = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_Birth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_MothersName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_IDentificationNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_LastAid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_PassedAway = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 532);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(933, 37);
			this.panel1.TabIndex = 0;
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.button2.Location = new System.Drawing.Point(3, 2);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(114, 32);
			this.button2.TabIndex = 1;
			this.button2.Text = "Bezárás";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.button1.Location = new System.Drawing.Point(664, 2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(266, 32);
			this.button1.TabIndex = 0;
			this.button1.Text = "Kijelölt Ügyfél visszaállítása";
			this.button1.UseVisualStyleBackColor = true;
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
            this.ch_PassedAway});
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.Location = new System.Drawing.Point(0, 0);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(933, 532);
			this.listView1.TabIndex = 1;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// ch_CustomerName
			// 
			this.ch_CustomerName.DisplayIndex = 1;
			this.ch_CustomerName.Text = "Név";
			this.ch_CustomerName.Width = 224;
			// 
			// ch_Address
			// 
			this.ch_Address.DisplayIndex = 2;
			this.ch_Address.Text = "Cím";
			// 
			// ch_Birth
			// 
			this.ch_Birth.DisplayIndex = 4;
			this.ch_Birth.Text = "Született";
			// 
			// ch_MothersName
			// 
			this.ch_MothersName.DisplayIndex = 5;
			this.ch_MothersName.Text = "Anyja Neve";
			// 
			// ch_IDentificationNumber
			// 
			this.ch_IDentificationNumber.DisplayIndex = 0;
			this.ch_IDentificationNumber.Text = "Azonosító";
			// 
			// ch_LastAid
			// 
			this.ch_LastAid.Text = "Legutóbbi támogatás ideje";
			// 
			// ch_PassedAway
			// 
			this.ch_PassedAway.Text = "Elhunyt";
			// 
			// f_DeletedCustomers
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(933, 569);
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
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader ch_CustomerName;
		private System.Windows.Forms.ColumnHeader ch_Address;
		private System.Windows.Forms.ColumnHeader ch_Birth;
		private System.Windows.Forms.ColumnHeader ch_MothersName;
		private System.Windows.Forms.ColumnHeader ch_IDentificationNumber;
		private System.Windows.Forms.ColumnHeader ch_LastAid;
		private System.Windows.Forms.ColumnHeader ch_PassedAway;
	}
}