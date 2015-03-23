using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Finah
{
    public static class UserDB
    {
        public static Users GetLogin(string log, string pass)
        {
            Users test = new Users();
            // connectie string gaan ophalen
            SqlConnection conn = Connectie.getCon();

            string Statement = "SELECT UserID, Role, Name " +
                "FROM Users " +
                "WHERE UserName=@log AND Password=@pass";
            SqlCommand command = new SqlCommand(Statement, conn);

            //via parameter kan je fields van c# gebruiken voor sql input/output
            command.Parameters.AddWithValue("@log", log);
            command.Parameters.AddWithValue("@pass", pass);
            SqlDataReader reader;
            try
            {
                conn.Open();

                //nu geeft de database een rij weer en niet alle gegevens

                reader = command.ExecuteReader(CommandBehavior.SingleRow);
                //reader = command.ExecuteReader();
                if (reader.Read())
                {
                    test.UserID = (int)reader["UserID"];
                    test.Role = (int)reader["Role"];
                    test.Name = reader["Name"].ToString();

                }
                else
                {
                    test = null;
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return test;
        }
    }
}
