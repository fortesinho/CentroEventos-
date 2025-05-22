using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Extra;

namespace CentroEventos.Repositorios;

public class RepositorioPersona : IRepositorioPersona
{
    readonly string _ArchivoPersona = "Personas.txt";
    readonly string _dirUltIdPer = "ultimo_id_persona.txt";
    public void Agregar(Persona persona)
    {
        persona.id = GeneradorId.obtener(_dirUltIdPer);
        using StreamWriter sw = new StreamWriter(_ArchivoPersona, append: true);
        sw.WriteLine($"{persona.id};{persona.dni};{persona.nombre};{persona.apellido};{persona.email};{persona.telefono}");

    }
    public void Eliminar(int id)
    {
        var personas = ObtenerTodas();
        for (int i = 0; i < personas.Count; i++)
        {
            if (personas[i].id == id)
            {
                personas.RemoveAt(i);
                i--;
            }
        }
        ActualizarPersonas(personas);
    }

    public void Modificar(Persona persona)
    {
        List<Persona> personas = ObtenerTodas();
        int aux = -1;
        for (int i = 0; i < personas.Count; i++)
        {
            if (personas[i].id == persona.id)
            {
                aux = i;
                break;
            }
        }
        if (aux >= 0)
        {
            personas[aux] = persona;
            ActualizarPersonas(personas);
        }
    }
    public bool ExisteConDni(string dni)
    {
        List<Persona> personas = ObtenerTodas();
        foreach (Persona p in personas)
        {
            if (p.dni == dni)
            {
                return true;
            }
        }
        return false;
    }
    public bool ExisteConEmail(string email)
    {
        List<Persona> personas = ObtenerTodas();
        foreach (Persona p in personas)
        {
            if (p.email == email)
            {
                return true;
            }
        }
        return false;
    }

    public Persona? ObtenerPorId(int id)
    {
        List<Persona> personas = ObtenerTodas();
        foreach (Persona p in personas)
        {
            if (p.id == id)
            {
                return p;
            }
        }
        return null;
    }

    public List<Persona> ObtenerTodas()
    {
        List<Persona> personas = new List<Persona>();
        if (!File.Exists(_ArchivoPersona))
        {
            return personas;
        }
        using StreamReader sr = new StreamReader(_ArchivoPersona);
        while (!sr.EndOfStream)
        {
            string? linea = sr.ReadLine();
            Persona? persona = ConvertirLinea(linea);
            if (persona != null)
            {
                personas.Add(persona);
            }
        }
        return personas;
    }

    //-------- METODOS PRIVADOS ---------- 
    private void ActualizarPersonas(List<Persona> personas)
    {
        using StreamWriter sw = new StreamWriter(_ArchivoPersona, false);
        foreach (Persona p in personas)
        {
            sw.WriteLine($"{p.id}|{p.dni}|{p.nombre}|{p.apellido}|{p.email}|{p.telefono}");
        }
    }

    private Persona? ConvertirLinea(string? linea)
    {
        if (string.IsNullOrWhiteSpace(linea))
        {
            return null;
        }
        string[]? partes = linea.Split('|');
        if (partes.Length != 6) {
            return null;
        }
        try{
        return new Persona{
            id = int.Parse(partes[0]),
            dni = partes[1],
            nombre = partes[2],
            apellido = partes[3],
            email = partes[4],
            telefono = partes[5]
        };
        }
        catch{
            return null;
        }
    }

}   

