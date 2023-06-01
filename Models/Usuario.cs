
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalLab3.Models;

public class Usuario
{   
    public int Id {get; set;}
    public string? Nombre {get; set;}
    public string? Apellido {get; set;}
    public string? NombreUsuario {get; set;}
    public string? Email {get; set;}
    public string? Contraseña {get; set;}
    public string? Imagen {get; set;}
    [NotMapped]
    public IFormFile imagenFile {get; set;}
    public string Portada {get; set;}
    [NotMapped]
    public IFormFile portadaFile {get; set;}

    
    public Usuario()
    {
       
    }

}
