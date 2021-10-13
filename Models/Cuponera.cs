using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Cuponera : FormaPago
    {
        public List<Actividad> Actividades { get; set; }
        public int Costo { get; set; }
    }
}
