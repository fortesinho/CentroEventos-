using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
namespace CentroEventos.Aplicacion.Servicios;
 
public class ServicioAutorizacion: IServicioAutorizacion
{
    private readonly UsuarioSesionActual _sesion;

    public ServicioAutorizacion(UsuarioSesionActual sesion)
    {
        _sesion = sesion;
    }
public bool PoseeElPermiso(Permiso permiso){
return _sesion.Usuario?.Permisos.Contains(permiso) ?? false;
}
}
