using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace CentroEventos.Repositorios;

public class RepositorioUsuario : IRepositorioUsuario
{
    private readonly CentroEventosContext _db;

    
    public RepositorioUsuario(CentroEventosContext db)
    {
        _db = db;
    }
    public void Agregar(Usuario usuario)
    {
       _db.Usuarios.Add(usuario);   
       _db.SaveChanges();
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
      return _db.Usuarios.Count();
    }

    public void Eliminar(int id)
    {
      var usuario = _db.Usuarios.Find(id);
        if (usuario != null)
        {
            _db.Usuarios.Remove(usuario);
            _db.SaveChanges();
        }
    }

    public List<Usuario> Listar()
    {
       return _db.Usuarios.ToList();
    }

    public void Modificar(Usuario usuario)
    { 
       _db.Usuarios.Update(usuario); 
        _db.SaveChanges();
    }
}
