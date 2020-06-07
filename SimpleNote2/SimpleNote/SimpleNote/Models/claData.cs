using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SimpleNote.Models
{
    class claData
    {
     
        SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=SimpleNote;Integrated Security=True");
        BindingSource bs = new BindingSource();
        
        private void openconnect()
        {
             if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        private void closeconnect()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        //Add, delete, update data
        public Boolean excedata(string cmd)
        {
            openconnect();
            Boolean check = false;
            try
            {
                SqlCommand cmds = new SqlCommand(cmd,con);
                cmds.ExecuteNonQuery();
                check = true;
            }
            catch (Exception)
            {
                check = false;                
            }
            closeconnect();
            return check;            
        }
        //return data
        public DataTable readdata(string cmd)
        {
            openconnect();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmds = new SqlCommand(cmd,con);
                SqlDataAdapter da = new SqlDataAdapter(cmds);
                da.Fill(dt);
            }
            catch (Exception)
            {
                dt = null;
            }
            closeconnect();
            return dt;
        }

        
    }
}
