using System;

namespace CentroEventos.Aplicacion.Entidades;

public class Reserva
{
private int _Id; // (int, único, debe ser autoincremental gestionado por el repositorio)
private string? _PersonaId; // (int - Id de la Persona que hace la reserva)
private int _EventoDeportivoId; // (int - Id de la EventoDeportivo reservado)
private DateTime _FechaAltaReserva; // (DateTime - Fecha y hora en que se realizó la inscripción)
private EstadoAsis _EstadoAsistencia; // (enum: Pendiente, Presente, Ausente)

 public int Id { get => _Id; set => _Id = value; }
public string? PersonaId { get => _PersonaId; set => _PersonaId = value; }
public int EventoDeportivoId { get => _EventoDeportivoId; set => _EventoDeportivoId = value; }
public DateTime FechaAltaReserva { get => _FechaAltaReserva; set => _FechaAltaReserva = value; }
private EstadoAsis EstadoAsistencia { get => _EstadoAsistencia; set => _EstadoAsistencia = value; }

    enum EstadoAsis 
{
Pendiente, Presente, Ausente
}
public override string ToString(){
   return $"Id: {this.Id}, Id persona: {this.PersonaId}, Id evento deportivo: {this._EventoDeportivoId}, Fecha de alta de la reserva: {this._FechaAltaReserva}, Estado asistencia: {this._EstadoAsistencia}   ";
}
}
