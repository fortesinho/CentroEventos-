using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
namespace CentroEventos.Aplicacion.CasosDeUso.UsuarioCasosDeUso;

public class UsuarioListadoUseCase
{
private readonly IRepositorioUsuario _repo;

 public UsuarioListadoUseCase(IRepositorioUsuario repo)
 {
    _repo = repo;
 }
public List<Usuario> Ejecutar()
    {
        //Devuelve la lista de usuarios
        return _repo.Listar();
    }
}