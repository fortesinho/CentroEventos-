using System;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IServicioAutorizacion
{
    bool PoseeElPermiso(Permiso permiso);
}
