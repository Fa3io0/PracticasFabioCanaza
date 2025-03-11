public class IssPosition
{
    public string longitude { get; set; }
    public string latitude { get; set; }
}

public class API
{
    public IssPosition iss_position { get; set; }
    public int timestamp { get; set; }
    public string message { get; set; }
}
public class Pais
{
    public string languages { get; set; }
    public string distance { get; set; }
    public string countryCode { get; set; }
    public string countryName { get; set; }
}