using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleNote.Models;
using SimpleNote.Controllers;
namespace SimpleNote
{
    public partial class FrmRemind : Form
    {
        int ID = 0;
        claData data = new claData();
        RemindNoteController remindNoteController = new RemindNoteController();
        public FrmRemind(int ID)
        {
            InitializeComponent();
            this.ID = ID;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Boolean check = remindNoteController.InsertRemindNote(ID, this.dtpDateRemind.Value, this.cbbNoteStatus.Text);
            if (check == false)
                check = remindNoteController.UpdateRemindNote(ID, this.dtpDateRemind.Value, this.cbbNoteStatus.Text);
            if (check == false)
                MessageBox.Show("error");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
