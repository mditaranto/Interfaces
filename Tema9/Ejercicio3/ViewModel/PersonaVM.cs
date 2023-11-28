using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Clases;

namespace Ejercicio3.ViewModel
{
    internal class PersonaVM : INotifyPropertyChanged
    {

        private ClsPersona persona;
        private string nombre;
        private string apellido;

        public event PropertyChangedEventHandler PropertyChanged;

        public String Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                OnPropertyChanged();
            }
        }

        public String Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public PersonaVM() {

            nombre = persona.Nombre;
        
        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
