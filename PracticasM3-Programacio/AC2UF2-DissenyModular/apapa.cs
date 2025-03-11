// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class IssPosition
    {
        public string longitude { get; set; }
        public string latitude { get; set; }
    }

    public class Api
    {
        public IssPosition iss_position { get; set; }
        public int timestamp { get; set; }
        public string message { get; set; }
    }


// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Pais
{
    public string languages { get; set; }
    public string distance { get; set; }
    public string countryCode { get; set; }
    public string countryName { get; set; }
}

