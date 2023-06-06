
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalLab3.Models;

public class Comentario
{   
    public int Id {get; set;}
    public string? Texto {get; set;}
    public DateTime? fechaCreacion {get; set;}
    public int? id_usuario {get; set;}
    [ForeignKey(nameof(id_usuario))]
    public Usuario? usuario {get; set;}
    public string? captura {get; set;}
    [NotMapped]
    public IFormFile? capturaFile {get; set;}
    public int? id_respuesta {get; set;}
    [ForeignKey(nameof(id_respuesta))]
    public Respuesta? respuesta {get; set;}
    


    public Comentario()
    {
       
    }
    

}
