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

    private async void irACitas(object sender, SelectedItemChangedEventArgs e)
    {
        Citas cita = e.SelectedItem as Citas;
        await Navigation.PushAsync(new CitasVista(cita));
    }
}