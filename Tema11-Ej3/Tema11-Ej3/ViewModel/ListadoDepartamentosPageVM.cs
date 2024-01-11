using Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema11_Ej3.Views;

namespace Tema11_Ej3.ViewModel
{
    public class ListadoDepartamentosPageVM : clsVMBase
    {

        #region atributos privados
        private ObservableCollection<ClsDepartamento> listadoDepartamentos;
        private List<ClsDepartamento> listadoDeptBL;
        private String textoBusqueda;
        private ClsDepartamento departamentoSelecionado;
        private DelegateCommand editarDepartamentoCommand;
        private DelegateCommand insertarDepartamentoCommand;
        private DelegateCommand filtrarDepartamentosCommand;
        private DelegateCommand deleteDepartamentoCommand;
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
                filtrarDepartamentosCommand_Executed();
            }
        }

        public DelegateCommand EditarDepartamentoCommand
        {
            get
            {
                return editarDepartamentoCommand;
            }
        }

        public DelegateCommand InsertarDepartamentoCommand
        {
            get
            {
                return insertarDepartamentoCommand;
            }
        }

        public DelegateCommand DeleteDepartamentoCommand
        {
            get
            {
                return deleteDepartamentoCommand;
            }
        }

        public DelegateCommand FiltrarDepartamentosCommand
        {
            get
            {
                return filtrarDepartamentosCommand;
            }
        }

        public ObservableCollection<ClsDepartamento> ListadoDepartamentos
        {
            get
            {
                return listadoDepartamentos;
            }

            set
            {
                listadoDepartamentos = value;
                NotifyPropertyChanged("ListadoDepartamentos");
            }
        }

        public ClsDepartamento DepartamentoSeleccionada
        {
            get
            {
                return departamentoSelecionado;
            }
            set
            {
                departamentoSelecionado = value;
                NotifyPropertyChanged("PersonaSeleccionada");
                deleteDepartamentoCommand.RaiseCanExecuteChanged();
                editarDepartamentoCommand.RaiseCanExecuteChanged();
            }
        }
        #endregion

        #region constructores
        public ListadoDepartamentosPageVM()
        {
            rellenarListado();
            editarDepartamentoCommand = new DelegateCommand(editarDepartamentoCommand_Executed, editarDepartamentoCommand_CanExecute);
            insertarDepartamentoCommand = new DelegateCommand(insertarDepartamentoCommand_Executed);
            filtrarDepartamentosCommand = new DelegateCommand(filtrarDepartamentosCommand_Executed);
            deleteDepartamentoCommand = new DelegateCommand(deleteDepartamentoCommand_Executed, deleteDepartamentoCommand_CanExecute);
        }

        #endregion

        #region metodos
        /// <summary>
        /// Metodo que rellena el listado de personas
        /// </summary>
        /// <returns></returns>
        private async Task rellenarListado()
        {
            listadoDeptBL = await BL.clsListadosBL.listadoDepartamentosBL();
            // Se instancia el listado de personas
            listadoDepartamentos = new ObservableCollection<ClsDepartamento>(listadoDeptBL);
            NotifyPropertyChanged("ListadoDepartamentos");
        }
        #endregion

        #region commands
        /// <summary>
        /// Comando que comprueba si se puede ejecutar el comando de eliminar
        /// </summary>
        /// <returns></returns>
        private bool deleteDepartamentoCommand_CanExecute()
        {
            if (departamentoSelecionado != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Comando que elimina un departamento
        /// </summary>
        private void deleteDepartamentoCommand_Executed()
        {
            BL.clsManejadoraDepartamentosBL.eliminarDepartamentoBL(departamentoSelecionado.id);
            listadoDepartamentos.Remove(departamentoSelecionado);
            NotifyPropertyChanged("ListadoDepartamentos");
        }

        /// <summary>
        /// Comando que filtra los departamentos
        /// </summary>
        private void filtrarDepartamentosCommand_Executed()
        {
            listadoDepartamentos = new ObservableCollection<ClsDepartamento>(listadoDeptBL.Where(x => x.nombre.Contains(textoBusqueda)));
            NotifyPropertyChanged("ListadoDepartamentos");
        }

        /// <summary>
        /// Comando que envia a la pagina de insertar departamentos
        /// </summary>
        private async void insertarDepartamentoCommand_Executed()
        {
            await Shell.Current.Navigation.PushAsync(new EditarInsertarDepartamentoPage());
        }

        /// <summary>
        /// Comando que comprueba si se puede ejecutar el comando de editar
        /// </summary>
        /// <returns></returns>
        private bool editarDepartamentoCommand_CanExecute()
        {
            if (departamentoSelecionado != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Comando que envia a la pagina de editar departamentos
        /// </summary>
        private async void editarDepartamentoCommand_Executed()
        {
            await Shell.Current.Navigation.PushAsync(new EditarInsertarDepartamentoPage(departamentoSelecionado));
        }

        #endregion







    }
}

