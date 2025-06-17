using System;
using CentroEventos.Aplicacion.Entidades;

public class UsuarioValidador
{
    public bool Validar(Usuario usuario, out string mensajeError)
    {
        mensajeError = "";
        if (string.IsNullOrWhiteSpace(usuario.Nombre))
            mensajeError=mensajeError +" No existe el nombre ";
        if (string.IsNullOrWhiteSpace(usuario.Apellido))
            mensajeError=mensajeError +" No existe el apellido ";
        if (string.IsNullOrWhiteSpace(usuario.ContraseñaHash))
            mensajeError=mensajeError +" No existe la contraseña ";
        return mensajeError == "";
    }
}
