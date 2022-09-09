using System;
using System.Collections.Generic;

namespace BikeDrivers.Modelos
{
    public partial class Provedor
    {
        public int IdProvedor { get; set; }
        public string? NombreProvedor { get; set; }
        public string? TipoDocumento { get; set; }
        public long? NumDocumento { get; set; }
        public string? Correo { get; set; }
        public string? Direccion { get; set; }
    }
}
