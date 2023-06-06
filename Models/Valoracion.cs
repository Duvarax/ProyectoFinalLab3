
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalLab3.Models;

public class Valoracion
{
    public int Id {get; set;}
    public int id_respuesta {get; set;}
    [ForeignKey(nameof(id_respuesta))]
    public Respuesta? respuesta {get; set;}
    public int id_usuario {get; set;}
    [ForeignKey(nameof(id_usuario))]
    public Usuario? usuario {get; set;}

}