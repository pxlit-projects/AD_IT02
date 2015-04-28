using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Net.Http.Headers;
using desktopapp.classes;

namespace desktopapp.classes
{
   public class DAL
   {
       private Persoon Gebruiker;


        public DAL()
        {
           
        }

        public async void getGebruiker(string gebruikersnaam, string wachtwoord) //MOET NOG AAN GEWERKT WORDEN
        {
            
            using (var client = new HttpClient())
            {
                // New code:
                client.BaseAddress = new Uri("http://finahback.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                 HttpResponseMessage response =client.GetAsync("api/Persoons?gebruikersnaam="+gebruikersnaam+"&wachtwoord="+wachtwoord).Result;
    if (response.IsSuccessStatusCode)
    {
        
        Gebruiker = await response.Content.ReadAsAsync<Persoon>();
        Console.WriteLine(Gebruiker);
        
    }
}
            }

       public Persoon ZoekGebruiker(String gbrnaam, String wwoord)
       {
           getGebruiker(gbrnaam, wwoord);
           return Gebruiker;
       }



       /*  public void insertPatient(Patient p)
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

           public static void insertPersoon(Persoon p)
           {
               using (SqlConnection connection = new SqlConnection(ConnectionData))
               {
                   SqlTransaction transaction = null;
                   try
                   {
                       connection.Open();
                       command = new SqlCommand("insertPersoon", connection);
                       command.CommandType = CommandType.StoredProcedure;
                       command.Transaction = transaction;
                       command.Parameters.Add(new SqlParameter("@naam", p.naam));
                       command.Parameters.Add(new SqlParameter("@voornaam", p.voornaam));
                       command.Parameters.Add(new SqlParameter("@geboortejaar", p.geboortejaar));
                       command.Parameters.Add(new SqlParameter("@geslacht", p.geslacht));
                       command.Parameters.Add(new SqlParameter("@straat", p.straat));
                       command.Parameters.Add(new SqlParameter("@postcode", p.postcode));
                       command.Parameters.Add(new SqlParameter("@gsm", p.gsm));
                       command.Parameters.Add(new SqlParameter("@bedrijf", p.bedrijf));
                       command.Parameters.Add(new SqlParameter("@gebruikersnaam", p.gebruikersnaam));
                       command.Parameters.Add(new SqlParameter("@wachtwoord", p.wachtwoord));
                       command.Parameters.Add(new SqlParameter("@telefoon", p.telefoon));
                       command.Parameters.Add(new SqlParameter("@email", p.email));
                       command.Parameters.Add(new SqlParameter("@id", p.Id));

                    
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
           } */

   }
}
