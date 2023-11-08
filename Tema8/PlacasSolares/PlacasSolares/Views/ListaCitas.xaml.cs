using Biblioteca;
using System.Collections.ObjectModel;
namespace PlacasSolares.Views;

public partial class ListaCitas : ContentPage
{
	public ListaCitas()
	{
		InitializeComponent();

        BindingContext = this;

        ObservableCollection<Citas> listaCitas = ListadoCitas.GetListadoCitas();
        ListaCitasView.ItemsSource = listaCitas;
    }

    private void irACitas(object sender, SelectedItemChangedEventArgs e)
    {

    }
}