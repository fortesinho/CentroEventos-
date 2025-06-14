using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarPersonaUseCase(IRepositorioPersona repoPersona)
{
    public List<Persona> Ejecutar()
    {
        return repoPersona.ObtenerTodas();
    }
}