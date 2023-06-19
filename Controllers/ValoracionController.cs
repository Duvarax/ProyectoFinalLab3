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
     public IActionResult altaValoracion([FromBody] Respuesta respuesta)
     {
        Usuario usuario = ObtenerUsuarioLogueado();
        int countUserVal = _context.Valoraciones.Count(v => v.id_usuario == usuario.Id && v.id_respuesta==respuesta.Id);
        if(countUserVal > 0){
            return Ok(false);
        }
        if(respuesta != null)
        {
            Valoracion valoracion = new Valoracion
            {
                Id = 0,
                id_respuesta = respuesta.Id,
                id_usuario = usuario.Id
            };
            _context.Add(valoracion);
            return Ok(_context.SaveChanges());
        }else
        {
            return BadRequest("Valoracion invalida");
        }
     }
     [HttpDelete("eliminar")]
     public IActionResult bajaValoracion([FromBody] Respuesta respuesta)
     {  
        Usuario usuario = ObtenerUsuarioLogueado();
        if(respuesta != null)
        {
            Valoracion valoracion = _context.Valoraciones.FirstOrDefault(v => v.id_usuario == usuario.Id && v.id_respuesta==respuesta.Id);
            _context.Remove(valoracion);
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
