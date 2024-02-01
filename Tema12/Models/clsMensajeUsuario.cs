namespace Models
{
    public class clsMensajeUsuario
    {
        string nombreUsuario;
        string mensajeUsuario;

        public clsMensajeUsuario()
        {
        }

        public clsMensajeUsuario(string nombreUsuario, string mensajeUsuario)
        {
            this.nombreUsuario = nombreUsuario;
            this.mensajeUsuario = mensajeUsuario;
        }

        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string MensajeUsuario { get => mensajeUsuario; set => mensajeUsuario = value; }
    }
}