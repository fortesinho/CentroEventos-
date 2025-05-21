using System;
using CentroEventos.Aplicacion.Entidades;
namespace CentroEventos.Aplicacion.Interfaces;

public interface IRepositorioPersona
{
    /// Agrega una nueva persona al repositorio.
    void Agregar(Persona persona);
    /// Elimina una persona por su ID.
    void Eliminar(int id);
    /// Devuelve una persona por su ID, o null si no se encuentra.
    void Modificar(Persona persona);
    Persona? ObtenerPorId(int id);
    /// Devuelve todas las personas guardadas.
    List<Persona> ObtenerTodas();
    bool ExisteConDni(string dni);
    bool ExisteConEmail(string email);
}
