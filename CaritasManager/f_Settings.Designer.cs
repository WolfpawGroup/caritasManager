namespace CaritasManager
{
	partial class f_Settings
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
			this.components = new System.ComponentModel.Container();
			this.btn_EditProfile = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.lbl_Profile = new System.Windows.Forms.Label();
			this.btn_ChangePass = new System.Windows.Forms.Button();
			this.cb_ShowDeceased = new System.Windows.Forms.CheckBox();
			this.cb_ColorfulImages = new System.Windows.Forms.CheckBox();
			this.cb_BackupWithDate = new System.Windows.Forms.CheckBox();
			this.cb_AutoBackup = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.cb_AutoBackupRate = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cb_DefaultOrderer = new System.Windows.Forms.ComboBox();
			this.btn_Save = new System.Windows.Forms.Button();
			this.btn_Cancel = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.tb_BackupFolder = new System.Windows.Forms.TextBox();
			this.btn_BrowseFolder = new System.Windows.Forms.Button();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.btn_ShowDeletedCustomers = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btn_EditProfile
			// 
			this.btn_EditProfile.Location = new System.Drawing.Point(356, 12);
			this.btn_EditProfile.Name = "btn_EditProfile";
			this.btn_EditProfile.Size = new System.Drawing.Size(105, 23);
			this.btn_EditProfile.TabIndex = 0;
			this.btn_EditProfile.Text = "Profil Szerkesztése";
			this.toolTip1.SetToolTip(this.btn_EditProfile, "Itt lehet szerkeszteni a jelenleg belépett felhasználói profilt");
			this.btn_EditProfile.UseVisualStyleBackColor = true;
			this.btn_EditProfile.Click += new System.EventHandler(this.btn_EditProfile_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Belépve mint: ";
			// 
			// lbl_Profile
			// 
			this.lbl_Profile.AutoSize = true;
			this.lbl_Profile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbl_Profile.Location = new System.Drawing.Point(92, 12);
			this.lbl_Profile.Name = "lbl_Profile";
			this.lbl_Profile.Size = new System.Drawing.Size(14, 20);
			this.lbl_Profile.TabIndex = 2;
			this.lbl_Profile.Text = "|";
			// 
			// btn_ChangePass
			// 
			this.btn_ChangePass.Location = new System.Drawing.Point(356, 41);
			this.btn_ChangePass.Name = "btn_ChangePass";
			this.btn_ChangePass.Size = new System.Drawing.Size(105, 23);
			this.btn_ChangePass.TabIndex = 3;
			this.btn_ChangePass.Text = "Jelszó Módosítása";
			this.toolTip1.SetToolTip(this.btn_ChangePass, "Itt lehet módosítani a jelszót amivel a programba be lehet lépni (A jelenlegi jel" +
        "szó ismerete szükséges hozzá!)");
			this.btn_ChangePass.UseVisualStyleBackColor = true;
			this.btn_ChangePass.Click += new System.EventHandler(this.btn_ChangePass_Click);
			// 
			// cb_ShowDeceased
			// 
			this.cb_ShowDeceased.AutoSize = true;
			this.cb_ShowDeceased.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cb_ShowDeceased.Location = new System.Drawing.Point(211, 59);
			this.cb_ShowDeceased.Name = "cb_ShowDeceased";
			this.cb_ShowDeceased.Size = new System.Drawing.Size(15, 14);
			this.cb_ShowDeceased.TabIndex = 4;
			this.toolTip1.SetToolTip(this.cb_ShowDeceased, "Ha be van pipálva, az elhunyt ügyfelek is meg fognak jelenni a főképernyőn a list" +
        "ában");
			this.cb_ShowDeceased.UseVisualStyleBackColor = true;
			// 
			// cb_ColorfulImages
			// 
			this.cb_ColorfulImages.AutoSize = true;
			this.cb_ColorfulImages.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cb_ColorfulImages.Location = new System.Drawing.Point(211, 83);
			this.cb_ColorfulImages.Name = "cb_ColorfulImages";
			this.cb_ColorfulImages.Size = new System.Drawing.Size(15, 14);
			this.cb_ColorfulImages.TabIndex = 5;
			this.toolTip1.SetToolTip(this.cb_ColorfulImages, "Ha be van pipálva, a feketefehér ikonok helyett színes ikonok lesznek láthatóak a" +
        " főképernyőn és a támogatás  ablakban");
			this.cb_ColorfulImages.UseVisualStyleBackColor = true;
			// 
			// cb_BackupWithDate
			// 
			this.cb_BackupWithDate.AutoSize = true;
			this.cb_BackupWithDate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cb_BackupWithDate.Location = new System.Drawing.Point(211, 107);
			this.cb_BackupWithDate.Name = "cb_BackupWithDate";
			this.cb_BackupWithDate.Size = new System.Drawing.Size(15, 14);
			this.cb_BackupWithDate.TabIndex = 6;
			this.toolTip1.SetToolTip(this.cb_BackupWithDate, "Ha be van pipálva, akkor az adatbázisról készülő biztonsági mentések egy külön dá" +
        "tumozott mappába kerülnek, így megmaradnak a korábbi mentések is");
			this.cb_BackupWithDate.UseVisualStyleBackColor = true;
			// 
			// cb_AutoBackup
			// 
			this.cb_AutoBackup.AutoSize = true;
			this.cb_AutoBackup.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cb_AutoBackup.Location = new System.Drawing.Point(211, 131);
			this.cb_AutoBackup.Name = "cb_AutoBackup";
			this.cb_AutoBackup.Size = new System.Drawing.Size(15, 14);
			this.cb_AutoBackup.TabIndex = 7;
			this.toolTip1.SetToolTip(this.cb_AutoBackup, "Ha be van pipálva, az adatbázist időnként automatikusan lementi a program, a véle" +
        "tlen adatvesztés elkerülése végett");
			this.cb_AutoBackup.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 60);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(139, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Elhunyt ügyfelek látszanak: ";
			this.toolTip1.SetToolTip(this.label2, "Ha be van pipálva, az elhunyt ügyfelek is meg fognak jelenni a főképernyőn a list" +
        "ában");
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 84);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(78, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Színes ikonok:";
			this.toolTip1.SetToolTip(this.label3, "Ha be van pipálva, a feketefehér ikonok helyett színes ikonok lesznek láthatóak a" +
        " főképernyőn és a támogatás  ablakban");
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 108);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(198, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "Adatbázis mentés dátumozott mappába: ";
			this.toolTip1.SetToolTip(this.label4, "Ha be van pipálva, akkor az adatbázisról készülő biztonsági mentések egy külön dá" +
        "tumozott mappába kerülnek, így megmaradnak a korábbi mentések is");
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 132);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(156, 13);
			this.label5.TabIndex = 11;
			this.label5.Text = "Automatikus adatbázis mentés: ";
			this.toolTip1.SetToolTip(this.label5, "Ha be van pipálva, az adatbázist időnként automatikusan lementi a program, a véle" +
        "tlen adatvesztés elkerülése végett");
			// 
			// cb_AutoBackupRate
			// 
			this.cb_AutoBackupRate.FormattingEnabled = true;
			this.cb_AutoBackupRate.Items.AddRange(new object[] {
            "Naponta",
            "Hetente",
            "Havonta"});
			this.cb_AutoBackupRate.Location = new System.Drawing.Point(241, 128);
			this.cb_AutoBackupRate.Name = "cb_AutoBackupRate";
			this.cb_AutoBackupRate.Size = new System.Drawing.Size(155, 21);
			this.cb_AutoBackupRate.TabIndex = 12;
			this.toolTip1.SetToolTip(this.cb_AutoBackupRate, "Itt kiválasztható, hogy Naponta, Hetente vagy Havonta készüljön automatikus adatb" +
        "ázis mentés amennyiben be van kapcsolva");
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 180);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(131, 13);
			this.label6.TabIndex = 13;
			this.label6.Text = "Alapértelmezett rendezés: ";
			this.toolTip1.SetToolTip(this.label6, "Itt azt lehet kiválasztani, hogy a program alapértelmezetten melyik oszlop alapjá" +
        "n rendezze az ügyfeleket a főképernyőn és azon belül növekvő (▲) vagy csökkenő (" +
        "▼) sorrendben");
			// 
			// cb_DefaultOrderer
			// 
			this.cb_DefaultOrderer.FormattingEnabled = true;
			this.cb_DefaultOrderer.Items.AddRange(new object[] {
            "Név ▲",
            "Név ▼",
            "Azonosító ▲",
            "Azonosító ▼",
            "Lakhely ▲",
            "Lakhely ▼",
            "Állapot ▲",
            "Állapot ▼",
            "Felvétel Dátuma ▲",
            "Felvétel Dátuma ▼",
            "Legutóbbi Támogatás Időpontja ▲",
            "Legutóbbi Támogatás Időpontja ▼"});
			this.cb_DefaultOrderer.Location = new System.Drawing.Point(211, 176);
			this.cb_DefaultOrderer.Name = "cb_DefaultOrderer";
			this.cb_DefaultOrderer.Size = new System.Drawing.Size(185, 21);
			this.cb_DefaultOrderer.TabIndex = 14;
			this.toolTip1.SetToolTip(this.cb_DefaultOrderer, "Itt azt lehet kiválasztani, hogy a program alapértelmezetten melyik oszlop alapjá" +
        "n rendezze az ügyfeleket a főképernyőn és azon belül növekvő (▲) vagy csökkenő (" +
        "▼) sorrendben");
			// 
			// btn_Save
			// 
			this.btn_Save.Location = new System.Drawing.Point(386, 210);
			this.btn_Save.Name = "btn_Save";
			this.btn_Save.Size = new System.Drawing.Size(75, 23);
			this.btn_Save.TabIndex = 15;
			this.btn_Save.Text = "Mentés";
			this.btn_Save.UseVisualStyleBackColor = true;
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.Location = new System.Drawing.Point(15, 210);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_Cancel.TabIndex = 16;
			this.btn_Cancel.Text = "Mégse";
			this.btn_Cancel.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(12, 156);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(139, 13);
			this.label7.TabIndex = 17;
			this.label7.Text = "Adatbázis mentés mappája: ";
			this.toolTip1.SetToolTip(this.label7, "A mappa ahova az adatbázis mentések kerülnek. Ha nincs kitöltve, vagy nem létezik" +
        " a beírt mappa, akkor az asztalon lesz létrehozva egy mappa a mentéseknek");
			// 
			// tb_BackupFolder
			// 
			this.tb_BackupFolder.Location = new System.Drawing.Point(211, 152);
			this.tb_BackupFolder.Name = "tb_BackupFolder";
			this.tb_BackupFolder.Size = new System.Drawing.Size(161, 20);
			this.tb_BackupFolder.TabIndex = 18;
			this.toolTip1.SetToolTip(this.tb_BackupFolder, "A mappa ahova az adatbázis mentések kerülnek. Ha nincs kitöltve, vagy nem létezik" +
        " a beírt mappa, akkor az asztalon lesz létrehozva egy mappa a mentéseknek");
			// 
			// btn_BrowseFolder
			// 
			this.btn_BrowseFolder.BackgroundImage = global::CaritasManager.Properties.Resources.browse_folder;
			this.btn_BrowseFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btn_BrowseFolder.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btn_BrowseFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btn_BrowseFolder.Location = new System.Drawing.Point(375, 151);
			this.btn_BrowseFolder.Name = "btn_BrowseFolder";
			this.btn_BrowseFolder.Size = new System.Drawing.Size(22, 22);
			this.btn_BrowseFolder.TabIndex = 19;
			this.btn_BrowseFolder.UseVisualStyleBackColor = true;
			// 
			// btn_ShowDeletedCustomers
			// 
			this.btn_ShowDeletedCustomers.Location = new System.Drawing.Point(356, 70);
			this.btn_ShowDeletedCustomers.Name = "btn_ShowDeletedCustomers";
			this.btn_ShowDeletedCustomers.Size = new System.Drawing.Size(105, 23);
			this.btn_ShowDeletedCustomers.TabIndex = 20;
			this.btn_ShowDeletedCustomers.Text = "Törölt Ügyfelek";
			this.toolTip1.SetToolTip(this.btn_ShowDeletedCustomers, "Itt megtekintheti és visszaállíthatja a törölt ügyfél sorokat");
			this.btn_ShowDeletedCustomers.UseVisualStyleBackColor = true;
			this.btn_ShowDeletedCustomers.Click += new System.EventHandler(this.btn_ShowDeletedCustomers_Click);
			// 
			// f_Settings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(473, 242);
			this.Controls.Add(this.btn_ShowDeletedCustomers);
			this.Controls.Add(this.btn_BrowseFolder);
			this.Controls.Add(this.tb_BackupFolder);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.btn_Cancel);
			this.Controls.Add(this.btn_Save);
			this.Controls.Add(this.cb_DefaultOrderer);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.cb_AutoBackupRate);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cb_AutoBackup);
			this.Controls.Add(this.cb_BackupWithDate);
			this.Controls.Add(this.cb_ColorfulImages);
			this.Controls.Add(this.cb_ShowDeceased);
			this.Controls.Add(this.btn_ChangePass);
			this.Controls.Add(this.lbl_Profile);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btn_EditProfile);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "f_Settings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Beállítások";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btn_EditProfile;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lbl_Profile;
		private System.Windows.Forms.Button btn_ChangePass;
		private System.Windows.Forms.CheckBox cb_ShowDeceased;
		private System.Windows.Forms.CheckBox cb_ColorfulImages;
		private System.Windows.Forms.CheckBox cb_BackupWithDate;
		private System.Windows.Forms.CheckBox cb_AutoBackup;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cb_AutoBackupRate;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cb_DefaultOrderer;
		private System.Windows.Forms.Button btn_Save;
		private System.Windows.Forms.Button btn_Cancel;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tb_BackupFolder;
		private System.Windows.Forms.Button btn_BrowseFolder;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button btn_ShowDeletedCustomers;
	}
}