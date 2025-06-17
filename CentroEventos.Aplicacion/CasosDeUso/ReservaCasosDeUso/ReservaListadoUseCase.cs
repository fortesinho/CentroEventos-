using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ReservaListadoUseCase(IRepositorioReserva repoReserva)
{
     public List<Reserva> Ejecutar()
    {
        return repoReserva.Listar();
    }
}
    
    