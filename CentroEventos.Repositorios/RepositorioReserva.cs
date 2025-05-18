
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Repositorios;

public class RepositorioReserva : IRepositorioReserva
{
    public void Agregar(Reserva reserva)
    { }
    public void Eliminar(int id)
    {
   
    }

    public List<Reserva> Listar()
    {
        return null;
    }

    public void Modificar(Reserva reserva)
    {
     
    }

    public List<Reserva> ObtenerPorEvento(int eventoDeportivoId)
    {
        return null;
    }

    public List<Reserva> ObtenerPorEventoYPersona(int eventoDeportivoId, int personaId)
    {
        return null;
    }

    public Reserva? ObtenerPorId(int id)
    {
        return null;
    }
}

