using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.Models
{
    internal class ClsPersona : INotifyPropertyChanged
    {

        #region atributos
        private int id;
        private string nombre;
        private string apellido;

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region constructores
        public ClsPersona()
        {
            id = 0;
            nombre = "Matias";
            apellido = "Ditaranto";
        }

        public ClsPersona(string nombre, string apellido, int idDepartamento, int id)
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
            set { nombre = value;
                OnPropertyChanged();
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
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        #endregion
    }
}
