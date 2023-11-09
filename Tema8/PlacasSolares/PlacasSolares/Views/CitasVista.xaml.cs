using Biblioteca;

namespace PlacasSolares.Views;

public partial class CitasVista : ContentPage
{
	public CitasVista(Citas cita)
	{
		InitializeComponent();

		Nombre.Text = cita.Cliente;
		Direccion.Text = cita.Direccion;
		Telf.Text = "Telefono:  " + cita.Telefono.ToString();
	}

    private void Switch_Toggled(object sender, ToggledEventArgs e)
    {

    }
}