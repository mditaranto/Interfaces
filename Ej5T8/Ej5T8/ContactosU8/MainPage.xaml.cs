using Biblioteca;
using System.Collections.ObjectModel;

namespace ContactosU8
{
    public partial class MainPage : ContentPage
    {

        
        ObservableCollection<Persona> listaContactView { get; set; }
        public MainPage()
        {
            InitializeComponent();

            listaContactView = new ObservableCollection<Persona>(ListadoPersonaCompleto.ListadoCompletoPersona());

            BindingContext = this;

        }

        

    }
}