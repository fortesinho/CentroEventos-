using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Repositorios;

public class RepositorioPersona : IRepositorioPersona
{
    readonly string _nombreArch = "Personas.txt";
    readonly string _dirUltId = "ultimo_id_persona.txt";
    public void Agregar(Persona persona)
    {

       
    }

    public void Eliminar(int id)
    {
        
    }

    public bool ExisteConDni(string dni)
    {
        return true;
    }

    public bool ExisteConEmail(string email)
    {
        return true;
    }

    public Persona? ObtenerPorId(int id)
    {
        return null;
    }

    public List<Persona> ObtenerTodas()
    {
        return null;
    }

    private int ObtenerNuevoId(){
      int ultimoId = 0;
        if(File.Exists(_dirUltId)){
            using var sr = new StreamReader(_dirUltId);
            string? linea = sr.ReadLine();
            if (!string.IsNullOrWhiteSpace(linea))
               ultimoId = int.Parse(linea);
            }
        int nuevoId = ultimoId + 1;
        using var sw = new StreamWriter(_dirUltId, false);
        sw.WriteLine(nuevoId);
    return nuevoId;
        }

    }

