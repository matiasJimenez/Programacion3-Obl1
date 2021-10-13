using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Actividad
    {
        public int IdActividad { get; set; }
        public string Nombre { get; set; }
        public int RangoMin { get; set; }
        public int RangoMax { get; set; }
        public eSemana DiaSemana { get; set; }
        public int DiaHora { get; set; }

        public enum eSemana
        {
            lunes = 1,
            martes = 2,
            miercoles = 3,
            jueves = 4,
            viernes = 5,
            sabado = 6,
            domingo = 7
        }
    }
}
