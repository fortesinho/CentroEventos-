using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Extra;
namespace CentroEventos.Repositorios;

public class RepositorioEventoDeportivo : IRepositorioEventoDeportivo
{
    public void Agregar(EventoDeportivo evento)
    {
        
    }

    public void Eliminar(int id)
    {
     
    }

    public bool ExisteResponsable(int responsableId)
    {
        return true;
    }

    public List<EventoDeportivo> Listar()
    {
        return null;
    }

    public void Modificar(EventoDeportivo evento)
    {
        
    }

    public EventoDeportivo? ObtenerPorId(int id)
    {
        return null;
    }
}
