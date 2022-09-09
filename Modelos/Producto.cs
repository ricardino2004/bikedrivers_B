using System;
using System.Collections.Generic;

namespace BikeDrivers.Modelos
{
    public partial class Producto
    {
        public int IdProducto { get; set; }
        public string? NombreProducto { get; set; }
        public string? Descripciion { get; set; }
        public decimal? Precio { get; set; }
        public int? Stock { get; set; }
        public int? FkMarcaid { get; set; }
        public int? FkProvedorid { get; set; }
        public int? FkIdCategoria { get; set; }
    }
}
