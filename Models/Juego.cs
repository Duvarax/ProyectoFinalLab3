using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProyectoFinalLab3.Models;

public class Juego
{   
    public int Id {get; set;}
    public string? Nombre {get; set;}
    public string? Portada {get; set;}
    public string? Descripcion {get; set;}
    public string? Autor {get; set;}
    public DateTime? fechaLanzamiento {get; set;}
    public int? id_pregunta {get; set;}
    [ForeignKey(nameof(id_pregunta))]
    public Pregunta? pregunta {get; set;}

    public Juego()
    {
       
    }

}
