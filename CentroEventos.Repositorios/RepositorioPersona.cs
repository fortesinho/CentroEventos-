using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Repositorios;

public class RepositorioPersona : IRepositorioPersona
{
    public void Agregar(Persona persona)
    {
        
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
