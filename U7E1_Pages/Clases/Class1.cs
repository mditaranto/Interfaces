namespace Clases
{
    // All the code in this file is included in all platforms.
    public class clsPersona
    {
        private String nombre;
        private String apellidos;

        public clsPersona()
        {
            this.nombre = null;
            this.apellidos = null;
        }

        public clsPersona(String nombre, String apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }

        public string nombres
        {
            get { return nombres; }
            set { this.nombre = value; }
        }

        public String apellido
        {
            get { return apellidos; }
            set { this.apellidos = value; }
        }

        public string NombreCompleto
        {
            get { return nombre + " " + apellidos; }
        }

        public string FuncionNombreCompleto()
        {
            return $"El nombre completo es {nombres} {apellidos}";
        }

    }
}