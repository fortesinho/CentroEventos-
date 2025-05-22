using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ReservaAltaUseCase(IRepositorioReserva repoReserva, IServicioAutorizacion autorizacion, ValidadorReserva validador){

    public void Ejecutar(Reserva datosReserva, int idUsuario){
        if (!autorizacion.PoseeElPermiso(idUsuario, Permiso.ReservaAlta))
            throw new FalloAutorizacionException("El usuario no tiene permiso para dar de alta reservas.");
        validador.Validar(datosReserva);
        datosReserva.FechaAltaReserva = DateTime.Now;
        datosReserva.EstadoAsistencia = Reserva.EstadoAsis.Pendiente;
        repoReserva.Agregar(datosReserva);
        
    }
   
    
}
