using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ReservaListadoUseCase(IRepositorioReserva repoReserva, IServicioAutorizacion autorizacion)
{
    public List<Reserva> Ejecutar(int idUsuario)
    {
        if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.ReservaListado))
            throw new FalloAutorizacionException("El usuario no tiene permiso para listar reservas.");

        return repoReserva.Listar();//devuelve la lista de las reservas
        
    }
    
    }