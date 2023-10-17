using System.Security.Cryptography.X509Certificates;

namespace ClassLibrary1
{
    public class clsPersona
    {

        #region atributos
        private string nombres;
        private string apellidos;
        #endregion

        #region constructores
        public clsPersona()
        {
            nombres = string.Empty;
            apellidos = string.Empty;
        }

        public clsPersona(String nombres, String apellidos)
        {
            this.nombres = nombres;
            this.apellidos = apellidos;
        }
        #endregion

        #region propiedades
        public string nombre
        {
            get { return nombres; }
            set { nombres = value; }
        }

        public String apellido
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        public String Direccion { get; set; }
        public string NombreCompleto 
        {
            get { return nombre + " " + apellidos; }
        }
        #endregion

        #region funciones

        public string FuncionNombreCompleto()
        {
            return $"El nombre completo es {nombres} {apellidos}";
        }
        #endregion

    }

}