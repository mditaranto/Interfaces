namespace ExamenDI
{
    public partial class MainPage : ContentPage
    {
        //Variable para los errores
        private int errores = 0;
        //Variables para los aciertos
        private Boolean adivinada1 = false;
        private Boolean adivinada2 = false;
        private Boolean adivinada3 = false;

        public MainPage()
        {
            InitializeComponent();

        }

        //Queria buscar alguna manera de no hacer 7 tapevents diferente con alguna funcion o algo, pero no me ha dado tiempo

        /// <summary>
        /// Funcion que añade un error al precionar en la imagen
        /// Pre: 
        /// Post:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Foto1tap(object sender, TappedEventArgs e)
        {
            errores++;
            ErroresCont.IsVisible = true;
            ErroresCont.Text = "Errores: " + errores.ToString();
            Terminar();
        }

        /// <summary>
        /// Funcion que añade un error al precionar en la imagen 2
        /// Pre: 
        /// Post:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Foto2tap(object sender, TappedEventArgs e)
        {
            errores++;
            ErroresCont.IsVisible = true;
            ErroresCont.Text = "Errores: " + errores.ToString();
            Terminar();
        }
        /// <summary>
        /// Funcion que revela la pista acertada
        /// Pre: 
        /// Post:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            pista1.Opacity = 100;
            pista21.Opacity = 100;
            adivinada1 = true;

            Terminar();
        }

        /// <summary>
        /// Funcion que revela la pista acertada
        /// Pre: 
        /// Post:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
        {
            pista2.Opacity = 100;
            pista22.Opacity = 100;
            adivinada2 = true;

            Terminar();
        }

        /// <summary>
        /// Funcion que revela la pista acertada
        /// Pre: 
        /// Post:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapGestureRecognizer_Tapped_2(object sender, TappedEventArgs e)
        {
            pista3.Opacity = 100;
            pista23.Opacity = 100;  
            adivinada3 = true;

            Terminar();
        }

        /// <summary>
        /// Funcion que revela la pista acertada
        /// Pre: 
        /// Post:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapGestureRecognizer_Tapped_3(object sender, TappedEventArgs e)
        {
            pista21.Opacity = 100;
            pista1.Opacity = 100;
            adivinada1 = true;

            Terminar();
        }

        /// <summary>
        /// Funcion que revela la pista acertada
        /// Pre: 
        /// Post:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapGestureRecognizer_Tapped_4(object sender, TappedEventArgs e)
        {
            pista22.Opacity = 100;
            pista2.Opacity = 100;
            adivinada2 = true;

            Terminar();
        }

        /// <summary>
        /// Funcion que revela la pista acertada
        /// Pre: 
        /// Post:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapGestureRecognizer_Tapped_5(object sender, TappedEventArgs e)
        {
            pista23.Opacity = 100;
            pista3.Opacity = 100;
            adivinada3 = true;

            Terminar();
        }

        /// <summary>
        /// Funcion que envia a la vista del final y envia un texto segun los resultados del jugador
        /// Pre: que haya cometido 3 errores o aciertos
        /// Post: 
        /// </summary>
        private async void Terminar()
        {
            String texto = "";
            if (errores == 3)
            {
                texto = "Has perdido :(";
                await Navigation.PushAsync(new FinPartida(texto));
            }
            else if (adivinada1 == true &&  adivinada2 == true && adivinada3 == true)
            {
                texto = "Enhorabuena!! Has ganado!!";
                await Navigation.PushAsync(new FinPartida(texto));
            }
        }

      
    }
}