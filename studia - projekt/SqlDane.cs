using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace studia___projekt
{
    class SqlDane
    {
        private SqlConnection con;
        private SqlCommand com;
        private SqlDataAdapter da;
        private DataTable dt;


        public SqlDane()
        {
            con = new SqlConnection(@"Data Source =(LocalDB)\MSSQLLocalDB; AttachDbFilename =""C:\Users\Oaza\Documents\Visual Studio 2015\Projects\studia - projekt\studia - projekt\Database1.mdf""; Integrated Security = True");
            con.Open();
            com = new SqlCommand();
            com.Connection = con;


        }
        public void OdbierzDane(string wiadomosc,string temat)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Dane SET wiadomosc = @wiadomosc Where temat = @temat", con);
           // com.CommandText = "UPDATE Dane SET wiadomosc = @wiadomosc Where temat = @temat";
            cmd.Parameters.AddWithValue("@temat", temat);
            cmd.Parameters.AddWithValue("@wiadomosc", wiadomosc);
            cmd.ExecuteNonQuery();
        }
        public string UstawDane(string temat)
        {
            com.CommandText = "SELECT* FROM Dane where temat ='" + temat + "'";
            da = new SqlDataAdapter(com);
            dt = new DataTable();
            da.Fill(dt);
            return dt.Rows[0]["wiadomosc"].ToString();
        }
    }
}
