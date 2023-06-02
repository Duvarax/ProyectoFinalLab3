

using Newtonsoft.Json;

namespace ProyectoFinalLab3.Models;

public class GameApiIGDB
{
    public String name {get; set;}
    public String summary {get; set;}
    public Cover cover {get; set;}
    public long first_release_date {get; set;}
    public InvolvedCompany[] involved_companies {get; set;}

    public GameApiIGDB()
    {
        
    }
}
public class Cover
{
    
    public int id { get; set; }
    public string image_id { get; set; }
    public Cover()
    {
        
    }
}

public class InvolvedCompany
{
    [JsonProperty("company")]
    public Company Company { get; set; }
}

public class Company
{
    [JsonProperty("name")]
    public string Name { get; set; }
}