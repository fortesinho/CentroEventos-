# CentroEventos-

En la primer depuracion del proyecto se deberian de dar de alta las personas que estan declaradas en el programa, eventos y reservas.
Contienen:

	-5 personas
	-2 eventos
	-2 reservas

Tiene que devolver exactamente esto:

---------------Comienzo del programa ---------------

 Persona VIP dada de alta correctamente:
 Id: 1, Dni: 00000001, Nombre: Profe, Apellido: Sores, Email: profes.net@gmail.com, Telefono: 221-000-0001
 
 Persona 1 dada de alta correctamente:
 Id: 2, Dni: 11111111, Nombre: Juan, Apellido: Perez, Email: juanperez@gmail.com, Telefono: 221-111-1111
 
 Persona 2 dada de alta correctamente:
 Id: 3, Dni: 22222222, Nombre: Emanuel, Apellido: Perez, Email: emanuelperez@gmail.com, Telefono: 221-222-2222
 
 Persona 3 dada de alta correctamente:
 Id: 4, Dni: 33333333, Nombre: Lautaro, Apellido: Martinez, Email: lautaro@hotmail.com, Telefono: 221-333-3333
 
 Persona 4 dada de alta correctamente:
 Id: 5, Dni: 44444444, Nombre: Maria, Apellido: Gomez, Email: maria@gmail.com, Telefono: 221-444-5555
 
 Evento dado de alta correctamente:
 Id: 1, Nombre: Torneo de Fútbol, Descripcion: Cancha 1, FechaHoraInicio: 15/6/2025 18:30:00, DuracionHoras: 2, CupoMaximo: 20, ResponsableId: 1
 
 Evento dado de alta correctamente:
 Id: 2, Nombre: Torneo de Basquet, Descripcion: Cancha Principal, FechaHoraInicio: 6/6/2025 21:45:00, DuracionHoras: 2,5, CupoMaximo: 30, ResponsableId: 2

 
 Reserva realizada con éxito:Id: 1, Id persona: 1, Id evento deportivo: 1, Fecha de alta de la reserva: 22/5/2025 07:50:47, Estado asistencia: Pendiente   
 Reserva realizada con éxito:Id: 2, Id persona: 4, Id evento deportivo: 2, Fecha de alta de la reserva: 22/5/2025 07:50:47, Estado asistencia: Pendiente   

 Error al modificar la persona: No se encontró la entidad Persona con ID 10.

 Error al eliminar persona Id=20: No se encontró la entidad Persona con ID 20.

 No se encontró el evento: No se encontró la entidad Evento con ID 20.

 Error inesperado: No se encontró la entidad Evento con ID 10.

 No se encontró la reserva: No se encontró la entidad Reserva con ID 5.

 No se encontró la reserva: No se encontró la entidad Reserva con ID 10.

=== Listado de Personas ===

 Id: 1, Dni: 00000001, Nombre: Profe, Apellido: Sores, Email: profes.net@gmail.com, Telefono: 221-000-0001
 
 Id: 2, Dni: 11111111, Nombre: Juan, Apellido: Perez, Email: juanperez@gmail.com, Telefono: 221-111-1111
 
 Id: 3, Dni: 22222222, Nombre: Emanuel, Apellido: Perez, Email: emanuelperez@gmail.com, Telefono: 221-222-2222
 
 Id: 4, Dni: 33333333, Nombre: Lautaro, Apellido: Martinez, Email: lautaro@hotmail.com, Telefono: 221-333-3333

 Id: 5, Dni: 44444444, Nombre: Maria, Apellido: Gomez, Email: maria@gmail.com, Telefono: 221-444-5555

 

=== Listado de Eventos Deportivos ===

Id: 1, Nombre: Torneo de Fútbol, Descripcion: Cancha 1, FechaHoraInicio: 15/6/2025 18:30:00, DuracionHoras: 2, CupoMaximo: 20, ResponsableId: 1

Id: 2, Nombre: Torneo de Basquet, Descripcion: Cancha Principal, FechaHoraInicio: 6/6/2025 21:45:00, DuracionHoras: 2,5, CupoMaximo: 30, ResponsableId: 2

=== Listado de Reservas ===

Id: 1, Id persona: 1, Id evento deportivo: 1, Fecha de alta de la reserva: 22/5/2025 07:50:47, Estado asistencia: Pendiente

Id: 2, Id persona: 4, Id evento deportivo: 2, Fecha de alta de la reserva: 22/5/2025 07:50:47, Estado asistencia: Pendiente


----------Fin del programa----------

Luego de haber depurado y haber dado de alta las entidades que utilizaremos podemos probar lo siguiente en la proxima depuracion:

*PersonaModificacionUseCase
	-No se va a poder modificar la persona porque esta puesto un id que no existe(para que esto funcione cambiar el id por uno existente en la proxima vez que se depure el programa.. por ejemplo usar el id 1, 2, 3...5)
	Ahi se podra apreciar el caso de uso de PersonaModificacionUseCase
	
*PersonaBajaUseCase
	-No se va a poder eliminar la persona porque esta puesto un id que no existe(para que esto suceda antes de depurar por 2da vez el programa cambiar el id por uno que exista para ver su funcion)

*EventoDeportivoModificacionUseCase
	-No se va a poder modificar el evento porque esta puesto un id que no existe(para que esto suceda antes de depurar por 2da vez el programa cambiar el id por uno que exista para ver su funcion)

*EventoDeportivoBajaUseCase
	-No se va a poder eliminar el evento porque esta puesto un id que no existe(para que esto funcione cambiar el id por uno existente en la proxima vez que se depure el programa)

*ReservaBajaUseCase 
	-No se va a poder eliminar la reserva porque esta puesto un id que no existe(para que esto funcione cambiar el id por uno existente en la proxima vez que se depure el programa)

*ReservaModificacionUseCase
	-No se va a poder modificar la reserva porque esta puesto un id que no existe(para que esto suceda antes de depurar por 2da vez el programa cambiar el id por uno que exista para ver su funcion)

Al aplicar los casos de usos veremos como se modifican los datos que estamos usando.


// problemas
	cuando agregamos eventos al escribir los archivos y poner el StreamWriter (_archivoEventos,true) nos guarda los datos y agrega el evento correctamente, el problema es que cuando depuramos devuelta, sigue agregando esos mismos eventos, y si ponemos el StreamWriter en false solo guarda el ultimo evento

 public List<Exception> ValidateAlta(Persona persona)
    {
        var errores = new List<Exception>();

        // 1) Campos obligatorios
        if (string.IsNullOrWhiteSpace(persona.Nombre))
            errores.Add(new ValidacionException("El nombre no puede estar vacío."));
        if (string.IsNullOrWhiteSpace(persona.Apellido))
            errores.Add(new ValidacionException("El apellido no puede estar vacío."));
        if (string.IsNullOrWhiteSpace(persona.Dni))
            errores.Add(new ValidacionException("El DNI no puede estar vacío."));
        if (string.IsNullOrWhiteSpace(persona.Email))
            errores.Add(new ValidacionException("El email no puede estar vacío."));

        // 2) Reglas de duplicado (solo Alta, Id == 0)
        if (_repoPersona.ExisteConDni(persona.Dni))
            errores.Add(new DuplicadoException($"Ya existe una persona con el DNI {persona.Dni}."));
        if (_repoPersona.ExisteConEmail(persona.Email))
            errores.Add(new DuplicadoException($"Ya existe una persona con el email {persona.Email}."));

        return errores;
    }
}

 public void Ejecutar(Persona persona, int usuarioId)
    {
        // 1) Autorización
        if (!_auth.PoseeElPermiso(usuarioId, Permiso.UsuarioAlta))
            throw new FalloAutorizacionException("No tienes permiso para dar de alta personas.");

        // 2) Validación
        var errores = _validator.ValidateAlta(persona);
        if (errores.Any())
            throw new AggregateException("Errores al validar Alta de Persona", errores);

        // 3) Persistencia
        _repo.Agregar(persona);
    }
}

try
{
    var persona = new Persona { Nombre = "", Apellido = "", Dni = "123", Email = null };
    var useCase = new AltaPersonaUseCase(repo, new PersonaValidator(repo), authService);

    useCase.Ejecutar(persona, usuarioId);
}
catch (AggregateException aex)
{
    Console.WriteLine(aex.Message);
    // → “Errores al validar Alta de Persona”
    foreach (var inner in aex.InnerExceptions)
    {
        Console.WriteLine($"  • {inner.Message}");
    }
    // Ejemplo de salida:
    //   • El nombre no puede estar vacío.
    //   • El apellido no puede estar vacío.
    //   • El email no puede estar vacío.
}

using CentroEventos.UI.Components;
using CentroEventos.Aplicacion.Servicios;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.CasosDeUso;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Repositorios;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// configuracion EF Core con SQLite
builder.Services.AddDbContext<CentroEventosContext>(options =>options.UseSqlite("Data Source=centroeventos.db"));
// repositorios
builder.Services.AddScoped<IRepositorioPersona, RepositorioPersona>();
builder.Services.AddScoped<IRepositorioReserva, RepositorioReserva>();
builder.Services.AddScoped<IRepositorioEventoDeportivo, RepositorioEventoDeportivo>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
// casos de uso Persona
builder.Services.AddScoped<PersonaAltaUseCase>();
builder.Services.AddScoped<PersonaBajaUseCase>();
builder.Services.AddScoped<PersonaModificacionUseCase>();
builder.Services.AddScoped<PersonaListadoUseCase>();
// casos de uso Evento Deportivo
builder.Services.AddScoped<EventoDeportivoAltaUseCase>();
builder.Services.AddScoped<EventoDeportivoBajaUseCase>();
builder.Services.AddScoped<EventoDeportivoModificacionUseCase>();
builder.Services.AddScoped<EventoDeportivoListadoUseCase>();
builder.Services.AddScoped<ListarAsistenciaAEventoUseCase>();
builder.Services.AddScoped<ListarEventoConCupoDisponibleUseCase>();
// casos de uso Reserva
builder.Services.AddScoped<ReservaAltaUseCase>();
builder.Services.AddScoped<ReservaBajaUseCase>();
builder.Services.AddScoped<ReservaModificacionUseCase>();
builder.Services.AddScoped<ReservaListadoUseCase>();

builder.Services.AddScoped<UsuarioSesionActual>(); // Guarda el usuario actual
builder.Services.AddScoped<IServicioAutorizacion, ServicioAutorizacion>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); // Necesario para sesiones
builder.Services.AddSession(); // Activa el soporte de sesiones en Blazor Server

builder.Services.AddRazorComponents().AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();
app.UseSession(); // Habilita el uso de sesión en los servicios

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();