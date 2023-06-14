using Microsoft.EntityFrameworkCore;


namespace ProyectoFinalLab3.Models;

	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}
		public DbSet<Juego> Juegos { get; set; }
		public DbSet<Pregunta> Preguntas {get; set;}
		public DbSet<Usuario> Usuarios {get; set;}

		public DbSet<Respuesta> Respuestas {get; set;}

		public DbSet<Comentario> Comentarios {get; set;}

		public DbSet<Valoracion> Valoraciones {get; set;}
		public DbSet<Reciente> Recientes {get; set;}
		public DbSet<Cloudinaries> cloudinaries {get; set;}

		
	}