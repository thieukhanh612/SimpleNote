using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleNote.Models;

namespace SimpleNote.Controllers
{
    class NoteTagController:NoteController
    {
        claData data = new claData();
        public Boolean UpdateNoteTag(int NoteId, string NoteTag)
        {
            Boolean check = data.excedata("UPDATE Note SET NoteTag='" + NoteTag + "' WHERE NoteId=" + NoteId + ";");
            return check;
        }
        public DataTable GetNoteTag()
        {
            DataTable dt = data.readdata("SELECT DISTINCT Note.NoteTag FROM NOTE WHERE NoteId NOT IN (SELECT Note.NoteId  FROM Note, TrashNote WHERE Note.NoteId = TrashNote.NoteId) AND Note.NoteTag<> 'NULL';");
            return dt;
        }
        public DataTable GetNoteTag(int IDNote)
        {
            DataTable dt = data.readdata("SELECT Note.NoteTag FROM Note WHERE NoteId =" + IDNote + ";");
            return dt;
        }
    
    }
}
