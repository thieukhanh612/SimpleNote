using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleNote.Controllers;

namespace SimpleNote.Views
{
    public partial class NextJob : UserControl
    {
        NoteController noteController = new NoteController();
        RemindNoteController remindNoteController = new RemindNoteController();
        private DataRow note;
        public DataRow Note { get => note; set => note = value; }
        public NextJob(DataRow Note)
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            this.Note = Note;
            this.label1.Text = Note[0].ToString();
            this.label2.Text = ((DateTime)Note[1]).ToString("dd/MM/yyyy HH:mm");
            if (DateTime.Now.CompareTo((DateTime)Note[1]) == 1)
            {
                this.label2.ForeColor = Color.Red;
            }
            this.label3.Text = Note[2].ToString();
            

        }

        private void NextJob_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.SkyBlue;
        }

        private void NextJob_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.CompareTo((DateTime)Note[1]) == 1)
            {
                this.label2.ForeColor = Color.Red;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.Dispose();
            Boolean check = remindNoteController.UpdateRemindNote((int)Note[3], DateTime.Now, "DONE");
            if (check == false)
                MessageBox.Show("Error");
        }
    }
}
