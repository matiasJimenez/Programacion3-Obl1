using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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


        public static bool ValidarConatraseña(string contraseña)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");

            return hasLowerChar.IsMatch(contraseña) && hasUpperChar.IsMatch(contraseña) && hasNumber.IsMatch(contraseña) && contraseña.Length >= 6;
        }

        public static bool ValidarMail(string mail)
        {
            var strMail = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");

            return strMail.IsMatch(mail);
        }
    }
}
