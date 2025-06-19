using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso.UsuarioCasosDeUso;

public class UsuarioModificacionUseCase
{
    private readonly IValidadorUsuario _validador;
    private readonly IRepositorioUsuario _repositorio;

    private readonly IServicioAutorizacion _autorizacion;

    public UsuarioModificacionUseCase(IValidadorUsuario validador, IRepositorioUsuario repositorio, IServicioAutorizacion autorizacion)
    {
        _validador = validador;
        _repositorio = repositorio;
        _autorizacion = autorizacion;
    }

    public void Ejecutar(Usuario usuario){
        if (!_autorizacion.PoseeElPermiso(Permiso.UsuarioModificacion))
            throw new ValidacionException("No tiene permisos para modificar usuarios.");

        var usuarioExistente = _repositorio.BuscarPorId(usuario.Id);
        if (usuarioExistente == null)
            throw new ValidacionException("El usuario no existe ");

        if (!_validador.Validar(usuario, out string mensajeError))
            throw new ValidacionException(mensajeError);

        if (_autorizacion.PoseeElPermiso(Permiso.UsuarioModificacion))// Si el usuario actual tiene un permiso(el que sea) para asignar permisos puede asignar permisos a otros usuarios
        {
            usuarioExistente.Permisos = usuario.Permisos;
        }

        _repositorio.Modificar(usuarioExistente);
    }
    public void Ejecutar2(Usuario usuario){
        var usuarioExistente = _repositorio.BuscarPorId(usuario.Id);
        if (usuarioExistente == null)
            throw new ValidacionException("El usuario no existe ");

        if (!_validador.Validar(usuario, out string mensajeError))
            throw new ValidacionException(mensajeError);

        if (_autorizacion.PoseeElPermiso(Permiso.UsuarioModificacion))// Si el usuario actual tiene un permiso(el que sea) para asignar permisos puede asignar permisos a otros usuarios
        {
            usuarioExistente.Permisos = usuario.Permisos;
        }

        _repositorio.Modificar(usuarioExistente);
    }
}
