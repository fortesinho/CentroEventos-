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
PersonaAltaUseCase personaAltaUC = new PersonaAltaUseCase(repoPersona, autorizacion, validadorPersona);

EventoDeportivoAltaUseCase eventoAltaUC = new EventoDeportivoAltaUseCase(repoEvento, autorizacion, validadorEvento);

ReservaAltaUseCase reservaAltaUC = new ReservaAltaUseCase(repoReserva, autorizacion, validadorReserva);

PersonaModificacionUseCase personaModificacionUC = new PersonaModificacionUseCase(repoPersona, autorizacion, validadorPersona);

PersonaBajaUseCase personaBajaUC = new PersonaBajaUseCase(repoPersona, repoEvento, repoReserva, autorizacion);


// Crear una persona
Persona persona1 = new Persona { nombre = "Juan", apellido = "Perez", dni = "11111111", email = "juanperez@gmail.com", telefono = "221-111-1111" };
Persona persona2 = new Persona { nombre = "Emanuel", apellido = "Perez", dni = "22222222", email = "emanuelperez@gmail.com", telefono = "221-222-2222" };
Persona persona3 = new Persona { nombre = "Lautaro", apellido = "Martinez", dni = "33333333", email = "lautaro@hotmail.com", telefono = "221-333-3333" };
Persona persona4 = new Persona { nombre = "Maria", apellido = "Gomez", dni = "44444444", email = "maria@gmail.com", telefono = "221-444-5555" };
Persona usuarioVIP = new Persona {nombre = "Profe", apellido = "Sores", dni = "00000001", email = "profes.net@gmail.com", telefono = "221-000-0001" };

//crear un evento deportivo 
EventoDeportivo evento1 = new EventoDeportivo { Nombre = "Torneo de Fútbol", Descripcion = "Cancha 1",FechaHoraInicio = new DateTime(2025, 6, 15,18,30,0),DuracionHoras = 2.0,CupoMaximo = 20,ResponsableId= 1};
EventoDeportivo evento2 = new EventoDeportivo { Nombre = "Torneo de Basquet", Descripcion = "Cancha Principal",FechaHoraInicio = new DateTime(2025, 6, 6,21,45,0),DuracionHoras = 2.5,CupoMaximo = 30,ResponsableId= 2};

//crear una reserva
Reserva reserva1 = new Reserva { PersonaId = 1, EventoDeportivoId = 1, FechaAltaReserva = DateTime.Now, EstadoAsistencia = Reserva.EstadoAsis.Presente, };

//crear persona modificada, probando con id X que sabemos ya sabemos que esta en la lista
Persona personaModificada = new Persona { id = 10, nombre = "Lionel", apellido = "Messi", dni = "10101010", email = "lionelmessi10@gmail.com", telefono = "342-111-7539" };

// eliminar una persona por id 
int eliminarId = 10; //elegimos un id que queramos eliminar
try
{
    personaAltaUC.Ejecutar(usuarioVIP, idUsuario);
    Console.WriteLine(" Persona VIP dada de alta correctamente:\n" + usuarioVIP);
}
catch (Exception ex)
{
    Console.WriteLine($" Error al dar de alta a la persona : {ex.Message}");
}
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
    personaAltaUC.Ejecutar(persona3, idUsuario);
    Console.WriteLine(" Persona 3 dada de alta correctamente:\n" + persona2);
}
catch (Exception ex)
{
    Console.WriteLine($" Error al dar de alta persona 3: {ex.Message}");
}
try
{
    personaAltaUC.Ejecutar(persona4, idUsuario);
    Console.WriteLine(" Persona 4 dada de alta correctamente:\n" + persona2);
}
catch (Exception ex)
{
    Console.WriteLine($" Error al dar de alta persona 4: {ex.Message}");
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
    eventoAltaUC.Ejecutar(evento2, idUsuario);
    Console.WriteLine(" Evento dado de alta correctamente:\n" + evento2);
}
catch (Exception ex)
{
    Console.WriteLine($" Error al dar de alta el evento: {ex.Message}");
}
try
{
    reservaAltaUC.Ejecutar(reserva1, idUsuario);
    Console.WriteLine(" Reserva realizada con éxito:" + reserva1);
}
catch (Exception ex)
{
    Console.WriteLine($" Error al realizar la reserva: {ex.Message}");
}
try
{
    personaModificacionUC.Ejecutar(personaModificada, idUsuario);
    Console.WriteLine("\n Persona modificada correctamente:");
    Console.WriteLine(personaModificada);
}
catch (Exception ex)
{
    Console.WriteLine($"\n Error al modificar la persona: {ex.Message}");
}
try
{
    personaBajaUC.Ejecutar(eliminarId, idUsuario);
    Console.WriteLine($"\n Persona con Id={eliminarId} eliminada correctamente.");
}
catch (Exception ex)
{
    Console.WriteLine($"\n Error al eliminar persona Id={eliminarId}: {ex.Message}");
}

// === Mostrar Listados ===
Console.WriteLine("\n=== Listado de Personas ===");
foreach (Persona p in repoPersona.ObtenerTodas())
    Console.WriteLine(p);

Console.WriteLine("\n=== Listado de Eventos Deportivos ===");
foreach (EventoDeportivo e in repoEvento.Listar())
    Console.WriteLine(e);

Console.WriteLine("\n=== Listado de Reservas ===");
foreach (Reserva r in repoReserva.Listar())
    Console.WriteLine(r);
