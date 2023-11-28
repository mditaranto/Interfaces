using Ejercicio2.Models;

namespace Ejercicio2
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            ClsPersona persona = new ClsPersona();

            BindingContext = persona;
        }
    }
}