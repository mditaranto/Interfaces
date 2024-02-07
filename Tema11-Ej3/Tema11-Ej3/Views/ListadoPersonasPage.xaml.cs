namespace Tema11_Ej3.Views;

public partial class ListadoPersonasPage : ContentPage
{
	public ListadoPersonasPage()
	{
		InitializeComponent();
        var vm = new Tema11_Ej3.ViewModel.ListadoPersonasPageVM();
        BindingContext = vm;
    }
}