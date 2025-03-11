using System;
using System.Threading;
using Newtonsoft.Json;
internal class EjercicioAPI
{
    private static void Main(string[] args)
    {
        do
        {
            string longitud;
            string latitud;

            string URL = "http://api.open-notify.org/iss-now.json";

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(URL).Result;
                string jsonResponse = response.Content.ReadAsStringAsync().Result;

                var apiObject = JsonConvert.DeserializeObject<API>(jsonResponse);
                longitud = apiObject.iss_position.longitude;
                latitud = apiObject.iss_position.latitude;
            }

            string UrlLaLon = $"http://api.geonames.org/countryCodeJSON?lat={latitud}&lng={longitud}&username=fa3io0";

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(UrlLaLon).Result;
                string jsonResponse = response.Content.ReadAsStringAsync().Result;

                var apiObject = JsonConvert.DeserializeObject<Pais>(jsonResponse);

                string nombrePais = apiObject.countryName;

                Console.WriteLine("Estamos en el pais de " + nombrePais);

            }
            
            Thread.Sleep(500);

            string URL2 = "https://api.wheretheiss.at/v1/coordinates/37.795517,-122.393693";

            using (var client2 = new HttpClient())
            {
                HttpResponseMessage response2 = client2.GetAsync(URL2).Result;
                string jsonResponse2 = response2.Content.ReadAsStringAsync().Result;

                var apiObject2 = JsonConvert.DeserializeObject<API2>(jsonResponse2);
            }

            string UrlLaLon2 = $"http://api.geonames.org/countryCodeJSON?lat={latitud}&lng={longitud}&username=fa3io0";

            using (var client2 = new HttpClient())
            {
                HttpResponseMessage response2 = client2.GetAsync(UrlLaLon2).Result;
                string jsonResponse2 = response2.Content.ReadAsStringAsync().Result;

                var apiObject2 = JsonConvert.DeserializeObject<Pais>(jsonResponse2);

                string nombrePais2 = apiObject2.countryName;

                Console.WriteLine("El segundo pais es " + nombrePais2);
            }

            Thread.Sleep(500);

        } while (true);
    }
}