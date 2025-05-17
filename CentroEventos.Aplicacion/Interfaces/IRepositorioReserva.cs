using CentroEventos.Aplicacion.Entidades;
namespace CentroEventos.Aplicacion.Interfaces;

public interface IRepositorioReserva
{
    //métodos básicos de CRUD:
    void Agregar(Reserva reserva);// Agrega una nueva reserva
    void Eliminar(int id);// Elimina una reserva por ID
    void Modificar(Reserva reserva);// Cambia los datos de una reserva existente
    List<Reserva> Listar();// Devuelve todas las reservas
    Reserva? ObtenerPorId(int id);// Busca una reserva por ID
    
}
