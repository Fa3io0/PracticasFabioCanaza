
// dotnet add package Newtonsoft.Json   

using Newtonsoft.Json;


internal class EjercicioAPIS
{
    private static void Main(string[] args)
    {

        do
        {
            string url = "http://api.open-notify.org/iss-now.json";
            string longitud ;
            string latitud;
            using (var client = new HttpClient())

            {
            HttpResponseMessage response = client.GetAsync(url).Result;
            string jsonResponse = response.Content.ReadAsStringAsync().Result;

            var apiObject = JsonConvert.DeserializeObject<Api>(jsonResponse);
            longitud = apiObject.iss_position.longitude;
            latitud = apiObject.iss_position.latitude;
            }

            string url2 = $"http://api.geonames.org/countryCodeJSON?lat={latitud}&lng={longitud}&username=darren";

            using (var client = new HttpClient())

            {
                HttpResponseMessage response = client.GetAsync(url2).Result;
                string jsonResponse = response.Content.ReadAsStringAsync().Result;

                var apiObject = JsonConvert.DeserializeObject<Pais>(jsonResponse);

                string nombrePais = apiObject.countryName;

                Console.WriteLine("Estamos en el pais " + nombrePais);

            }


            
        Thread.Sleep(500);

        } while (true);
    }

}