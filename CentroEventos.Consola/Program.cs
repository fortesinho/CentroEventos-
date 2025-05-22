using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.CasosDeUso;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Repositorios;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Servicios;




Console.WriteLine(" prueba ");


// Esto va dentro del método Main()
var repoPersona = new RepositorioPersona();
var repoEvento = new RepositorioEventoDeportivo();
var repoReserva = new RepositorioReserva();
var autorizacion = new ServicioAutorizacion();

// Crear el caso de uso
var useCase = new ReservaAltaUseCase(repoReserva, repoEvento, repoPersona, autorizacion);

// Crear una reserva de prueba
var reserva = new Reserva
{
    PersonaId = 1,
    EventoDeportivoId = 2
    // FechaAltaReserva y EstadoAsistencia se asignan dentro del caso de uso
};

// ID del usuario que intenta hacer la reserva
int idUsuario = 1;

try
{
    useCase.Ejecutar(reserva, idUsuario);
    Console.WriteLine("✅ Reserva registrada con éxito.");
}
catch (exception)
{
    Console.WriteLine($"🚫 Error de autorización: {ex.Message}");

    Console.WriteLine($"🚫 Entidad no encontrada: {ex.Message}");
}
catch (CupoExcedidoException ex)
{
    Console.WriteLine($"🚫 Cupo excedido: {ex.Message}");
}
catch (DuplicadoException ex)
{
    Console.WriteLine($"🚫 Reserva duplicada: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"❌ Error inesperado: {ex.Message}");
}






