namespace CaritasManager
{
	partial class f_AddState
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
			this.lbl_StateGreeting = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cb_States = new System.Windows.Forms.ComboBox();
			this.btn_Cancel = new System.Windows.Forms.Button();
			this.btn_Add = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lbl_StateGreeting
			// 
			this.lbl_StateGreeting.AutoSize = true;
			this.lbl_StateGreeting.Location = new System.Drawing.Point(12, 9);
			this.lbl_StateGreeting.Name = "lbl_StateGreeting";
			this.lbl_StateGreeting.Size = new System.Drawing.Size(192, 13);
			this.lbl_StateGreeting.TabIndex = 0;
			this.lbl_StateGreeting.Text = "Állapot hozzáadása <name> ügyfélnek:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(45, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Állapot: ";
			// 
			// cb_States
			// 
			this.cb_States.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.cb_States.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cb_States.FormattingEnabled = true;
			this.cb_States.Items.AddRange(new object[] {
            "Elköltözött",
            "?EU?",
            "Gyermekgondozási segély",
            "Hajléktalan",
            "Halmozottan hátrányos helyzetű",
            "?Határban lakik?",
            "?Málnát növeszt?",
            "Nagycsaládos",
            "Nyugdíjas",
            "?RÉV?",
            "Rokkant Nyugdíjas",
            "Ritkán jár",
            "???"});
			this.cb_States.Location = new System.Drawing.Point(63, 37);
			this.cb_States.Name = "cb_States";
			this.cb_States.Size = new System.Drawing.Size(193, 21);
			this.cb_States.TabIndex = 2;
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.Location = new System.Drawing.Point(12, 85);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_Cancel.TabIndex = 3;
			this.btn_Cancel.Text = "Mégse";
			this.btn_Cancel.UseVisualStyleBackColor = true;
			this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
			// 
			// btn_Add
			// 
			this.btn_Add.Location = new System.Drawing.Point(195, 85);
			this.btn_Add.Name = "btn_Add";
			this.btn_Add.Size = new System.Drawing.Size(75, 23);
			this.btn_Add.TabIndex = 4;
			this.btn_Add.Text = "Hozzáadás";
			this.btn_Add.UseVisualStyleBackColor = true;
			this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
			// 
			// f_AddState
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(282, 120);
			this.ControlBox = false;
			this.Controls.Add(this.btn_Add);
			this.Controls.Add(this.btn_Cancel);
			this.Controls.Add(this.cb_States);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lbl_StateGreeting);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "f_AddState";
			this.ShowIcon = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Állapot hozzáadása";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbl_StateGreeting;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cb_States;
		private System.Windows.Forms.Button btn_Cancel;
		private System.Windows.Forms.Button btn_Add;
	}
}