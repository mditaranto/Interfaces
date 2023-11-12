using PlacasSolares.Views;
namespace PlacasSolares

{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Funcion que envia a la lista de citas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnLoginClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaCitas());
        }
    }
}