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
        List<EventoDeportivo> eventos = new List<EventoDeportivo>(); //creo la lista vacia
        if (!File.Exists(_archivoEventos)){
            return eventos;
        }
        using StreamReader sr = new StreamReader(_archivoEventos);
        while (!sr.EndOfStream){
            string? linea = sr.ReadLine();//guardo en un string la linea del archivo
            EventoDeportivo? evento = ConvertirLinea(linea);//
            if (evento != null){
                eventos.Add(evento);
            }
        }
        return eventos;
    }

    public void Modificar(EventoDeportivo evento){
        List<EventoDeportivo> eventos = Listar();
        int aux = -1;
        for (int i = 0; i < eventos.Count; i++){
            if (eventos[i].Id == evento.Id){
                aux = i;
                break;
            }
        }
        if (aux >= 0){
            eventos[aux] = evento;//guardo el evento que recibi
            ActualizarArchivo(eventos); // actualizo la lista
        }
    }
    public EventoDeportivo? ObtenerPorId(int id){
        if (!File.Exists(_archivoEventos))
            return null;
        using StreamReader sr = new StreamReader(_archivoEventos);
        while (!sr.EndOfStream){
            string? linea = sr.ReadLine();
            EventoDeportivo? evento = ConvertirLinea(linea); // guarda en evento null o si la linea que paso como parametro tiene los campos completos guardo el evento
            if (evento?.Id == id) // si el evento coincide con el id
                return evento; // lo devuelvo
        }
        return null;
    }
    public List<EventoDeportivo> ListarEventosDisponibles(){
        List<EventoDeportivo> eventosFuturos = ObtenerEventosFuturos(); 
        List<EventoDeportivo> eventosConCupo = new List<EventoDeportivo>();
        foreach (EventoDeportivo evento in eventosFuturos) {//recorre todos los eventosFuturos 
            int cantidadReservas = _repoReserva.ObtenerPorEvento(evento.Id).Count();
            if (cantidadReservas < evento.CupoMaximo) {// si hay lugar en el evento lo agrego al evento con cupos
                eventosConCupo.Add(evento);
            }
        }

    return eventosConCupo;
}
    
    //-------- METODOS PRIVADOS ---------- 

    private static string DarFormato(EventoDeportivo evento)
    {
        return $"{evento.Id}|{evento.Nombre}|{evento.Descripcion}|{evento.FechaHoraInicio:O}|{evento.DuracionHoras}|{evento.CupoMaximo}|{evento.ResponsableId}";
    }
    private void ActualizarArchivo(List<EventoDeportivo> eventos){
        using StreamWriter sw = new StreamWriter(_archivoEventos);
        foreach (EventoDeportivo evento in eventos){
            sw.WriteLine(DarFormato(evento));
        }
    }
    private static EventoDeportivo? ConvertirLinea(string? linea){
        if (string.IsNullOrWhiteSpace(linea))
            return null;
        string[] partes = linea.Split('|');
        if (partes.Length != 7)
            return null;
        try{
            return new EventoDeportivo{
                Id = int.Parse(partes[0]),
                Nombre = partes[1],
                Descripcion = partes[2],
                FechaHoraInicio = DateTime.Parse(partes[3]),
                DuracionHoras = double.Parse(partes[4]),
                CupoMaximo = int.Parse(partes[5]),
                ResponsableId = int.Parse(partes[6])
        };
        }
        catch{
            return null;
        }
    }
    private List<EventoDeportivo> ObtenerEventosFuturos(){
        List<EventoDeportivo> eventosFuturos = new List<EventoDeportivo>();
        List<EventoDeportivo> todosLosEventos = Listar();
        foreach (EventoDeportivo evento in todosLosEventos)
        {
            if (evento.FechaHoraInicio > DateTime.Now)
            {
                eventosFuturos.Add(evento);
            }
        }
        return eventosFuturos;
    }
    

}
