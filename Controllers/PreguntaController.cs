using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
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

     [HttpPost("guardar")]
     public IActionResult altaPregunta([FromBody] Pregunta pregunta)
     {
        if(pregunta != null)
        {
            _context.Add(pregunta);
            return Ok(_context.SaveChanges());
        }else
        {
            return BadRequest("Pregunta invalida");
        }
     }

      [HttpDelete("eliminar")]
     public IActionResult bajaPregunta([FromBody] Pregunta pregunta)
     {
        if(pregunta != null)
        {
            _context.Remove(pregunta);
            return Ok(_context.SaveChanges());
        }else
        {
            return BadRequest("Pregunta invalida");
        }
     }

     [HttpGet]
     public IActionResult obtenerPreguntas()
     {
        Usuario usuario = ObtenerUsuarioLogueado();

        return Ok(_context.Preguntas
        .Include(r => r.usuario)
        .Include(r => r.juego)
        .Where(p => p.id_usuario == usuario.Id)
        .ToList());
     }
     [HttpPost("cantidad")]
     public IActionResult obtenerCantidadPreguntas([FromBody] Juego juego)
     {
        int count = _context.Preguntas.Count(r => r.id_juego == juego.Id);
        return Ok(count);
     }

     	private Usuario ObtenerUsuarioLogueado()
    {
        var email = User.Identity.Name;
        var usuario = _context.Usuarios.FirstOrDefault(p => p.Email == email);
        return usuario;
    }


    
}
