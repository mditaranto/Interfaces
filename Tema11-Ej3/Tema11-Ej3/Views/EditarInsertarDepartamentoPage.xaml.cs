using Tema11_Ej3.ViewModel;

namespace Tema11_Ej3.Views;

public partial class EditarInsertarDepartamentoPage : ContentPage
{
	public EditarInsertarDepartamentoPage()
	{
		InitializeComponent();
		var vm = new EditarInsertarDepartamentoPageVM();
        BindingContext = vm;
	}

	public EditarInsertarDepartamentoPage(Entidades.ClsDepartamento departamentoSeleccionado)
	{
        
        InitializeComponent();
        var vm = new EditarInsertarDepartamentoPageVM(departamentoSeleccionado);
        BindingContext = vm;
    }
}