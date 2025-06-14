using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
namespace CentroEventos.Aplicacion.Validadores;



public class  ValidadorPersona(IRepositorioPersona repoPersona)
{
    public bool ValidarAlta(Persona persona, out string mensajeError) // con el out devuelve el mensaje de la excepcion 
    {
        mensajeError = "";

        if (string.IsNullOrWhiteSpace(persona.nombre))
            mensajeError += "Nombre no puede estar vacío.\n";

        if (string.IsNullOrWhiteSpace(persona.apellido))
            mensajeError += "Apellido no puede estar vacío.\n";

        if (string.IsNullOrWhiteSpace(persona.dni))
            mensajeError += "DNI no puede estar vacío.\n";

        if (string.IsNullOrWhiteSpace(persona.email))
            mensajeError += "Email no puede estar vacío.\n";

        return mensajeError == "";
    }
public void ValidarModificacion(Persona persona)
{
    if (string.IsNullOrWhiteSpace(persona.nombre))
        throw new ValidacionException("El nombre no puede estar vacío.");

    if (string.IsNullOrWhiteSpace(persona.apellido))
        throw new ValidacionException("El apellido no puede estar vacío.");

    if (string.IsNullOrWhiteSpace(persona.dni))
        throw new ValidacionException("El DNI no puede estar vacío.");

    if (string.IsNullOrWhiteSpace(persona.email))
        throw new ValidacionException("El email no puede estar vacío.");

    var personas = repoPersona.ObtenerTodas();

    if (personas.Any(p => p.id != persona.id && p.dni == persona.dni))
        throw new DuplicadoException("Ya existe otra persona con el mismo DNI.");

    if (personas.Any(p => p.id != persona.id && p.email == persona.email))
        throw new DuplicadoException("Ya existe otra persona con el mismo Email.");
}

}
