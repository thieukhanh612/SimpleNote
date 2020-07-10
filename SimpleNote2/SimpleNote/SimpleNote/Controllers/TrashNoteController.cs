using SimpleNote.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNote.Controllers
{
    class TrashNoteController:NoteController
    {
        private claData data = new claData();
        public Boolean InsertTrashNote(int IDNote)
        {
            Boolean check = data.excedata("INSERT INTO TrashNote VALUES(" + IDNote + ",'" + DateTime.Now + "');");
            return check;
        }     
        public override DataTable getNotes()
        {
            DataTable dt = data.readdata("SELECT Note.NoteID , Note.NoteName FROM Note INNER JOIN TrashNote ON Note.NoteID= TrashNote.NoteId;");
            return dt;
        }
        public override DataTable getNotes(string SearchNote)
        {
            DataTable dt = data.readdata("SELECT NoteId,NoteName FROM Note WHERE CHARINDEX('" + SearchNote + "',NoteName) <>0 AND NoteId IN (SELECT NoteId FROM TrashNote) ORDER BY NoteId DESC;");
            return dt;
        }
        public override bool DeleteNote(int IDNote)
        {
            Boolean check = data.excedata("DELETE FROM TrashNote WHERE NoteId=" + IDNote + ";");
            return check;
        }
        public DataTable getNoteTag()
        {
            DataTable dt = data.readdata("SELECT DISTINCT Note.NoteTag FROM NOTE WHERE NoteId IN (SELECT Note.NoteId  FROM Note, TrashNote WHERE Note.NoteId = TrashNote.NoteId) AND Note.NoteTag<> 'NULL';");
            return dt;
        }
        public override DataTable getNotesbyNoteTag(string NoteTag)
        {
            DataTable dt = data.readdata("SELECT NoteId,NoteName FROM Note WHERE CHARINDEX('" + NoteTag + "',NoteTag) <>0 AND NoteId IN (SELECT NoteId FROM TrashNote) ORDER BY NoteId DESC;");
            return dt;
        }
        public override DataTable getNotesbyNoteContent(string NoteContent)
        {
            DataTable dt = data.readdata("SELECT NoteId, NoteName FROM Note WHERE CHARINDEX('" + NoteContent + "',NoteContent) <>0 AND NoteId IN (SELECT NoteId FROM TrashNote) ORDER BY NoteId DESC;");
            return dt;
        }
    }
}
