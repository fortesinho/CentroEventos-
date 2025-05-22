using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Extra;
namespace CentroEventos.Repositorios;

public class RepositorioEventoDeportivo : IRepositorioEventoDeportivo
{
    private readonly string _archivoEventos = "Eventos.txt";
    private readonly string _archivoUltimoId = "ultimo_id_evento.txt";

    public void Agregar(EventoDeportivo evento){
        evento.Id = GeneradorId.Obtener(_archivoUltimoId);
        using StreamWriter sw = new StreamWriter(_archivoEventos,true);// lo ponemos en false para que sobreescriba, si ponemos true va a agregar siempre el mismo evento
        sw.WriteLine(DarFormato(evento)); // escribe el evento en el archivo
    }
    public void Eliminar(int id){
        List<EventoDeportivo> eventos = Listar(); // carga todos los eventos
        for (int i = 0; i < eventos.Count; i++){
            if (eventos[i].Id == id){
                eventos.RemoveAt(i);
                i--; // en caso de ids seguidos,sino no funcionaria bien
            }
        }
        ActualizarArchivo(eventos); // sobrescribe el archivo sin los elementos eliminados
    }

    public bool ExisteResponsable(int responsableId){
        List<EventoDeportivo> eventos = Listar();
        foreach (EventoDeportivo evento in eventos) { // recorro la lista de eventos hasta encontrar el id del responsable si no lo encuentra devuelve false
            if (evento.ResponsableId == responsableId){
                return true;
            }
        }
        return false;
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
    //-------- METODOS PRIVADOS ---------- 

    private static string DarFormato(EventoDeportivo evento){
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

    

}
