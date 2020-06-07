using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleNote.Models;
using SimpleNote.Controllers;

namespace SimpleNote
{
    public partial class Form1 : Form
    {
        int ID;
        claData data = new claData();
        BindingSource bs = new BindingSource();
        FrmInfo FormInfo;
        FrmRemind FormRemind;
        NoteController noteController = new NoteController();
        TrashNoteController trashNoteController = new TrashNoteController();
        RemindNoteController remindNoteController = new RemindNoteController();
        Form2 FrmCarlendar;
        int AppTime = 0;
        public Form1()
        {
            InitializeComponent();
            this.btnAllNote.BackColor = Color.SkyBlue;
            this.btnTrashNote.BackColor = Color.White;
            this.ID = 1;
            timer.Enabled = true;
            int CountRemindNote = remindNoteController.CountRemindNotes(DateTime.Now);
            Notify.ShowBalloonTip(Cons.notifyTimeOut, "Today Plan", string.Format("You have {0} job today", CountRemindNote), ToolTipIcon.Info);

        }
        OpenFileDialog open;
        SaveFileDialog save;

        private void txtNoteContent_TextChanged(object sender, EventArgs e)
        {
            this.tsNote.Visible = true;
            if (this.btnAllNote.BackColor == Color.SkyBlue)
            {
                this.toolStripBtnDeleteForever.Visible = false;
                this.toolStripBtnRestore.Visible = false;
                this.toolStripBtnInfo.Visible = true;
                this.toolStripbtnRemind.Visible = true;
                this.toolStripbtnDelete.Visible = true;
            }
            else if (this.btnTrashNote.BackColor == Color.SkyBlue)
            {
                this.toolStripBtnInfo.Visible = false;
                this.toolStripbtnRemind.Visible = false;
                this.toolStripbtnDelete.Visible = false;
                this.toolStripBtnDeleteForever.Visible = true;
                this.toolStripBtnRestore.Visible = true;
            }
            Boolean check = noteController.UpdateNoteContent(this.txtNoteContent.Text, (int)DGVNoteName.CurrentRow.Cells[0].Value );
            if (check == false) MessageBox.Show("That bai");
            if (txtNoteContent.Text.Length > 0)
            {
                undoToolStripMenuItem.Enabled = true;
                cutToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem.Enabled = true;
                selectAllToolStripMenuItem1.Enabled = true;
                boldToolStripMenuItem.Enabled = true;
                italicToolStripMenuItem.Enabled = true;
                normalToolStripMenuItem.Enabled = true;
                strikeThroughtToolStripMenuItem.Enabled = true;

            }
            else
            {
                selectAllToolStripMenuItem1.Enabled = false;
                cutToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;

                undoToolStripMenuItem.Enabled = false;
                redoToolStripMenuItem.Enabled = false;
                boldToolStripMenuItem.Enabled = false;
                italicToolStripMenuItem.Enabled = false;
                normalToolStripMenuItem.Enabled = false;
                strikeThroughtToolStripMenuItem.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt =noteController.getNotes();
            bs.DataSource = dt;
            DGVNoteName.DataSource = bs;

            if (DGVNoteName.Rows.Count != 0)
            {
                this.txtNoteContent.Visible = true;
                this.tsNote.Visible = true;
                if (this.btnAllNote.BackColor == Color.SkyBlue)
                {
                    this.toolStripBtnDeleteForever.Visible = false;
                    this.toolStripBtnRestore.Visible = false;
                    this.toolStripBtnInfo.Visible = true;
                    this.toolStripbtnRemind.Visible = true;
                    this.toolStripbtnDelete.Visible = true;
                }
                else if (this.btnTrashNote.BackColor == Color.SkyBlue)
                {
                    this.toolStripBtnInfo.Visible = false;
                    this.toolStripbtnRemind.Visible = false;
                    this.toolStripbtnDelete.Visible = false;
                    this.toolStripBtnDeleteForever.Visible = true;
                    this.toolStripBtnRestore.Visible = true;
                }
                dt = noteController.getNotes( (int)DGVNoteName.CurrentRow.Cells[0].Value );
                this.txtNoteContent.DataBindings.Add("Text", dt, "NoteContent");
                this.txtNoteContent.DataBindings.Clear();
            }

        }

        private void toolStripbtnAdd_Click(object sender, EventArgs e)
        {
            this.txtNoteContent.Visible = true;

            this.tsNote.Visible = true;
            this.toolStripBtnDeleteForever.Visible = false;
            this.toolStripBtnRestore.Visible = false;
            DateTime dtime = DateTime.Now;
            Boolean check = noteController.InsertNote( dtime);
            if (check == false) MessageBox.Show("That bai");
            DataTable dt = noteController.getNotes();
            bs.DataSource = dt;
            dt.Dispose();
            dt = noteController.getNotes( (int)DGVNoteName.CurrentRow.Cells[0].Value );
            this.txtNoteContent.DataBindings.Add("Text", dt, "NoteContent");
            this.txtNoteContent.DataBindings.Clear();




        }

        private void DGVNoteName_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.txtNoteContent.Visible = true;
            this.tsNote.Visible = true;
            if (this.btnAllNote.BackColor == Color.SkyBlue)
            {
                this.toolStripBtnDeleteForever.Visible = false;
                this.toolStripBtnRestore.Visible = false;
                this.toolStripBtnInfo.Visible = true;
                this.toolStripbtnRemind.Visible = true;
                this.toolStripbtnDelete.Visible = true;
            }
            else if (this.btnTrashNote.BackColor == Color.SkyBlue)
            {
                this.toolStripBtnInfo.Visible = false;
                this.toolStripbtnRemind.Visible = false;
                this.toolStripbtnDelete.Visible = false;
                this.toolStripBtnDeleteForever.Visible = true;
                this.toolStripBtnRestore.Visible = true;
            }
            DataTable dt = data.readdata("SELECT NoteContent FROM Note WHERE NoteId=" + DGVNoteName.CurrentRow.Cells[0].Value + ";");
            this.txtNoteContent.DataBindings.Add("Text", dt, "NoteContent");
            this.txtNoteContent.DataBindings.Clear();
        }

        private void toolStripBtnInfo_Click(object sender, EventArgs e)
        {

            if (FormInfo == null || FormInfo.IsDisposed)
            {
                FormInfo = new FrmInfo((int)this.DGVNoteName.CurrentRow.Cells[0].Value);
                FormInfo.Show();
            }

        }

        private void toolStripbtnDelete_Click(object sender, EventArgs e)
        {
            if (DGVNoteName.Rows.Count != 0)
            {
                Boolean check =trashNoteController.InsertTrashNote((int) this.DGVNoteName.CurrentRow.Cells[0].Value );
                if (check == false) MessageBox.Show("That bai");
                check = data.excedata("DELETE FROM RemindNote WHERE NoteId=" + this.DGVNoteName.CurrentRow.Cells[0].Value + ";");
                if (check == false) MessageBox.Show("Error");
                DataTable dt = noteController.getNotes();
                bs.DataSource = dt;
                DGVNoteName.DataSource = bs;
                this.txtNoteContent.Visible = true;
                this.tsNote.Visible = true;
                if (DGVNoteName.Rows.Count == 0)
                {
                    this.txtNoteContent.Visible = false;
                    this.tsNote.Visible = false;
                    return;
                }
                dt = noteController.getNotes((int) DGVNoteName.CurrentRow.Cells[0].Value );
                this.txtNoteContent.DataBindings.Add("Text", dt, "NoteContent");
                this.txtNoteContent.DataBindings.Clear();

            }



        }

        private void toolStripbtnRemind_Click(object sender, EventArgs e)
        {
            if (FormRemind == null || FormRemind.IsDisposed)
            {
                FormRemind = new FrmRemind((int)this.DGVNoteName.CurrentRow.Cells[0].Value);
                FormRemind.Show();
            }
        }

        private void DGVNoteName_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Boolean check = noteController.UpdateNoteName(DGVNoteName.CurrentRow.Cells[1].Value.ToString(), (int)this.DGVNoteName.CurrentRow.Cells[0].Value );
            if (check == false)
                MessageBox.Show("Error");
        }

        private void btnTrashNote_Click(object sender, EventArgs e)
        {

            this.btnAllNote.BackColor = Color.White;
            this.btnTrashNote.BackColor = Color.SkyBlue;
            this.toolStripbtnAdd.Visible = false;
            DataTable dt = trashNoteController.getTrashNotes();
            this.txtNoteContent.ReadOnly = true;
            bs.DataSource = dt;
            this.DGVNoteName.DataSource = bs;
            if (DGVNoteName.Rows.Count != 0)
            {
                this.txtNoteContent.Visible = true;
                this.tsNote.Visible = true;
                if (this.btnAllNote.BackColor == Color.SkyBlue)
                {
                    this.toolStripBtnDeleteForever.Visible = false;
                    this.toolStripBtnRestore.Visible = false;
                    this.toolStripBtnInfo.Visible = true;
                    this.toolStripbtnRemind.Visible = true;
                    this.toolStripbtnDelete.Visible = true;
                }
                else if (this.btnTrashNote.BackColor == Color.SkyBlue)
                {
                    this.toolStripBtnInfo.Visible = false;
                    this.toolStripbtnRemind.Visible = false;
                    this.toolStripbtnDelete.Visible = false;
                    this.toolStripBtnDeleteForever.Visible = true;
                    this.toolStripBtnRestore.Visible = true;
                }
                dt = noteController.getNotes((int) DGVNoteName.CurrentRow.Cells[0].Value );
                this.txtNoteContent.DataBindings.Add("Text", dt, "NoteContent");
                this.txtNoteContent.DataBindings.Clear();
            }
            else
            {
                this.txtNoteContent.Visible = false;
                this.tsNote.Visible = false;
            }
        }

        private void btnAllNote_Click(object sender, EventArgs e)
        {

            this.btnAllNote.BackColor = Color.SkyBlue;
            this.btnTrashNote.BackColor = Color.White;
            this.toolStripbtnAdd.Visible = true;
            DataTable dt = noteController.getNotes();
            this.txtNoteContent.ReadOnly = false;
            bs.DataSource = dt;
            DGVNoteName.DataSource = bs;
            if (DGVNoteName.Rows.Count != 0)
            {
                this.txtNoteContent.Visible = true;
                this.tsNote.Visible = true;
                if (this.btnAllNote.BackColor == Color.SkyBlue)
                {
                    this.toolStripBtnDeleteForever.Visible = false;
                    this.toolStripBtnRestore.Visible = false;
                    this.toolStripBtnInfo.Visible = true;
                    this.toolStripbtnRemind.Visible = true;
                    this.toolStripbtnDelete.Visible = true;
                }
                else if (this.btnTrashNote.BackColor == Color.SkyBlue)
                {
                    this.toolStripBtnInfo.Visible = false;
                    this.toolStripbtnRemind.Visible = false;
                    this.toolStripbtnDelete.Visible = false;
                    this.toolStripBtnDeleteForever.Visible = true;
                    this.toolStripBtnRestore.Visible = true;
                }
                dt = noteController.getNotes((int)DGVNoteName.CurrentRow.Cells[0].Value );
                this.txtNoteContent.DataBindings.Add("Text", dt, "NoteContent");
                this.txtNoteContent.DataBindings.Clear();
            }
            else
            {
                this.txtNoteContent.Visible = false;
                this.tsNote.Visible = false;
            }
        }

        private void toolStripBtnDeleteForever_Click(object sender, EventArgs e)
        {
            if (DGVNoteName.Rows.Count != 0)
            {
                Boolean check = trashNoteController.DeleteTrashNote((int) this.DGVNoteName.CurrentRow.Cells[0].Value );
                if (check == false) MessageBox.Show("Error");
                check = data.excedata("DELETE FROM RemindNote WHERE NoteId=" + this.DGVNoteName.CurrentRow.Cells[0].Value + ";");
                if (check == false) MessageBox.Show("Error");
                check = noteController.DeleteNote((int) this.DGVNoteName.CurrentRow.Cells[0].Value );
                if (check == false) MessageBox.Show("Error");
                DataTable dt = trashNoteController.getTrashNotes();
                bs.DataSource = dt;
                this.DGVNoteName.DataSource = bs;
                if (DGVNoteName.Rows.Count == 0)
                {
                    this.txtNoteContent.Visible = false;
                    this.tsNote.Visible = false;
                    return;
                }
                dt = noteController.getNotes((int) DGVNoteName.CurrentRow.Cells[0].Value );
                this.txtNoteContent.DataBindings.Add("Text", dt, "NoteContent");
                this.txtNoteContent.DataBindings.Clear();
            }


        }

        private void toolStripBtnRestore_Click(object sender, EventArgs e)
        {
            if (DGVNoteName.Rows.Count != 0)
            {
                Boolean check = trashNoteController.DeleteTrashNote((int) this.DGVNoteName.CurrentRow.Cells[0].Value );
                if (check == false) MessageBox.Show("Error");
                DataTable dt = trashNoteController.getTrashNotes();
                bs.DataSource = dt;
                this.DGVNoteName.DataSource = bs;
                if (DGVNoteName.Rows.Count == 0)
                {
                    this.txtNoteContent.Visible = false;
                    this.tsNote.Visible = false;
                    return;
                }
                dt = noteController.getNotes((int) DGVNoteName.CurrentRow.Cells[0].Value );
                this.txtNoteContent.DataBindings.Add("Text", dt, "NoteContent");
                this.txtNoteContent.DataBindings.Clear();
            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.btnAllNote.BackColor == Color.SkyBlue)
            {
                if (toolStripTextBox1.Text.Length > 0)
                {
                    DataTable dt = noteController.getNotes( toolStripTextBox1.Text );
                    bs.DataSource = dt;
                    this.DGVNoteName.DataSource = bs;
                }
                else
                {
                    DataTable dt = noteController.getNotes();
                    bs.DataSource = dt;
                    DGVNoteName.DataSource = bs;
                }
            }
            else if(this.btnTrashNote.BackColor != Color.White)
            {
                if (toolStripTextBox1.Text.Length > 0)
                {
                    DataTable dt = trashNoteController.getTrashNotes( toolStripTextBox1.Text );
                    bs.DataSource = dt;
                    this.DGVNoteName.DataSource = bs;
                }
                else
                {
                    DataTable dt = trashNoteController.getTrashNotes();
                    bs.DataSource = dt;
                    DGVNoteName.DataSource = bs;
                }
            }

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Simple note by group 11.Contact to gmail:abc@gmail.com", "Help", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void newNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNoteContent.Undo();
            undoToolStripMenuItem.Enabled = false;
            redoToolStripMenuItem.Enabled = true;

        }

        private void DGVNoteName_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNoteContent.Redo();
            redoToolStripMenuItem.Enabled = false;
            undoToolStripMenuItem.Enabled = true;

        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNoteContent.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNoteContent.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNoteContent.Paste();
        }
        private void selectAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            txtNoteContent.SelectAll();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //delete
            txtNoteContent.SelectedText = "";
        }

        private void dateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("\n\n");
            txtNoteContent.Text = txtNoteContent.Text + DateTime.Now;
        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNoteContent.SelectionFont = new Font(txtNoteContent.Font, FontStyle.Bold);
        }

        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNoteContent.SelectionFont = new Font(txtNoteContent.Font, FontStyle.Italic);
        }

        private void underlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNoteContent.SelectionFont = new Font(txtNoteContent.Font, FontStyle.Underline);
        }

        private void strikeThroughtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNoteContent.SelectionFont = new Font(txtNoteContent.Font, FontStyle.Strikeout);
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNoteContent.SelectionFont = new Font(txtNoteContent.Font, FontStyle.Regular);
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string s = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            toolStripStatusLabel1.Text = s;
            

       
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void DGVNoteName_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter write = new StreamWriter(txtNoteContent.Text.Trim());
            write.WriteLine(txtNoteContent.Text);
            write.Close();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save = new SaveFileDialog();
            save.Filter = "Plain Text |*.txt|All |*.*";
            save.RestoreDirectory = true;
            if(save.ShowDialog()==DialogResult.OK)
            {
                StreamWriter write = new StreamWriter(save.FileName);
                write.WriteLine(txtNoteContent.Text);
                write.Close();
            }
        }
        //open
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open = new OpenFileDialog();
            open.Filter = "Plain Text |*.txt|All |*.*";
            if(open.ShowDialog()==DialogResult.OK)
            {
              
                StreamReader read = new StreamReader(open.FileName);
                txtNoteContent.Text = read.ReadToEnd();
                read.Close();
            }
            else
            {
                MessageBox.Show("You don't save");
            }
        }
        //exit
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show(
             "Do you want to exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (ret == DialogResult.Yes)
                Close();
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
           
        }

        private void textColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = txtNoteContent.BackColor;
            //txtNoteContent.BackColor= textColorToolStripMenuItem.BackColor;
         if(colorDialog1.ShowDialog()==DialogResult.OK)
            {
               txtNoteContent.BackColor = colorDialog1.Color;
            }
        
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
           
            if (FrmCarlendar == null || FrmCarlendar.IsDisposed)
            {
                FrmCarlendar = new Form2();
                FrmCarlendar.Show();
            }
        }

        private void tmNotify_Tick(object sender, EventArgs e)
        {
            AppTime++;
            if (AppTime > Cons.notifyTime)
                return;
            int CountRemindNote = remindNoteController.CountRemindNotes(DateTime.Now);          
            Notify.ShowBalloonTip(Cons.notifyTimeOut, "Today Plan", string.Format("You have {0} job today", CountRemindNote), ToolTipIcon.Info);
        }
    }
}
