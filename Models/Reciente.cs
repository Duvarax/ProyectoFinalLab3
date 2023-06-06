
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalLab3.Models;

public class Reciente
{
    public int Id {get; set;}
    public int id_juego {get; set;}
    [ForeignKey(nameof(id_juego))]
    public Juego? juego {get; set;}
    public int id_usuario {get; set;}
    [ForeignKey(nameof(id_usuario))]
    public Usuario? usuario {get; set;}

}