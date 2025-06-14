using System;

namespace CentroEventos.Aplicacion.Excepciones;

public class EntidadNotFoundException: Exception
{
    public EntidadNotFoundException(string entidad) : base(entidad) { }
}
