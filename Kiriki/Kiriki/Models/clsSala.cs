using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiriki.Models
{
    public class clsSala
    {
        private string nombre;

        public clsSala(string nombre)
        {
            this.nombre = nombre;
        }

        public string Nombre { get { return nombre; } }
    }
}
