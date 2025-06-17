using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace CentroEventos.Repositorios;

public class RepositorioPersona : IRepositorioPersona
{
    private readonly CentroEventosContext _db;

    public RepositorioPersona(CentroEventosContext db)
    {
        _db = db;
    }
    public void Agregar(Persona persona)
    {
        _db.Personas.Add(persona); 
        _db.SaveChanges();

    }
    public void Eliminar(int id)
    {
        var persona = _db.Personas.Find(id);  
        if (persona is not null)
        {
            _db.Personas.Remove(persona);     
            _db.SaveChanges();                
        }
    }

    public void Modificar(Persona persona){
        _db.Personas.Update(persona);  
        _db.SaveChanges();
    }
    public bool ExisteConDni(string? dni){
        if (dni == null){
              return false;
        }
          
        return _db.Personas.Any(p => p.dni == dni);
    }
    public bool ExisteConEmail(string? email){
        if (email == null){
            return false;
        }
        return _db.Personas.Any(p => p.email == email);
    }

    public Persona? ObtenerPorId(int id){
        return _db.Personas.Find(id);
    }

    public List<Persona> ObtenerTodas()
    {
       return _db.Personas.ToList();
    }

}   

