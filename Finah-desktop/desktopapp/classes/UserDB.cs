using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using desktopapp.classes;

namespace desktopapp
{
    public static class UserDB
    {
        public static Persoon GetLogin(string naam, string wachtwoord)
        {
            Persoon test = new Persoon();
            // connectie string gaan ophalen
            SqlConnection conn = Connectie.getCon();

            string Statement = "SELECT gebruikersnaam, wachtwoord " +
                "FROM Persoon " +
                "WHERE gebruikersnaam=@naam AND wachtwoord=@wachtwoord";
            SqlCommand command = new SqlCommand(Statement, conn);

            //via parameter kan je fields van c# gebruiken voor sql input/output
            command.Parameters.AddWithValue("@naam", naam);
            command.Parameters.AddWithValue("@wachtwoord", wachtwoord);
            SqlDataReader reader;
            try
            {
                conn.Open();

                //nu geeft de database een rij weer en niet alle gegevens

                reader = command.ExecuteReader(CommandBehavior.SingleRow);
                //reader = command.ExecuteReader();
                if (reader.Read())
                {
                    test.gebruikersnaam = reader["gebruikersnaam"].ToString();
                    test.wachtwoord = reader["wachtwoord"].ToString();

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
