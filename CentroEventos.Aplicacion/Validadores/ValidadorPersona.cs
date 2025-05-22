using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
namespace CentroEventos.Aplicacion.Validadores;



public class  ValidadorPersona(IRepositorioPersona repositorioPersona)
{
    public void Validar(Persona persona){
        
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
        if (repositorioPersona.ExisteConDni(persona.dni))
                throw new DuplicadoException($"Ya existe una persona con el DNI {persona.dni}.");

        if (repositorioPersona.ExisteConEmail (persona.email))
                throw new DuplicadoException($"Ya existe una persona con el email {persona.email}.");

    }

}
