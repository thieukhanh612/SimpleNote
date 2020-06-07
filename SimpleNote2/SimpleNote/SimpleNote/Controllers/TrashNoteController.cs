using SimpleNote.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNote.Controllers
{
    class TrashNoteController
    {
        private claData data = new claData();
        public Boolean InsertTrashNote(int IDNote)
        {
            Boolean check = data.excedata("INSERT INTO TrashNote VALUES(" + IDNote + ",'" + DateTime.Now + "');");
            return check;
        }
        public DataTable getTrashNotes()
        {
            DataTable dt = data.readdata("SELECT Note.NoteID , Note.NoteName FROM Note INNER JOIN TrashNote ON Note.NoteID= TrashNote.NoteId;");
            return dt;
        }
        public DataTable getTrashNotes(string NoteName)
        {
            DataTable dt = data.readdata("SELECT NoteName FROM Note WHERE CHARINDEX('" + NoteName + "',NoteName) <>0 AND NoteId IN (SELECT NoteId FROM TrashNote) ORDER BY NoteId DESC;");
            return dt;
        }
        public Boolean DeleteTrashNote(int IDNote)
        {
            Boolean check = data.excedata("DELETE FROM TrashNote WHERE NoteId=" + IDNote + ";");
            return check;
        }

    }
}
