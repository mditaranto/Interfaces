namespace Biblioteca
{
    // All the code in this file is included in all platforms.
    public class Persona
    {
            #region atributos
           
            private string nombre;
    
            private string apellido;
            #endregion

            #region constructores

            public Persona()
            {
                this.nombre = "";
                this.apellido = "";
            }

            public Persona(string nombre, string apellido)
            {
                this.nombre = nombre;
                this.apellido = apellido;
            }
            #endregion

            #region propiedades

            public String Nombre
            {
                get { return nombre; }
                set { nombre = value; }
            }

            public String Apellido
            {
                get { return apellido; }
                set { apellido = value; }
            }

            public String Direccion { get; set; }

            public String NombreCompleto
            {
                get { return $"{nombre} {apellido}"; }
            }

            #endregion

        }
    }
