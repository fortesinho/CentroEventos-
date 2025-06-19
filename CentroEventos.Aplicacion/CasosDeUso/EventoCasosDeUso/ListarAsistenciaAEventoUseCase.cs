using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarAsistenciaAEventoUseCase(IRepositorioEventoDeportivo repoEvento)
{
    public List<Persona> Ejecutar(int idEvento)
        {
            EventoDeportivo? evento = repoEvento.ObtenerPorId(idEvento);
            if (evento == null)
                throw new EntidadNotFoundException("El evento no se encontró");

            if (evento.FechaHoraInicio > DateTime.Now)
                throw new OperacionInvalidaException("El evento aún no se realizo");

            return repoEvento.ObtenerPersonasAsistieron(idEvento);
        }
    }
