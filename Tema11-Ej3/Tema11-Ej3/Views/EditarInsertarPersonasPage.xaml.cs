namespace Tema11_Ej3.Views;

public partial class EditarInsertarPersonasPage : ContentPage
{
    public EditarInsertarPersonasPage()
    {
        InitializeComponent();
        var vm = new Tema11_Ej3.ViewModel.EditarInsertarPersonasPageVM();
        BindingContext = vm;
    }

    public EditarInsertarPersonasPage(Entidades.ClsPersona personaSeleccionada)
	{
        
        InitializeComponent();
        var vm = new Tema11_Ej3.ViewModel.EditarInsertarPersonasPageVM(personaSeleccionada);
        BindingContext = vm;
	}
}