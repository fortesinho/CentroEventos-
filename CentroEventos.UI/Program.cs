using CentroEventos.UI.Components;
using CentroEventos.Repositorios;
using CentroEventos.Aplicacion.CasosDeUso;
using CentroEventos.Aplicacion.Interfaces;
using Microsoft.EntityFrameworkCore;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Servicios;
using CentroEventos.Aplicacion.CasosDeUso.UsuarioCasosDeUso;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CentroEventosContext>(options => options.UseSqlite("Data Source=centroeventos.db"));
//REPOSITORIOS
builder.Services.AddScoped<IRepositorioPersona, RepositorioPersona>();
builder.Services.AddScoped<IRepositorioReserva, RepositorioReserva>();
builder.Services.AddScoped<IRepositorioEventoDeportivo, RepositorioEventoDeportivo>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
// CASOS DE USO PERSONA
builder.Services.AddScoped<PersonaAltaUseCase>();
builder.Services.AddScoped<PersonaBajaUseCase>();
builder.Services.AddScoped<PersonaModificacionUseCase>();
builder.Services.AddScoped<PersonaListadoUseCase>();
// CASOS DE USO EVENTO
builder.Services.AddScoped<EventoDeportivoAltaUseCase>();
builder.Services.AddScoped<EventoDeportivoBajaUseCase>();
builder.Services.AddScoped<EventoDeportivoModificacionUseCase>();
builder.Services.AddScoped<EventoDeportivoListadoUseCase>();
builder.Services.AddScoped<ListarEventoConCupoDisponibleUseCase>();
builder.Services.AddScoped<ListarAsistenciaAEventoUseCase>();
// CASOS DE USO RESERVA
builder.Services.AddScoped<ReservaAltaUseCase>();
builder.Services.AddScoped<ReservaBajaUseCase>();
builder.Services.AddScoped<ReservaModificacionUseCase>();
builder.Services.AddScoped<ReservaListadoUseCase>();
// CASOS DE USO USUARIO
builder.Services.AddScoped<UsuarioAltaUseCase>();
builder.Services.AddScoped<UsuarioBajaUseCase>();
builder.Services.AddScoped<UsuarioModificacionUseCase>();
builder.Services.AddScoped<UsuarioLoginUseCase>();
builder.Services.AddScoped<UsuarioLogOutUseCase>();
builder.Services.AddScoped<UsuarioListadoUseCase>();
// VALIDADORES
builder.Services.AddScoped<IValidadorUsuario, ValidadorUsuario>();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
