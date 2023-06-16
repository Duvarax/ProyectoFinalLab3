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
public class ComentarioController : ControllerBase
{   
    private readonly DataContext _context;
    private readonly IConfiguration config;
    private readonly IWebHostEnvironment environment;

    public ComentarioController(DataContext context, IConfiguration config, IWebHostEnvironment environment)
    {
        this._context = context;
        this.config = config;
        this.environment = environment;
    }

     [HttpPost("guardar")]
     public IActionResult altaComentario([FromBody] Comentario comentario)
     {
        Usuario usuarioLogeado = ObtenerUsuarioLogueado();
        if(usuarioLogeado == null){
            return Unauthorized();
        }
        if(comentario != null)
        {
            comentario.fechaCreacion = DateTime.Now;
            comentario.id_respuesta = comentario.respuesta.Id;
            comentario.id_usuario = usuarioLogeado.Id;
            comentario.usuario = null;
            comentario.respuesta = null;
            _context.Add(comentario);
            _context.SaveChanges();
            return Ok(comentario);
        }else
        {
            return BadRequest("Comentario invalido");
        }
     }
     [HttpDelete("eliminar")]
     public IActionResult bajaComentario([FromBody] Comentario comentario)
     {
        if(comentario != null)
        {
            _context.Remove(comentario);
            return Ok(_context.SaveChanges());
        }else
        {
            return BadRequest("comentario invalido");
        }
     }

     [HttpPost]
     public IActionResult obtenerComentarios([FromBody] Respuesta respuesta)
     {
        Usuario usuario = ObtenerUsuarioLogueado();
        if(usuario == null)
        {
            return Unauthorized();
        }

        return Ok(_context.Comentarios
        .Include(r => r.respuesta)
        .Include(r => r.usuario)
        .Where(r => r.id_respuesta == respuesta.Id)
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
