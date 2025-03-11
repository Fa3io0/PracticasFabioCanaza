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

            string URL2 = $"http://api.geonames.org/countryCodeJSON?lat={latitud}&lng={longitud}&username=fa3io0";

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(URL2).Result;
                string jsonResponse = response.Content.ReadAsStringAsync().Result;

                var apiObject = JsonConvert.DeserializeObject<Pais>(jsonResponse);

                string nombrePais = apiObject.countryName;

                Console.WriteLine("Estamos en el pais de " + nombrePais);

            }
            
        Thread.Sleep(500);

        } while (true);
    }
}