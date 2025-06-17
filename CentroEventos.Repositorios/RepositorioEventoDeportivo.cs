using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace CentroEventos.Repositorios;

public class RepositorioEventoDeportivo : IRepositorioEventoDeportivo
{
   private readonly CentroEventosContext _db;
    private readonly IRepositorioReserva _repoReserva;

    
    public RepositorioEventoDeportivo(CentroEventosContext db, IRepositorioReserva repoReserva)
    {
        _db = db;
        _repoReserva = repoReserva;
    }
    public void Agregar(EventoDeportivo evento)
    {
        _db.EventosDeportivos.Add(evento);  
        _db.SaveChanges();  
    }
    public void Eliminar(int id){
         var evento = _db.EventosDeportivos.Find(id);  
        if (evento is not null)
        {
            _db.EventosDeportivos.Remove(evento);    
            _db.SaveChanges();                        
        }
    }

    public bool ExisteResponsable(int responsableId){
        return _db.EventosDeportivos.Any(e => e.ResponsableId == responsableId);
    }

    public List<EventoDeportivo> Listar(){
       return _db.EventosDeportivos.ToList(); 
    }

    public void Modificar(EventoDeportivo evento){
        _db.EventosDeportivos.Update(evento);  
        _db.SaveChanges();    
    }
    public EventoDeportivo? ObtenerPorId(int id){
       return _db.EventosDeportivos.Find(id);
    }
    public List<EventoDeportivo> ListarEventosDisponibles(){
       var eventosFuturos = _db.EventosDeportivos
                                .Where(e => e.FechaHoraInicio > DateTime.Now) 
                                .ToList();

        List<EventoDeportivo> eventosConCupo = new();

        foreach (var evento in eventosFuturos)
        {
            int cantidadReservas = _repoReserva.ObtenerPorEvento(evento.Id).Count;
            if (cantidadReservas < evento.CupoMaximo)
            {
                eventosConCupo.Add(evento);  
            }
        }

        return eventosConCupo;
    }
}
    
    

   
    
    


