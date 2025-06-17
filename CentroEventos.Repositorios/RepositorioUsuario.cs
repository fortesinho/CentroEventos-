using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace CentroEventos.Repositorios;

public class RepositorioUsuario : IRepositorioUsuario
{
    public void Agregar(Usuario usuario)
    {
        throw new NotImplementedException();
    }

    public Usuario? BuscarPorEmail(string email)
    {
        throw new NotImplementedException();
    }

    public Usuario? BuscarPorId(int id)
    {
        throw new NotImplementedException();
    }

    public int CantidadUsuarios()
    {
        throw new NotImplementedException();
    }

    public void Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public List<Usuario> Listar()
    {
        throw new NotImplementedException();
    }

    public void Modificar(Usuario usuario)
    { 
       throw new NotImplementedException();
    }
}
