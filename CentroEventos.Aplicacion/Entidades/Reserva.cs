using System;

namespace CentroEventos.Aplicacion.Entidades;

public class Reserva
{
    public Reserva(int id, int personaId, int eventoDeportivoId, DateTime fechaAltaReserva, EstadoAsis estadoAsistencia)
    {
        Id = id;
        PersonaId = personaId;
        EventoDeportivoId = eventoDeportivoId;
        FechaAltaReserva = fechaAltaReserva;
        EstadoAsistencia = estadoAsistencia;
    }
public Reserva(){}
public int Id { get; set; }
public int PersonaId { get; set; }
public int EventoDeportivoId { get; set; }
public DateTime FechaAltaReserva { get; set; }
public EstadoAsis EstadoAsistencia { get; set; }

public enum EstadoAsis{
      Pendiente, Presente, Ausente
}
public override string ToString(){
   return $"Id: {this.Id}, Id persona: {this.PersonaId}, Id evento deportivo: {this.EventoDeportivoId}, Fecha de alta de la reserva: {this.FechaAltaReserva}, Estado asistencia: {this.EstadoAsistencia}   ";
}
}
