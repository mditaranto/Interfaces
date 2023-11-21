using Ejercicio4.ViewModel;

namespace Ejercicio4
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();

            BindingContext = new PersonaVM();
        }

    }
}