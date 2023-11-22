using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio5.Models
{
    internal class ClsPersona
    {

        #region atributos
        private int id;
        private string nombre;
        private string apellido;
        private string fechaNacimiento;
        private string direccion;
        private string telefono;
        private string foto;

        #endregion

        #region constructores
        public ClsPersona()
        {

        }
        

        public ClsPersona(string nombre, string apellido, int id)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;

        }

        public ClsPersona(string nombre, string apellido, int id, string fechaNacimiento, string direccion, string telefono, string foto)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.fechaNacimiento = fechaNacimiento;
            this.direccion = direccion;
            this.telefono = telefono;
            this.foto = foto;

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

        public string FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string Foto
        {
            get { return foto; }
            set { foto = value; }
        }

        #endregion
    }
}
