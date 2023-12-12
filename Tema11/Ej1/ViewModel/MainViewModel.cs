using BL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ej1.ViewModel
{
    public class MainViewModel
    {
        private List<ClsPersona> _listadoPersonas;
        private ObservableCollection<ClsPersona> listadoPersonas;

        public ObservableCollection<ClsPersona> ListadoPersonas
        {
            get
            {
                return _listadoPersonas;
            }
        }

        public MainViewModel()
        {
            cargarPersonas();
            
        }

        private async Task cargarPersonas()
        {
            _listadoPersonas = await clsListadoPersonasBL.listadoPersonasBL();
            listadoPersonas = new ObservableCollection<ClsPersona>(_listadoPersonas);
        }
    
    }
}
