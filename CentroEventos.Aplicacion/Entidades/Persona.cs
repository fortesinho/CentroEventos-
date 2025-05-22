using System;

namespace CentroEventos.Aplicacion.Entidades;

public class Persona
{

    public Persona(int id, string? dNI, string? nombre, string? apellido, string? email, string? telefono)
    {
        this.id = id;
        this.dni = dni;
        this.nombre = nombre;
        this.apellido = apellido;
        this.email = email;
        this.telefono = telefono;
    }
    public Persona(){}

   public int id { get; set; }
   public string? dni { get; set; }
   public string? nombre { get; set; }
   public string? apellido { get; set;}
   public string? email{ get; set; }
   public string? telefono{ get; set; }

   public override string ToString(){
      return $" Id: {this.id}, Dni: {this.dni}, Nombre: {this.nombre}, Apellido: {this.apellido}, Email: {this.email}, Telefono: {this.telefono}";
   }
}
