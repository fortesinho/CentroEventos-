using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Servicios;

namespace CentroEventos.Aplicacion.CasosDeUso.UsuarioCasosDeUso;

public class UsuarioLoginUseCase
{
    private readonly IRepositorioUsuario _repo;
    private readonly UsuarioSesionActual _usuarioSesion;

    public UsuarioLoginUseCase(IRepositorioUsuario repo, UsuarioSesionActual usuarioSesion)
    {
        _repo = repo;
        _usuarioSesion = usuarioSesion;
    }
    public void Ejecutar(string email, string contraseña)
    {
      var usuario = _repo.BuscarPorEmail(email); // buscar el usuario por email
        if (usuario is null)
            throw new ValidacionException("Usuario o contraseña incorrectos.");

       var hashIngresado = CalculadorHash.CalcularSha256(contraseña); // calcular el hash de la contraseña ingresada

       if (usuario.ContraseñaHash != hashIngresado) // comparar con el hash guardado
            throw new ValidacionException("Usuario o contraseña incorrectos.");

      _usuarioSesion.IniciarSesion(usuario); // guardar usuario en la sesion actual

    }
}
