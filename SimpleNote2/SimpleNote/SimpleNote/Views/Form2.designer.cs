namespace SimpleNote
{
    partial class Form2
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPreviours = new System.Windows.Forms.Button();
            this.btnToday = new System.Windows.Forms.Button();
            this.dtpkDate = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnThursday = new System.Windows.Forms.Button();
            this.btnFriday = new System.Windows.Forms.Button();
            this.btnTuesday = new System.Windows.Forms.Button();
            this.btnWednesday = new System.Windows.Forms.Button();
            this.btnSaturday = new System.Windows.Forms.Button();
            this.btnSunday = new System.Windows.Forms.Button();
            this.btnMonday = new System.Windows.Forms.Button();
            this.pnlMatrix = new System.Windows.Forms.Panel();
            this.nmNotify = new System.Windows.Forms.NumericUpDown();
            this.ckbNotify = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmNotify)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(9, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(833, 458);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.btnNext);
            this.panel3.Controls.Add(this.btnPreviours);
            this.panel3.Controls.Add(this.btnToday);
            this.panel3.Controls.Add(this.dtpkDate);
            this.panel3.Location = new System.Drawing.Point(2, 2);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(829, 40);
            this.panel3.TabIndex = 1;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.nmNotify);
            this.panel6.Controls.Add(this.ckbNotify);
            this.panel6.Location = new System.Drawing.Point(64, 5);
            this.panel6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(173, 35);
            this.panel6.TabIndex = 2;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(708, 2);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(64, 35);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click_1);
            // 
            // btnPreviours
            // 
            this.btnPreviours.Location = new System.Drawing.Point(518, 2);
            this.btnPreviours.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPreviours.Name = "btnPreviours";
            this.btnPreviours.Size = new System.Drawing.Size(64, 35);
            this.btnPreviours.TabIndex = 1;
            this.btnPreviours.Text = "<";
            this.btnPreviours.UseVisualStyleBackColor = true;
            this.btnPreviours.Click += new System.EventHandler(this.btnPreviours_Click_1);
            // 
            // btnToday
            // 
            this.btnToday.Location = new System.Drawing.Point(596, 2);
            this.btnToday.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(98, 35);
            this.btnToday.TabIndex = 1;
            this.btnToday.Text = "Today";
            this.btnToday.UseVisualStyleBackColor = true;
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click_1);
            // 
            // dtpkDate
            // 
            this.dtpkDate.Location = new System.Drawing.Point(308, 11);
            this.dtpkDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpkDate.Name = "dtpkDate";
            this.dtpkDate.Size = new System.Drawing.Size(190, 20);
            this.dtpkDate.TabIndex = 0;
            this.dtpkDate.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.pnlMatrix);
            this.panel2.Location = new System.Drawing.Point(2, 54);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(831, 396);
            this.panel2.TabIndex = 0;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnThursday);
            this.panel5.Controls.Add(this.btnFriday);
            this.panel5.Controls.Add(this.btnTuesday);
            this.panel5.Controls.Add(this.btnWednesday);
            this.panel5.Controls.Add(this.btnSaturday);
            this.panel5.Controls.Add(this.btnSunday);
            this.panel5.Controls.Add(this.btnMonday);
            this.panel5.Location = new System.Drawing.Point(2, 2);
            this.panel5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(826, 39);
            this.panel5.TabIndex = 2;
            // 
            // btnThursday
            // 
            this.btnThursday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnThursday.Location = new System.Drawing.Point(368, 2);
            this.btnThursday.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnThursday.Name = "btnThursday";
            this.btnThursday.Size = new System.Drawing.Size(98, 35);
            this.btnThursday.TabIndex = 8;
            this.btnThursday.Text = "Thursday";
            this.btnThursday.UseVisualStyleBackColor = false;
            // 
            // btnFriday
            // 
            this.btnFriday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnFriday.Location = new System.Drawing.Point(470, 2);
            this.btnFriday.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFriday.Name = "btnFriday";
            this.btnFriday.Size = new System.Drawing.Size(98, 35);
            this.btnFriday.TabIndex = 7;
            this.btnFriday.Text = "Friday";
            this.btnFriday.UseVisualStyleBackColor = false;
            this.btnFriday.Click += new System.EventHandler(this.button8_Click);
            // 
            // btnTuesday
            // 
            this.btnTuesday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnTuesday.Location = new System.Drawing.Point(164, 2);
            this.btnTuesday.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTuesday.Name = "btnTuesday";
            this.btnTuesday.Size = new System.Drawing.Size(98, 35);
            this.btnTuesday.TabIndex = 6;
            this.btnTuesday.Text = "Tuesday";
            this.btnTuesday.UseVisualStyleBackColor = false;
            // 
            // btnWednesday
            // 
            this.btnWednesday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnWednesday.Location = new System.Drawing.Point(266, 2);
            this.btnWednesday.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnWednesday.Name = "btnWednesday";
            this.btnWednesday.Size = new System.Drawing.Size(98, 35);
            this.btnWednesday.TabIndex = 5;
            this.btnWednesday.Text = "Wednesday";
            this.btnWednesday.UseVisualStyleBackColor = false;
            this.btnWednesday.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnSaturday
            // 
            this.btnSaturday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnSaturday.Location = new System.Drawing.Point(572, 2);
            this.btnSaturday.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSaturday.Name = "btnSaturday";
            this.btnSaturday.Size = new System.Drawing.Size(98, 35);
            this.btnSaturday.TabIndex = 4;
            this.btnSaturday.Text = "Saturday";
            this.btnSaturday.UseVisualStyleBackColor = false;
            // 
            // btnSunday
            // 
            this.btnSunday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnSunday.Location = new System.Drawing.Point(674, 2);
            this.btnSunday.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSunday.Name = "btnSunday";
            this.btnSunday.Size = new System.Drawing.Size(98, 35);
            this.btnSunday.TabIndex = 3;
            this.btnSunday.Text = "Sunday";
            this.btnSunday.UseVisualStyleBackColor = false;
            // 
            // btnMonday
            // 
            this.btnMonday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnMonday.ForeColor = System.Drawing.Color.Black;
            this.btnMonday.Location = new System.Drawing.Point(62, 2);
            this.btnMonday.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMonday.Name = "btnMonday";
            this.btnMonday.Size = new System.Drawing.Size(98, 35);
            this.btnMonday.TabIndex = 2;
            this.btnMonday.Text = "Monday";
            this.btnMonday.UseVisualStyleBackColor = false;
            this.btnMonday.Click += new System.EventHandler(this.btnMonday_Click_1);
            // 
            // pnlMatrix
            // 
            this.pnlMatrix.Location = new System.Drawing.Point(64, 46);
            this.pnlMatrix.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlMatrix.Name = "pnlMatrix";
            this.pnlMatrix.Size = new System.Drawing.Size(709, 340);
            this.pnlMatrix.TabIndex = 1;
            this.pnlMatrix.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // nmNotify
            // 
            this.nmNotify.Enabled = false;
            this.nmNotify.Location = new System.Drawing.Point(56, 7);
            this.nmNotify.Margin = new System.Windows.Forms.Padding(2);
            this.nmNotify.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.nmNotify.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmNotify.Name = "nmNotify";
            this.nmNotify.Size = new System.Drawing.Size(46, 20);
            this.nmNotify.TabIndex = 1;
            this.nmNotify.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmNotify.ValueChanged += new System.EventHandler(this.nmNotify_ValueChanged);
            // 
            // ckbNotify
            // 
            this.ckbNotify.AutoSize = true;
            this.ckbNotify.Location = new System.Drawing.Point(2, 8);
            this.ckbNotify.Margin = new System.Windows.Forms.Padding(2);
            this.ckbNotify.Name = "ckbNotify";
            this.ckbNotify.Size = new System.Drawing.Size(53, 17);
            this.ckbNotify.TabIndex = 0;
            this.ckbNotify.Text = "Notify";
            this.ckbNotify.UseVisualStyleBackColor = true;
            this.ckbNotify.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 496);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calendar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmNotify)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlMatrix;
        private System.Windows.Forms.DateTimePicker dtpkDate;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPreviours;
        private System.Windows.Forms.Button btnToday;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnFriday;
        private System.Windows.Forms.Button btnTuesday;
        private System.Windows.Forms.Button btnWednesday;
        private System.Windows.Forms.Button btnSaturday;
        private System.Windows.Forms.Button btnSunday;
        private System.Windows.Forms.Button btnMonday;
        private System.Windows.Forms.Button btnThursday;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.NumericUpDown nmNotify;
        private System.Windows.Forms.CheckBox ckbNotify;
    }
}

