using System;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
namespace CentroEventos.Aplicacion.CasosDeUso;

public class PersonaAltaUseCase(IRepositorioPersona repoPersona,IServicioAutorizacion autorizacion, ValidadorPersona validador)
{

public void Ejecutar(Persona persona, int idUsuario){
    if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.UsuarioAlta))  
        throw new FalloAutorizacionException("El usuario no tiene permiso para dar de alta personas.");
            
    validador.ValidarAlta(persona);
    repoPersona.Agregar(persona);

    }
}
