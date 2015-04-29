using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
using System.Windows.Media.Media3D;
using desktopapp.classes;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Text;

namespace desktopapp.classes
{
    public class DAL
    {
        public Persoon Gebruiker;


        public DAL()
        {

        }

        public void getGebruiker(string gebruikersnaam, string wachtwoord) //Gebruiker opzoeken in de database
        {
            List<Persoon> model = null;
            using (var client = new HttpClient())
            {
                //Connectie:
                client.BaseAddress = new Uri("http://finahback.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                try
                {
                    var task = client.GetAsync("api/Persoons?gebruikersnaam=" + gebruikersnaam + "&wachtwoord=" + wachtwoord)
           .ContinueWith((taskwithresponse) =>
           {
               var response = taskwithresponse.Result;
               var jsonString = response.Content.ReadAsStringAsync();
               jsonString.Wait();

               model = JsonConvert.DeserializeObject<List<Persoon>>(jsonString.Result);
           });
                    task.Wait();

                    Gebruiker = model.Find(x => x.gebruikersnaam == gebruikersnaam);
                }
                catch (Exception)
                {

                    MessageBox.Show("Gebruikersnaam ofwachtwoord fout.");
                }
            }
        }

        public Persoon ZoekGebruiker(String gbrnaam, String wwoord) //Gebruiker terug geven uit database
        {
            getGebruiker(gbrnaam, wwoord);
            return Gebruiker;
        }

        public static async Task<int> UpdateGebruiker(Persoon per) //Wijzig Persoonsgegevens in database
        {
            using (var client = new HttpClient())
            {
                // Connectie:
                client.BaseAddress = new Uri("http://finahback.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Uri uri = new Uri(client.BaseAddress + "api/Patients/");
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, uri);
                String json = JsonConvert.SerializeObject(per);
                httpRequestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(uri, httpRequestMessage.Content);
                if (response.IsSuccessStatusCode)
                {
                    Uri gizmoUrl = response.Headers.Location;
                }
                return 1;
            }
            
        }
        public async Task<int> insertPatient(Patient p) //Nieuwe patient ingeven
        {

            using (var client = new HttpClient())
            {
                // Connectie:
                client.BaseAddress = new Uri("http://finahback.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Uri uri = new Uri(client.BaseAddress + "api/Patients/");
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);
                String json = JsonConvert.SerializeObject(p);
                httpRequestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(uri, httpRequestMessage.Content);
                if (response.IsSuccessStatusCode)
                {
                    Uri gizmoUrl = response.Headers.Location;
                }
                return 1;
            }
        }
            public List<Categorie> getCategorie() //Categorieen opzoeken in de database
            {
                List<Categorie> model = null;
                using (var client = new HttpClient())
                {
                    //Connectie:
                    client.BaseAddress = new Uri("http://finahback.azurewebsites.net/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    try
                    {
                        var task = client.GetAsync("api/Categories")
               .ContinueWith((taskwithresponse) =>
               {
                   var response = taskwithresponse.Result;
                   var jsonString = response.Content.ReadAsStringAsync();
                   jsonString.Wait();

                   model = JsonConvert.DeserializeObject<List<Categorie>>(jsonString.Result);
               });
                        task.Wait();
                    }
                    catch (Exception)
                    {

                    }
                    return model;
                }
            }

           /*public static void insertPersoon(Persoon p)
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
