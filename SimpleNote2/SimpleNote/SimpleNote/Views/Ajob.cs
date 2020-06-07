using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleNote.Models;
using SimpleNote.Controllers;

namespace SimpleNote
{
    public partial class Ajob : UserControl
    {
        private DataRow job;
        public DataRow Job { get => job; set => job = value; }
        NoteController noteController = new NoteController();
        RemindNoteController remindNoteController = new RemindNoteController();

        private event EventHandler edited;
        public event EventHandler Edited
        {
            add { edited += value; }
            remove { edited -= value; }
        }

        private event EventHandler deleteed;
        public event EventHandler Deleteed
        {
            add { deleteed += value; }
            remove { deleteed -= value; }
        }



        public Ajob(DataRow job)
        {
            InitializeComponent();
            this.Job = job;
            ShowInfo(); 
        }

        void ShowInfo()
        {            
            DataTable dt = noteController.getNoteName((int)Job[0]);
            this.txbJob.DataBindings.Add("Text", dt, "NoteName");
            this.txbJob.ReadOnly = true;
            dtpDateRemind.Value = DateTime.Parse(Job[1].ToString());
            cbStatus.Text = Job[2].ToString();
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (deleteed != null)
                deleteed(this, new EventArgs());
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Job[1] = dtpDateRemind.Value;
            Job[2] = cbStatus.Text;
            remindNoteController.UpdateRemindNote((int)Job[0], (DateTime)Job[1], (string)Job[2]);
            if (edited != null)
                edited(this, new EventArgs());
        }

      

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
