using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
namespace CentroEventos.Aplicacion.Validadores;



public class  ValidadorPersona(IRepositorioPersona repositorioPersona)
{
    public void Validar(Persona persona){
        
        if(string.IsNullOrWhiteSpace(persona.Nombre)){
            throw new ValidacionException("Nombre no puede estar vacio");
        }
        if(string.IsNullOrWhiteSpace(persona.Apellido)){
            throw new ValidacionException("Apellido no puede estar vacio");
        }
        if(string.IsNullOrWhiteSpace(persona.DNI)){
            throw new ValidacionException("Apellido no puede estar vacio");
        }
        if(string.IsNullOrWhiteSpace(persona.Email)){
            throw new ValidacionException("Email no puede estar vacio");
        }
        if (repositorioPersona.ExisteConDni(persona.DNI))
                throw new DuplicadoException($"Ya existe una persona con el DNI {persona.DNI}.");

        if (repositorioPersona.ExisteConEmail(persona.Email))
                throw new DuplicadoException($"Ya existe una persona con el email {persona.Email}.");

    }

}
