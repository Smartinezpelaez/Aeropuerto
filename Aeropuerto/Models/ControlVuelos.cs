using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aeropuerto.Models
{
    public class ControlVuelos
    {
        public int Id { get; set; }
        public int IdReserva { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public DateTime? FechaSalida { get; set; }       
        public int HoraVuelo { get; set; }
        public string  Aerolinea { get; set; }

    }
}
