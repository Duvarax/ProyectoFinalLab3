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
public class PreguntaController : ControllerBase
{   
    private readonly DataContext _context;
    private readonly IConfiguration config;
    private readonly IWebHostEnvironment environment;

    public PreguntaController(DataContext context, IConfiguration config, IWebHostEnvironment environment)
    {
        this._context = context;
        this.config = config;
        this.environment = environment;
    }

    // [HttpPost]
    // public IActionResult altaPregunta([FromBody] Pregunta pregunta)
    // {

    // }
    
}
