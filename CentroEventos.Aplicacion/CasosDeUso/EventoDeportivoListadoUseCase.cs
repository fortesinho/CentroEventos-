using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class EventoDeportivoListadoUseCase(IRepositorioEventoDeportivo repoEvento )
{
     public List<EventoDeportivo>? Ejecutar(){
        return repoEvento.Listar();
    }
}
        