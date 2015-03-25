using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopapp
{
    public class Connectie
    {
        public static SqlConnection getCon()
        {
            string connectionString =
                "Data Source=of4tna6c1a.database.windows.net;Initial Catalog=Main;Persist Security Info=True;User ID=finah;Password=Potlood123";
            SqlConnection conn= new SqlConnection(connectionString );
            return conn;


        }
    }
}
