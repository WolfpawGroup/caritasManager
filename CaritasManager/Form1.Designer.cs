﻿namespace CaritasManager
{
	partial class Form1
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.ts_Tools = new System.Windows.Forms.ToolStrip();
			this.btn_NewCustomer = new System.Windows.Forms.ToolStripButton();
			this.btn_Exit = new System.Windows.Forms.ToolStripButton();
			this.btn_Help = new System.Windows.Forms.ToolStripButton();
			this.btn_Settings = new System.Windows.Forms.ToolStripButton();
			this.btn_DatabaseBackup = new System.Windows.Forms.ToolStripButton();
			this.btn_Edit = new System.Windows.Forms.ToolStripButton();
			this.t_Timer = new System.Windows.Forms.Timer(this.components);
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.lbl_NumOfCustomers = new System.Windows.Forms.ToolStripStatusLabel();
			this.lbl_LoggedInAs = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.cb_FullMatch = new System.Windows.Forms.CheckBox();
			this.p_FilterContainer = new System.Windows.Forms.Panel();
			this.p_FilterContainerInner = new System.Windows.Forms.Panel();
			this.cb_Filter_State = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btn_ClearFilter = new System.Windows.Forms.Button();
			this.tb_Filter_City = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btn_Filter = new System.Windows.Forms.Button();
			this.tb_Filter_Name = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.lbl_AdditionalInfo = new System.Windows.Forms.Button();
			this.p_FilterPartition = new System.Windows.Forms.Panel();
			this.lbl_SelectedCustomer_Dwelling_Street = new System.Windows.Forms.Label();
			this.lbl_SelectedCustomer_Dwelling_ZipCode = new System.Windows.Forms.Label();
			this.lbl_SelectedCustomer_Dwelling_City = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.lbl_SelectedCustomer_JILead = new System.Windows.Forms.Label();
			this.lbl_SelectedCustomer_LastSupported = new System.Windows.Forms.Label();
			this.lbl_SelectedCustomer_Added = new System.Windows.Forms.Label();
			this.lbl_SelectedCustomer_ID = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.lbl_SelectedCustomer_Name = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lb_SelectedCustomer_State = new System.Windows.Forms.ListBox();
			this.lb_SelectedCustomer_Kin = new System.Windows.Forms.ListBox();
			this.dg_DataTable = new CaritasManager.myDataGridView();
			this.tt_Tooltip = new CaritasManager.uc_Tooltip();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btn_FullScreen = new System.Windows.Forms.ToolStripButton();
			this.ch_CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ch_jovedelemig = new System.Windows.Forms.DataGridViewImageColumn();
			this.ch_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ch_PlaceOfResidence = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ch_State = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ch_DateAdded = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ch_LastSupport = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ch_AddSupport = new System.Windows.Forms.DataGridViewButtonColumn();
			this.ts_Tools.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.p_FilterContainer.SuspendLayout();
			this.p_FilterContainerInner.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dg_DataTable)).BeginInit();
			this.SuspendLayout();
			// 
			// ts_Tools
			// 
			this.ts_Tools.AutoSize = false;
			this.ts_Tools.BackColor = System.Drawing.Color.Transparent;
			this.ts_Tools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ts_Tools.ImageScalingSize = new System.Drawing.Size(40, 40);
			this.ts_Tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_NewCustomer,
            this.btn_FullScreen,
            this.btn_Help,
            this.toolStripSeparator1,
            this.btn_Exit,
            this.btn_Settings,
            this.btn_DatabaseBackup,
            this.btn_Edit});
			this.ts_Tools.Location = new System.Drawing.Point(0, 0);
			this.ts_Tools.Name = "ts_Tools";
			this.ts_Tools.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.ts_Tools.Size = new System.Drawing.Size(989, 50);
			this.ts_Tools.TabIndex = 0;
			this.ts_Tools.Text = "toolStrip1";
			// 
			// btn_NewCustomer
			// 
			this.btn_NewCustomer.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btn_NewCustomer.Image = global::CaritasManager.Properties.Resources.addusr;
			this.btn_NewCustomer.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_NewCustomer.Name = "btn_NewCustomer";
			this.btn_NewCustomer.Size = new System.Drawing.Size(133, 47);
			this.btn_NewCustomer.Text = "Új Ügyfél";
			this.btn_NewCustomer.Click += new System.EventHandler(this.btn_NewCustomer_Click);
			// 
			// btn_Exit
			// 
			this.btn_Exit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btn_Exit.Font = new System.Drawing.Font("Segoe UI", 14.25F);
			this.btn_Exit.Image = global::CaritasManager.Properties.Resources.power;
			this.btn_Exit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_Exit.Name = "btn_Exit";
			this.btn_Exit.Size = new System.Drawing.Size(116, 47);
			this.btn_Exit.Text = "Kilépés";
			this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
			// 
			// btn_Help
			// 
			this.btn_Help.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btn_Help.AutoSize = false;
			this.btn_Help.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btn_Help.Image = global::CaritasManager.Properties.Resources.q_32;
			this.btn_Help.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_Help.Margin = new System.Windows.Forms.Padding(0);
			this.btn_Help.Name = "btn_Help";
			this.btn_Help.Size = new System.Drawing.Size(36, 32);
			this.btn_Help.Text = "Segítség";
			this.btn_Help.Click += new System.EventHandler(this.btn_Help_Click);
			// 
			// btn_Settings
			// 
			this.btn_Settings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btn_Settings.Font = new System.Drawing.Font("Segoe UI", 14.25F);
			this.btn_Settings.Image = global::CaritasManager.Properties.Resources.settings;
			this.btn_Settings.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_Settings.Name = "btn_Settings";
			this.btn_Settings.Size = new System.Drawing.Size(146, 47);
			this.btn_Settings.Text = "Beállítások";
			this.btn_Settings.Click += new System.EventHandler(this.btn_Settings_Click);
			// 
			// btn_DatabaseBackup
			// 
			this.btn_DatabaseBackup.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btn_DatabaseBackup.Font = new System.Drawing.Font("Segoe UI", 14.25F);
			this.btn_DatabaseBackup.Image = global::CaritasManager.Properties.Resources.save;
			this.btn_DatabaseBackup.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_DatabaseBackup.Name = "btn_DatabaseBackup";
			this.btn_DatabaseBackup.Size = new System.Drawing.Size(210, 47);
			this.btn_DatabaseBackup.Text = "Biztonsági Mentés";
			this.btn_DatabaseBackup.Click += new System.EventHandler(this.btn_DatabaseBackup_Click);
			// 
			// btn_Edit
			// 
			this.btn_Edit.Font = new System.Drawing.Font("Segoe UI", 14.25F);
			this.btn_Edit.Image = global::CaritasManager.Properties.Resources.edit;
			this.btn_Edit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_Edit.Name = "btn_Edit";
			this.btn_Edit.Size = new System.Drawing.Size(232, 47);
			this.btn_Edit.Text = "Adatlap Szerkesztése";
			this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
			// 
			// t_Timer
			// 
			this.t_Timer.Tick += new System.EventHandler(this.t_Timer_Tick);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl_NumOfCustomers,
            this.lbl_LoggedInAs});
			this.statusStrip1.Location = new System.Drawing.Point(0, 477);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(989, 22);
			this.statusStrip1.TabIndex = 4;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// lbl_NumOfCustomers
			// 
			this.lbl_NumOfCustomers.Name = "lbl_NumOfCustomers";
			this.lbl_NumOfCustomers.Size = new System.Drawing.Size(895, 17);
			this.lbl_NumOfCustomers.Spring = true;
			this.lbl_NumOfCustomers.Text = "Ügyfelek száma: ";
			this.lbl_NumOfCustomers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbl_LoggedInAs
			// 
			this.lbl_LoggedInAs.Name = "lbl_LoggedInAs";
			this.lbl_LoggedInAs.Size = new System.Drawing.Size(79, 17);
			this.lbl_LoggedInAs.Text = "Belépve mint:";
			// 
			// toolTip1
			// 
			this.toolTip1.AutoPopDelay = 20000;
			this.toolTip1.InitialDelay = 500;
			this.toolTip1.ReshowDelay = 100;
			// 
			// cb_FullMatch
			// 
			this.cb_FullMatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cb_FullMatch.AutoSize = true;
			this.cb_FullMatch.Location = new System.Drawing.Point(187, 10);
			this.cb_FullMatch.Name = "cb_FullMatch";
			this.cb_FullMatch.Size = new System.Drawing.Size(118, 17);
			this.cb_FullMatch.TabIndex = 12;
			this.cb_FullMatch.Text = "csak teljes egyezés";
			this.toolTip1.SetToolTip(this.cb_FullMatch, "Csak azokat a találatokat jelenítse meg ahol a találat teljesen egyezik a beírt s" +
        "zöveggel.");
			this.cb_FullMatch.UseVisualStyleBackColor = true;
			// 
			// p_FilterContainer
			// 
			this.p_FilterContainer.Controls.Add(this.p_FilterContainerInner);
			this.p_FilterContainer.Controls.Add(this.label9);
			this.p_FilterContainer.Controls.Add(this.label7);
			this.p_FilterContainer.Controls.Add(this.lbl_AdditionalInfo);
			this.p_FilterContainer.Controls.Add(this.p_FilterPartition);
			this.p_FilterContainer.Controls.Add(this.lbl_SelectedCustomer_Dwelling_Street);
			this.p_FilterContainer.Controls.Add(this.lbl_SelectedCustomer_Dwelling_ZipCode);
			this.p_FilterContainer.Controls.Add(this.lbl_SelectedCustomer_Dwelling_City);
			this.p_FilterContainer.Controls.Add(this.label18);
			this.p_FilterContainer.Controls.Add(this.label19);
			this.p_FilterContainer.Controls.Add(this.label12);
			this.p_FilterContainer.Controls.Add(this.lbl_SelectedCustomer_JILead);
			this.p_FilterContainer.Controls.Add(this.lbl_SelectedCustomer_LastSupported);
			this.p_FilterContainer.Controls.Add(this.lbl_SelectedCustomer_Added);
			this.p_FilterContainer.Controls.Add(this.lbl_SelectedCustomer_ID);
			this.p_FilterContainer.Controls.Add(this.label10);
			this.p_FilterContainer.Controls.Add(this.label8);
			this.p_FilterContainer.Controls.Add(this.label6);
			this.p_FilterContainer.Controls.Add(this.label5);
			this.p_FilterContainer.Controls.Add(this.lbl_SelectedCustomer_Name);
			this.p_FilterContainer.Controls.Add(this.label4);
			this.p_FilterContainer.Controls.Add(this.lb_SelectedCustomer_State);
			this.p_FilterContainer.Controls.Add(this.lb_SelectedCustomer_Kin);
			this.p_FilterContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.p_FilterContainer.Location = new System.Drawing.Point(0, 423);
			this.p_FilterContainer.Name = "p_FilterContainer";
			this.p_FilterContainer.Size = new System.Drawing.Size(989, 54);
			this.p_FilterContainer.TabIndex = 5;
			// 
			// p_FilterContainerInner
			// 
			this.p_FilterContainerInner.Controls.Add(this.cb_Filter_State);
			this.p_FilterContainerInner.Controls.Add(this.label3);
			this.p_FilterContainerInner.Controls.Add(this.btn_ClearFilter);
			this.p_FilterContainerInner.Controls.Add(this.tb_Filter_City);
			this.p_FilterContainerInner.Controls.Add(this.label2);
			this.p_FilterContainerInner.Controls.Add(this.cb_FullMatch);
			this.p_FilterContainerInner.Controls.Add(this.btn_Filter);
			this.p_FilterContainerInner.Controls.Add(this.tb_Filter_Name);
			this.p_FilterContainerInner.Controls.Add(this.label1);
			this.p_FilterContainerInner.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.p_FilterContainerInner.Location = new System.Drawing.Point(0, 19);
			this.p_FilterContainerInner.Name = "p_FilterContainerInner";
			this.p_FilterContainerInner.Size = new System.Drawing.Size(989, 35);
			this.p_FilterContainerInner.TabIndex = 28;
			// 
			// cb_Filter_State
			// 
			this.cb_Filter_State.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cb_Filter_State.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.cb_Filter_State.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cb_Filter_State.FormattingEnabled = true;
			this.cb_Filter_State.Items.AddRange(new object[] {
            "Elköltözött",
            "Gyermekgondozási segély",
            "Hajléktalan",
            "Hátrányos helyzetű",
            "Háztartásbeli",
            "Munkanélküli",
            "Nagycsaládos",
            "Nyugdíjas",
            "Rokkant Nyugdíjas",
            "RÉV által felvéve",
            "Családsegítő által felvéve",
            "Ritkán jár"});
			this.cb_Filter_State.Location = new System.Drawing.Point(578, 8);
			this.cb_Filter_State.Name = "cb_Filter_State";
			this.cb_Filter_State.Size = new System.Drawing.Size(121, 21);
			this.cb_Filter_State.TabIndex = 17;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label3.Location = new System.Drawing.Point(527, 11);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(54, 13);
			this.label3.TabIndex = 16;
			this.label3.Text = "Állapot: ";
			// 
			// btn_ClearFilter
			// 
			this.btn_ClearFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_ClearFilter.Location = new System.Drawing.Point(808, 6);
			this.btn_ClearFilter.Name = "btn_ClearFilter";
			this.btn_ClearFilter.Size = new System.Drawing.Size(91, 23);
			this.btn_ClearFilter.TabIndex = 15;
			this.btn_ClearFilter.Text = "Szűrő törlése";
			this.btn_ClearFilter.UseVisualStyleBackColor = true;
			this.btn_ClearFilter.Click += new System.EventHandler(this.btn_ClearFilter_Click);
			// 
			// tb_Filter_City
			// 
			this.tb_Filter_City.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.tb_Filter_City.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.tb_Filter_City.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.tb_Filter_City.Location = new System.Drawing.Point(367, 8);
			this.tb_Filter_City.Name = "tb_Filter_City";
			this.tb_Filter_City.Size = new System.Drawing.Size(154, 20);
			this.tb_Filter_City.TabIndex = 14;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label2.Location = new System.Drawing.Point(311, 11);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 13);
			this.label2.TabIndex = 13;
			this.label2.Text = "Lakhely: ";
			// 
			// btn_Filter
			// 
			this.btn_Filter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Filter.Location = new System.Drawing.Point(905, 6);
			this.btn_Filter.Name = "btn_Filter";
			this.btn_Filter.Size = new System.Drawing.Size(75, 23);
			this.btn_Filter.TabIndex = 11;
			this.btn_Filter.Text = "Szűrés";
			this.btn_Filter.UseVisualStyleBackColor = true;
			this.btn_Filter.Click += new System.EventHandler(this.btn_Filter_Click);
			// 
			// tb_Filter_Name
			// 
			this.tb_Filter_Name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.tb_Filter_Name.Location = new System.Drawing.Point(47, 8);
			this.tb_Filter_Name.Name = "tb_Filter_Name";
			this.tb_Filter_Name.Size = new System.Drawing.Size(134, 20);
			this.tb_Filter_Name.TabIndex = 10;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label1.Location = new System.Drawing.Point(8, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "Név: ";
			// 
			// label9
			// 
			this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label9.Location = new System.Drawing.Point(759, 19);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(97, 13);
			this.label9.TabIndex = 25;
			this.label9.Text = "Ügyfél Állapota:";
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label7.Location = new System.Drawing.Point(523, 19);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(132, 13);
			this.label7.TabIndex = 24;
			this.label7.Text = "Ügyfél Hozzátartozói: ";
			// 
			// lbl_AdditionalInfo
			// 
			this.lbl_AdditionalInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lbl_AdditionalInfo.FlatAppearance.BorderSize = 0;
			this.lbl_AdditionalInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lbl_AdditionalInfo.Location = new System.Drawing.Point(878, -1);
			this.lbl_AdditionalInfo.Name = "lbl_AdditionalInfo";
			this.lbl_AdditionalInfo.Size = new System.Drawing.Size(111, 17);
			this.lbl_AdditionalInfo.TabIndex = 10;
			this.lbl_AdditionalInfo.Text = "   ▲     Részletek";
			this.lbl_AdditionalInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lbl_AdditionalInfo.UseVisualStyleBackColor = true;
			this.lbl_AdditionalInfo.Click += new System.EventHandler(this.lbl_AdditionalInfo_Click);
			// 
			// p_FilterPartition
			// 
			this.p_FilterPartition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.p_FilterPartition.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.p_FilterPartition.Location = new System.Drawing.Point(-2, 16);
			this.p_FilterPartition.Name = "p_FilterPartition";
			this.p_FilterPartition.Size = new System.Drawing.Size(996, 3);
			this.p_FilterPartition.TabIndex = 9;
			// 
			// lbl_SelectedCustomer_Dwelling_Street
			// 
			this.lbl_SelectedCustomer_Dwelling_Street.AutoSize = true;
			this.lbl_SelectedCustomer_Dwelling_Street.Location = new System.Drawing.Point(310, 70);
			this.lbl_SelectedCustomer_Dwelling_Street.Name = "lbl_SelectedCustomer_Dwelling_Street";
			this.lbl_SelectedCustomer_Dwelling_Street.Size = new System.Drawing.Size(9, 13);
			this.lbl_SelectedCustomer_Dwelling_Street.TabIndex = 21;
			this.lbl_SelectedCustomer_Dwelling_Street.Text = "|";
			// 
			// lbl_SelectedCustomer_Dwelling_ZipCode
			// 
			this.lbl_SelectedCustomer_Dwelling_ZipCode.AutoSize = true;
			this.lbl_SelectedCustomer_Dwelling_ZipCode.Location = new System.Drawing.Point(310, 55);
			this.lbl_SelectedCustomer_Dwelling_ZipCode.Name = "lbl_SelectedCustomer_Dwelling_ZipCode";
			this.lbl_SelectedCustomer_Dwelling_ZipCode.Size = new System.Drawing.Size(9, 13);
			this.lbl_SelectedCustomer_Dwelling_ZipCode.TabIndex = 22;
			this.lbl_SelectedCustomer_Dwelling_ZipCode.Text = "|";
			// 
			// lbl_SelectedCustomer_Dwelling_City
			// 
			this.lbl_SelectedCustomer_Dwelling_City.AutoSize = true;
			this.lbl_SelectedCustomer_Dwelling_City.Location = new System.Drawing.Point(310, 38);
			this.lbl_SelectedCustomer_Dwelling_City.Name = "lbl_SelectedCustomer_Dwelling_City";
			this.lbl_SelectedCustomer_Dwelling_City.Size = new System.Drawing.Size(9, 13);
			this.lbl_SelectedCustomer_Dwelling_City.TabIndex = 23;
			this.lbl_SelectedCustomer_Dwelling_City.Text = "|";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(215, 70);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(90, 13);
			this.label18.TabIndex = 17;
			this.label18.Text = "Utca / Házszám: ";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(215, 55);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(73, 13);
			this.label19.TabIndex = 18;
			this.label19.Text = "Irányítószám: ";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label12.Location = new System.Drawing.Point(198, 38);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(106, 13);
			this.label12.TabIndex = 15;
			this.label12.Text = "Ügyfél Lakhelye: ";
			// 
			// lbl_SelectedCustomer_JILead
			// 
			this.lbl_SelectedCustomer_JILead.AutoSize = true;
			this.lbl_SelectedCustomer_JILead.Location = new System.Drawing.Point(98, 70);
			this.lbl_SelectedCustomer_JILead.Name = "lbl_SelectedCustomer_JILead";
			this.lbl_SelectedCustomer_JILead.Size = new System.Drawing.Size(9, 13);
			this.lbl_SelectedCustomer_JILead.TabIndex = 14;
			this.lbl_SelectedCustomer_JILead.Text = "|";
			// 
			// lbl_SelectedCustomer_LastSupported
			// 
			this.lbl_SelectedCustomer_LastSupported.AutoSize = true;
			this.lbl_SelectedCustomer_LastSupported.Location = new System.Drawing.Point(98, 53);
			this.lbl_SelectedCustomer_LastSupported.Name = "lbl_SelectedCustomer_LastSupported";
			this.lbl_SelectedCustomer_LastSupported.Size = new System.Drawing.Size(9, 13);
			this.lbl_SelectedCustomer_LastSupported.TabIndex = 14;
			this.lbl_SelectedCustomer_LastSupported.Text = "|";
			// 
			// lbl_SelectedCustomer_Added
			// 
			this.lbl_SelectedCustomer_Added.AutoSize = true;
			this.lbl_SelectedCustomer_Added.Location = new System.Drawing.Point(98, 36);
			this.lbl_SelectedCustomer_Added.Name = "lbl_SelectedCustomer_Added";
			this.lbl_SelectedCustomer_Added.Size = new System.Drawing.Size(9, 13);
			this.lbl_SelectedCustomer_Added.TabIndex = 14;
			this.lbl_SelectedCustomer_Added.Text = "|";
			// 
			// lbl_SelectedCustomer_ID
			// 
			this.lbl_SelectedCustomer_ID.AutoSize = true;
			this.lbl_SelectedCustomer_ID.Location = new System.Drawing.Point(98, 19);
			this.lbl_SelectedCustomer_ID.Name = "lbl_SelectedCustomer_ID";
			this.lbl_SelectedCustomer_ID.Size = new System.Drawing.Size(9, 13);
			this.lbl_SelectedCustomer_ID.TabIndex = 14;
			this.lbl_SelectedCustomer_ID.Text = "|";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(17, 70);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(84, 13);
			this.label10.TabIndex = 13;
			this.label10.Text = "Jöv. Ig. Leadta: ";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(17, 53);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(67, 13);
			this.label8.TabIndex = 13;
			this.label8.Text = "Támogatva: ";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(17, 36);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(50, 13);
			this.label6.TabIndex = 13;
			this.label6.Text = "Felvétel: ";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(17, 19);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(61, 13);
			this.label5.TabIndex = 13;
			this.label5.Text = "Azonosító: ";
			// 
			// lbl_SelectedCustomer_Name
			// 
			this.lbl_SelectedCustomer_Name.AutoSize = true;
			this.lbl_SelectedCustomer_Name.Location = new System.Drawing.Point(98, 2);
			this.lbl_SelectedCustomer_Name.Name = "lbl_SelectedCustomer_Name";
			this.lbl_SelectedCustomer_Name.Size = new System.Drawing.Size(9, 13);
			this.lbl_SelectedCustomer_Name.TabIndex = 12;
			this.lbl_SelectedCustomer_Name.Text = "|";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label4.Location = new System.Drawing.Point(3, 2);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(93, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = "Kijelölt Ügyfél: ";
			// 
			// lb_SelectedCustomer_State
			// 
			this.lb_SelectedCustomer_State.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lb_SelectedCustomer_State.FormattingEnabled = true;
			this.lb_SelectedCustomer_State.Location = new System.Drawing.Point(762, 32);
			this.lb_SelectedCustomer_State.Name = "lb_SelectedCustomer_State";
			this.lb_SelectedCustomer_State.Size = new System.Drawing.Size(227, 4);
			this.lb_SelectedCustomer_State.TabIndex = 30;
			// 
			// lb_SelectedCustomer_Kin
			// 
			this.lb_SelectedCustomer_Kin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lb_SelectedCustomer_Kin.FormattingEnabled = true;
			this.lb_SelectedCustomer_Kin.Location = new System.Drawing.Point(526, 32);
			this.lb_SelectedCustomer_Kin.Name = "lb_SelectedCustomer_Kin";
			this.lb_SelectedCustomer_Kin.Size = new System.Drawing.Size(227, 4);
			this.lb_SelectedCustomer_Kin.TabIndex = 29;
			// 
			// dg_DataTable
			// 
			this.dg_DataTable.AllowUserToAddRows = false;
			this.dg_DataTable.AllowUserToDeleteRows = false;
			this.dg_DataTable.AllowUserToResizeRows = false;
			this.dg_DataTable.colors = null;
			this.dg_DataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dg_DataTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ch_CustomerName,
            this.ch_jovedelemig,
            this.ch_ID,
            this.ch_PlaceOfResidence,
            this.ch_State,
            this.ch_DateAdded,
            this.ch_LastSupport,
            this.ch_AddSupport});
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dg_DataTable.DefaultCellStyle = dataGridViewCellStyle2;
			this.dg_DataTable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dg_DataTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dg_DataTable.Location = new System.Drawing.Point(0, 50);
			this.dg_DataTable.MultiSelect = false;
			this.dg_DataTable.Name = "dg_DataTable";
			this.dg_DataTable.ReadOnly = true;
			this.dg_DataTable.RowHeadersVisible = false;
			this.dg_DataTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dg_DataTable.ShowEditingIcon = false;
			this.dg_DataTable.Size = new System.Drawing.Size(989, 373);
			this.dg_DataTable.TabIndex = 7;
			this.dg_DataTable.ColumnDividerDoubleClick += new System.Windows.Forms.DataGridViewColumnDividerDoubleClickEventHandler(this.dg_DataTable_ColumnDividerDoubleClick);
			this.dg_DataTable.MouseEnter += new System.EventHandler(this.dg_DataTable_MouseEnter);
			// 
			// tt_Tooltip
			// 
			this.tt_Tooltip.BackColor = System.Drawing.Color.LightYellow;
			this.tt_Tooltip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tt_Tooltip.font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.tt_Tooltip.Location = new System.Drawing.Point(-100, -100);
			this.tt_Tooltip.Name = "tt_Tooltip";
			this.tt_Tooltip.position = new System.Drawing.Point(10, 10);
			this.tt_Tooltip.Size = new System.Drawing.Size(13, 18);
			this.tt_Tooltip.TabIndex = 3;
			this.tt_Tooltip.text = "poop";
			this.tt_Tooltip.title = null;
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 50);
			// 
			// btn_FullScreen
			// 
			this.btn_FullScreen.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btn_FullScreen.AutoSize = false;
			this.btn_FullScreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btn_FullScreen.Image = global::CaritasManager.Properties.Resources.expand_32;
			this.btn_FullScreen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_FullScreen.Name = "btn_FullScreen";
			this.btn_FullScreen.Size = new System.Drawing.Size(36, 32);
			this.btn_FullScreen.Click += new System.EventHandler(this.btn_FullScreen_Click);
			// 
			// ch_CustomerName
			// 
			this.ch_CustomerName.HeaderText = "Ügyfél Név";
			this.ch_CustomerName.MinimumWidth = 200;
			this.ch_CustomerName.Name = "ch_CustomerName";
			this.ch_CustomerName.ReadOnly = true;
			this.ch_CustomerName.Width = 200;
			// 
			// ch_jovedelemig
			// 
			this.ch_jovedelemig.HeaderText = "J";
			this.ch_jovedelemig.Name = "ch_jovedelemig";
			this.ch_jovedelemig.ReadOnly = true;
			this.ch_jovedelemig.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.ch_jovedelemig.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.ch_jovedelemig.Width = 37;
			// 
			// ch_ID
			// 
			this.ch_ID.HeaderText = "Azonosító";
			this.ch_ID.Name = "ch_ID";
			this.ch_ID.ReadOnly = true;
			this.ch_ID.Width = 80;
			// 
			// ch_PlaceOfResidence
			// 
			this.ch_PlaceOfResidence.HeaderText = "Lakhely";
			this.ch_PlaceOfResidence.MinimumWidth = 200;
			this.ch_PlaceOfResidence.Name = "ch_PlaceOfResidence";
			this.ch_PlaceOfResidence.ReadOnly = true;
			this.ch_PlaceOfResidence.Width = 200;
			// 
			// ch_State
			//
			this.ch_State.HeaderText = "Állapot";
			this.ch_State.Name = "ch_State";
			this.ch_State.ReadOnly = true;
			// 
			// ch_DateAdded
			// 
			this.ch_DateAdded.HeaderText = "Felvétel Dátuma";
			this.ch_DateAdded.Name = "ch_DateAdded";
			this.ch_DateAdded.ReadOnly = true;
			// 
			// ch_LastSupport
			// 
			this.ch_LastSupport.HeaderText = "Legutóbbi Támogatás időpontja";
			this.ch_LastSupport.Name = "ch_LastSupport";
			this.ch_LastSupport.ReadOnly = true;
			this.ch_LastSupport.Width = 165;
			// 
			// ch_AddSupport
			//
			this.ch_AddSupport.HeaderText = "Támogatás";
			this.ch_AddSupport.MinimumWidth = 100;
			this.ch_AddSupport.Name = "ch_AddSupport";
			this.ch_AddSupport.ReadOnly = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(989, 499);
			this.Controls.Add(this.dg_DataTable);
			this.Controls.Add(this.p_FilterContainer);
			this.Controls.Add(this.tt_Tooltip);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.ts_Tools);
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Caritas Manager";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
			this.ts_Tools.ResumeLayout(false);
			this.ts_Tools.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.p_FilterContainer.ResumeLayout(false);
			this.p_FilterContainer.PerformLayout();
			this.p_FilterContainerInner.ResumeLayout(false);
			this.p_FilterContainerInner.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dg_DataTable)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip ts_Tools;
		private System.Windows.Forms.ToolStripButton btn_NewCustomer;
		private System.Windows.Forms.ToolStripButton btn_Settings;
		private System.Windows.Forms.ToolStripButton btn_Edit;
		private uc_Tooltip tt_Tooltip;
		private System.Windows.Forms.Timer t_Timer;
		private System.Windows.Forms.ToolStripButton btn_Exit;
		private System.Windows.Forms.ToolStripButton btn_DatabaseBackup;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel lbl_NumOfCustomers;
		private System.Windows.Forms.ToolStripStatusLabel lbl_LoggedInAs;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Panel p_FilterContainer;
		private System.Windows.Forms.Panel p_FilterPartition;
		private System.Windows.Forms.Button lbl_AdditionalInfo;
		private System.Windows.Forms.Label lbl_SelectedCustomer_Name;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lbl_SelectedCustomer_ID;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lbl_SelectedCustomer_JILead;
		private System.Windows.Forms.Label lbl_SelectedCustomer_LastSupported;
		private System.Windows.Forms.Label lbl_SelectedCustomer_Added;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lbl_SelectedCustomer_Dwelling_Street;
		private System.Windows.Forms.Label lbl_SelectedCustomer_Dwelling_ZipCode;
		private System.Windows.Forms.Label lbl_SelectedCustomer_Dwelling_City;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Panel p_FilterContainerInner;
		private System.Windows.Forms.ComboBox cb_Filter_State;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btn_ClearFilter;
		private System.Windows.Forms.TextBox tb_Filter_City;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox cb_FullMatch;
		private System.Windows.Forms.Button btn_Filter;
		private System.Windows.Forms.TextBox tb_Filter_Name;
		private System.Windows.Forms.Label label1;
		private myDataGridView dg_DataTable;
		private System.Windows.Forms.ListBox lb_SelectedCustomer_State;
		private System.Windows.Forms.ListBox lb_SelectedCustomer_Kin;
		private System.Windows.Forms.ToolStripButton btn_Help;
		private System.Windows.Forms.ToolStripButton btn_FullScreen;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.DataGridViewTextBoxColumn ch_CustomerName;
		private System.Windows.Forms.DataGridViewImageColumn ch_jovedelemig;
		private System.Windows.Forms.DataGridViewTextBoxColumn ch_ID;
		private System.Windows.Forms.DataGridViewTextBoxColumn ch_PlaceOfResidence;
		private System.Windows.Forms.DataGridViewTextBoxColumn ch_State;
		private System.Windows.Forms.DataGridViewTextBoxColumn ch_DateAdded;
		private System.Windows.Forms.DataGridViewTextBoxColumn ch_LastSupport;
		private System.Windows.Forms.DataGridViewButtonColumn ch_AddSupport;
	}
}

