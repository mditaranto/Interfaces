using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_2._0
{
    public class Class1
    {

        #region atributos
        private string nombres;
        private string apellidos;
        #endregion

        #region constructores
        public Class1()
        {
            nombres = string.Empty;
            apellidos = string.Empty;
        }

        public Class1(String nombres, String apellidos)
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
