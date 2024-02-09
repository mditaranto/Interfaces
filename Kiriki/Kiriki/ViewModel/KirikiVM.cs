
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
    public class KirikiVM : clsVMBase
    {
        #region atributos privados

        private readonly HubConnection conexion;

        private int valorDado1;
        private int valorDado2;
        private String fotoDado1;
        private String fotoDado2;

        private Player jugador;
        private string textoBoton;
        private string textoBoton2;

        private bool comprobarMentira;
        private bool haComprobado;

        private DelegateCommand miente;
        private DelegateCommand tirar;
        #endregion

        #region propiedades publicas

        public int ValorDado1
        {
            get { return valorDado1; }
            set
            {
                valorDado1 = value;
                NotifyPropertyChanged("ValorDado1");
            }
        }
        public int ValorDado2
        {
            get { return valorDado2; }
            set
            {
                valorDado2 = value;
                NotifyPropertyChanged("ValorDado2");
            }
        }
        public String FotoDado1
        {
            get { return fotoDado1; }
            set
            {
                fotoDado1 = value;
                NotifyPropertyChanged("FotoDado1");
            }
        }
        public String FotoDado2
        {
            get { return fotoDado2; }
            set
            {
                fotoDado2 = value;
                NotifyPropertyChanged("FotoDado2");
            }
        }
        public DelegateCommand Miente
        {
            get { return miente; }
        }
        public DelegateCommand Tirar
        {
            get { return tirar; }
        }

        public string TextoBoton
        {
            get { return textoBoton; }
            set
            {
                textoBoton = value;
                NotifyPropertyChanged("TextoBoton");
            }
        }

        public string TextoBoton2
        {
            get { return textoBoton2; }
            set
            {
                textoBoton2 = value;
                NotifyPropertyChanged("TextoBoton2");
            }
        }

        public Player Jugador
        {
            get { return jugador; }
        }
        #endregion

        #region constructores
        public KirikiVM(string usuario)
        {
            jugador = new Player(usuario);
            conexion = new HubConnectionBuilder().WithUrl("http://localhost:5196/KirikiHub").Build();
            miente = new DelegateCommand(MienteCommandExecute, MienteCommandCanExecute);
            tirar = new DelegateCommand(TirarCommandExecute);
            textoBoton = "Mostrar dados";
            textoBoton2 = "Tirar";
            fotoDado1 = "interr.png";
            fotoDado2 = "interr.png";
            conexion.On<int, int>("Tirar", TirarDado);
            conexion.On("PasarTurno", PasarTurno);
            conexion.On("CalcularVida", CalcularVida);
            IniciarConexion();

        }

        #endregion

        #region comandos
        public async void MienteCommandExecute()
        {
            if (comprobarMentira)
            {
                await conexion.InvokeAsync("CalcularVida");
                TextoBoton = "Mostrar dados";
                TextoBoton2 = "Tirar";
                comprobarMentira = false;
                FotoDado1 = "interr.png";
                FotoDado2 = "interr.png";
                haComprobado = true;

            }
            else if (jugador.PuedeTirar && !haComprobado)
            {
                FotoDado1 = "dado" + valorDado1 + ".png";
                FotoDado2 = "dado" + valorDado2 + ".png";
                TextoBoton = "Miente";
                TextoBoton2 = "No Miente";
                comprobarMentira = true;
            }

        }

        public async void TirarCommandExecute()
        {
            if (comprobarMentira)
            {
                jugador.Vidas--;
                TextoBoton = "Mostrar dados";
                TextoBoton2 = "Tirar";
                comprobarMentira = false;
                FotoDado1 = "interr.png";
                FotoDado2 = "interr.png";
                haComprobado = true;
            }
            else if (!jugador.PuedeTirar)
            {
                TextoBoton2 = "Tirar";
                await conexion.InvokeAsync("PasarTurno");

            }
            else
            {
                TextoBoton2 = "Pasar turno";
                jugador.PuedeTirar = false;
                Random rnd = new Random();
                valorDado1 = rnd.Next(1, 6);
                valorDado2 = rnd.Next(1, 6);
                FotoDado1 = "dado" + valorDado1 + ".png";
                FotoDado2 = "dado" + valorDado2 + ".png";
                miente.RaiseCanExecuteChanged();
                await conexion.InvokeAsync("Tirar", ValorDado1, ValorDado2 );
            }
        }

        private bool MienteCommandCanExecute()
        {
            if (valorDado1 != 0 && valorDado2 != 0 && jugador.PuedeTirar)
                return true;
            else
                return false;
        }
        #endregion

        #region metodos
        private async void IniciarConexion()
        {
            await conexion.StartAsync();
        }

 
        private void CalcularVida()
        {
            Device.BeginInvokeOnMainThread(() => //para que se ejecute en el hilo principal y no explote
            {
                jugador.Vidas--;
            });
        }

        private void PasarTurno()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                jugador.PuedeTirar = true;
                NotifyPropertyChanged("PuedeTirar");
            });
        }

        private void TirarDado(int dado1, int dado2)
        {
            ValorDado1 = dado1;
            ValorDado2 = dado2;
        }
        #endregion
    }
}
