using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Socio
    {
        public int? IdSocio { get; set; }
        [Required]
        public string Cedula { get; set; }
        [Required]
        public string NombreCompleto { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaAlta { get; set; }
        [Required]
        public bool Activo { get; set; }

    }
}
