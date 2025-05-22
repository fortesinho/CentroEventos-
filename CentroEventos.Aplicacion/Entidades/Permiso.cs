namespace CentroEventos.Aplicacion.Entidades;

public enum Permiso
{
    EventoAlta, //Puede crear nuevos eventos deportivos en el centro
    EventoModificacion,//Puede modificar los detalles de los eventos deportivos
    EventoBaja,//Puede eliminar eventos deportivos del centro
    ReservaAlta,//Alta Puede registrar nuevas reservas
    ReservaModificacion,//Puede modificar las reservas
    ReservaBaja,//Puede dar de baja reservas
    ReservaListado,//Puede dar el listado de las reservas
    UsuarioAlta,//Puede dar de alta nuevos usuarios del sistema
    UsuarioModificacion,//Puede modificar los datos de los usuarios
    UsuarioBaja,//Puede dar de baja usuarios del sistema
    UsuarioListado,// Puede dar el listado de los usuarios
}
