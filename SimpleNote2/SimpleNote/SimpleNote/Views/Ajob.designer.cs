namespace SimpleNote
{
    partial class Ajob
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.txbJob = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpDateRemind = new System.Windows.Forms.DateTimePicker();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txbJob);
            this.panel1.Location = new System.Drawing.Point(2, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(190, 27);
            this.panel1.TabIndex = 0;
            // 
            // txbJob
            // 
            this.txbJob.Location = new System.Drawing.Point(2, 3);
            this.txbJob.Margin = new System.Windows.Forms.Padding(2);
            this.txbJob.Name = "txbJob";
            this.txbJob.Size = new System.Drawing.Size(186, 20);
            this.txbJob.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtpDateRemind);
            this.panel2.Controls.Add(this.btnDel);
            this.panel2.Controls.Add(this.btnEdit);
            this.panel2.Controls.Add(this.cbStatus);
            this.panel2.Location = new System.Drawing.Point(196, 5);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(377, 27);
            this.panel2.TabIndex = 1;
            // 
            // dtpDateRemind
            // 
            this.dtpDateRemind.CustomFormat = "dd/MM/yyy hh:mm";
            this.dtpDateRemind.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateRemind.Location = new System.Drawing.Point(1, 2);
            this.dtpDateRemind.Name = "dtpDateRemind";
            this.dtpDateRemind.Size = new System.Drawing.Size(127, 20);
            this.dtpDateRemind.TabIndex = 9;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(318, 3);
            this.btnDel.Margin = new System.Windows.Forms.Padding(2);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(47, 19);
            this.btnDel.TabIndex = 8;
            this.btnDel.Text = "Del";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(267, 3);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(47, 19);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "DONE",
            "DOING",
            "COMING",
            "MISSED"});
            this.cbStatus.Location = new System.Drawing.Point(133, 3);
            this.cbStatus.Margin = new System.Windows.Forms.Padding(2);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(130, 21);
            this.cbStatus.TabIndex = 6;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
            // 
            // Ajob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Ajob";
            this.Size = new System.Drawing.Size(577, 39);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txbJob;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.DateTimePicker dtpDateRemind;
    }
}
