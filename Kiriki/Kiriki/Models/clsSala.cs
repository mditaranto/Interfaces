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
        private int numJugadores;
        private List<Player> jugadores;

        public clsSala(string nombre)
        {
            this.nombre = nombre;
            numJugadores = 0;
            jugadores = new List<Player>();
        }

        public string Nombre { get { return nombre; } }
        public int NumJugadores { get { return numJugadores; } }
        public List<Player> Jugadores { get { return jugadores; } }

    }
}
