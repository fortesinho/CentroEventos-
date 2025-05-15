using System;

namespace CentroEventos.Aplicacion.Excepciones;

public class OperacionInvalidaException : Exception
{

   public OperacionInvalidaException(): base("La operación solicitada no está permitida por las reglas de negocio") { }

   public OperacionInvalidaException(string mensaje) : base(mensaje) { }
}
