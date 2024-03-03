using Kiriki.ViewModel;

namespace Kiriki.Views;

public partial class Salas : ContentPage
{
	public Salas(string usuario)
	{
        InitializeComponent();
        var vm = new SalasVM(usuario);
        BindingContext = vm;
    }
}