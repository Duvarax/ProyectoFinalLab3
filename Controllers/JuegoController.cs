using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ProyectoFinalLab3.Models;
using Newtonsoft.Json;
using System.Text;

namespace ProyectoFinalLab3.Controllers;

[Route("[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class JuegoController : ControllerBase
{   
    private readonly DataContext _context;
    private readonly IConfiguration config;
    private readonly IWebHostEnvironment environment;
    private readonly IHttpClientFactory _httpClientFactory;
    private const string ClientId = "hrf9wxam9zk4vcvevscji61l2jr8wj";
    private const string ClientSecret = "1az53ys5j6yxmd2t0oku561ouci6qh";
    public JuegoController(DataContext context, IConfiguration config, IWebHostEnvironment environment, IHttpClientFactory _httpClientFactory)
    {
        this._context = context;
        this.config = config;
        this.environment = environment;
        this._httpClientFactory = _httpClientFactory;
    }

    // [HttpPost("cargar")]
    // public Juego cargarJuegos(){    
    //     var Games =  IGDBApiTraerJuegos();

    //     Juego juego = new Juego(1, "messi", "messi", "messi", "messi", "")
    // }

    [AllowAnonymous]
    [HttpGet("test")]
    public async Task<string> testAsync(){
        var token = await GetAccessToken();
        Console.WriteLine(token.ToString());
        return "aaa";
    }
    static async Task<string> GetAccessToken()
    {
        String clientId = "hrf9wxam9zk4vcvevscji61l2jr8wj";
        String clientSecret = "1az53ys5j6yxmd2t0oku561ouci6qh";
        string url = $"https://id.twitch.tv/oauth2/token?client_id={clientId}&client_secret={clientSecret}&grant_type=client_credentials";
        try{
             using (var httpClient = new HttpClient())
        {

            var response = await httpClient.PostAsync(url, null);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var accessToken = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(jsonResponse).access_token;
                return accessToken;
            }else{
                return "";
            }
            
        }
        }catch(Exception ex)
        {
            return ex.ToString();
        }
       
    }
}
