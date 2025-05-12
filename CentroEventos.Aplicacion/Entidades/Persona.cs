using System;

namespace CentroEventos.Aplicacion.Entidades;

public class Persona
{
   private int _Id;// (int, único, debe ser autoincremental gestionado por el repositorio)
   private int _DNI; // (string, único)
   private string? _Nombre;
   private string? _Apellido;
   private string? _Email;// (string, único)
   private string? _Telefono;

    public int Id { get => _Id; set => _Id = value; }
    public int DNI { get => _DNI; set => _DNI = value; }
    public string? Nombre { get => _Nombre; set => _Nombre = value; }
    public string? Apellido { get => _Apellido; set => _Apellido = value; }
    public string? Email { get => _Email; set => _Email = value; }
    public string? Telefono { get => _Telefono; set => _Telefono = value; }

    public override string ToString(){
      return $" Id: {this.Id}, Dni: {this.DNI}, Nombre: {this.Nombre}, Apellido: {this.Apellido}, Email: {this.Email}, Telefono: {this.Telefono}";
   }

}
