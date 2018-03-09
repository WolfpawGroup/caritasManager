namespace CaritasManager
{
	partial class f_AddVagyon
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
			this.rb_Income = new System.Windows.Forms.RadioButton();
			this.rb_Expenditure = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.tb_Name = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.num_Amount = new System.Windows.Forms.NumericUpDown();
			this.btn_Cancel = new System.Windows.Forms.Button();
			this.btn_Save = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.num_Amount)).BeginInit();
			this.SuspendLayout();
			// 
			// rb_Income
			// 
			this.rb_Income.AutoSize = true;
			this.rb_Income.Checked = true;
			this.rb_Income.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.rb_Income.Location = new System.Drawing.Point(12, 12);
			this.rb_Income.Name = "rb_Income";
			this.rb_Income.Size = new System.Drawing.Size(80, 24);
			this.rb_Income.TabIndex = 0;
			this.rb_Income.TabStop = true;
			this.rb_Income.Text = "Bevétel";
			this.rb_Income.UseVisualStyleBackColor = true;
			// 
			// rb_Expenditure
			// 
			this.rb_Expenditure.AutoSize = true;
			this.rb_Expenditure.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.rb_Expenditure.Location = new System.Drawing.Point(12, 37);
			this.rb_Expenditure.Name = "rb_Expenditure";
			this.rb_Expenditure.Size = new System.Drawing.Size(75, 24);
			this.rb_Expenditure.TabIndex = 1;
			this.rb_Expenditure.Text = "Kiadás";
			this.rb_Expenditure.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label1.Location = new System.Drawing.Point(114, 39);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(107, 20);
			this.label1.TabIndex = 2;
			this.label1.Text = "Megnevezés: ";
			// 
			// tb_Name
			// 
			this.tb_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tb_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.tb_Name.Location = new System.Drawing.Point(227, 39);
			this.tb_Name.Name = "tb_Name";
			this.tb_Name.Size = new System.Drawing.Size(249, 22);
			this.tb_Name.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label2.Location = new System.Drawing.Point(491, 39);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(71, 20);
			this.label2.TabIndex = 4;
			this.label2.Text = "Összeg: ";
			// 
			// num_Amount
			// 
			this.num_Amount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.num_Amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.num_Amount.Location = new System.Drawing.Point(568, 40);
			this.num_Amount.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
			this.num_Amount.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
			this.num_Amount.Name = "num_Amount";
			this.num_Amount.Size = new System.Drawing.Size(106, 22);
			this.num_Amount.TabIndex = 5;
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btn_Cancel.Location = new System.Drawing.Point(12, 79);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new System.Drawing.Size(89, 33);
			this.btn_Cancel.TabIndex = 6;
			this.btn_Cancel.Text = "Mégse";
			this.btn_Cancel.UseVisualStyleBackColor = true;
			this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
			// 
			// btn_Save
			// 
			this.btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btn_Save.Location = new System.Drawing.Point(585, 79);
			this.btn_Save.Name = "btn_Save";
			this.btn_Save.Size = new System.Drawing.Size(89, 33);
			this.btn_Save.TabIndex = 7;
			this.btn_Save.Text = "Mentés";
			this.btn_Save.UseVisualStyleBackColor = true;
			this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
			// 
			// f_AddVagyon
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(688, 121);
			this.Controls.Add(this.btn_Save);
			this.Controls.Add(this.btn_Cancel);
			this.Controls.Add(this.num_Amount);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tb_Name);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.rb_Expenditure);
			this.Controls.Add(this.rb_Income);
			this.MaximumSize = new System.Drawing.Size(10000, 160);
			this.MinimumSize = new System.Drawing.Size(586, 160);
			this.Name = "f_AddVagyon";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Bevétel / Kiadás hozzáadása";
			((System.ComponentModel.ISupportInitialize)(this.num_Amount)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RadioButton rb_Income;
		private System.Windows.Forms.RadioButton rb_Expenditure;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tb_Name;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown num_Amount;
		private System.Windows.Forms.Button btn_Cancel;
		private System.Windows.Forms.Button btn_Save;
	}
}