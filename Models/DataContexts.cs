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

		
	}