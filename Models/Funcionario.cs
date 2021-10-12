using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Funcionario
    {
        public int? IdFuncionario { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Contraseña { get; set; }

    }
}
