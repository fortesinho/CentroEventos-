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
