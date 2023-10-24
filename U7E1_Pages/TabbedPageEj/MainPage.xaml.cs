using Clases;

namespace TabbedPageEj
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Views.TabbedPageDemo());
        }

        private async void IrPage4(object sender, EventArgs e)
        {
            clsPersona clsPersona = new clsPersona();

            clsPersona.nombres = Nombre.Text;
            clsPersona.apellido = Apellidos.Text;
            await Navigation.PushAsync(new Views.Page4(clsPersona));
        }
    }
}