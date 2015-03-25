using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopapp.classes
{
    class DAL
    {
        private string ConnectionData = ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString;
        private SqlConnection Connection;
        private SqlCommand command;

        public DAL()
        {
            Connection = new SqlConnection(ConnectionData);
        }

        public Persoon getGebruiker(string gebruikersnaam, string wachtwoord) //MOET NOG AAN GEWERKT WORDEN
        {
            Persoon gebruiker = new Persoon();
            using (SqlConnection connection = new SqlConnection(ConnectionData))
            {
                SqlTransaction transaction = null;
                try
                {
                    connection.Open();
                    command = new SqlCommand("getGebruiker", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Transaction = transaction;
                    command.Parameters.Add(new SqlParameter("@gebruikersnaam", gebruikersnaam));
                    command.Parameters.Add(new SqlParameter("@wachtwoord", wachtwoord));
                    command.Connection = connection;
                    SqlDataReader dr = command.ExecuteReader(CommandBehavior.SingleRow);
                        if (dr.Read())
                        { 
                            gebruiker.gebruikersnaam = dr["gebruikersnaam"].ToString();
                            gebruiker.wachtwoord = dr["wachtwoord"].ToString();
                            gebruiker.functie = Convert.ToInt32(dr["functie"]);
                        }
                        else
                        {
                            gebruiker = null;
                        }     
                }
                catch (SqlException ex)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return gebruiker;
        }

        public void insertPatient(Patient p)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionData))
            {
                SqlTransaction transaction = null;
                try
                {
                    connection.Open();
                    command = new SqlCommand("insertPatient", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Transaction = transaction;
                    command.Parameters.Add(new SqlParameter("@beschrijving", p.beschrijving));
                    command.Parameters.Add(new SqlParameter("@leeftijd", p.leeftijd));
                    command.Parameters.Add(new SqlParameter("@categorie", p.categorie));
                    command.Parameters.Add(new SqlParameter("@mantelzorgerleeftijd", p.mantelzorgerleeftijd));
                    command.Parameters.Add(new SqlParameter("@relatie", p.relatie));
                    command.Parameters.Add(new SqlParameter("@hulpverlener", p.hulpverlener));
                    command.Parameters.Add(new SqlParameter("@overig", p.overig));
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }

        public List<Categorie> getCategorie()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionData))
            {
                SqlTransaction transaction = null;
                try
                {
                    connection.Open();
                    command = new SqlCommand("getCategorie", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Transaction = transaction;
                    command.Connection = connection;
                    SqlDataReader dr = command.ExecuteReader();
                    List<Categorie> ListCategorie = new List<Categorie>();
                    while (dr.Read())
                    {
                        int id = int.Parse(dr["Id"].ToString());
                        string naam = dr["naam"].ToString();
                        string beschrijving = dr["beschrijving"].ToString();
                        ListCategorie.Add(new Categorie(id, naam, beschrijving));
                    }
                    return ListCategorie;
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    return null;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return null;
                }
            }
        }

    }
}
