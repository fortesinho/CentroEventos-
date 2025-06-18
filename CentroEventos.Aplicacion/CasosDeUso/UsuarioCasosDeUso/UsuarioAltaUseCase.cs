using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Servicios;

namespace CentroEventos.Aplicacion.CasosDeUso.UsuarioCasosDeUso;


public class UsuarioAltaUseCase
{
    private readonly IValidadorUsuario _validador;
    private readonly IRepositorioUsuario _repositorio;

    public UsuarioAltaUseCase(IValidadorUsuario validador, IRepositorioUsuario repositorio)
    {
        _validador = validador;
        _repositorio = repositorio;
    }

    public void Ejecutar(Usuario usuario, string contraseñaPlano)
    {
        if (!_validador.Validar(usuario, out string mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }

        if (_repositorio.BuscarPorEmail(usuario.Email) is not null)
        {
            throw new Exception("Ya existe un usuario con ese email.");
        }

        usuario.ContraseñaHash = CalculadorHash.CalcularSha256(contraseñaPlano);
        usuario.Permisos ??= new List<Permiso>(); // Asegura que la lista esté inicializada

        if (_repositorio.CantidadUsuarios() == 0)
        {
            usuario.Permisos = Enum.GetValues<Permiso>().ToList();// si no hay usuarios le da todos los permisos al primero que seria el administrador
        }
        else
        {
            usuario.Permisos = new List<Permiso>(); // sino crea la lista de permisos vacia (solo lectura)
        }

        _repositorio.Agregar(usuario);
    }
}
