using System;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
namespace CentroEventos.Aplicacion.CasosDeUso;

public class PersonaAltaUseCase(IRepositorioPersona repoPersona,IServicioAutorizacion autorizacion, ValidadorPersona validador)
{

public void Ejecutar(Persona persona){
    if (!autorizacion.PoseeElPermiso(Permiso.UsuarioAlta))  
        throw new FalloAutorizacionException("El usuario no tiene permiso para dar de alta personas.");

    if (!validador.ValidarAlta(persona, out string mensajeError))
        throw new ValidacionException(mensajeError);

    if (repoPersona.ExisteConDni(persona.dni))
        throw new DuplicadoException("Ya existe una persona con ese DNI.");

    if (repoPersona.ExisteConEmail(persona.email))
        throw new DuplicadoException("Ya existe una persona con ese email.");

    repoPersona.Agregar(persona);
    }

    

    
}
