namespace Entidades
{
    public class ClsPersona
    {
        private int id;
        private string nombre;
        private string apellidos;
        private string direccion;
        private string telefono;
        private string foto;
        private DateTime fechaNac;
        private int idDepartamento;

        public ClsPersona()
        {
        }

        public ClsPersona(int id, string nombre, string apellido, string direccion, string telefono, string foto, DateTime fechaNacimiento, int idDepartamento)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellidos = apellido;
            this.direccion = direccion;
            this.telefono = telefono;
            this.foto = foto;
            this.fechaNac = fechaNacimiento;
            this.idDepartamento = idDepartamento;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value.Trim(); }
        public string Apellidos { get => apellidos; set => apellidos = value.Trim(); }
        public string Direccion { get => direccion; set => direccion = value.Trim(); }

        public string Telefono
        {
            get => telefono; set
            {
                
                {
                    telefono = value;
                }
               
            }
        }

        public string Foto { get => foto; set => foto = value.Trim(); }
        public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }

        public int IdDepartamento { get => idDepartamento; set => idDepartamento = value; }
    }
}