
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalLab3.Models;

public class Respuesta
{   
    public int Id {get; set;}
    public string? Texto {get; set;}
    public DateTime? fechaCreacion {get; set;}
    public int? id_usuario {get; set;}
    [ForeignKey(nameof(id_usuario))]
    public Usuario? usuario {get; set;}
    public int? id_pregunta {get; set;}
    [ForeignKey(nameof(id_pregunta))]
    public Pregunta? pregunta {get; set;}

    public Boolean valorada{get; set;} = false; 



    


    public Respuesta()
    {
       
    }
    

}
