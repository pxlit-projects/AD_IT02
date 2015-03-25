using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finah
{
    public class Connectie
    {
        public static SqlConnection getCon()
        {
            string connectionString =
                "Data Source=of4tna6c1a.database.windows.net;Initial Catalog=finah;Persist Security Info=True;User ID=finah;Password=Potlood123";
            SqlConnection conn= new SqlConnection(connectionString );
            return conn;

        }
    }
}
