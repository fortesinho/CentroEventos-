using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarEventoConCupoDisponibleUseCase(IRepositorioEventoDeportivo repoEvento)
{
    
    public List<EventoDeportivo>? Ejecutar(){
        
        return repoEvento.ListarEventosDisponibles();
    }
        
}

