using CentroEventos.Aplicacion.Entidades;
namespace CentroEventos.Aplicacion.Interfaces;


public interface IRepositorioReserva
{

    void Agregar(Reserva reserva);// Agrega una nueva reserva
    void Eliminar(int id);// Elimina una reserva por ID
    void Modificar(Reserva reserva);// Cambia los datos de una reserva existente
    List<Reserva> Listar();// Devuelve todas las reservas
    List<Reserva> ObtenerPorEventoYPersona(int eventoDeportivoId, int personaId);
    List<Reserva> ObtenerPorEvento(int eventoDeportivoId);
    List<Reserva> ObtenerPorPersona(int id);
}
