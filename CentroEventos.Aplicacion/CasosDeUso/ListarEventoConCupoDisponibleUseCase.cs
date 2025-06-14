using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarEventoConCupoDisponibleUseCase(IRepositorioEventoDeportivo repoEvento, IRepositorioReserva repoReserva)
{
    public List<EventoDeportivo> Ejecutar()
    {

        List<EventoDeportivo> eventosFuturos = new List<EventoDeportivo>();
        foreach (EventoDeportivo? evento in repoEvento.Listar())
        { //recorre toda la lista de eventos  
            if (evento.FechaHoraInicio > DateTime.Now)
            {
                eventosFuturos.Add(evento);//agrega las que son despues de la fecha actual
            }
        }
        List<EventoDeportivo> eventosConCupo = new List<EventoDeportivo>();

        foreach (EventoDeportivo? evento in eventosFuturos)
        {
            int cantidadReservas = repoReserva.ObtenerPorEvento(evento.Id).Count(); //guardo la cantidad total de reservas para ese evento
            if (cantidadReservas < evento.CupoMaximo)
            {
                eventosConCupo.Add(evento);
            }
        }
        return eventosConCupo;
    }
        //agregar al repositorio y aca solo hacer la invocacion 
    }

