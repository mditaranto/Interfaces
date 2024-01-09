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
        #region atributos privados
        private ObservableCollection<ClsPersona> listadoPersonas;
        private List<ClsPersona> listadoPersonasBL;
        private ClsPersona personaSeleccionada;
        private DelegateCommand filtrarPersonasCommand;
        private DelegateCommand eliminarPersonaCommand;
        #endregion

        #region propiedades publicas
        public DelegateCommand EliminarPersonaCommand
        {
            get
            {
                return eliminarPersonaCommand;
            }
        }

        public DelegateCommand FiltrarPersonasCommand
        {
            get
            {
                return filtrarPersonasCommand;
            }
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
                eliminarPersonaCommand.RaiseCanExecuteChanged();
            }
        }
        #endregion

        #region constructores
        public ListadoPersonasPageVM()
        {
            rellenarListado();
            eliminarPersonaCommand = new DelegateCommand(eliminarPersonaCommand_Executed, eliminarPersonaCommand_CanExecute);
            //filtrarPersonasCommand = new DelegateCommand(filtrarPersonasCommand_Executed, filtrarPersonasCommand_CanExecute);
        }

        #endregion

        #region metodos

        private async Task rellenarListado()
        {
            listadoPersonasBL = await BL.clsListadosBL.listadoPersonasBL();
            // Se instancia el listado de personas
            listadoPersonas = new ObservableCollection<ClsPersona>(listadoPersonasBL);
            NotifyPropertyChanged("ListadoPersonas");
        }

        #endregion


        #region commands
        private bool eliminarPersonaCommand_CanExecute()
        {
            if (personaSeleccionada != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void eliminarPersonaCommand_Executed()
        {
            BL.clsManejadoraPersonaBL.insertaPersonaBL(personaSeleccionada);
        }

        #endregion

    }
}
