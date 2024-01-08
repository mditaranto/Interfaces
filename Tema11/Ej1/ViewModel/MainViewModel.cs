using BL;
using Entidades;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace Ej1.ViewModel
{
    public class MainViewModel
    {
        #region atributos
        private ObservableCollection<ClsPersona> listadoPersonas;
        private List<ClsPersona> listadoPersonasBL;

        private bool isRunning;

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region constructores
        /// <summary>
        /// Propiedad que devuelve el listado de personas
        /// </summary>
        public ObservableCollection<ClsPersona> ListadoPersonas
        {
            get
            {
                return listadoPersonas;
            }

        }

        public MainViewModel()
        {
            // Se inicializa la variable isRunning a true
            isRunning = true;
            // Llamada al método que carga el listado de personas
            this.cargarPersonas();

        }
        #endregion

        #region funciones
        /// <summary>
        /// Función que devuelve el listado de personas de la capa BL y rellena el listadoPersonas 
        /// </summary>
        private async Task cargarPersonas()
        {
            // Llamada al método de la capa BL que devuelve el listado de personas de manera asíncrona
            listadoPersonasBL = await clsListadoPersonasBL.listadoPersonasBL();
            // Se instancia el listado de personas
            listadoPersonas = new ObservableCollection<ClsPersona>(listadoPersonasBL);

            // Se cambia el valor de isRunning a false
            isRunning = false;
            OnPropertyChanged(nameof(IsRunning)); // Coge la propiedad
            OnPropertyChanged(nameof(ListadoPersonas));
        }

        private void OnPropertyChanged(String property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        #endregion

        #region propiedades
        public bool IsRunning
        {
            get { return isRunning; }
        }

        #endregion
    }
}
