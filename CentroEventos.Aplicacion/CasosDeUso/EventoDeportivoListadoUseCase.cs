using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class EventoDeportivoListadoUseCase(IRepositorioEventoDeportivo repoEvento, IServicioAutorizacion autorizacion){
    public List<EventoDeportivo> Ejecutar(int idUsuario){
        if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.EventoListado))
            throw new FalloAutorizacionException("El usuario no tiene permiso para listar eventos deportivos.");

        return repoEvento.Listar();
    }
}