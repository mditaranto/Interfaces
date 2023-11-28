using Clases;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ejercicio4.ViewModel
{
    internal class PersonaVM : ClsPersona, INotifyPropertyChanged
    {
        public PersonaVM() : base()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public String Nombre
        {
            get { return base.Nombre; }
            set
            {
                base.Nombre = value;
                if (value.Contains("n"))
                {
                    base.Apellido = "";
                }
                OnPropertyChanged("Apellido");
            }
        }

        public String Apellido
        {
            get { return base.Apellido; }
            set { base.Apellido = value;
                if (value.Contains("n"))
                {
                    base.Nombre = "";
                }   
                OnPropertyChanged("Nombre");
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
