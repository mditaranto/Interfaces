using Ej1.ViewModel;

namespace Ej1.Views
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageVM();
        }
    }
}