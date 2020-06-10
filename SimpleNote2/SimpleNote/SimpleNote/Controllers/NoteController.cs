﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleNote.Models;

namespace SimpleNote.Controllers
{
    
    class NoteController
    {
        private claData data = new claData();
        public DataTable getNotes()
        {
            DataTable dt = data.readdata("SELECT Note.Noteid, Note.NoteName FROM NOTE WHERE NoteId NOT IN (SELECT Note.NoteId  FROM Note, TrashNote WHERE Note.NoteId = TrashNote.NoteId) ORDER BY NoteId DESC; ");
            return dt;
        }
        public Boolean UpdateNoteContent(string NoteContent,int IDNote)
        {
            Boolean check = data.excedata("UPDATE Note SET NoteContent='" + NoteContent + "' WHERE NoteId=" + IDNote + ";");
            return check;
        }
        public Boolean UpdateNoteName(string NoteName, int IDNote)
        {
            Boolean check = data.excedata("UPDATE Note SET NoteName='" + NoteName + "' WHERE NoteId=" + IDNote + ";");
            return check;
        }
        public DataTable getNotes(int IDNote)
        {
            DataTable dt = data.readdata("SELECT NoteContent FROM Note WHERE NoteId=" + IDNote + ";");
            return dt;
        }
        public DataTable getNotes(string SearchNote)
        {
            DataTable dt = data.readdata("SELECT NoteName FROM Note WHERE CHARINDEX('" + SearchNote + "',NoteName) <>0 AND NoteId NOT IN (SELECT NoteId FROM TrashNote) ORDER BY NoteId DESC;");
            return dt;
        }
        public DataTable getNoteName(int IDNote)
        {
            DataTable dt = data.readdata("SELECT NoteName FROM Note WHERE NoteId=" + IDNote + ";");
            return dt;
        }
        public DataTable getNoteDateCreated(int IDNote)
        {
            DataTable dt = data.readdata("SELECT NoteDateCreated FROM Note WHERE NoteId=" + IDNote + ";");
            return dt;
        }
        public Boolean InsertNote( DateTime NoteDateCreated)
        {
            Boolean check = data.excedata("INSERT INTO Note(NoteName,NoteDateCreated) VALUES('New Note....','" + NoteDateCreated + "');");
            return check;
        }
        public Boolean DeleteNote(int IDNote)
        {
            Boolean check = data.excedata("DELETE FROM Note WHERE NoteId=" + IDNote + ";");
            return check;
        }
        public DataTable getNoteRemind()
        {
            DataTable dt = data.readdata("SELECT Note.NoteName, RemindNote.NoteDateReminded, RemindNote.NoteStatus FROM(Note join RemindNote on Note.NoteID = RemindNote.NoteId) ORDER BY RemindNote.NoteDateReminded;");
            return dt;
        }

    }

}
