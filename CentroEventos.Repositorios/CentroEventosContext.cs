using CentroEventos.Aplicacion.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CentroEventos.Repositorios
{
    public class CentroEventosContext : DbContext
    {
        //public DbSet<Usuario> Usuarios { get; set; } = null!;
        public DbSet<Persona> Personas { get; set; } = null!;
        public DbSet<EventoDeportivo> Eventos { get; set; } = null!;
        public DbSet<Reserva> Reservas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=centroeventos.sqlite");
        }
    }
    
    public static class CentroEventosDbInicializador
    {
        public static void Inicializar()
        {
            using var context = new CentroEventosContext();
            if (context.Database.EnsureCreated())
            {
                Console.WriteLine("Base de datos creada correctamente.");
            }
        }
    }
}
