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
        private Logger logger = new Logger();

        public DAL()
        {
        }

        //Get
        public Persoon getGebruiker(string gebruikersnaam, string wachtwoord)
        {
            List<Persoon> model = null;
            Persoon Gebruiker = null;
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
                return Gebruiker;
            }
        }
        public List<Persoon> getPersonen()
        {
            List<Persoon> p = get<Persoon>("api/Persoons/");
            return p;
        }
        public List<Persoon> getPersoon(int id)
        {
            List<Persoon> p = get<Persoon>("api/Persoons/" + id);
            return p;
        }
        public List<Categorie> getCategorie()
        {
            List<Categorie> c = get<Categorie>("api/Categories/");
            return c;
        }
        public List<Categorie> getCategorie(int id)
        {
            List<Categorie> c = get<Categorie>("api/Categories/" + id);
            return c;
        }
        public List<Functie> getFunctie()
        {
            List<Functie> f = get<Functie>("api/Functies");
            return f;
        }
        public List<Functie> getFunctie(int id)
        {
            List<Functie> f = get<Functie>("api/Functies/" + id);
            return f;
        }
        public List<Patient> getPatienten()
        {
            List<Patient> p = get<Patient>("api/Patients");
            return p;
        }
        public List<Overzicht> getOverzicht()
        {
            List<Overzicht> o = get<Overzicht>("api/Overzicht/");
            return o;
        }

        //Update
        public async Task<int> UpdateGebruiker(Persoon per)
        {
            int i = await update<Persoon>("api/Persoons/" + per.Id, per);
            return i;
        }
        public async Task<int> UpdateFunctie(Functie f)
        {
            int i = await update<Functie>("api/Functies/" + f.id, f);
            return i;
        }
        public async Task<int> UpdateCategorie(Categorie cat)
        {
            int i = await update<Categorie>("api/Categories/" + cat.id, cat);
            return i;
        }

        //Insert
        public async Task<int> insertPersoon(Persoon p)
        {
            int i = await insert<Persoon>("api/Persoons/", p);
            return i;
        }
        public async Task<int> insertPatient(Patient p)
        {
            int i = await insert<Patient>("api/Patients/", p);
            return i;
        }
        public async Task<int> insertFunctie(Functie f)
        {
            int i = await insert<Functie>("api/Functies/", f);
            return i;
        }
        public async Task<int> insertCategorie(Categorie cat)
        {
            int i = await insert<Categorie>("api/Categories/", cat);
            return i;
        }
        public async Task<int> insertOverzicht(Overzicht overzicht)
        {
            int i = await insert<Overzicht>("api/Overzicht/", overzicht);
            return i;
        }

        //Delete
        public async Task<int> deletePersoon(int id)
        {
            int i = await delete("api/Persoons/"+id);
            return i;
        }
        public async Task<int> deleteFunctie(int id)
        {
            int i = await delete("api/Functies/" + id);
            return i;
        }
        public async Task<int> deleteCategorie(int id)
        {
            int i = await delete("api/Categories/" + id);
            return i;
        }

        //Functies
        private List<T> get<T>(string api)
        {
            List<T> model = null;
            using (var client = new HttpClient())
            {
                //Connectie:
                try
                {
                client.BaseAddress = new Uri("http://finahback.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var task = client.GetAsync(api)
           .ContinueWith((taskwithresponse) =>
           {
               var response = taskwithresponse.Result;
               var jsonString = response.Content.ReadAsStringAsync();
               jsonString.Wait();

               model = JsonConvert.DeserializeObject<List<T>>(jsonString.Result);
           });
                    task.Wait();
                }
                catch (Exception ex)
                {
                    logger.log(ex.Message);
                }
                return model;
            } 
        }
        private async Task<int> update<T>(String api, T t)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    // Connectie:
                    client.BaseAddress = new Uri("http://finahback.azurewebsites.net/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    Uri uri = new Uri(client.BaseAddress + api);
                    HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, uri);
                    String json = JsonConvert.SerializeObject(t);
                    httpRequestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PutAsync(uri, httpRequestMessage.Content);
                    if (response.IsSuccessStatusCode)
                    {
                        Uri gizmoUrl = response.Headers.Location;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.log(ex.Message);
            }
            return 1;
        }
        private async Task<int> insert<T>(String api, T t)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    // Connectie:
                    client.BaseAddress = new Uri("http://finahback.azurewebsites.net/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    Uri uri = new Uri(client.BaseAddress + api);
                    HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, uri);
                    String json = JsonConvert.SerializeObject(t);
                    httpRequestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(uri, httpRequestMessage.Content);
                    if (response.IsSuccessStatusCode)
                    {
                        Uri gizmoUrl = response.Headers.Location;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.log(ex.Message);
            }
            return 1;
        }
        private async Task<int> delete(String api)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    // Connectie:
                    client.BaseAddress = new Uri("http://finahback.azurewebsites.net/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    Uri uri = new Uri(client.BaseAddress + api);
                    HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, uri);

                    var response = await client.DeleteAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        Uri gizmoUrl = response.Headers.Location;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.log(ex.Message);
            }
            return 1;
        }
    }
}
