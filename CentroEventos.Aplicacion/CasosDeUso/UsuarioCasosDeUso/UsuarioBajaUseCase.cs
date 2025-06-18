using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;
namespace CentroEventos.Aplicacion.CasosDeUso;

public class UsuarioBajaUseCase
{
    private readonly IRepositorioUsuario _repo;
    private readonly IServicioAutorizacion _autorizacion;

    public UsuarioBajaUseCase(IRepositorioUsuario repo, IServicioAutorizacion autorizacion)
    {
        _repo = repo;
        _autorizacion = autorizacion;
    }

     public void Ejecutar(int idUsuario){
        if (!_autorizacion.PoseeElPermiso(Permiso.UsuarioBaja)) // verifica permisos
            throw new ValidacionException("No tiene permisos para eliminar usuarios.");

        var usuario = _repo.BuscarPorId(idUsuario); // busca el usuario
        if (usuario is null)
            throw new ValidacionException("El usuario no existe.");

        // Elimina el usuario
        _repo.Eliminar(idUsuario);

     }
}
