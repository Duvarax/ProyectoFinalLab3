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

     [HttpPost("guardar")]
     public IActionResult altaValoracion([FromBody] Valoracion valoracion)
     {
        Usuario usuario = ObtenerUsuarioLogueado();
        int countUserVal = _context.Valoraciones.Count(v => v.id_usuario == usuario.Id && v.id_respuesta==valoracion.id_respuesta);
        if(countUserVal > 0){
            return Ok(false);
        }
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


	private Usuario ObtenerUsuarioLogueado()
    {
        var email = User.Identity.Name;
        var usuario = _context.Usuarios.FirstOrDefault(p => p.Email == email);
        return usuario;
    }

    
}
