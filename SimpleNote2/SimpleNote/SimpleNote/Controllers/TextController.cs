using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using SimpleNote.Models;
namespace SimpleNote.Controllers
{
    class TextController:NoteController
    {
        claData data = new claData();
        public Boolean UpdateNoteContentFontStyle(FontStyle style, int IDNote)
        {
            Boolean check = data.excedata("UPDATE Note SET NoteContentStyle='" + style.ToString() + "' WHERE NoteId=" + IDNote + ";");
            return check;
        }
        public Boolean UpdateNoteContentColor(Color color, int IDNote)
        {
            Boolean check = data.excedata("UPDATE Note SET NoteContentColor ='" + color.Name.ToString() + "' WHERE NoteId=" + IDNote + ";") ;
            return check;
        }
        public FontStyle GetNoteContentFontStyle(int IDNote)
        {
            DataTable dt = data.readdata("SELECT NoteContentStyle FROM Note WHERE NoteId=" + IDNote + ";");
            FontStyle style = new FontStyle();
            foreach(DataRow row in dt.Rows)
            {
                string NoteContentFontStyle = row[0].ToString();
                string [] ListNoteContentFontStyle = NoteContentFontStyle.Split(' ',',');
                foreach(string s in ListNoteContentFontStyle)
                {
                    switch (s)
                    {
                        case "Bold":
                            style |= FontStyle.Bold;
                            break;
                        case "Italic":
                            style |= FontStyle.Italic;
                            break;
                        case "Underline":
                            style |= FontStyle.Underline;
                            break;
                        case "Strikeout":
                            style |= FontStyle.Strikeout;
                            break;
                        case "Regular":
                            style |= FontStyle.Regular;
                            break;
                    }
                }                
            }
            return style;
        }
        public Color GetNoteContentColor(int IDNote)
        {
            DataTable dt = data.readdata("SELECT NoteContentColor FROM NOTE WHERE NoteId=" + IDNote + ";");
            Color color = new Color() ;
            foreach(DataRow row in dt.Rows)
            {
                color = Color.FromName(row[0].ToString());
            }
            return color;
        }
    }

}
