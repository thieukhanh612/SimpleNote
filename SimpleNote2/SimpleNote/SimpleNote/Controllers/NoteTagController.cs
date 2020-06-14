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
            DataTable dt = data.readdata("SELECT DISTINCT NoteTag FROM Note");
            return dt;
        }
        public override DataTable getNotes(string SearchNote)
        {
            DataTable dt = data.readdata("SELECT NoteId, NoteName FROM Note WHERE NoteTag='" + SearchNote + "';");
            return dt;
        }
    }
}
