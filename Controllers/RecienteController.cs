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
public class RecienteController : ControllerBase
{   
    private readonly DataContext _context;
    private readonly IConfiguration config;
    private readonly IWebHostEnvironment environment;

    public RecienteController(DataContext context, IConfiguration config, IWebHostEnvironment environment)
    {
        this._context = context;
        this.config = config;
        this.environment = environment;
    }


    [HttpGet]
    public IActionResult obtenerJuegosRecientes()
    {
        Usuario usuario = ObtenerUsuarioLogueado();
        if(usuario == null){
            return Unauthorized();
        }
        var juegosRecientes = _context.Recientes.Include(r => r.juego).Where(r => r.id_usuario == usuario.Id).OrderByDescending(r => r.Cantidad).Take(3).Select(r => r.juego);
        return Ok(juegosRecientes);
        
    }

     [HttpPost("guardar")]
     public IActionResult altaReciente([FromBody] Reciente reciente)
     {
        Usuario usuario = ObtenerUsuarioLogueado();

        Reciente recienteExiste = _context.Recientes.FirstOrDefault(r => r.id_juego == reciente.id_juego && r.id_usuario == reciente.id_usuario);
        if(recienteExiste != null){
            recienteExiste.Cantidad += 1;
            return Ok(_context.SaveChanges());
        }
        if(reciente != null)
        {   
            reciente.Cantidad = 1;
            _context.Add(reciente);
            return Ok(_context.SaveChanges());
        }else
        {
            return BadRequest("Reciente invalido");
        }
     }
     [HttpDelete("eliminar")]
     public IActionResult bajaReciente([FromBody] Reciente reciente)
     {
        if(reciente != null)
        {
            _context.Remove(reciente);
            return Ok(_context.SaveChanges());
        }else
        {
            return BadRequest("Valoracion invalido");
        }
     }


	private Usuario ObtenerUsuarioLogueado()
    {
        var email = User.Identity.Name;
        var usuario = _context.Usuarios.FirstOrDefault(p => p.Email == email);
        return usuario;
    }

    
}
