using System;

namespace CentroEventos.Aplicacion.Excepciones;

public class DuplicadoException: Exception
{
    
    public DuplicadoException() :base("Ya existe una entidad con los mismos datos"){}
    public DuplicadoException(string mensaje):base(mensaje){}
}
