using System;

namespace CentroEventos.Aplicacion.Entidades;

public class Reserva
{
private int _Id; // (int, único, debe ser autoincremental gestionado por el repositorio)
private string _PersonaId; // (int - Id de la Persona que hace la reserva)
private int _EventoDeportivoId; // (int - Id de la EventoDeportivo reservado)
private DateTime _FechaAltaReserva; // (DateTime - Fecha y hora en que se realizó la inscripción)
private enum _EstadoAsistencia; // (enum: Pendiente, Presente, Ausente)
}
