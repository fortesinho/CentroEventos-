using System;

namespace CentroEventos.Aplicacion.Excepciones;

public class FalloAutorizacionException: Exception
{
    public FalloAutorizacionException():base("El usuario no tiene permiso para realizar esta operación.") { }

    public FalloAutorizacionException(string mensaje): base(mensaje) { }
}
