using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Helpers
{
    public static class Validador
    {
        public static bool camposVacios(string[] campos)
        {
            foreach (var item in campos)
                if (string.IsNullOrEmpty(item))
                    return true;
            return false;
        }

        public static bool formatoEmail(string email)
        {
            string expresion = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            return Regex.IsMatch(email, expresion);
        }

        public static bool contraseñaValida(string contraseña)
        {
            if (contraseña.Length < 4)
                return false;
            return true;
        }
    }
}
