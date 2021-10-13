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
        public FormaPago FormaPago { get; set; }


        public static bool ValidarCedula(string cedula)
        {
            return cedula.Length >= 7 && cedula.Length <= 9;
        }

        public static bool ValidarNombreCompleto(string nombre)
        {
            return nombre.Length >= 6; 
        }

        public static bool ValidadFechaNacimiento(DateTime fechaNacimiento)
        {
            return (DateTime.Now.Year - fechaNacimiento.Year) > 3 && (DateTime.Now.Year - fechaNacimiento.Year) < 90;
        }
    }
}
