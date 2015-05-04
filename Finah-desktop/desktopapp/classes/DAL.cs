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

                Uri uri = new Uri(client.BaseAddress + "api/Persoons/"+per.Id);
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, uri);
                String json = JsonConvert.SerializeObject(per);
                httpRequestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(uri, httpRequestMessage.Content);
                if (response.IsSuccessStatusCode)
                {
                    Uri gizmoUrl = response.Headers.Location;
                }
               
            }
            
            return 1;
            
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
        public List<Persoon> getPersonen() //Categorieen opzoeken in de database
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
                    var task = client.GetAsync("api/Persoons")
           .ContinueWith((taskwithresponse) =>
           {
               var response = taskwithresponse.Result;
               var jsonString = response.Content.ReadAsStringAsync();
               jsonString.Wait();

               model = JsonConvert.DeserializeObject<List<Persoon>>(jsonString.Result);
           });
                    task.Wait();
                }
                catch (Exception)
                {

                }
                return model;
            }
        }
        public List<Persoon> getPersoon(int id) //Categorieen opzoeken in de database
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
                    var task = client.GetAsync("api/Persoons/"+id)
           .ContinueWith((taskwithresponse) =>
           {
               var response = taskwithresponse.Result;
               var jsonString = response.Content.ReadAsStringAsync();
               jsonString.Wait();

               model = JsonConvert.DeserializeObject<List<Persoon>>(jsonString.Result);
           });
                    task.Wait();
                }
                catch (Exception)
                {

                }
                return model;
            }
        }
        public async Task<int> insertPersoon(Persoon p) //Nieuwe persoon ingeven
        {
            using (var client = new HttpClient())
            {
                // Connectie:
                client.BaseAddress = new Uri("http://finahback.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Uri uri = new Uri(client.BaseAddress + "api/Persoons/");
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
        public List<Functie> getFunctie() //Functies opzoeken in de database
        {
            List<Functie> model = null;
            using (var client = new HttpClient())
            {
                //Connectie:
                client.BaseAddress = new Uri("http://finahback.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                try
                {
                    var task = client.GetAsync("api/Functies")
           .ContinueWith((taskwithresponse) =>
           {
               var response = taskwithresponse.Result;
               var jsonString = response.Content.ReadAsStringAsync();
               jsonString.Wait();

               model = JsonConvert.DeserializeObject<List<Functie>>(jsonString.Result);
           });
                    task.Wait();
                }
                catch (Exception)
                {

                }
                return model;
            }
        }
        public async Task<int> deletePersoon(int id) //Nieuwe persoon ingeven
        {
            using (var client = new HttpClient())
            {
                // Connectie:
                client.BaseAddress = new Uri("http://finahback.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Uri uri = new Uri(client.BaseAddress + "api/Persoons/" + id);
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, uri);

                var response = await client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Uri gizmoUrl = response.Headers.Location;
                }

            }

            return 1;
        }
        public List<Functie> getFunctie(int id) //Categorieen opzoeken in de database
        {
            List<Functie> model = null;
            using (var client = new HttpClient())
            {
                //Connectie:
                client.BaseAddress = new Uri("http://finahback.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var task = client.GetAsync("api/Functies/" + id)
           .ContinueWith((taskwithresponse) =>
           {
               var response = taskwithresponse.Result;
               var jsonString = response.Content.ReadAsStringAsync();
               jsonString.Wait();

               model = JsonConvert.DeserializeObject<List<Functie>>(jsonString.Result);
           });
                    task.Wait();
                }
                catch (Exception)
                {

                }
                return model;
            }
        }
        public List<Categorie> getCategorie(int id) //Categorieen opzoeken in de database
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
                    var task = client.GetAsync("api/Categories/" + id)
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
        public async Task<int> insertFunctie(Functie f) //Nieuwe persoon ingeven
        {
            using (var client = new HttpClient())
            {
                // Connectie:
                client.BaseAddress = new Uri("http://finahback.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Uri uri = new Uri(client.BaseAddress + "api/Functies/");
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);
                String json = JsonConvert.SerializeObject(f);
                httpRequestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(uri, httpRequestMessage.Content);
                if (response.IsSuccessStatusCode)
                {
                    Uri gizmoUrl = response.Headers.Location;
                }
                return 1;
            }
        }
        public static async Task<int> UpdateFunctie(Functie f) //Wijzig Persoonsgegevens in database
        {


            using (var client = new HttpClient())
            {
                // Connectie:
                client.BaseAddress = new Uri("http://finahback.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Uri uri = new Uri(client.BaseAddress + "api/Functies/" + f.id);
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, uri);
                String json = JsonConvert.SerializeObject(f);
                httpRequestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(uri, httpRequestMessage.Content);
                if (response.IsSuccessStatusCode)
                {
                    Uri gizmoUrl = response.Headers.Location;
                }

            }

            return 1;

        }
        public async Task<int> deleteFunctie(int id) //Nieuwe persoon ingeven
        {
            using (var client = new HttpClient())
            {
                // Connectie:
                client.BaseAddress = new Uri("http://finahback.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Uri uri = new Uri(client.BaseAddress + "api/Functies/" + id);
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, uri);

                var response = await client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Uri gizmoUrl = response.Headers.Location;
                }

            }

            return 1;
        }
        public async Task<int> insertCategorie(Categorie cat) //Nieuwe persoon ingeven
        {
            using (var client = new HttpClient())
            {
                // Connectie:
                client.BaseAddress = new Uri("http://finahback.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Uri uri = new Uri(client.BaseAddress + "api/Categories/");
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);
                String json = JsonConvert.SerializeObject(cat);
                httpRequestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(uri, httpRequestMessage.Content);
                if (response.IsSuccessStatusCode)
                {
                    Uri gizmoUrl = response.Headers.Location;
                }
                return 1;
            }
        }
        public static async Task<int> UpdateCategorie(Categorie cat) //Wijzig Persoonsgegevens in database
        {


            using (var client = new HttpClient())
            {
                // Connectie:
                client.BaseAddress = new Uri("http://finahback.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Uri uri = new Uri(client.BaseAddress + "api/Categories/" + cat.id);
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, uri);
                String json = JsonConvert.SerializeObject(cat);
                httpRequestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(uri, httpRequestMessage.Content);
                if (response.IsSuccessStatusCode)
                {
                    Uri gizmoUrl = response.Headers.Location;
                }

            }

            return 1;

        }
        public async Task<int> deleteCategorie(int id) //Nieuwe persoon ingeven
        {
            using (var client = new HttpClient())
            {
                // Connectie:
                client.BaseAddress = new Uri("http://finahback.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Uri uri = new Uri(client.BaseAddress + "api/Categories/" + id);
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, uri);

                var response = await client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Uri gizmoUrl = response.Headers.Location;
                }

            }

            return 1;
        }
        public async Task<int> insertOverzicht(Overzicht overzicht) //Nieuwe patient ingeven
        {

            using (var client = new HttpClient())
            {
                // Connectie:
                client.BaseAddress = new Uri("http://finahback.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Uri uri = new Uri(client.BaseAddress + "api/Overzicht/");
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);
                String json = JsonConvert.SerializeObject(overzicht);
                httpRequestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(uri, httpRequestMessage.Content);
                if (response.IsSuccessStatusCode)
                {
                    Uri gizmoUrl = response.Headers.Location;
                }
                return 1;
            }
        }
        public List<Overzicht> getOverzicht() //Functies opzoeken in de database
        {
            List<Overzicht> model = null;
            using (var client = new HttpClient())
            {
                //Connectie:
                client.BaseAddress = new Uri("http://finahback.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                try
                {
                    var task = client.GetAsync("api/Overzicht")
           .ContinueWith((taskwithresponse) =>
           {
               var response = taskwithresponse.Result;
               var jsonString = response.Content.ReadAsStringAsync();
               jsonString.Wait();

               model = JsonConvert.DeserializeObject<List<Overzicht>>(jsonString.Result);
           });
                    task.Wait();
                }
                catch (Exception)
                {

                }
                return model;
            }
        }
        public List<Patient> getPatienten() //Functies opzoeken in de database
        {
            List<Patient> model = null;
            using (var client = new HttpClient())
            {
                //Connectie:
                client.BaseAddress = new Uri("http://finahback.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                try
                {
                    var task = client.GetAsync("api/Patients")
           .ContinueWith((taskwithresponse) =>
           {
               var response = taskwithresponse.Result;
               var jsonString = response.Content.ReadAsStringAsync();
               jsonString.Wait();

               model = JsonConvert.DeserializeObject<List<Patient>>(jsonString.Result);
           });
                    task.Wait();
                }
                catch (Exception)
                {

                }
                return model;
            }
        }
          
    }
}
