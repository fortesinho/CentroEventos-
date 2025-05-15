using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
namespace CentroEventos.Aplicacion.Validadores;

    

public class  ValidadorPersona
{
    public void Validar(Persona persona){
        private readonly IRepositorioPersona _repositorioPersona;
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

        /*falta dni e email (Requiere consulta a IRepositorioPersona) */
    }
/*○ Nombre, Apellido, DNI, Email no deben estar vacíos.
○ DNI no puede repetirse entre Personas. (Requiere consulta a IRepositorioPersona)
○ Email no puede repetirse entre Personas. (Requiere consulta a IRepositorioPersona)
*/
}
