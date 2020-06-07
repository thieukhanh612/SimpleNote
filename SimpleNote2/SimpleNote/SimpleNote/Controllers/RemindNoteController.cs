using SimpleNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleNote.Models;
using System.Data;

namespace SimpleNote.Controllers
{
    class RemindNoteController
    {
        claData data = new claData();
        public Boolean InsertRemindNote(int NoteID, DateTime NoteDate, string NoteStatus)
        {
            Boolean check = data.excedata("INSERT INTO RemindNote VALUES(" + NoteID + ",'" + NoteDate + "','" + NoteStatus + "');");
            return check;
        }
        public Boolean UpdateRemindNote(int NoteID, DateTime NoteDate, string NoteStatus)
        {
            Boolean check = data.excedata("UPDATE RemindNote SET NoteDateReminded ='" + NoteDate + "',NoteStatus='" + NoteStatus + "' WHERE NoteId =" + NoteID + ";");
            return check;
        }
        public Boolean DeleteRemindNote(int NoteID)
        {
            Boolean check = data.excedata("DELETE FROM RemindNote WHERE NoteID =" + NoteID + ";");
            return check;
        }
        public DataTable getRemindNotes(DateTime date)
        {
            DataTable dt = data.readdata("SELECT *  FROM RemindNote WHERE DATEDIFF(day,'" + date.Date + "', NoteDateReminded)=0;");
            return dt;
        }
        public int CountRemindNotes(DateTime date)
        {
            DataTable dt = data.readdata("SELECT *  FROM RemindNote WHERE DATEDIFF(day,'" + date.Date + "', NoteDateReminded)=0;");
            return dt.Rows.Count;
        }

    }
}
