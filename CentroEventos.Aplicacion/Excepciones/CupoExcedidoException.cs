using System;

namespace CentroEventos.Aplicacion.Excepciones;

public class CupoExcedidoException: Exception
{
    public CupoExcedidoException() : base("No hay cupo disponible para el evento deportivo.") { }

    public CupoExcedidoException(string mensaje) : base(mensaje) { }
}
