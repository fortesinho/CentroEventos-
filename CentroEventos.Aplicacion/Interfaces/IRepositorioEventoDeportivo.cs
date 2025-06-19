using System;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IRepositorioEventoDeportivo
{
    void Agregar(EventoDeportivo evento);
    void Eliminar(int id);
    void Modificar(EventoDeportivo evento);
    List<EventoDeportivo> Listar();
    EventoDeportivo? ObtenerPorId(int id);
    bool ExisteResponsable(int responsableId);
    List<EventoDeportivo>? ListarEventosDisponibles();
    List<Persona> ObtenerPersonasAsistieron(int idEvento);
}
