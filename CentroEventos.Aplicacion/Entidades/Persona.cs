using System;

namespace CentroEventos.Aplicacion.Entidades;

public class Persona
{

    public Persona(int id, string? dNI, string? nombre, string? apellido, string? email, string? telefono)
    {
        this.Id = id;
        this.DNI = dNI;
        this.Nombre = nombre;
        this.Apellido = apellido;
        this.Email = email;
        this.Telefono = telefono;
    }
    public Persona(){}

   public int Id { get; set; }
   public string? DNI { get; set; }
   public string? Nombre { get; set; }
   public string? Apellido { get; set;}
   public string? Email{ get; set; }
   public string? Telefono{ get; set; }

   public override string ToString(){
      return $" Id: {this.Id}, Dni: {this.DNI}, Nombre: {this.Nombre}, Apellido: {this.Apellido}, Email: {this.Email}, Telefono: {this.Telefono}";
   }
}
