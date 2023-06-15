using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalLab3.Models;
using Newtonsoft.Json;
using System.Text;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;

namespace ProyectoFinalLab3.Controllers;

[Route("[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class PreguntaController : ControllerBase
{   
    private readonly DataContext _context;
    private readonly IConfiguration config;
    private readonly IWebHostEnvironment environment;
    private Cloudinary cloudinary;
    public static string capturaUrl;

    public PreguntaController(DataContext context, IConfiguration config, IWebHostEnvironment environment)
    {
        this._context = context;
        this.config = config;
        this.environment = environment;
        cloudinary = new Cloudinary(new Account(config["cloud-name"], config["cloud-key"], config["cloud-secret"]));
        capturaUrl = "";
    }

     [HttpPost("guardar")]
     public IActionResult altaPregunta([FromBody] Pregunta pregunta)
     {  
        Usuario usuarioLogeado = ObtenerUsuarioLogueado();
        if(pregunta != null)
        {  
            pregunta.fechaCreacion = DateTime.Now;
            pregunta.id_usuario = usuarioLogeado.Id;
            if(capturaUrl == "" || capturaUrl == null){
                pregunta.captura = capturaUrl;
            }
            _context.Add(pregunta);
            return Ok(_context.SaveChanges());
        }else
        {
            return BadRequest("Pregunta invalida");
        }
     }
     [HttpPost("captura")]
     public async Task<IActionResult> setCaptura(IFormFile captura){
         Usuario usuarioLogeado = ObtenerUsuarioLogueado();
        // Upload

        var tempPath = Path.GetTempFileName();
        using (var stream = new FileStream(tempPath, FileMode.Create))
        {
            await captura.CopyToAsync(stream);
        }

         var uploadParams = new ImageUploadParams()
        {
            File = new FileDescription(tempPath),
            UniqueFilename = true,
            PublicIdPrefix = "gamerask_"

        };
        var uploadResults = await cloudinary.UploadAsync(uploadParams);

        capturaUrl = uploadResults.Url.ToString();
        return Ok(capturaUrl);
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
        if(usuario == null){
            return Unauthorized();
        }

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
