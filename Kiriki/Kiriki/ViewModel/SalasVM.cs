using Kiriki.Models;
using Kiriki.ViewModel.Sources;
using Kiriki.Views;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiriki.ViewModel
{
    /// <summary>
    /// Clase que representa el ViewModel de la pagina de salas
    /// </summary>
    public class SalasVM : clsVMBase
    {
        #region propiedades privadas
        private readonly HubConnection conexion;
        private DelegateCommand crearSalaCommand;
        private DelegateCommand unirseSalaCommand;
        private ObservableCollection<clsSala> salas;
        private string usuario;
        private clsSala salaSeleccionada;
        #endregion

        #region constructores
        public SalasVM(string usuario)
        {
            //Se conecta al servidor
            conexion = new HubConnectionBuilder().WithUrl("https://kirikiserver.azurewebsites.net/kirikiHub").Build();
            crearSalaCommand = new DelegateCommand(crearSalaExecute); 
            unirseSalaCommand = new DelegateCommand(unirseSalaExecute, unirseSalaCanExecute);
            // Coge el usuario del login
            this.usuario = usuario;
            salas = new ObservableCollection<clsSala>();
            conexion.On<List<string>>("SalaCreada", rellenarSalas);
            conexion.On<List<string>>("SalaUnida", rellenarSalas);
            conexion.On<List<string>>("rellenarSalas", rellenarSalas);
            IniciarConexion();
        }
        #endregion

        #region propiedades publicas
        public clsSala SalaSeleccionada
        {
            get { return salaSeleccionada; }
            set { salaSeleccionada = value; NotifyPropertyChanged("SalaSeleccionada"); unirseSalaCommand.RaiseCanExecuteChanged(); }
        }

        public ObservableCollection<clsSala> Salas
        {
            get { return salas; }
            set { salas = value; NotifyPropertyChanged("Salas"); }
        }

        public DelegateCommand CrearSalaCommand
        { get { return crearSalaCommand; } }

        public DelegateCommand UnirseSalaCommand
        { get { return unirseSalaCommand; } }
        #endregion

        #region metodos
        /// <summary>
        /// Al iniciar la conexion, se conecta al servidor y rellena las salas
        /// </summary>
        private async void IniciarConexion()
        {
            await conexion.StartAsync();
            conexion.InvokeAsync("rellenarSalas");
        }

        /// <summary>
        /// Funcion que rellena las salas, se ejecuta al iniciar, al crear una sala y al unirse a una sala
        /// </summary>
        /// <param name="salas"></param>
        public void rellenarSalas(List<string> salas)
        {
            ObservableCollection<clsSala> salasLista = new ObservableCollection<clsSala>();
            foreach (string sala in salas)
            {
                salasLista.Add(new clsSala(sala));
            }
            this.salas = salasLista;
            NotifyPropertyChanged("Salas");
        }
        #endregion

        #region comandos
        /// <summary>
        /// Funcion que crea una sala
        /// </summary>
        private async void crearSalaExecute()
        {
            conexion.InvokeAsync("CrearSala", usuario);
            await Shell.Current.Navigation.PushAsync(new KirikiPage(usuario, new clsSala(usuario)));
        }

        /// <summary>
        /// Funcion que comprueba si se puede unir a una sala
        /// </summary>
        /// <returns></returns>
        private bool unirseSalaCanExecute()
        {
            if (salaSeleccionada != null)
            {
                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// Funcion que se encarga de unirse a una sala
        /// </summary>
        private async void unirseSalaExecute()
        {
            //Se navega a la pagina de juego
            await Shell.Current.Navigation.PushAsync(new KirikiPage(usuario, salaSeleccionada));
        }
        #endregion

    }
}
