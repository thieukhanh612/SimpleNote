﻿using System;
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
using SimpleNote.Views;

namespace SimpleNote
{
    public partial class Form1 : Form
    {
        int ID;
        claData data = new claData();
        BindingSource bs = new BindingSource();
        FrmInfo FormInfo ;
        FrmRemind FormRemind ;
        NoteController noteController = new NoteController();
        TrashNoteController trashNoteController = new TrashNoteController();
        RemindNoteController remindNoteController = new RemindNoteController();
        TextController textController = new TextController();
        NoteTagController noteTagController = new NoteTagController();
        Form2 FrmCarlendar=new Form2();
        Frmhelp frmHelp = new Frmhelp();
        int AppTime = 0;
       
        FlowLayoutPanel fPanel = new FlowLayoutPanel();
        
        public Form1()
        {
            InitializeComponent();
            this.btnAllNote.BackColor = Color.SkyBlue;
            this.btnTrashNote.BackColor = Color.White;
            this.ID = 1;
            timer.Enabled = true;
            int CountRemindNote = remindNoteController.CountRemindNotes(DateTime.Now);
            Notify.ShowBalloonTip(Cons.notifyTimeOut, "Today Plan", string.Format("You have {0} job today", CountRemindNote), ToolTipIcon.Info);
            fPanel.Width = splitContainer8.Panel2.Width;
            fPanel.Height = splitContainer8.Panel2.Height;
            splitContainer8.Panel2.Controls.Add(fPanel);
            fPanel.AutoScroll = true;
            fPanel.Dock = DockStyle.Fill;
            getJobs();
        }
        OpenFileDialog open;
        SaveFileDialog save;
        void getJobs()
        {
           
            DataTable dt = remindNoteController.getNotes();
            foreach(DataRow row in dt.Rows)
            {
                NextJob nextJob = new NextJob(row);
                nextJob.Width = this.splitContainer8.Panel2.Width;
                fPanel.Controls.Add(nextJob);
               
            }
        }
     
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
                underlineToolStripMenuItem.Enabled = true;
                strikeThroughtToolStripMenuItem.Enabled = true;

            }
            else
            {
                selectAllToolStripMenuItem1.Enabled = false;
                cutToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
                underlineToolStripMenuItem.Enabled = false;
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
            BindingSource bs2 = new BindingSource();
            dt = noteTagController.GetNoteTag();
            bs2.DataSource = dt;
            this.DGVNoteTags.DataSource = bs2;

            if (DGVNoteName.Rows.Count != 0)
            {
                this.txtNoteContent.Visible = true;
                this.txtTag.Visible = true;
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
                ShowNoteContent();
            }

        }

        private void toolStripbtnAdd_Click(object sender, EventArgs e)
        {
            this.txtNoteContent.Visible = true;
            this.txtTag.Visible = true;
            this.tsNote.Visible = true;
            this.toolStripBtnDeleteForever.Visible = false;
            this.toolStripBtnRestore.Visible = false;
            DateTime dtime = DateTime.Now;
            Boolean check = noteController.InsertNote( dtime);
            if (check == false) MessageBox.Show("That bai");
            DataTable dt = noteController.getNotes();
            bs.DataSource = dt;
            dt.Dispose();
            ShowNoteContent();
            this.DGVNoteName.ClearSelection();
            this.DGVNoteName.Rows[0].Selected = true;
            



        }

        private void DGVNoteName_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.txtNoteContent.Visible = true;
            this.txtTag.Visible = true;
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
            ShowNoteContent();
        }
        private void ShowNoteContent()
        {
            DataTable dt = noteController.getNotes((int)DGVNoteName.CurrentRow.Cells[0].Value);
            this.txtNoteContent.DataBindings.Add("Text", dt, "NoteContent");
            this.txtNoteContent.DataBindings.Clear();
            this.txtNoteContent.SelectAll();
            dt = noteTagController.GetNoteTag((int)DGVNoteName.CurrentRow.Cells[0].Value);
            this.txtTag.DataBindings.Add("Text", dt, "NoteTag");
            this.txtTag.DataBindings.Clear();
            if (txtTag.Text == "" || txtTag.Text=="Add a tag...")
            {
                txtTag.Text = "Add a tag...";
                this.txtTag.ForeColor = SystemColors.ControlDark;
            }
            else
            {
                this.txtTag.ForeColor = Color.Black;
            }
            FontStyle style = textController.GetNoteContentFontStyle((int)DGVNoteName.CurrentRow.Cells[0].Value);
            this.txtNoteContent.SelectionFont = new Font(this.txtNoteContent.SelectionFont, style);
            Color color = textController.GetNoteContentColor((int)this.DGVNoteName.CurrentRow.Cells[0].Value);       
            this.txtNoteContent.ForeColor = color;



        }
        private void toolStripBtnInfo_Click(object sender, EventArgs e)
        {
            FormInfo = new FrmInfo((int)this.DGVNoteName.CurrentRow.Cells[0].Value);
            FormInfo.ShowDialog();

        }

        private void toolStripbtnDelete_Click(object sender, EventArgs e)
        {
            if (DGVNoteName.Rows.Count != 0)
            {
                Boolean check =trashNoteController.InsertTrashNote((int) this.DGVNoteName.CurrentRow.Cells[0].Value );
                if (check == false) MessageBox.Show("That bai");
                check = remindNoteController.DeleteNote((int) this.DGVNoteName.CurrentRow.Cells[0].Value );
                if (check == false) MessageBox.Show("Error");
                DataTable dt = noteController.getNotes();
                bs.DataSource = dt;
                DGVNoteName.DataSource = bs;
                BindingSource bs2 = new BindingSource();
                dt = noteTagController.GetNoteTag();
                bs2.DataSource = dt;
                this.DGVNoteTags.DataSource = bs2;
                this.txtNoteContent.Visible = true;
                this.txtTag.Visible = true;
                this.tsNote.Visible = true;
                if (DGVNoteName.Rows.Count == 0)
                {
                    this.txtNoteContent.Visible = false;
                    this.txtTag.Visible = false;
                    this.tsNote.Visible = false;
                    return;
                }
                ShowNoteContent();

            }



        }

        private void toolStripbtnRemind_Click(object sender, EventArgs e)
        {
            FormRemind = new FrmRemind((int)this.DGVNoteName.CurrentRow.Cells[0].Value);
            FormRemind.FormClosed += FormRemind_FormClosed1;
            FormRemind.ShowDialog();
              
        }

        private void FormRemind_FormClosed1(object sender, FormClosedEventArgs e)
        {
            fPanel.Controls.Clear();
            fPanel.AutoScroll = true;
            getJobs();
        }

     

        private void DGVNoteName_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Boolean check = noteController.UpdateNoteName(DGVNoteName.CurrentRow.Cells[1].Value.ToString(), (int)this.DGVNoteName.CurrentRow.Cells[0].Value );
            if (check == false)
                MessageBox.Show("Error");
            fPanel.Controls.Clear();
            getJobs();
        }

        private void btnTrashNote_Click(object sender, EventArgs e)
        {

            this.btnAllNote.BackColor = Color.White;
            this.btnTrashNote.BackColor = Color.SkyBlue;
            this.toolStripbtnAdd.Visible = false;
            DataTable dt = trashNoteController.getNotes();
            this.txtNoteContent.ReadOnly = true;
            this.txtTag.ReadOnly = true;
            bs.DataSource = dt;
            this.DGVNoteName.DataSource = bs;
            BindingSource bs2 = new BindingSource();
            dt = trashNoteController.getNoteTag();
            bs2.DataSource = dt;
            this.DGVNoteTags.DataSource = bs2;
            if (DGVNoteName.Rows.Count != 0)
            {
                this.txtNoteContent.Visible = true;
                this.txtTag.Visible = true;
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
                ShowNoteContent();
            }
            else
            {
                this.txtNoteContent.Visible = false;
                this.txtTag.Visible = false;
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
            this.txtTag.ReadOnly = false;
            bs.DataSource = dt;
            DGVNoteName.DataSource = bs;
            BindingSource bs2 = new BindingSource();
            dt = noteTagController.GetNoteTag();
            bs2.DataSource = dt;
            this.DGVNoteTags.DataSource = bs2;
            if (DGVNoteName.Rows.Count != 0)
            {
                this.txtNoteContent.Visible = true;
                this.txtTag.Visible = true;
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
                ShowNoteContent();
            }
            else
            {
                this.txtNoteContent.Visible = false;
                this.txtTag.Visible = false;
                this.tsNote.Visible = false;
            }
        }

        private void toolStripBtnDeleteForever_Click(object sender, EventArgs e)
        {
            if (DGVNoteName.Rows.Count != 0)
            {
                Boolean check = trashNoteController.DeleteNote((int) this.DGVNoteName.CurrentRow.Cells[0].Value );
                if (check == false) MessageBox.Show("Error");
                check = remindNoteController.DeleteNote((int)this.DGVNoteName.CurrentRow.Cells[0].Value);
                if (check == false) MessageBox.Show("Error");
                check = noteController.DeleteNote((int) this.DGVNoteName.CurrentRow.Cells[0].Value );
                if (check == false) MessageBox.Show("Error");
                DataTable dt = trashNoteController.getNotes();
                bs.DataSource = dt;
                this.DGVNoteName.DataSource = bs;
                BindingSource bs2 = new BindingSource();
                dt = trashNoteController.getNoteTag();
                bs2.DataSource = dt;
                this.DGVNoteTags.DataSource = bs2;
                if (DGVNoteName.Rows.Count == 0)
                {
                    this.txtNoteContent.Visible = false;
                    this.txtTag.Visible = false;
                    this.tsNote.Visible = false;
                    return;
                }
                ShowNoteContent();
            }


        }

        private void toolStripBtnRestore_Click(object sender, EventArgs e)
        {
            if (DGVNoteName.Rows.Count != 0)
            {
                Boolean check = trashNoteController.DeleteNote((int) this.DGVNoteName.CurrentRow.Cells[0].Value );
                if (check == false) MessageBox.Show("Error");
                DataTable dt = trashNoteController.getNotes();
                bs.DataSource = dt;
                this.DGVNoteName.DataSource = bs;
                BindingSource bs2 = new BindingSource();
                dt = trashNoteController.getNoteTag();
                bs2.DataSource = dt;
                this.DGVNoteTags.DataSource = bs2;
                if (DGVNoteName.Rows.Count == 0)
                {
                    this.txtNoteContent.Visible = false;
                    this.txtTag.Visible = false;
                    this.tsNote.Visible = false;
                    return;
                }
                ShowNoteContent();
            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (toolStripMenuItem1.Checked == true)
            {
                if (this.btnAllNote.BackColor == Color.SkyBlue)
                {
                    if (toolStripTextBox1.Text.Length > 0)
                    {
                        DataTable dt = noteController.getNotes(toolStripTextBox1.Text);
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
                else if (this.btnTrashNote.BackColor != Color.White)
                {
                    if (toolStripTextBox1.Text.Length > 0)
                    {
                        DataTable dt = trashNoteController.getNotes(toolStripTextBox1.Text);
                        bs.DataSource = dt;
                        this.DGVNoteName.DataSource = bs;
                    }
                    else
                    {
                        DataTable dt = trashNoteController.getNotes();
                        bs.DataSource = dt;
                        DGVNoteName.DataSource = bs;
                    }
                }
            }
            else if (toolStripMenuItem2.Checked == true)
            {
                if (this.btnAllNote.BackColor == Color.SkyBlue)
                {
                    if (toolStripTextBox1.Text.Length > 0)
                    {
                        DataTable dt = noteController.getNotesbyNoteTag(toolStripTextBox1.Text);
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
                else if (this.btnTrashNote.BackColor != Color.White)
                {
                    if (toolStripTextBox1.Text.Length > 0)
                    {
                        DataTable dt = trashNoteController.getNotesbyNoteTag(toolStripTextBox1.Text);
                        bs.DataSource = dt;
                        this.DGVNoteName.DataSource = bs;
                    }
                    else
                    {
                        DataTable dt = trashNoteController.getNotes();
                        bs.DataSource = dt;
                        DGVNoteName.DataSource = bs;
                    }
                }
            }
            else if (toolStripMenuItem3.Checked == true)
            {
                if (this.btnAllNote.BackColor == Color.SkyBlue)
                {
                    if (toolStripTextBox1.Text.Length > 0)
                    {
                        DataTable dt = noteController.getNotesbyNoteContent(toolStripTextBox1.Text);
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
                else if (this.btnTrashNote.BackColor != Color.White)
                {
                    if (toolStripTextBox1.Text.Length > 0)
                    {
                        DataTable dt = trashNoteController.getNotesbyNoteTag(toolStripTextBox1.Text);
                        bs.DataSource = dt;
                        this.DGVNoteName.DataSource = bs;
                    }
                    else
                    {
                        DataTable dt = trashNoteController.getNotes();
                        bs.DataSource = dt;
                        DGVNoteName.DataSource = bs;
                    }
                }
            }


        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
           /* if(about ==null || about.IsDisposed())
            {
                about.Show();
            }*/
        }

        private void newNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNoteContent.Undo();
            this.redoToolStripMenuItem.Enabled = true;

        }

        private void DGVNoteName_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNoteContent.Redo();

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
            if (txtNoteContent.SelectionFont == null)
            {
                return;
            }

            FontStyle style = txtNoteContent.SelectionFont.Style;

            if (txtNoteContent.SelectionFont.Bold)
            {
                style &= ~FontStyle.Bold;
            }
            else
            {
                style |= FontStyle.Bold;

            }
            txtNoteContent.SelectionFont = new Font(txtNoteContent.SelectionFont, style);
            Boolean check=textController.UpdateNoteContentFontStyle(style, (int)this.DGVNoteName.CurrentRow.Cells[0].Value);
            if (check == false) MessageBox.Show("Error");
        }

        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtNoteContent.SelectionFont == null)
            {
                return;
            }
            FontStyle style = txtNoteContent.SelectionFont.Style;

            if (txtNoteContent.SelectionFont.Italic)
            {
                style &= ~FontStyle.Italic;
            }
            else
            {
                style |= FontStyle.Italic;
            }
            txtNoteContent.SelectionFont = new Font(txtNoteContent.SelectionFont, style);
            Boolean check = textController.UpdateNoteContentFontStyle(style, (int)this.DGVNoteName.CurrentRow.Cells[0].Value);
            if (check == false) MessageBox.Show("Error");
        }

        private void underlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtNoteContent.SelectionFont == null)
            {
                return;
            }

            FontStyle style = txtNoteContent.SelectionFont.Style;

            if (txtNoteContent.SelectionFont.Underline)
            {
                style &= ~FontStyle.Underline;
            }
            else
            {
                style |= FontStyle.Underline;
            }
            txtNoteContent.SelectionFont = new Font(txtNoteContent.SelectionFont, style);
            Boolean check = textController.UpdateNoteContentFontStyle(style, (int)this.DGVNoteName.CurrentRow.Cells[0].Value);
            if (check == false) MessageBox.Show("Error");
        }

        private void strikeThroughtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtNoteContent.SelectionFont == null)
            {
                return;
            }

            FontStyle style = txtNoteContent.SelectionFont.Style;

            if (txtNoteContent.SelectionFont.Strikeout)
            {
                style &= ~FontStyle.Strikeout;
            }
            else
            {
                style |= FontStyle.Strikeout;
            }
            txtNoteContent.SelectionFont = new Font(txtNoteContent.SelectionFont, style);
            Boolean check = textController.UpdateNoteContentFontStyle(style, (int)this.DGVNoteName.CurrentRow.Cells[0].Value);
            if (check == false) MessageBox.Show("Error");
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtNoteContent.SelectionFont == null)
            {
                return;
            }
            FontStyle style = FontStyle.Regular;           
            txtNoteContent.SelectionFont = new Font(txtNoteContent.SelectionFont, style);
            Boolean check = textController.UpdateNoteContentFontStyle(style, (int)this.DGVNoteName.CurrentRow.Cells[0].Value);
            if (check == false) MessageBox.Show("Error");
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
           ;
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
              this.txtNoteContent.ForeColor = colorDialog1.Color;
              Boolean check = textController.UpdateNoteContentColor(colorDialog1.Color,(int)this.DGVNoteName.CurrentRow.Cells[0].Value);
              if (check == false) MessageBox.Show("Error");
            }
        
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {

            FrmCarlendar.ShowDialog();
            FrmCarlendar.FormClosed += FrmCarlendar_FormClosed;
        }

        private void FrmCarlendar_FormClosed(object sender, FormClosedEventArgs e)
        {
            fPanel.Controls.Clear();
            fPanel.AutoScroll = true;
            getJobs();
        }

        private void tmNotify_Tick(object sender, EventArgs e)
        {
            AppTime++;
            if (AppTime > Cons.notifyTime)
                return;
            int CountRemindNote = remindNoteController.CountRemindNotes(DateTime.Now);          
            Notify.ShowBalloonTip(Cons.notifyTimeOut, "Today Plan", string.Format("You have {0} job today", CountRemindNote), ToolTipIcon.Info);
        }

        private void txtTag_Enter(object sender, EventArgs e)
        {
            if(this.txtTag.Text=="Add a tag...")
            {
                this.txtTag.Text = "";
                this.txtTag.ForeColor = Color.Black;

            }
        }

        private void txtTag_Leave(object sender, EventArgs e)
        {
            if (this.txtTag.Text == "")
            {
                this.txtTag.Text = "Add a tag...";
                this.txtTag.ForeColor = SystemColors.ControlDark ;
            }
            BindingSource bs2 = new BindingSource();
            DataTable dt = noteTagController.GetNoteTag();
            bs2.DataSource = dt;
            this.DGVNoteTags.DataSource = bs2;
        }

        private void newNoteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.txtNoteContent.Visible = true;
            this.txtTag.Visible = true;
            this.tsNote.Visible = true;
            this.toolStripBtnDeleteForever.Visible = false;
            this.toolStripBtnRestore.Visible = false;
            DateTime dtime = DateTime.Now;
            Boolean check = noteController.InsertNote(dtime);
            if (check == false) MessageBox.Show("That bai");
            DataTable dt = noteController.getNotes();
            bs.DataSource = dt;
            dt.Dispose();
            ShowNoteContent();
            this.DGVNoteName.ClearSelection();
            this.DGVNoteName.Rows[0].Selected = true;
        }

        private void txtTag_TextChanged(object sender, EventArgs e)
        {
            if (txtTag.Text.Length > 0 && txtTag.Text != "Add a tag...")
            {
                Boolean check = noteTagController.UpdateNoteTag((int)this.DGVNoteName.CurrentRow.Cells[0].Value, txtTag.Text);
                if (check == false)
                    MessageBox.Show("Error");
            }  
            
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            fPanel.Controls.Clear();
            fPanel.AutoScroll = true;
            getJobs();
            
        }

        private void DGVNoteTags_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataTable dt = noteTagController.getNotesbyNoteTag(this.DGVNoteTags.CurrentRow.Cells[0].Value.ToString());
            bs.DataSource = dt;
            DGVNoteName.DataSource = bs;
            ShowNoteContent();
        }

        private void DGVNoteTags_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.DGVNoteTags.ClearSelection();
            DataTable dt = noteController.getNotes();
            bs.DataSource = dt;
            DGVNoteName.DataSource = bs;
            ShowNoteContent();
        }

        private void MenuSearchSelection_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (this.MenuSearchSelection.DropDownItems[1].Selected)
            {
                this.toolStripMenuItem1.Checked = false ;
                this.toolStripMenuItem3.Checked = false;
            }
            else if (this.MenuSearchSelection.DropDownItems[0].Selected)
            {
                this.toolStripMenuItem2.Checked = false;
                this.toolStripMenuItem3.Checked = false;
            }
            else if (this.MenuSearchSelection.DropDownItems[2].Selected)
            {
                this.toolStripMenuItem1.Checked = false;
                this.toolStripMenuItem2.Checked = false;
            }
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmHelp.ShowDialog();
        }
    }
}
