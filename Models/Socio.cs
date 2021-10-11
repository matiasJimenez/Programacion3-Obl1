using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Socio
    {
        public int IdSocio { get; set; }
        public string Cedula { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaAlta { get; set; }
        public bool Activo { get; set; }

    }
}
