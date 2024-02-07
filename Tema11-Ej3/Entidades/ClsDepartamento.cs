using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ClsDepartamento
    {

        public int id;
        public string nombre;

        public ClsDepartamento()
        {

        }

        public ClsDepartamento(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value.Trim(); }

    }
}
