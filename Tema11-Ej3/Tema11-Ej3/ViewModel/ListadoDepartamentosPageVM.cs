using Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema11_Ej3.ViewModel
{
    public class ListadoDepartamentosPageVM : clsVMBase
    {

        public ObservableCollection<ClsDepartamento> listadoDepartamentos;
        public List<ClsDepartamento> listadoDeptBL;
        public ClsDepartamento departamentoSelecionado;
        public DelegateCommand editarPersonaCommand;
        public DelegateCommand insertarPersonaCommand;
        public DelegateCommand filtrarPersonasCommand;

        public ListadoDepartamentosPageVM()
        {
            rellenarListado();
        }

        private async Task rellenarListado()
        {
            listadoDeptBL = await BL.clsListadosBL.listadoDepartamentosBL();
            // Se instancia el listado de personas
            listadoDepartamentos = new ObservableCollection<ClsDepartamento>(listadoDeptBL);
        }

        public ObservableCollection<ClsDepartamento> ListadoDepartamentos
        {
            get
            {
                return listadoDepartamentos;
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
            }
        }

    }
}
}
