using System;

namespace CentroEventos.Aplicacion.Entidades;

public class EventoDeportivo
{
    public EventoDeportivo(int id, string? nombre, string? descripcion, DateTime fechaHoraInicio, double duracionHoras, int cupoMaximo, int responsableId)
    {
        Id = id;
        Nombre = nombre;
        Descripcion = descripcion;
        FechaHoraInicio = fechaHoraInicio;
        DuracionHoras = duracionHoras;
        CupoMaximo = cupoMaximo;
        ResponsableId = responsableId;
    }

    public EventoDeportivo() {}

    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public DateTime FechaHoraInicio { get; set; }
    public double DuracionHoras { get; set; }
    public int CupoMaximo { get; set; }
    public int ResponsableId { get; set; }

    
    public override string ToString()
    {
        return $"Id: {this.Id}, Nombre: {this.Nombre}, Descripcion: {this.Descripcion}, FechaHoraInicio: {this.FechaHoraInicio}, DuracionHoras: {this.DuracionHoras}, CupoMaximo: {this.CupoMaximo}, ResponsableId: {this.ResponsableId}";
    }
}
