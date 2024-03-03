namespace KirikiServer
{
    /// <summary>
    /// Clase que representa una sala del servidor
    /// </summary>
    public class clsSalaServer
    {
        private string nombre;
        private int numJugadores;

        public clsSalaServer(string nombre)
        {
            this.nombre = nombre;
            numJugadores = 0;
        }

        public string Nombre { get { return nombre; } }
        public int NumJugadores { get { return numJugadores; } set { numJugadores = value; } }
    }
}
