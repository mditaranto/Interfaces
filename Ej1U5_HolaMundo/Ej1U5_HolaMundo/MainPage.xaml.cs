using Clases;

namespace Ej1U5_HolaMundo
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            String nombre1 = nombre.Text;

            string result = await DisplayPromptAsync("", "Introduce tu apellido: ");

            await DisplayAlert("Hola!!", nombre1 + " " +result, "ok");

            saludo.Text = $"Hola {nombre1} {result}";
        }
    }
}