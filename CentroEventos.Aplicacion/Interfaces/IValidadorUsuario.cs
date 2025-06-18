using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IValidadorUsuario
{
    public bool Validar(Usuario usuario, out string mensajeError);
}