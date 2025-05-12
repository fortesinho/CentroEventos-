using System;

namespace CentroEventos.Aplicacion.Entidades;

public class EventoDeportivo
{
    private int _Id;//(int, único, debe ser autoincremental gestionado por el repositorio)
    private string? _Nombre;//(string - ej: "Clase de Spinning Avanzado", "Partido final de Vóley")
    private string? _Descripcion;
    private DateTime _FechaHoraInicio; //(DateTime - Fecha y hora exactas de inicio del evento)
    private double _DuracionHoras;//(double - Duración del evento en horas, ej: 1.5 para una hora y media)
    private int _CupoMaximo; //(int - Cantidad máxima de participantes permitidos)
    private int _ResponsableId; //(int - Id de la Persona a cargo del evento)

    public int Id { get => _Id; set => _Id = value; }
    public string? Nombre { get => _Nombre; set => _Nombre = value; }
    public string? Descripcion { get => _Descripcion; set => _Descripcion = value; }
    public DateTime FechaHoraInicio { get => _FechaHoraInicio; set => _FechaHoraInicio = value; }
    public double DuracionHoras { get => _DuracionHoras; set => _DuracionHoras = value; }
    public int CupoMaximo { get => _CupoMaximo; set => _CupoMaximo = value; }
    public int ResponsableId { get => _ResponsableId; set => _ResponsableId = value; }

    public override string ToString(){
        return $"Id: {this._Id}, Nombre: {this._Nombre}, Descripcion: {this._Descripcion}, FechaHoraInicio: {this._FechaHoraInicio}, DuracionHoras: {this._DuracionHoras}, CupoMaximo: {this._CupoMaximo}, ResponsableId: {this._ResponsableId}";
    }
}
