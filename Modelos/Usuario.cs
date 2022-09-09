using System;
using System.Collections.Generic;

namespace BikeDrivers.Modelos
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string? NombreUsuario { get; set; }
        public string? ApellidoUsuario { get; set; }
        public string? Correo { get; set; }
        public string? Contraseña { get; set; }
        public long? Telefono { get; set; }
        public int? FkRolid { get; set; }

        public virtual Rol? FkRol { get; set; }
    }
}
