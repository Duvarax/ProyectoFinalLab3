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
public class RespuestaController : ControllerBase
{   
    private readonly DataContext _context;
    private readonly IConfiguration config;
    private readonly IWebHostEnvironment environment;

    public RespuestaController(DataContext context, IConfiguration config, IWebHostEnvironment environment)
    {
        this._context = context;
        this.config = config;
        this.environment = environment;
    }

     [HttpPost("guardar")]
     public IActionResult altaRespuesta([FromBody] Respuesta respuesta)
     {
        if(respuesta != null)
        {
            _context.Add(respuesta);
            return Ok(_context.SaveChanges());
        }else
        {
            return BadRequest("Respuesta invalida");
        }
     }
     [HttpDelete("eliminar")]
     public IActionResult bajaRespuesta([FromBody] Respuesta respuesta)
     {
        if(respuesta != null)
        {
            _context.Remove(respuesta);
            return Ok(_context.SaveChanges());
        }else
        {
            return BadRequest("Respuesta invalida");
        }
     }

     [HttpPost]
     public IActionResult obtenerRespuestas([FromBody] Pregunta pregunta)
     {
        Usuario usuario = ObtenerUsuarioLogueado();
        if(usuario == null)
        {
            return Unauthorized();
        }

        return Ok(_context.Respuestas
        .Include(r => r.pregunta)
        .Include(r => r.usuario)
        .Where(r => r.id_pregunta == pregunta.Id)
        .ToList()
        );
     }

     	private Usuario ObtenerUsuarioLogueado()
    {
        var email = User.Identity.Name;
        var usuario = _context.Usuarios.FirstOrDefault(p => p.Email == email);
        return usuario;
    }


    
}
