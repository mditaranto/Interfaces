using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Clases
{
    // All the code in this file is included in all platforms.

    public class ClsPersona 
        {

            #region atributos
            private int id;
            private string nombre;
            private string apellido;

            #endregion

            #region constructores
            public ClsPersona()
            {
                id = 0;
                nombre = "Matias";
                apellido = "Ditaranto";
            }

            public ClsPersona(string nombre, string apellido, int id)
            {
                this.id = id;
                this.nombre = nombre;
                this.apellido = apellido;

            }
            #endregion

            #region propiedades
            public String Nombre
            {
                get { return nombre; }
                set
                {
                    nombre = value;
                }
            }

            public String Apellido
            {
                get { return apellido; }
                set { apellido = value; }
            }

            public int Id
            {
                get { return id; }
                set { id = value; }
            }

            public String NombreCompleto
            {
                get { return $"{nombre} {apellido}"; }
            }

            #endregion
        }
    }
