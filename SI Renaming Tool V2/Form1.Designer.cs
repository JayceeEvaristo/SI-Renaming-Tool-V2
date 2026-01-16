namespace SI_Renaming_Tool_V2_V2
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_worksheet = new System.Windows.Forms.ComboBox();
            this.btn_select_loc_mf = new System.Windows.Forms.Button();
            this.lbl_masfile_loc = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_select_location_si = new System.Windows.Forms.Button();
            this.lbl_ser_inv_loc = new System.Windows.Forms.Label();
            this.btn_start = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_start_emailing = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_renamed_SI = new System.Windows.Forms.Button();
            this.lbl_renamed_si_loc = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_email_masfile = new System.Windows.Forms.Button();
            this.lbl_email_masfile_loc = new System.Windows.Forms.Label();
            this.cb_test = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cb_worksheet);
            this.groupBox1.Controls.Add(this.btn_select_loc_mf);
            this.groupBox1.Controls.Add(this.lbl_masfile_loc);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(499, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Master File Location";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(6, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select Worksheet:";
            // 
            // cb_worksheet
            // 
            this.cb_worksheet.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_worksheet.FormattingEnabled = true;
            this.cb_worksheet.Location = new System.Drawing.Point(145, 71);
            this.cb_worksheet.Name = "cb_worksheet";
            this.cb_worksheet.Size = new System.Drawing.Size(348, 21);
            this.cb_worksheet.TabIndex = 2;
            this.cb_worksheet.SelectedIndexChanged += new System.EventHandler(this.cb_worksheet_SelectedIndexChanged);
            // 
            // btn_select_loc_mf
            // 
            this.btn_select_loc_mf.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_select_loc_mf.Location = new System.Drawing.Point(418, 42);
            this.btn_select_loc_mf.Name = "btn_select_loc_mf";
            this.btn_select_loc_mf.Size = new System.Drawing.Size(75, 23);
            this.btn_select_loc_mf.TabIndex = 1;
            this.btn_select_loc_mf.Text = "Select";
            this.btn_select_loc_mf.UseVisualStyleBackColor = true;
            this.btn_select_loc_mf.Click += new System.EventHandler(this.btn_select_loc_mf_Click);
            // 
            // lbl_masfile_loc
            // 
            this.lbl_masfile_loc.AutoSize = true;
            this.lbl_masfile_loc.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lbl_masfile_loc.Location = new System.Drawing.Point(6, 25);
            this.lbl_masfile_loc.Name = "lbl_masfile_loc";
            this.lbl_masfile_loc.Size = new System.Drawing.Size(242, 13);
            this.lbl_masfile_loc.TabIndex = 0;
            this.lbl_masfile_loc.Text = "Press the button to select Master File location";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_select_location_si);
            this.groupBox2.Controls.Add(this.lbl_ser_inv_loc);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(6, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(499, 83);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Service Invoice Location";
            // 
            // btn_select_location_si
            // 
            this.btn_select_location_si.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_select_location_si.Location = new System.Drawing.Point(418, 54);
            this.btn_select_location_si.Name = "btn_select_location_si";
            this.btn_select_location_si.Size = new System.Drawing.Size(75, 23);
            this.btn_select_location_si.TabIndex = 1;
            this.btn_select_location_si.Text = "Select";
            this.btn_select_location_si.UseVisualStyleBackColor = true;
            this.btn_select_location_si.Click += new System.EventHandler(this.btn_select_location_si_Click);
            // 
            // lbl_ser_inv_loc
            // 
            this.lbl_ser_inv_loc.AutoSize = true;
            this.lbl_ser_inv_loc.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lbl_ser_inv_loc.Location = new System.Drawing.Point(6, 25);
            this.lbl_ser_inv_loc.Name = "lbl_ser_inv_loc";
            this.lbl_ser_inv_loc.Size = new System.Drawing.Size(260, 13);
            this.lbl_ser_inv_loc.TabIndex = 0;
            this.lbl_ser_inv_loc.Text = "Press the button to select Service Invoice location";
            // 
            // btn_start
            // 
            this.btn_start.Enabled = false;
            this.btn_start.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_start.Location = new System.Drawing.Point(221, 207);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 2;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(528, 262);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.btn_start);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(520, 236);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Renaming";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cb_test);
            this.tabPage2.Controls.Add(this.btn_start_emailing);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(520, 236);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Emailing";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_start_emailing
            // 
            this.btn_start_emailing.Enabled = false;
            this.btn_start_emailing.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_start_emailing.Location = new System.Drawing.Point(219, 205);
            this.btn_start_emailing.Name = "btn_start_emailing";
            this.btn_start_emailing.Size = new System.Drawing.Size(75, 23);
            this.btn_start_emailing.TabIndex = 4;
            this.btn_start_emailing.Text = "Start";
            this.btn_start_emailing.UseVisualStyleBackColor = true;
            this.btn_start_emailing.Click += new System.EventHandler(this.btn_start_emailing_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_renamed_SI);
            this.groupBox4.Controls.Add(this.lbl_renamed_si_loc);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox4.Location = new System.Drawing.Point(8, 89);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(506, 83);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Renamed Service Invoice Location";
            // 
            // btn_renamed_SI
            // 
            this.btn_renamed_SI.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_renamed_SI.Location = new System.Drawing.Point(418, 54);
            this.btn_renamed_SI.Name = "btn_renamed_SI";
            this.btn_renamed_SI.Size = new System.Drawing.Size(75, 23);
            this.btn_renamed_SI.TabIndex = 1;
            this.btn_renamed_SI.Text = "Select";
            this.btn_renamed_SI.UseVisualStyleBackColor = true;
            this.btn_renamed_SI.Click += new System.EventHandler(this.btn_renamed_SI_Click);
            // 
            // lbl_renamed_si_loc
            // 
            this.lbl_renamed_si_loc.AutoSize = true;
            this.lbl_renamed_si_loc.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lbl_renamed_si_loc.Location = new System.Drawing.Point(6, 25);
            this.lbl_renamed_si_loc.Name = "lbl_renamed_si_loc";
            this.lbl_renamed_si_loc.Size = new System.Drawing.Size(311, 13);
            this.lbl_renamed_si_loc.TabIndex = 0;
            this.lbl_renamed_si_loc.Text = "Press the button to select Renamed Service Invoice location";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_email_masfile);
            this.groupBox3.Controls.Add(this.lbl_email_masfile_loc);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(8, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(506, 77);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Email Master File Location";
            // 
            // btn_email_masfile
            // 
            this.btn_email_masfile.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_email_masfile.Location = new System.Drawing.Point(418, 44);
            this.btn_email_masfile.Name = "btn_email_masfile";
            this.btn_email_masfile.Size = new System.Drawing.Size(75, 23);
            this.btn_email_masfile.TabIndex = 1;
            this.btn_email_masfile.Text = "Select";
            this.btn_email_masfile.UseVisualStyleBackColor = true;
            this.btn_email_masfile.Click += new System.EventHandler(this.btn_email_masfile_Click);
            // 
            // lbl_email_masfile_loc
            // 
            this.lbl_email_masfile_loc.AutoSize = true;
            this.lbl_email_masfile_loc.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lbl_email_masfile_loc.Location = new System.Drawing.Point(6, 25);
            this.lbl_email_masfile_loc.Name = "lbl_email_masfile_loc";
            this.lbl_email_masfile_loc.Size = new System.Drawing.Size(272, 13);
            this.lbl_email_masfile_loc.TabIndex = 0;
            this.lbl_email_masfile_loc.Text = "Press the button to select Email Master File location";
            // 
            // cb_test
            // 
            this.cb_test.AutoSize = true;
            this.cb_test.Checked = true;
            this.cb_test.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_test.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cb_test.Location = new System.Drawing.Point(212, 180);
            this.cb_test.Name = "cb_test";
            this.cb_test.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cb_test.Size = new System.Drawing.Size(90, 19);
            this.cb_test.TabIndex = 5;
            this.cb_test.Text = "Test to Excel";
            this.cb_test.UseVisualStyleBackColor = true;
            this.cb_test.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 262);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SI Renaming Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_select_loc_mf;
        private System.Windows.Forms.Label lbl_masfile_loc;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_select_location_si;
        private System.Windows.Forms.Label lbl_ser_inv_loc;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_worksheet;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_start_emailing;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_renamed_SI;
        private System.Windows.Forms.Label lbl_renamed_si_loc;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_email_masfile;
        private System.Windows.Forms.Label lbl_email_masfile_loc;
        private System.Windows.Forms.CheckBox cb_test;
    }
}

