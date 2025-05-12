using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.Validadores;

public class  ValidadorPersona
{
    public void Validar(Persona persona){
        if(string.IsNullOrWhiteSpace(persona.Nombre)){
            throw new ValidacionException("No puede estar vacio");
        }
        if(string.IsNullOrWhiteSpace(persona.Apellido)){
            throw new ValidacionException("No puede estar vacio");
        }
        if(string.IsNullOrWhiteSpace(persona.Email)){
            throw new ValidacionException("No puede estar vacio");
        }

        /*falta dni e email (Requiere consulta a IRepositorioPersona) */
    }
/*○ Nombre, Apellido, DNI, Email no deben estar vacíos.
○ DNI no puede repetirse entre Personas. (Requiere consulta a IRepositorioPersona)
○ Email no puede repetirse entre Personas. (Requiere consulta a IRepositorioPersona)
*/
}
