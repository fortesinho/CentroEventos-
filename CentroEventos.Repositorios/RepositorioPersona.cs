using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Repositorios;

public class RepositorioPersona : IRepositorioPersona
{
    public void Agregar(Persona persona)
    {
    int nuevoId = ObtenerTodas().Any() ? ObtenerTodas().Max(p => p.Id) + 1 : 1; // para poder generar ids unicos
    persona.Id = nuevoId;
       
    }

    public void Eliminar(int id)
    {
        
    }

    public bool ExisteConDni(string dni)
    {
        return true;
    }

    public bool ExisteConEmail(string email)
    {
        return true;
    }

    public Persona? ObtenerPorId(int id)
    {
        return null;
    }

    public List<Persona> ObtenerTodas()
    {
        return null;
    }
}
