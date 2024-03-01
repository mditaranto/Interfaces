using Kiriki.Models;
using Kiriki.ViewModel.Sources;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiriki.ViewModel
{
    public class SalasVM : clsVMBase
    {

        private readonly HubConnection conexion;
        private DelegateCommand crearSalaCommand;
        private DelegateCommand unirseSalaCommand;
        private DelegateCommand salirSalaCommand;
        private List<clsSala> salas;
        private clsSala salaSeleccionada;
        //private DelegateCommand verSalasCommand;

        public SalasVM()
        {
            conexion = new HubConnectionBuilder().WithUrl("http://localhost:5196/KirikiHub").Build();
            crearSalaCommand = new DelegateCommand(crearSalaExecute, crearSalaCanExecute);
            unirseSalaCommand = new DelegateCommand(unirseSalaExecute, unirseSalaCanExecute);
            salirSalaCommand = new DelegateCommand(salirSalaExecute, salirSalaCanExecute);
            salas = new List<clsSala>();
            conexion.On<string>("CrearSala", añadirSala);
        }

        private void añadirSala(string sala)
        {
            salas.Add(new clsSala(sala));
            NotifyPropertyChanged("Salas");
        }

        public void rellenarSalas()
        {
            //Rellena salas del servidor
            NotifyPropertyChanged("Salas");
        }

        public clsSala SalaSeleccionada
        {
            get { return salaSeleccionada; }
            set { salaSeleccionada = value; NotifyPropertyChanged("SalaSeleccionada"); }
        }

        public List<clsSala> Salas
        {
            get { return salas; }
        }

        public DelegateCommand CrearSalaCommand
        { get { return crearSalaCommand; } }

        public DelegateCommand UnirseSalaCommand
        { get { return unirseSalaCommand; } }

        public DelegateCommand SalirSalaCommand
        { get { return salirSalaCommand; } }
       /* public DelegateCommand VerSalasCommand
        { get { return verSalasCommand; } }*/

        private bool crearSalaCanExecute()
        {
            return true;
        }

        private void crearSalaExecute()
        {
            throw new NotImplementedException();
        }

        private bool unirseSalaCanExecute()
        {
            return true;
        }

        private void unirseSalaExecute()
        {
            throw new NotImplementedException();
        }

        private bool salirSalaCanExecute()
        {
            return true;
        }

        private void salirSalaExecute()
        {
            throw new NotImplementedException();
        }

    }
}
