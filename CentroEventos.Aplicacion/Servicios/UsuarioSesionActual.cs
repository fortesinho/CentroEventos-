using CentroEventos.Aplicacion.Entidades;
namespace CentroEventos.Aplicacion.Servicios;
public class UsuarioSesionActual
{
    public Usuario? Usuario { get; private set; }

    public void IniciarSesion(Usuario usuario)
    {
        Usuario = usuario;
    }

    public void CerrarSesion()
    {
        Usuario = null;
    }

    public bool EstaAutenticado => Usuario is not null;
}