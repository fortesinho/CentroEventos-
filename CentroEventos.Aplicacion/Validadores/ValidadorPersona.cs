using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
namespace CentroEventos.Aplicacion.Validadores;



public class  ValidadorPersona(IRepositorioPersona repoPersona)
{
    public void ValidarAlta(Persona persona){
        
        if(string.IsNullOrWhiteSpace(persona.nombre)){
            throw new ValidacionException("Nombre no puede estar vacio");
        }
        if(string.IsNullOrWhiteSpace(persona.apellido)){
            throw new ValidacionException("Apellido no puede estar vacio");
        }
        if(string.IsNullOrWhiteSpace(persona.dni)){
            throw new ValidacionException("Apellido no puede estar vacio");
        }
        if(string.IsNullOrWhiteSpace(persona.email)){
            throw new ValidacionException("Email no puede estar vacio");
        }
        if (repoPersona.ExisteConDni(persona.dni))
                throw new DuplicadoException($"Ya existe una persona con el DNI {persona.dni}.");

        if (repoPersona.ExisteConEmail (persona.email))
                throw new DuplicadoException($"Ya existe una persona con el email {persona.email}.");

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
