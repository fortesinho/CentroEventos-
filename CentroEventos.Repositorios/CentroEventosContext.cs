using CentroEventos.Aplicacion.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CentroEventos.Repositorios
{
    public class CentroEventosContext : DbContext //  CentroEventosContext hereda DbContext que trae el paquete Microsoft.EntityFrameworkCore;
    {
        public CentroEventosContext(DbContextOptions<CentroEventosContext> options)
        : base(options){}
        public DbSet<Persona> Personas { get; set; } = null!; //tabla de persona
        public DbSet<EventoDeportivo> EventosDeportivos { get; set; } = null!; //tabla de evento
        public DbSet<Reserva> Reservas { get; set; } = null!; //tabla de reserva
        public DbSet<Usuario> Usuarios { get; set; } = null!; //tabla de usuario
        
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)  
        {
            optionsBuilder.UseSqlite("Data Source=centroeventos.sqlite");
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aquí podrías agregar configuraciones adicionales, por ejemplo relaciones Usuario-Permisos cuando las agregues
        }
    }

    public static class CentroEventosDbInicializador
    {
        public static void Inicializar(IServiceProvider servicios)
    {
        using var context = servicios.GetRequiredService<CentroEventosContext>();
        if (context.Database.EnsureCreated()) // si la base de datos no existe la crea
            {
                Console.WriteLine("Base de datos creada correctamente.");

                var connection = context.Database.GetDbConnection();
                connection.Open();

                using var command = connection.CreateCommand();
                command.CommandText = "PRAGMA journal_mode=DELETE;";
                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        
    }
    
}