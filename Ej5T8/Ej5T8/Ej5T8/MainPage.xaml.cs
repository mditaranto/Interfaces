using Biblioteca;
using System.Collections.ObjectModel;

namespace Ej5T8
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            BindingContext = this;

            ObservableCollection<Persona> listaPersonas = ListaPersonas.GetListadoCompletoPersonas();
            ListaContactosView.ItemsSource = listaPersonas;
        }

    }
}