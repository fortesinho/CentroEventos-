using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IValidadorPersona
{
    bool ValidarAlta(Persona persona, out string mensajeError);

    public bool ValidarModificacion(Persona persona, out string mensajeError);
}