using Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema11_Ej3.Views;
using Windows.ApplicationModel.Contacts;

namespace Tema11_Ej3.ViewModel
{
    public class ListadoPersonasPageVM : clsVMBase 
    {
        #region atributos privados
        private ObservableCollection<ClsPersona> listadoPersonas;
        private List<ClsPersona> listadoPersonasBL;
        private ClsPersona personaSeleccionada;
        private String textoBusqueda;
        private DelegateCommand filtrarPersonasCommand;
        private DelegateCommand eliminarPersonaCommand;
        private DelegateCommand insertarPersonaCommand;
        private DelegateCommand editarPersonaCommand;
        #endregion

        #region propiedades publicas
        public String TextoBusqueda
        {
            get
            {
                return textoBusqueda;
            }
            set
            {
                textoBusqueda = value;
                NotifyPropertyChanged("TextoBusqueda");
                filtrarPersonasCommand_Executed();
            }
        }

        public DelegateCommand EditarPersonaCommand
        {
            get
            {
                return editarPersonaCommand;
            }
        }

        public DelegateCommand InsertarPersonaCommand
        {
            get
            {
                return insertarPersonaCommand;
            }
        }

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

            set
            {
                listadoPersonas = value;
                NotifyPropertyChanged("ListadoPersonas");
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
                editarPersonaCommand.RaiseCanExecuteChanged();
            }
        }
        #endregion

        #region constructores
        public ListadoPersonasPageVM()
        {
            rellenarListado();
            eliminarPersonaCommand = new DelegateCommand(eliminarPersonaCommand_Executed, eliminarPersonaCommand_CanExecute);
            insertarPersonaCommand = new DelegateCommand(insertarPersonaCommand_Executed);
            editarPersonaCommand = new DelegateCommand(editarPersonaCommand_Executed, editarPersonaCommand_CanExecute);
            filtrarPersonasCommand = new DelegateCommand(filtrarPersonasCommand_Executed);
            
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
        private bool editarPersonaCommand_CanExecute()
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

        private void editarPersonaCommand_Executed()
        {
            //IR a la pagina de editar
        }

        private async void insertarPersonaCommand_Executed()
        {
            await Shell.Current.Navigation.PushAsync(new EditarInsertarPersonasPage());
        }

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
            BL.clsManejadoraPersonaBL.borrarPersonaBL(personaSeleccionada.Id);
            listadoPersonas.Remove(personaSeleccionada);
            NotifyPropertyChanged("ListadoPersonas");
        }

        private void filtrarPersonasCommand_Executed()
        {
            ListadoPersonas = new ObservableCollection<ClsPersona>(listadoPersonasBL.Where(persona => persona.Nombre.Contains(textoBusqueda)));
            NotifyPropertyChanged("ListadoPersonas");
        }


        #endregion

    }
}
