namespace Biblioteca
{
    // All the code in this file is included in all platforms.
    public class Citas
    {

        #region atributos

        private string direccion;
        private string cliente;
        private int telefono;
        #endregion

        #region constructores

        public Citas()
        {
            this.cliente = "";
            this.direccion = "";
            this.telefono = 123456789;
        }

        public Citas(string cliente, string direccion, int telefono)
        {
            this.cliente = cliente;
            this.direccion = direccion;
            this.telefono = telefono;
        }
        #endregion

        #region propiedades

        public String Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        public String Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public int Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        #endregion

    }
}