using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ProyectoFinalLab3.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;

namespace ProyectoFinalLab3.Controllers;

[Route("[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class ValoracionController : ControllerBase
{   
    private readonly DataContext _context;
    private readonly IConfiguration config;
    private readonly IWebHostEnvironment environment;

    public ValoracionController(DataContext context, IConfiguration config, IWebHostEnvironment environment)
    {
        this._context = context;
        this.config = config;
        this.environment = environment;
    }

     [HttpPost("guardar")]
     public IActionResult altaValoracion([FromBody] Valoracion valoracion)
     {
        if(valoracion != null)
        {
            _context.Add(valoracion);
            return Ok(_context.SaveChanges());
        }else
        {
            return BadRequest("Valoracion invalida");
        }
     }
     [HttpDelete("eliminar")]
     public IActionResult bajaValoracion([FromBody] Valoracion valoracion)
     {
        if(valoracion != null)
        {
            _context.Remove(valoracion);
            return Ok(_context.SaveChanges());
        }else
        {
            return BadRequest("Valoracion invalido");
        }
     }




    
}
