namespace CaritasManager
{
	partial class f_Aids
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
			this.p_Food = new System.Windows.Forms.Panel();
			this.p_Clothes = new System.Windows.Forms.Panel();
			this.p_Medicine = new System.Windows.Forms.Panel();
			this.p_Bills = new System.Windows.Forms.Panel();
			this.p_Meal = new System.Windows.Forms.Panel();
			this.p_Housing = new System.Windows.Forms.Panel();
			this.p_ExtremeAid = new System.Windows.Forms.Panel();
			this.p_Furniture = new System.Windows.Forms.Panel();
			this.lbl_AidType = new System.Windows.Forms.Label();
			this.p_Extreme = new System.Windows.Forms.Panel();
			this.tb_AidAmount = new System.Windows.Forms.TextBox();
			this.lbl_AidUnit = new System.Windows.Forms.Label();
			this.lbl_Extreme = new System.Windows.Forms.Label();
			this.cb_ExtremeType = new System.Windows.Forms.ComboBox();
			this.tb_ExtremeAmount = new System.Windows.Forms.TextBox();
			this.cb_ExtremeUnit = new System.Windows.Forms.ComboBox();
			this.btn_Cancel = new System.Windows.Forms.Button();
			this.btn_AddAid = new System.Windows.Forms.Button();
			this.p_Extreme.SuspendLayout();
			this.SuspendLayout();
			// 
			// p_Food
			// 
			this.p_Food.BackColor = System.Drawing.Color.Transparent;
			this.p_Food.BackgroundImage = global::CaritasManager.Properties.Resources.food_0;
			this.p_Food.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.p_Food.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.p_Food.Location = new System.Drawing.Point(12, 6);
			this.p_Food.Name = "p_Food";
			this.p_Food.Size = new System.Drawing.Size(132, 132);
			this.p_Food.TabIndex = 0;
			this.p_Food.Tag = "Élelmiszer|";
			this.p_Food.Click += new System.EventHandler(this.selectAid);
			// 
			// p_Clothes
			// 
			this.p_Clothes.BackColor = System.Drawing.Color.Transparent;
			this.p_Clothes.BackgroundImage = global::CaritasManager.Properties.Resources.clothes_0;
			this.p_Clothes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.p_Clothes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.p_Clothes.Location = new System.Drawing.Point(145, 6);
			this.p_Clothes.Name = "p_Clothes";
			this.p_Clothes.Size = new System.Drawing.Size(132, 132);
			this.p_Clothes.TabIndex = 1;
			this.p_Clothes.Tag = "Ruha|kg";
			this.p_Clothes.Click += new System.EventHandler(this.selectAid);
			// 
			// p_Medicine
			// 
			this.p_Medicine.BackColor = System.Drawing.Color.Transparent;
			this.p_Medicine.BackgroundImage = global::CaritasManager.Properties.Resources.medicine_0;
			this.p_Medicine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.p_Medicine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.p_Medicine.Location = new System.Drawing.Point(411, 6);
			this.p_Medicine.Name = "p_Medicine";
			this.p_Medicine.Size = new System.Drawing.Size(132, 132);
			this.p_Medicine.TabIndex = 3;
			this.p_Medicine.Tag = "Gyógyszer|Ft";
			this.p_Medicine.Click += new System.EventHandler(this.selectAid);
			// 
			// p_Bills
			// 
			this.p_Bills.BackColor = System.Drawing.Color.Transparent;
			this.p_Bills.BackgroundImage = global::CaritasManager.Properties.Resources.utility_0;
			this.p_Bills.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.p_Bills.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.p_Bills.Location = new System.Drawing.Point(278, 6);
			this.p_Bills.Name = "p_Bills";
			this.p_Bills.Size = new System.Drawing.Size(132, 132);
			this.p_Bills.TabIndex = 2;
			this.p_Bills.Tag = "Számla befizetés|Ft";
			this.p_Bills.Click += new System.EventHandler(this.selectAid);
			// 
			// p_Meal
			// 
			this.p_Meal.BackColor = System.Drawing.Color.Transparent;
			this.p_Meal.BackgroundImage = global::CaritasManager.Properties.Resources.meal_0;
			this.p_Meal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.p_Meal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.p_Meal.Location = new System.Drawing.Point(145, 139);
			this.p_Meal.Name = "p_Meal";
			this.p_Meal.Size = new System.Drawing.Size(132, 132);
			this.p_Meal.TabIndex = 5;
			this.p_Meal.Tag = "Ebéd befizetés|Ft";
			this.p_Meal.Click += new System.EventHandler(this.selectAid);
			// 
			// p_Housing
			// 
			this.p_Housing.BackColor = System.Drawing.Color.Transparent;
			this.p_Housing.BackgroundImage = global::CaritasManager.Properties.Resources.home_0;
			this.p_Housing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.p_Housing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.p_Housing.Location = new System.Drawing.Point(12, 139);
			this.p_Housing.Name = "p_Housing";
			this.p_Housing.Size = new System.Drawing.Size(132, 132);
			this.p_Housing.TabIndex = 4;
			this.p_Housing.Tag = "Lakhatás|Ft";
			this.p_Housing.Click += new System.EventHandler(this.selectAid);
			// 
			// p_ExtremeAid
			// 
			this.p_ExtremeAid.BackColor = System.Drawing.Color.Transparent;
			this.p_ExtremeAid.BackgroundImage = global::CaritasManager.Properties.Resources.extreme_aid_0;
			this.p_ExtremeAid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.p_ExtremeAid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.p_ExtremeAid.Location = new System.Drawing.Point(411, 139);
			this.p_ExtremeAid.Name = "p_ExtremeAid";
			this.p_ExtremeAid.Size = new System.Drawing.Size(132, 132);
			this.p_ExtremeAid.TabIndex = 7;
			this.p_ExtremeAid.Tag = "Rendkívüli segély|??";
			this.p_ExtremeAid.Click += new System.EventHandler(this.selectAid);
			// 
			// p_Furniture
			// 
			this.p_Furniture.BackColor = System.Drawing.Color.Transparent;
			this.p_Furniture.BackgroundImage = global::CaritasManager.Properties.Resources.furniture_0;
			this.p_Furniture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.p_Furniture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.p_Furniture.Location = new System.Drawing.Point(278, 139);
			this.p_Furniture.Name = "p_Furniture";
			this.p_Furniture.Size = new System.Drawing.Size(132, 132);
			this.p_Furniture.TabIndex = 6;
			this.p_Furniture.Tag = "Bútor|db";
			this.p_Furniture.Click += new System.EventHandler(this.selectAid);
			// 
			// lbl_AidType
			// 
			this.lbl_AidType.AutoSize = true;
			this.lbl_AidType.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbl_AidType.Location = new System.Drawing.Point(7, 277);
			this.lbl_AidType.Name = "lbl_AidType";
			this.lbl_AidType.Size = new System.Drawing.Size(155, 25);
			this.lbl_AidType.TabIndex = 8;
			this.lbl_AidType.Text = "Ebéd befizetés";
			// 
			// p_Extreme
			// 
			this.p_Extreme.Controls.Add(this.cb_ExtremeUnit);
			this.p_Extreme.Controls.Add(this.tb_ExtremeAmount);
			this.p_Extreme.Controls.Add(this.cb_ExtremeType);
			this.p_Extreme.Controls.Add(this.lbl_Extreme);
			this.p_Extreme.Location = new System.Drawing.Point(12, 276);
			this.p_Extreme.Name = "p_Extreme";
			this.p_Extreme.Size = new System.Drawing.Size(530, 33);
			this.p_Extreme.TabIndex = 9;
			this.p_Extreme.Visible = false;
			// 
			// tb_AidAmount
			// 
			this.tb_AidAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.tb_AidAmount.Location = new System.Drawing.Point(168, 278);
			this.tb_AidAmount.Name = "tb_AidAmount";
			this.tb_AidAmount.Size = new System.Drawing.Size(337, 26);
			this.tb_AidAmount.TabIndex = 10;
			// 
			// lbl_AidUnit
			// 
			this.lbl_AidUnit.AutoSize = true;
			this.lbl_AidUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbl_AidUnit.Location = new System.Drawing.Point(511, 279);
			this.lbl_AidUnit.Name = "lbl_AidUnit";
			this.lbl_AidUnit.Size = new System.Drawing.Size(31, 25);
			this.lbl_AidUnit.TabIndex = 11;
			this.lbl_AidUnit.Text = "Ft";
			// 
			// lbl_Extreme
			// 
			this.lbl_Extreme.AutoSize = true;
			this.lbl_Extreme.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbl_Extreme.Location = new System.Drawing.Point(0, 3);
			this.lbl_Extreme.Name = "lbl_Extreme";
			this.lbl_Extreme.Size = new System.Drawing.Size(181, 25);
			this.lbl_Extreme.TabIndex = 9;
			this.lbl_Extreme.Text = "Rendkívüli segély";
			// 
			// cb_ExtremeType
			// 
			this.cb_ExtremeType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.cb_ExtremeType.FormattingEnabled = true;
			this.cb_ExtremeType.Items.AddRange(new object[] {
            "Élelmiszer",
            "Ruha",
            "Számla befizetés",
            "Gyógyszer",
            "Bútor",
            "Tüzifa",
            "Készpénz"});
			this.cb_ExtremeType.Location = new System.Drawing.Point(187, 1);
			this.cb_ExtremeType.Name = "cb_ExtremeType";
			this.cb_ExtremeType.Size = new System.Drawing.Size(132, 28);
			this.cb_ExtremeType.TabIndex = 10;
			// 
			// tb_ExtremeAmount
			// 
			this.tb_ExtremeAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.tb_ExtremeAmount.Location = new System.Drawing.Point(325, 3);
			this.tb_ExtremeAmount.Name = "tb_ExtremeAmount";
			this.tb_ExtremeAmount.Size = new System.Drawing.Size(147, 26);
			this.tb_ExtremeAmount.TabIndex = 11;
			// 
			// cb_ExtremeUnit
			// 
			this.cb_ExtremeUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.cb_ExtremeUnit.FormattingEnabled = true;
			this.cb_ExtremeUnit.Items.AddRange(new object[] {
            "Ft",
            "db",
            "cs",
            "kg"});
			this.cb_ExtremeUnit.Location = new System.Drawing.Point(478, 1);
			this.cb_ExtremeUnit.Name = "cb_ExtremeUnit";
			this.cb_ExtremeUnit.Size = new System.Drawing.Size(49, 28);
			this.cb_ExtremeUnit.TabIndex = 12;
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btn_Cancel.Location = new System.Drawing.Point(12, 315);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new System.Drawing.Size(82, 29);
			this.btn_Cancel.TabIndex = 12;
			this.btn_Cancel.Text = "Mégse";
			this.btn_Cancel.UseVisualStyleBackColor = true;
			// 
			// btn_AddAid
			// 
			this.btn_AddAid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btn_AddAid.Location = new System.Drawing.Point(348, 315);
			this.btn_AddAid.Name = "btn_AddAid";
			this.btn_AddAid.Size = new System.Drawing.Size(194, 29);
			this.btn_AddAid.TabIndex = 13;
			this.btn_AddAid.Text = "Támogatás Hozzáadása";
			this.btn_AddAid.UseVisualStyleBackColor = true;
			this.btn_AddAid.Click += new System.EventHandler(this.btn_AddAid_Click);
			// 
			// f_Aids
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(554, 349);
			this.Controls.Add(this.btn_AddAid);
			this.Controls.Add(this.btn_Cancel);
			this.Controls.Add(this.p_Extreme);
			this.Controls.Add(this.lbl_AidUnit);
			this.Controls.Add(this.tb_AidAmount);
			this.Controls.Add(this.lbl_AidType);
			this.Controls.Add(this.p_ExtremeAid);
			this.Controls.Add(this.p_Furniture);
			this.Controls.Add(this.p_Meal);
			this.Controls.Add(this.p_Housing);
			this.Controls.Add(this.p_Medicine);
			this.Controls.Add(this.p_Clothes);
			this.Controls.Add(this.p_Bills);
			this.Controls.Add(this.p_Food);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "f_Aids";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Támogatás";
			this.p_Extreme.ResumeLayout(false);
			this.p_Extreme.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel p_Food;
		private System.Windows.Forms.Panel p_Clothes;
		private System.Windows.Forms.Panel p_Medicine;
		private System.Windows.Forms.Panel p_Bills;
		private System.Windows.Forms.Panel p_Meal;
		private System.Windows.Forms.Panel p_Housing;
		private System.Windows.Forms.Panel p_ExtremeAid;
		private System.Windows.Forms.Panel p_Furniture;
		private System.Windows.Forms.Label lbl_AidType;
		private System.Windows.Forms.Panel p_Extreme;
		private System.Windows.Forms.ComboBox cb_ExtremeUnit;
		private System.Windows.Forms.TextBox tb_ExtremeAmount;
		private System.Windows.Forms.ComboBox cb_ExtremeType;
		private System.Windows.Forms.Label lbl_Extreme;
		private System.Windows.Forms.TextBox tb_AidAmount;
		private System.Windows.Forms.Label lbl_AidUnit;
		private System.Windows.Forms.Button btn_Cancel;
		private System.Windows.Forms.Button btn_AddAid;
	}
}