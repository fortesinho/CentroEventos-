
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Extra;
namespace CentroEventos.Repositorios;

public class RepositorioReserva : IRepositorioReserva
{
    readonly string ArchivoReservas = "Reservas.txt";
    readonly string _dirUltIdRes = "ultimo_id_reserva.txt";
    public void Agregar(Reserva reserva){
        reserva.Id = GeneradorId.Obtener(_dirUltIdRes); // genera nuevo id
        using StreamWriter sw = new StreamWriter(ArchivoReservas, true); //empieza a escribir al final del archivo sin borrar lo que ya habia 
        sw.WriteLine(DarFormato(reserva)); // escribe los datos de la reserva en el archivo
    }

    public void Eliminar(int id){
        List<Reserva> reservas = Listar(); //lee el archivo y se lo guarda en reservas
        for (int i = 0; i < reservas.Count; i++){ // recorre toda la lista y elimina todos los elementos que tengan el id recibido por parametro
            if (reservas[i].Id == id){
                reservas.RemoveAt(i);
                i--; // vuelvo uno atras porque si vienen 2 ids seguidos el segundo no lo borra
            }
        }
        ActualizarReservas(reservas);//sobreescribe el archivo pero ahora con los elementos eliminados
    }

    public void Modificar(Reserva reserva){
        List<Reserva> reservas = Listar();
        int aux = -1;
        for (int i = 0; i < reservas.Count; i++)
            if (reservas[i].Id == reserva.Id){
                aux = i;
                break;
            }
        if (aux >= 0){ // si encontro el id que quiere modificar
            reservas[aux] = reserva; // guardo en esa posicion el parametro que recibi
            ActualizarReservas(reservas);//actulizo la lista
        }
    }
    public List<Reserva> Listar()
    {
        List<Reserva> reservas = new List<Reserva>(); //creo una lista vacia
        if (!File.Exists(ArchivoReservas)){ // si no existe el archivo
            return reservas;//devuelve la lista vacia
        }
        using StreamReader sr = new StreamReader(ArchivoReservas,false);
        while (!sr.EndOfStream){    //mientras no llego al final del archivo
            string? linea = sr.ReadLine();//guardo la linea
            Reserva? reserva = ConvertirLinea(linea); // modifico la linea que recibi antes y me guardo sus campos en la variable reserva
            if (reserva != null){
                reservas.Add(reserva); //si los campos estaban cargados correctamente los agrego a la lista de reserva
            }
        }
        return reservas;
    }
    public Reserva? ObtenerPorId(int id) {
        if (!File.Exists(ArchivoReservas)){
            return null;
        }   
        using StreamReader sr = new StreamReader(ArchivoReservas);
        while (!sr.EndOfStream){
            string? linea = sr.ReadLine();
            Reserva? reserva = ConvertirLinea(linea);
            if (reserva?.Id == id)
                return reserva;
        }
        return null;
    }
   
    public List<Reserva> ObtenerPorEvento(int eventoDeportivoId){
        List<Reserva> listaNue = new List<Reserva>();
        List<Reserva> lista = Listar();
        foreach (Reserva r in lista){
            if (r.EventoDeportivoId == eventoDeportivoId){ // si la reserva coincide con el id del parametro se agrega a la lista nueva
                listaNue.Add(r);
            }
        }
        return listaNue;
    }
    public List<Reserva> ObtenerPorPersona(int id){
        List<Reserva> listaNue = new List<Reserva>();
        List<Reserva> lista = Listar();
        foreach (Reserva r in lista){
            if (r.PersonaId == id){
                listaNue.Add(r);
            }
        }
        return listaNue;
    }

    //-------- METODOS PRIVADOS ---------- 
    private static string DarFormato(Reserva reserva){
        return $"{reserva.Id}|{reserva.EventoDeportivoId}|{reserva.PersonaId}|{reserva.FechaAltaReserva:O}|{reserva.EstadoAsistencia}";
        }
        private void ActualizarReservas(List<Reserva> reservas){
            using StreamWriter sw = new StreamWriter(ArchivoReservas);
            foreach (Reserva reserva in reservas){
                sw.WriteLine(DarFormato(reserva));
            }
        }
    private static Reserva? ConvertirLinea(string? linea){
        if (string.IsNullOrWhiteSpace(linea)){ //si la linea es null o esta vacia devuelve null
            return null;
        }
        string[]? partes = linea.Split('|'); // me guardo la linea en un vector de strings usando '|' que lo usamos para separar los campos 
        if (partes.Length != 5)
            return null;
        try{
            return new Reserva {
                Id = int.Parse(partes[0]),
                EventoDeportivoId = int.Parse(partes[1]),
                PersonaId = int.Parse(partes[2]),
                FechaAltaReserva = DateTime.Parse(partes[3]),
                EstadoAsistencia = Enum.Parse<Reserva.EstadoAsis>(partes[4])
            };
        }
        catch{
            return null; // Si falla algo en el parseo, devuelve null y sigue sin tirar excepción
        }
    }
}


