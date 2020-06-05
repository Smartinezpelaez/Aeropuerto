﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aeropuerto.Models
{
    public class ControlAterrizaje
    {

        public int Id { get; set; }
        public int IdAterrizaje { get; set; }
        public string Pista { get; set; }
        public string Estado { get; set; }
        public string Clima { get; set; }
        public string Aeropuerto { get; set; }
        public DateTime? FechayHora { get; set; }

    }
}
