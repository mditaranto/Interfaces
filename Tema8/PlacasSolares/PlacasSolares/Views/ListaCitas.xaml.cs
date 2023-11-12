using Biblioteca;
using System.Collections.ObjectModel;

namespace PlacasSolares.Views;

public partial class ListaCitas : ContentPage
{
    /// <summary>
    /// Funcion al iniciar la pagina, coge el valor de la lista
    /// </summary>
	public ListaCitas()
	{
		InitializeComponent();

        BindingContext = this;

        ObservableCollection<Citas> listaCitas = ListadoCitas.GetListadoCitas();
        ListaCitasView.ItemsSource = listaCitas;
    }

    /// <summary>
    /// Funcion que envia a la pagina de la cita en concreto
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void irACitas(object sender, SelectedItemChangedEventArgs e)
    {
        Citas cita = e.SelectedItem as Citas;
        await Navigation.PushAsync(new CitasVista(cita));
    }
}