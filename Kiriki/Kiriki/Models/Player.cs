using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiriki.Models
{
    public class Player 
    {
        private int vidas;
        private string usuario;
        private bool puedeTirar;

        public Player(string usuario)
        {
            vidas = 3;
            puedeTirar = false;
        }

        public int Vidas { get { return vidas; } set { vidas = value; } }
        public string Usuario { get { return usuario; } }
        public bool PuedeTirar { get {  return puedeTirar; } set {  puedeTirar = value; } }
    }
}
