namespace BLOOD_MANAGEMENT_SYSREM
{
    partial class PDonor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PDonor));
            this.DLastDonationDate = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.DBGroupCB = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.DAddressTb = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.DGenderCb = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.DAgeTb = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.DPhoneTb = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.DNameTb = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // DLastDonationDate
            // 
            this.DLastDonationDate.Location = new System.Drawing.Point(26, 467);
            this.DLastDonationDate.Name = "DLastDonationDate";
            this.DLastDonationDate.Size = new System.Drawing.Size(247, 22);
            this.DLastDonationDate.TabIndex = 36;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.White;
            this.label18.Font = new System.Drawing.Font("Arial Narrow", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(20, 433);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(215, 31);
            this.label18.TabIndex = 35;
            this.label18.Text = "Last Donation Date";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Aqua;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(380, 513);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 62);
            this.button1.TabIndex = 33;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // DBGroupCB
            // 
            this.DBGroupCB.FormattingEnabled = true;
            this.DBGroupCB.Items.AddRange(new object[] {
            "A+",
            "A-",
            "O+",
            "O-",
            "B+",
            "B-",
            "AB+",
            "AB-"});
            this.DBGroupCB.Location = new System.Drawing.Point(343, 384);
            this.DBGroupCB.Name = "DBGroupCB";
            this.DBGroupCB.Size = new System.Drawing.Size(252, 24);
            this.DBGroupCB.TabIndex = 32;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.White;
            this.label16.Font = new System.Drawing.Font("Arial Narrow", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(337, 335);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(152, 31);
            this.label16.TabIndex = 31;
            this.label16.Text = "Blood Group";
            // 
            // DAddressTb
            // 
            this.DAddressTb.BackColor = System.Drawing.Color.White;
            this.DAddressTb.Location = new System.Drawing.Point(776, 397);
            this.DAddressTb.Multiline = true;
            this.DAddressTb.Name = "DAddressTb";
            this.DAddressTb.Size = new System.Drawing.Size(207, 120);
            this.DAddressTb.TabIndex = 30;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.White;
            this.label15.Font = new System.Drawing.Font("Arial Narrow", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(770, 347);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(103, 31);
            this.label15.TabIndex = 29;
            this.label15.Text = "Address";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.Font = new System.Drawing.Font("Arial Narrow", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(20, 335);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 31);
            this.label14.TabIndex = 28;
            this.label14.Text = "Phone";
            // 
            // DGenderCb
            // 
            this.DGenderCb.FormattingEnabled = true;
            this.DGenderCb.Items.AddRange(new object[] {
            "male ",
            "female"});
            this.DGenderCb.Location = new System.Drawing.Point(744, 243);
            this.DGenderCb.Name = "DGenderCb";
            this.DGenderCb.Size = new System.Drawing.Size(252, 24);
            this.DGenderCb.TabIndex = 27;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Font = new System.Drawing.Font("Arial Narrow", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(337, 200);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 31);
            this.label13.TabIndex = 26;
            this.label13.Text = "Age";
            // 
            // DAgeTb
            // 
            this.DAgeTb.BackColor = System.Drawing.Color.White;
            this.DAgeTb.Location = new System.Drawing.Point(343, 243);
            this.DAgeTb.Multiline = true;
            this.DAgeTb.Name = "DAgeTb";
            this.DAgeTb.Size = new System.Drawing.Size(263, 38);
            this.DAgeTb.TabIndex = 25;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("Arial Narrow", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(738, 200);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 31);
            this.label12.TabIndex = 24;
            this.label12.Text = "Gender";
            // 
            // DPhoneTb
            // 
            this.DPhoneTb.BackColor = System.Drawing.Color.White;
            this.DPhoneTb.Location = new System.Drawing.Point(26, 372);
            this.DPhoneTb.Multiline = true;
            this.DPhoneTb.Name = "DPhoneTb";
            this.DPhoneTb.Size = new System.Drawing.Size(247, 36);
            this.DPhoneTb.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Arial Narrow", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(20, 200);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 31);
            this.label11.TabIndex = 22;
            this.label11.Text = "Name ";
            // 
            // DNameTb
            // 
            this.DNameTb.BackColor = System.Drawing.Color.White;
            this.DNameTb.Location = new System.Drawing.Point(26, 243);
            this.DNameTb.Multiline = true;
            this.DNameTb.Name = "DNameTb";
            this.DNameTb.Size = new System.Drawing.Size(247, 38);
            this.DNameTb.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Arial Narrow", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(384, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 40);
            this.label10.TabIndex = 20;
            this.label10.Text = "Donor ";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(347, 95);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(173, 92);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 34;
            this.pictureBox2.TabStop = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Aqua;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(570, 513);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 62);
            this.button2.TabIndex = 37;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // PDonor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1017, 626);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.DLastDonationDate);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DBGroupCB);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.DAddressTb);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.DGenderCb);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.DAgeTb);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.DPhoneTb);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.DNameTb);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pictureBox2);
            this.Name = "PDonor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDonor";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DLastDonationDate;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox DBGroupCB;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox DAddressTb;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox DGenderCb;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox DAgeTb;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox DPhoneTb;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox DNameTb;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button2;
    }
}