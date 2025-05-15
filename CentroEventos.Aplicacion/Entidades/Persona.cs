using System;

namespace CentroEventos.Aplicacion.Entidades;

public class Persona
{
   private int _Id;// (int, único, debe ser autoincremental gestionado por el repositorio)
   private string? _DNI; // (string, único)
   private string? _Nombre;
   private string? _Apellido;
   private string? _Email;// (string, único)
   private string? _Telefono;

    public Persona(int id, string? dNI, string? nombre, string? apellido, string? email, string? telefono)
    {
        this._Id = id;
        this._DNI = dNI;
        this._Nombre = nombre;
        this._Apellido = apellido;
        this._Email = email;
        this._Telefono = telefono;
    }

    public int Id { get => _Id; set => _Id = value; }
   public string? DNI { get => _DNI; set => _DNI = value; }
   public string? Nombre { get => _Nombre; set => _Nombre = value; }
   public string? Apellido { get => _Apellido; set => _Apellido = value; }
   public string? Email { get => _Email; set => _Email = value; }
   public string? Telefono { get => _Telefono; set => _Telefono = value; }

   public override string ToString(){
      return $" Id: {this.Id}, Dni: {this.DNI}, Nombre: {this.Nombre}, Apellido: {this.Apellido}, Email: {this.Email}, Telefono: {this.Telefono}";
   }
}
