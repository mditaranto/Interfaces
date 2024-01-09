using Ej1.Models.DAL;
using Ej1.Models.Entidades;
using Ej1.ViewModel.Utilidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1.ViewModel
{
    public class MainPageVM : clsVMBase
    {
        #region Atributos

        DelegateCommand buscarCommand;
        DelegateCommand eliminarCommand;
        ObservableCollection<ClsPersona> listaPersonas;
        ClsPersona personaSeleccionada;
        string textoABuscar;
        #endregion

        #region constructores

        public MainPageVM()
        {
            listaPersonas = ListaDePersonas.GetListadoCompletoPersonas();
            NotifyPropertyChanged("ListaPersonas");
            buscarCommand = new DelegateCommand(buscarCommandExecute, buscarCommandCanExecute);
            eliminarCommand = new DelegateCommand(eliminarCommandExecute, eliminarCommandCanExecute);
        }

        #endregion

        #region propiedades
        public DelegateCommand BuscarCommand
        {
            get
            {
                return buscarCommand;
            }

        }

        public DelegateCommand EliminarCommand
        {
            get
            {
                return eliminarCommand;
            }

        }

        public ObservableCollection<ClsPersona> ListaPersonas
        {
            get
            {
                return listaPersonas;
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
            }

        }

        public string TextoABuscar
        {
            get
            {
                return textoABuscar;
            }
            set
            {
                textoABuscar = value;
            }

        }


        #endregion

        #region metodos y funciones
        #endregion

        #region comandos
        private void eliminarCommandExecute()
        {
            listaPersonas.Remove(personaSeleccionada);
            NotifyPropertyChanged("ListaPersonas");
        }

        private bool eliminarCommandCanExecute()
        {
            bool puedeEliminar = false;

            if (personaSeleccionada != null)
            {
                puedeEliminar = true;
            }
            return puedeEliminar;
        }

        private void buscarCommandExecute()
        {
            
        }

        private bool buscarCommandCanExecute()
        {
            bool puedeBuscar = true;

            if (!string.IsNullOrEmpty(textoABuscar))
            {
                puedeBuscar = true;
            }
            return puedeBuscar;
        }
        #endregion
    }
}
