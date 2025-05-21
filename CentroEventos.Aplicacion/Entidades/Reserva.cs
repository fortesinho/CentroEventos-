using System;

namespace CentroEventos.Aplicacion.Entidades;

public class Reserva
{
public int Id { get; set; }
public int PersonaId { get; set; }
public int EventoDeportivoId { get; set; }
public DateTime FechaAltaReserva { get; set; }
private EstadoAsis EstadoAsistencia { get; set; }

private enum EstadoAsis 
{
Pendiente, Presente, Ausente
}
public override string ToString(){
   return $"Id: {this.Id}, Id persona: {this.PersonaId}, Id evento deportivo: {this.EventoDeportivoId}, Fecha de alta de la reserva: {this.FechaAltaReserva}, Estado asistencia: {this.EstadoAsistencia}   ";
}
}
