using System;

namespace CentroEventos.Aplicacion.Excepciones;

public class EntidadNotFoundException: Exception
{
    public EntidadNotFoundException(string entidad, int id)
    : base($"No se encontró la entidad {entidad} con ID {id}.") { }
}
