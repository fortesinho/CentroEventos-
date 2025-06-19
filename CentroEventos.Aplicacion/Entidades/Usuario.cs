using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace CentroEventos.Aplicacion.Entidades;

public class Usuario
{
public int Id {get; set; }

public string? Nombre {get; set;}
public string? Apellido {get; set;}
public string? Email {get; set;} 

public string? ContraseñaHash {get; set;}


// No se guarda directamente esta propiedad, es para trabajar en código
[NotMapped]
public List<Permiso> Permisos {get;set;} = new List<Permiso>();

// Esta propiedad sí se guarda en la base como string
    public string PermisosSerializados
    {
        get => string.Join(",", Permisos.Select(p => p.ToString()));
        set => Permisos = string.IsNullOrWhiteSpace(value)
            ? new List<Permiso>()
            : value.Split(',').Select(p => Enum.Parse<Permiso>(p)).ToList();
    }


}
