using System;
using CentroEventos.Aplicacion.Servicios;
namespace CentroEventos.Aplicacion.CasosDeUso.UsuarioCasosDeUso;

public class UsuarioLogOutUseCase
{
  private readonly UsuarioSesionActual _usuarioSesion;
  public UsuarioLogOutUseCase(UsuarioSesionActual usuarioSesion)
    {
        _usuarioSesion = usuarioSesion;
    }

     public void Ejecutar()
    {
        _usuarioSesion.CerrarSesion();
    }
}
