using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.CasosDeUso;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Repositorios;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Servicios;
using CentroEventos.Aplicacion.Validadores;


Console.WriteLine(" *--*-*-*PROBANDO *-*-*- ");


RepositorioPersona repoPersona = new RepositorioPersona();
RepositorioEventoDeportivo repoEvento = new RepositorioEventoDeportivo();
RepositorioReserva repoReserva = new RepositorioReserva();
ServicioAutorizacionProvisorio autorizacion = new ServicioAutorizacionProvisorio();

    
int idUsuario = 1;

// Crear validadores
ValidadorPersona validadorPersona = new ValidadorPersona(repoPersona);
ValidadorEventoDeportivo validadorEvento = new ValidadorEventoDeportivo(repoPersona);
ValidadorReserva validadorReserva = new ValidadorReserva(repoPersona, repoEvento, repoReserva);

// Crear  casos de uso
var personaAltaUC = new PersonaAltaUseCase(repoPersona, autorizacion, validadorPersona);

var eventoAltaUC = new EventoDeportivoAltaUseCase(repoEvento, autorizacion, validadorEvento);

var reservaAltaUC = new ReservaAltaUseCase(repoReserva, autorizacion, validadorReserva);


// Crear una persona
var persona1 = new Persona { nombre = "Juan", apellido = "Pérez", dni = "12345678", email = "juan.perez@example.com", telefono = "1234-5678" };
var persona2 = new Persona { nombre = "Ju21n", apellido = "Pér21ez", dni = "12345652178", email = "juan.pere21z@example.com", telefono = "123214-5678" };

//crear un evento deportivo 
var evento1 = new EventoDeportivo{Nombre = "Torneo de Fútbol",Descripcion = "Cancha 1",FechaHoraInicio = new DateTime(2025, 6, 15),DuracionHoras = 2.0,CupoMaximo = 20,ResponsableId= 1};
// Ejecutar el caso de uso

//crear una reserva
var reserva1 = new Reserva{PersonaId=1,EventoDeportivoId=1,FechaAltaReserva = DateTime.Now,EstadoAsistencia= Reserva.EstadoAsis.Presente,};

try
{
    personaAltaUC.Ejecutar(persona1, idUsuario);
    Console.WriteLine(" Persona 1 dada de alta correctamente:\n" + persona1);
}
catch (Exception ex)
{
    Console.WriteLine($" Error al dar de alta persona 1: {ex.Message}");
}

try
{
    personaAltaUC.Ejecutar(persona2, idUsuario);
    Console.WriteLine(" Persona 2 dada de alta correctamente:\n" + persona2);
}
catch (Exception ex)
{
    Console.WriteLine($" Error al dar de alta persona 2: {ex.Message}");
}
try
{
    eventoAltaUC.Ejecutar(evento1, idUsuario);
    Console.WriteLine(" Evento dado de alta correctamente:\n" + evento1);
}
catch (Exception ex)
{
    Console.WriteLine($" Error al dar de alta el evento: {ex.Message}");
}
try
{
    reservaAltaUC.Ejecutar(reserva1, idUsuario);
    Console.WriteLine(" Reserva realizada con éxito:\n" + reserva1);
}
catch (Exception ex)
{
    Console.WriteLine($" Error al realizar la reserva: {ex.Message}");
}

// === Mostrar Listados ===
Console.WriteLine("\n=== Listado de Personas ===");
foreach (var p in repoPersona.ObtenerTodas())
    Console.WriteLine(p);

Console.WriteLine("\n=== Listado de Eventos Deportivos ===");
foreach (var e in repoEvento.Listar())
    Console.WriteLine(e);

Console.WriteLine("\n=== Listado de Reservas ===");
foreach (var r in repoReserva.Listar())
    Console.WriteLine(r);
