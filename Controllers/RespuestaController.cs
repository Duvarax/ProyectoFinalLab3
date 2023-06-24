using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ProyectoFinalLab3.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;
using System.Linq;

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
        Usuario usuarioLogeado = ObtenerUsuarioLogueado();
        if(usuarioLogeado == null){
            return Unauthorized();
        }
        
        if(respuesta != null)
        {   
            respuesta.fechaCreacion = DateTime.Now;
            respuesta.id_pregunta = respuesta.pregunta.Id;
            respuesta.id_usuario = usuarioLogeado.Id;
            respuesta.pregunta = null;
            respuesta.usuario = null;
            _context.Respuestas.Add(respuesta);
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
            _context.SaveChanges();
            return Ok(respuesta);
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
        var valoraciones = _context.Valoraciones.Include(v => v.respuesta).Where(v => v.respuesta.id_pregunta == pregunta.Id).ToList();
        List<OrdenRespuestas> ordenRespuestas = new List<OrdenRespuestas>();
        var respuestas = _context.Respuestas
        .Include(r => r.pregunta).Include(r => r.pregunta.juego).Include(r => r.pregunta.usuario)
        .Include(r => r.usuario)
        .Where(r => r.id_pregunta == pregunta.Id)
        .ToList();
        foreach (var respuesta in respuestas)
        {
            OrdenRespuestas orden = new OrdenRespuestas();
            orden.cantidad = _context.Valoraciones.Count(v => v.id_respuesta == respuesta.Id);
            orden.respuesta = respuesta;
            ordenRespuestas.Add(orden);
        }
        var respuestasOrdenadas = ordenRespuestas.OrderByDescending(o => o.cantidad).Select(o => o.respuesta).ToList();
        List<Respuesta> respuestasValoradas = new List<Respuesta>();
        foreach(var respuesta in respuestasOrdenadas)
        {
            int count = _context.Valoraciones.Count(v => v.id_respuesta == respuesta.Id && v.id_usuario == usuario.Id);
            if(count > 0){
                respuesta.valorada = true;
            }else{
                respuesta.valorada = false;
            }
            respuestasValoradas.Add(respuesta);
        }
        return Ok(respuestasValoradas);
     }

     	private Usuario ObtenerUsuarioLogueado()
    {
        var email = User.Identity.Name;
        var usuario = _context.Usuarios.FirstOrDefault(p => p.Email == email);
        return usuario;
    }


    
}
