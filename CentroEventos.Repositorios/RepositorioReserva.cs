
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Repositorios;

    public class RepositorioReservaTXT : IRepositorioReserva, IDisposable
    {
        private string ArchivoReservas = "reservas.txt"; 
        private bool _disposed = false;

        public void Agregar(Reserva reserva)
        {
            reserva.Id = ObtenerNuevoId(); //Asigna un id unico a la reserva antes de guardarla
            using StreamWriter sw = new StreamWriter(ArchivoReservas);
            sw.WriteLine(DarFormato(reserva));
        }

        public void Eliminar(int id)
        {
            var reservas = Listar();
            reservas.RemoveAll(r => r.Id == id);
            GuardarTodasReservas(reservas);
        }

        public void Modificar(Reserva reserva)
        {
            var reservas = Listar();
            var index = reservas.FindIndex(r => r.Id == reserva.Id);
            if (index >= 0)
            {
                reservas[index] = reserva;
                GuardarTodasReservas(reservas);
            }
        }

        public List<Reserva> Listar()
        {
            var reservas = new List<Reserva>();

            if (!File.Exists(ArchivoReservas))
                return reservas;

            using var sr = new StreamReader(ArchivoReservas);
            while (!sr.EndOfStream)
            {
                var linea = sr.ReadLine();
                var reserva = ParsearReserva(linea);
                if (reserva != null)
                    reservas.Add(reserva);
            }

            return reservas;
        }

        public Reserva? ObtenerPorId(int id)
        {
            if (!File.Exists(ArchivoReservas))
                return null;

            using var sr = new StreamReader(ArchivoReservas);
            while (!sr.EndOfStream)
            {
                var linea = sr.ReadLine();
                var reserva = ParsearReserva(linea);
                if (reserva?.Id == id)
                    return reserva;
            }

            return null;
        }

        public List<Reserva> ObtenerPorEventoYPersona(int eventoDeportivoId, int personaId)
        {
            return Listar().Where(r => r.EventoDeportivoId == eventoDeportivoId && r.PersonaId == personaId).ToList();
        }

        public List<Reserva> ObtenerPorEvento(int eventoDeportivoId)
        {
            return Listar().Where(r => r.EventoDeportivoId == eventoDeportivoId).ToList();
        }

        // metodos privados 
        private int ObtenerNuevoId(){
            List<Reserva> reservas = Listar(); //se guarda todas las reservas
            int maxId = 0;//guarda el id mas alto que encontro  
            foreach (Reserva reserva in reservas){ //recorre todas las reservas
                if (reserva.Id > maxId){
                    maxId = reserva.Id;
                }
            }
            return maxId + 1;
        }
        private void GuardarTodasReservas(List<Reserva> reservas)
    {
        using StreamWriter sw = new StreamWriter(ArchivoReservas, false);
        foreach (Reserva reserva in reservas)
        {
            sw.WriteLine(DarFormato(reserva));
        }
    }

        private string DarFormato(Reserva reserva)
        {
            return $"{reserva.Id}|{reserva.EventoDeportivoId}|{reserva.PersonaId}|{reserva.FechaAltaReserva:O}";
        }

        private static Reserva? ParsearReserva(string? linea)
        {
            if (string.IsNullOrWhiteSpace(linea))
                return null;

            var partes = linea.Split('|');
            if (partes.Length != 4)
                return null;

            return new Reserva
            {
                Id = int.Parse(partes[0]),
                EventoDeportivoId = int.Parse(partes[1]),
                PersonaId = int.Parse(partes[2]),
                FechaAltaReserva = DateTime.Parse(partes[3])
            };
        }

        // --- IDisposable ---

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // liberar recursos administrados si hiciera falta
                }
                _disposed = true;
            }
        }

        ~RepositorioReservaTXT()
        {
            Dispose(false);
        }
    }


