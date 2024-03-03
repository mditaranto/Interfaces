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
        private clsSala sala;

        public Player(string usuario, clsSala sala)
        {
            vidas = 3;
            puedeTirar = false;
            this.usuario = usuario;
            this.sala = sala;
        }

        public int Vidas { get { return vidas; } set { vidas = value; } }
        public string Usuario { get { return usuario; } }
        public bool PuedeTirar { get {  return puedeTirar; } set {  puedeTirar = value; } }
        public clsSala Sala { get { return sala; } }
    }
}
