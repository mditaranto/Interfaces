
using Kiriki.Models;
using Kiriki.ViewModel.Sources;
using Microsoft.AspNetCore.SignalR.Client;

namespace Kiriki.ViewModel
{
    public class KirikiVM : clsVMBase
    {
        #region atributos privados

        private readonly HubConnection conexion;

        //Valor de los dados
        private int valorDado1;
        private int valorDado2;
        private String fotoDado1;
        private String fotoDado2;

        //Jugador
        private Player jugador;

        //Texto de los botones que hay que ir cambiando
        private string textoBoton;
        private string textoBoton2;

        //Booleanos para controlar el estado del juego (Si se esta comprobando o no)
        private bool comprobarMentira;
        private bool haComprobado;

        // Botones
        private DelegateCommand miente;
        private DelegateCommand tirar;
        private DelegateCommand pasarTurno;
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

        public DelegateCommand PasarTurno
        {
            get { return pasarTurno; }
        }
        #endregion

        #region constructores
        public KirikiVM(string usuario, clsSala sala)
        {
            jugador = new Player(usuario, sala); //Se crea el jugador
            conexion = new HubConnectionBuilder().WithUrl("https://kirikiserver.azurewebsites.net/kirikiHub").Build();

            miente = new DelegateCommand(MienteCommandExecute, MienteCommandCanExecute);
            pasarTurno = new DelegateCommand(PasarTurnoCommandExecute, PasarTurnoCommandCanExecute);
            tirar = new DelegateCommand(TirarCommandExecute, TirarCommandCanExecute);

            //Se establece el valor iniciar a los botones
            textoBoton = "Mostrar dados";
            textoBoton2 = "Tirar";
            fotoDado1 = "interr.png";
            fotoDado2 = "interr.png";
            
            //Funciones que se ejecutan al recibir del servidos
            conexion.On<int, int>("Tirar", TirarDado);
            conexion.On("PasarTurno", NuevoTurno);
            conexion.On("CalcularVida", CalcularVida);
            conexion.On<string>("terminarJuego", terminarJuego);
            conexion.On("salaBorrada", salirSala);
            IniciarConexion();

        }

        #endregion

        #region comandos
        /// <summary>
        /// Comando que se encarga de comprobar si el jugador miente o no
        /// Usa 2 booleanos, uno se activaal pulsar el boton y el otro se activa al comprobar si miente o no
        /// Si quiere comprobar los dados, le da al boton y se activa el booleano, si pulsa otro boton, se activa el otro booleano
        /// de forma que solo pueda comprobar 1 vez.
        /// Esto esta hecho asi para evitarme hacer botones de mas y que se vea mas limpio
        /// </summary>
        public async void MienteCommandExecute()
        {
            //Si se esta comprobando si miente o no
            if (comprobarMentira)
            {
                //Pulsa el boton de miente por tanto se le resta una vida
                await conexion.InvokeAsync("CalcularVida", jugador.Sala.Nombre);
                //Se cambia el texto de los botones y se cambia la imagen de los dados
                TextoBoton = "Mostrar dados";
                TextoBoton2 = "Tirar";
                comprobarMentira = false; //Se desactiva el booleano por lo que los botones vuelven a hacer lo que hacian antes
                FotoDado1 = "interr.png";
                FotoDado2 = "interr.png";
                haComprobado = true; //Se activa el booleano para que no pueda volver a comprobar

            }
            
            else if (jugador.PuedeTirar && !haComprobado)
            {
                //Si pulsa el boton de miente sin haber comprobado antes
                // Se cambia el texto de los botones y se activa el booleano
                // Se revelan los dados
                FotoDado1 = "dado" + valorDado1 + ".png";
                FotoDado2 = "dado" + valorDado2 + ".png";
                TextoBoton = "Miente";
                TextoBoton2 = "No Miente";
                comprobarMentira = true; //Se activa el booleano para que sepa que esta comprobando
            }

        }

        /// <summary>
        /// Funcion que se encarga de pasar el turno al otro jugador
        /// </summary>
        /// <returns></returns>
        private bool PasarTurnoCommandCanExecute()
        {
            if (!jugador.PuedeTirar)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Funcion que se encarga de pasar el turno al otro jugador
        /// </summary>
        private async void PasarTurnoCommandExecute()
        {
            //Pasa el turno al otro jugador
            await conexion.InvokeAsync("PasarTurno", jugador.Sala.Nombre);
            TextoBoton2 = "Tirar";
            //Se ocultan los dados
            FotoDado1 = "interr.png";
            FotoDado2 = "interr.png";
            //Se cambia el estado de los botones
            tirar.RaiseCanExecuteChanged();
            miente.RaiseCanExecuteChanged();
            haComprobado = false;
        }

        public async void TirarCommandExecute()
        {
            if (comprobarMentira)
            {
                //Si pulsa el boton de tirar estando comprobando si miente o no, se le resta una vida
                // (Este boton seria "no miente")
                jugador.Vidas--;
                NotifyPropertyChanged("Jugador");
                comprobarVida(); //Se comprueba si ha perdido

                //Se cambia el texto de los botones y se cambia la imagen de los dados
                TextoBoton = "Mostrar dados";
                TextoBoton2 = "Tirar";
                comprobarMentira = false;
                FotoDado1 = "interr.png";
                FotoDado2 = "interr.png";
                haComprobado = true;
            }
            else
            {
                //Si pulsa el boton de tirar sin comprobar
                jugador.PuedeTirar = false; //No puede tirar mas

                //Se calcula un valor aleatorio para los dados
                Random rnd = new Random();
                valorDado1 = rnd.Next(1, 6);
                valorDado2 = rnd.Next(1, 6);
                FotoDado1 = "dado" + valorDado1 + ".png";
                FotoDado2 = "dado" + valorDado2 + ".png";
                miente.RaiseCanExecuteChanged();
                pasarTurno.RaiseCanExecuteChanged();
                //Se envian los dados
                await conexion.InvokeAsync("Tirar", ValorDado1, ValorDado2, jugador.Sala.Nombre);
            }
        }

        /// <summary>
        /// Si no ha tirado, puede tirar
        /// </summary>
        /// <returns></returns>
        private bool TirarCommandCanExecute()
        {
            if (jugador.PuedeTirar)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Si no ha tirado, puede comrpobar si miente
        /// </summary>
        /// <returns></returns>
        private bool MienteCommandCanExecute()
        {
            if (jugador.PuedeTirar)
                return true;
            else
                return false;
        }
        #endregion

        #region metodos
        /// <summary>
        /// Funcion que se ejecuta al iniciar la conexion
        /// </summary>
        public async void IniciarConexion()
        {
            await conexion.StartAsync();
            //Se une a la sala
            await conexion.InvokeAsync("UnirseSala", jugador.Sala.Nombre);
            //Se asigna el turno y se borra la sala si ya hay 2 jugadores
            await conexion.InvokeAsync("asignarTurno", jugador.Sala.Nombre);

        }

        /// <summary>
        /// Funcion que se encarga de terminar el juego
        /// </summary>
        /// <param name="perdedor"></param>
        [Obsolete]
        public void terminarJuego(string perdedor)
        {
            Device.BeginInvokeOnMainThread(async () => //para que se ejecute en el hilo principal y no explote
            {
                //Alert para mostrar que ha terminado el juego
                bool answer = await App.Current.MainPage.DisplayAlert("Ha perdido el jugador" + perdedor, "¿Quieres la revancha?", "Yes", "No");
                if (answer)
                {
                    jugador.Vidas = 3;
                    NotifyPropertyChanged("Jugador");
                }
                else
                {
                    //cerrar grupo
                    await conexion.InvokeAsync("borrarSala", jugador.Sala.Nombre);
                    salirSala();
                }
            });
        }

        /// <summary>
        /// Funcion que se encarga de calcular la vida del jugador
        /// Se ejecuta cuando ha mentido y le resta 1 vida
        /// </summary>
        [Obsolete]
        public void CalcularVida()
        {
            Device.BeginInvokeOnMainThread(() => //para que se ejecute en el hilo principal y no explote
            {
                jugador.Vidas--;
                NotifyPropertyChanged("Jugador");
                comprobarVida();
            });
        }

        /// <summary>
        /// Funcion que da el turno al jugador y levanta los botones
        /// </summary>
        [Obsolete]
        public void NuevoTurno()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                jugador.PuedeTirar = true;
                NotifyPropertyChanged("PuedeTirar");
                tirar.RaiseCanExecuteChanged();
                miente.RaiseCanExecuteChanged();
                pasarTurno.RaiseCanExecuteChanged();
            });
        }

        /// <summary>
        /// Funcion que recibe los dados del servidor
        /// </summary>
        /// <param name="dado1"></param>
        /// <param name="dado2"></param>
        public void TirarDado(int dado1, int dado2)
        {
            ValorDado1 = dado1;
            ValorDado2 = dado2;
        }

        /// <summary>
        /// Funcion que comprueba si el jugador ha perdido
        /// </summary>
        public void comprobarVida()
        {
            if (jugador.Vidas <= 0)
            {
                conexion.InvokeAsync("terminarJuego", jugador.Usuario, jugador.Sala.Nombre);
            }
        }

        /// <summary>
        /// Funcion que se encarga de salir de la sala
        /// </summary>
        public void salirSala()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Shell.Current.Navigation.PopAsync();
                conexion.InvokeAsync("rellenarSalas");
            });
        }
        #endregion
    }
}
