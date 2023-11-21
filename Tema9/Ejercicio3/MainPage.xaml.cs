using Ejercicio3.ViewModel;

namespace Ejercicio3
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