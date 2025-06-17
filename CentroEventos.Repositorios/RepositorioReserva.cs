
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace CentroEventos.Repositorios;

public class RepositorioReserva : IRepositorioReserva
{
   private readonly CentroEventosContext _db;

    public RepositorioReserva(CentroEventosContext db)
    {
        _db = db;
    }
    public void Agregar(Reserva reserva){
        _db.Reservas.Add(reserva);
        _db.SaveChanges();
    }

    public void Eliminar(int id){
        var reserva = _db.Reservas.Find(id);
        if (reserva is not null)
        {
            _db.Reservas.Remove(reserva);
            _db.SaveChanges();
        }
    }

    public void Modificar(Reserva reserva){
       _db.Reservas.Update(reserva);   
       _db.SaveChanges(); 
    }
    public List<Reserva> Listar(){
        return _db.Reservas.ToList();
    }

    public Reserva? ObtenerPorId(int id) {
         return _db.Reservas.Find(id);
    }
   
    public List<Reserva> ObtenerPorEvento(int eventoDeportivoId){
     return _db.Reservas
                 .Where(r => r.EventoDeportivoId == eventoDeportivoId) 
                 .ToList(); 
    }
    public List<Reserva> ObtenerPorPersona(int id){
        return _db.Reservas
                 .Where(r => r.PersonaId == id)  
                 .ToList(); 
    }
}


