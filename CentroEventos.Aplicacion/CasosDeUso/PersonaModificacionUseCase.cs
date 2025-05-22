using System;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class PersonaModificacionUseCase(IRepositorioPersona repoPersona,IServicioAutorizacion servicio, ValidadorPersona validador)
{
public void Ejecutar(Persona persona, int idUsuario){
 if (!servicio.PoseeElPermiso(idUsuario, Permiso.UsuarioModificacion))
      throw new FalloAutorizacionException("No tiene permiso para modificar personas.");
  if (repoPersona.ObtenerPorId(persona.id) == null)
        throw new EntidadNotFoundException("Persona", persona.id);
 validador.ValidarModificacion(persona);

 repoPersona.Modificar(persona);
}
}
