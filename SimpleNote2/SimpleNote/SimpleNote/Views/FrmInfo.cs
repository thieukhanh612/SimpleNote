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
    public partial class FrmInfo : Form
    {
        claData data = new claData();
        int IdNote;
        NoteController noteController = new NoteController();
        public FrmInfo(int id)
        {
            InitializeComponent();
            IdNote = id;

        }

        private void FrmInfo_Load(object sender, EventArgs e)
        {
           
            DataTable dt = noteController.getNoteDateCreated(IdNote);
            this.dtpDateCreated.DataBindings.Add("Text", dt, "NoteDateCreated");
            this.dtpDateCreated.DataBindings.Clear();
            dt = noteController.getNotes( IdNote );
            this.richTextBox1.DataBindings.Add("Text", dt, "NoteContent");
            this.richTextBox1.Visible = true;
            this.LbWordCount.Text = this.richTextBox1.Text.Count().ToString() + " characters.";
            this.richTextBox1.Visible = false;
            
                
        }
    }
}
