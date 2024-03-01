using Kiriki.Models;
using Kiriki.ViewModel.Sources;
using Kiriki.Views;
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

        public SalasVM()
        {
            conexion = new HubConnectionBuilder().WithUrl("http://localhost:5196/KirikiHub").Build();
            crearSalaCommand = new DelegateCommand(crearSalaExecute, crearSalaCanExecute);
            unirseSalaCommand = new DelegateCommand(unirseSalaExecute, unirseSalaCanExecute);
            salirSalaCommand = new DelegateCommand(salirSalaExecute, salirSalaCanExecute);
            salas = new List<clsSala>();
            conexion.On<string>("CrearSala", añadirSala);
            conexion.On<string>("SalaUnida", quitarSala);
            conexion.On<List<string>>("rellenarSalas", rellenarSalas);
            IniciarConexion();
        }

        private async void IniciarConexion()
        {
            await conexion.StartAsync();
            conexion.InvokeAsync("rellenarSala");
        }

        private void quitarSala(string sala)
        {

            Device.BeginInvokeOnMainThread(() => //para que se ejecute en el hilo principal y no explote
            {
                salas.Remove(salas.Find(x => x.Nombre == sala));
            });
        }

        private void añadirSala(string sala)
        {
            Device.BeginInvokeOnMainThread(() => //para que se ejecute en el hilo principal y no explote
            {
                salas.Add(new clsSala(sala));
                NotifyPropertyChanged("Salas");
            });
        }

        public void rellenarSalas(List<string> salas)
        {
            salas = salas.ToList();
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
            
        }

        private bool unirseSalaCanExecute()
        {
            if (salaSeleccionada != null)
            {
                return true;
            } else { return false; }
        }

        private async void unirseSalaExecute()
        {
            conexion.InvokeAsync("UnirseSala");
            await Shell.Current.Navigation.PushAsync(new KirikiPage());
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
