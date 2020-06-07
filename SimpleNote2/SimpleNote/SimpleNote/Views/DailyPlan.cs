using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleNote.Models;
using SimpleNote.Controllers;

namespace SimpleNote
{
    public partial class DailyPlan : Form
    {

        private DateTime date;
        public DateTime Date { get => date; set => date = value; }
        FlowLayoutPanel fPanel = new FlowLayoutPanel();
        RemindNoteController remindNoteController = new RemindNoteController();

        public DailyPlan(DateTime date)
        {
            InitializeComponent();
            this.Date = date;
           

            fPanel.Width = panelJob.Width;
            fPanel.Height = panelJob.Height;    
            panelJob.Controls.Add(fPanel);        

            dtpkDate.Value = Date;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        void ShowJobByDate(DateTime date)
        {
            fPanel.Controls.Clear();
            DataTable todayJob = GetJobByDay(date);
            foreach (DataRow Job in todayJob.Rows)
            {
                AddJob(Job);
            }


        }

        private void AJob_Deleteed(object sender, EventArgs e)
        {
            Ajob uc = sender as Ajob;
            DataRow job = uc.Job;
            fPanel.Controls.Remove(uc);
            remindNoteController.DeleteRemindNote((int)job[0]);
            
        }

        private void AddJob(DataRow job)
        {
            Ajob aJob = new Ajob(job);
            aJob.Edited += AJob_Edited;
            aJob.Deleteed += AJob_Deleteed;

            fPanel.Controls.Add(aJob);

        }

        private void AJob_Edited(object sender, EventArgs e)
        {
            Ajob uc = sender as Ajob;
            DataRow job = uc.Job;
            remindNoteController.UpdateRemindNote((int)job[0], (DateTime)job[1], (string)job[2]);
        }

        DataTable GetJobByDay(DateTime date)
        {
            DataTable dt=remindNoteController.getRemindNotes(date);
            return dt;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            ShowJobByDate((sender as DateTimePicker).Value);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddDays(1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddDays(-1);

        }

  

        private void mnsToday_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = DateTime.Now;
        }
    }
}
