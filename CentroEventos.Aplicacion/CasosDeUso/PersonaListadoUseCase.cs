using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class PersonaListadoUseCase(IRepositorioPersona repoPersona, IServicioAutorizacion autorizacion)
{
    public List<Persona> Ejecutar(int idUsuario)
    {
        if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.UsuarioListado))
            throw new FalloAutorizacionException("El usuario no tiene permiso para listar personas.");

        return repoPersona.ObtenerTodas(); //devuelve la lista de todas las personas
    }
}