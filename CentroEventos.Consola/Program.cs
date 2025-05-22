using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.CasosDeUso;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Repositorios;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Servicios;
using CentroEventos.Aplicacion.Validadores;


Console.WriteLine(" prueba ");


RepositorioPersona repoPersona = new RepositorioPersona();
RepositorioEventoDeportivo repoEvento = new RepositorioEventoDeportivo();
RepositorioReserva repoReserva = new RepositorioReserva();
ServicioAutorizacionProvisorio   autorizacion = new ServicioAutorizacionProvisorio();

    
int idUsuario = 0;


// Crear servicio de autorización provisorio
ServicioAutorizacionProvisorio autorizador = new ServicioAutorizacionProvisorio();

// Crear validadores
ValidadorPersona validadorPersona = new ValidadorPersona(repoPersona);
ValidadorEventoDeportivo validadorEvento = new ValidadorEventoDeportivo(repoPersona);
ValidadorReserva validadorReserva = new ValidadorReserva(repoPersona, repoEvento, repoReserva);

// === Alta de Persona ===
Persona persona = new Persona(0,"dni111", "Lucía", "Pérez", "lucia@gmail.com", "1234-5678");
PersonaAltaUseCase useCaseAltaPersona = new PersonaAltaUseCase(repoPersona, autorizador, validadorPersona);

try
{
    useCaseAltaPersona.Ejecutar(persona, idUsuario);
    Console.WriteLine("Persona dada de alta exitosamente.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error al dar de alta persona: {ex.Message}");
}

// === Alta de Evento ===
EventoDeportivo evento = new EventoDeportivo(0,"Torneo de Fútbol", "5 vs 5", DateTime.Now.AddDays(3), 2, 10, persona.id);
EventoDeportivoAltaUseCase useCaseAltaEvento = new EventoDeportivoAltaUseCase(repoEvento, autorizador, validadorEvento);
try
{
    useCaseAltaEvento.Ejecutar(evento, idUsuario);
    Console.WriteLine("Evento dado de alta exitosamente.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error al dar de alta evento: {ex.Message}");
}

// === Alta de Reserva ===
Reserva reserva = new Reserva(0,persona.id, evento.Id,DateTime.Today,Reserva.EstadoAsis.Presente);
ReservaAltaUseCase useCaseAltaReserva = new ReservaAltaUseCase(repoReserva, autorizador, validadorReserva);

try
{
    useCaseAltaReserva.Ejecutar(reserva, idUsuario);
    Console.WriteLine("Reserva registrada exitosamente.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error al registrar reserva: {ex.Message}");
}

// === Listar Personas ===
Console.WriteLine("\nListado de personas:");
foreach (var p in repoPersona.ObtenerTodas())
    Console.WriteLine(p);

// === Listar Eventos ===
Console.WriteLine("\nListado de eventos:");
foreach (var e in repoEvento.Listar())
    Console.WriteLine(e);

// === Listar Reservas ===
Console.WriteLine("\nListado de reservas:");
foreach (var r in repoReserva.Listar())
    Console.WriteLine(r);