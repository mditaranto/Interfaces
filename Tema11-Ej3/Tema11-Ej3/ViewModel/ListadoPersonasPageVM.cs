using Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema11_Ej3.ViewModel
{
    public class ListadoPersonasPageVM : clsVMBase 
    {

        public ObservableCollection<ClsPersona> listadoPersonas;
        public List<ClsPersona> listadoPersonasBL;
        public ClsPersona personaSeleccionada;
        public DelegateCommand editarPersonaCommand;
        public DelegateCommand insertarPersonaCommand;
        public DelegateCommand filtrarPersonasCommand;

        public ListadoPersonasPageVM()
        {
            rellenarListado();
        }

        private async Task rellenarListado()
        {
            listadoPersonasBL = await BL.clsListadosBL.listadoPersonasBL();
            // Se instancia el listado de personas
            listadoPersonas = new ObservableCollection<ClsPersona>(listadoPersonasBL);
        }

        public ObservableCollection<ClsPersona> ListadoPersonas
        {
            get
            {
                return listadoPersonas;
            }
        }

        public ClsPersona PersonaSeleccionada
        {
            get
            {
                return personaSeleccionada;
            }
            set
            {
                personaSeleccionada = value;
                NotifyPropertyChanged("PersonaSeleccionada");
            }
        }

    }
}
