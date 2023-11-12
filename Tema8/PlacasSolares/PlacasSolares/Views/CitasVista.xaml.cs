using Biblioteca;

namespace PlacasSolares.Views;

public partial class CitasVista : ContentPage
{
	/// <summary>
	/// Funcion al iniciar la pagina, establece los valores de la cita
	/// a sus labels
	/// </summary>
	/// <param name="cita"></param>
	public CitasVista(Citas cita)
	{
		InitializeComponent();

		Nombre.Text = cita.Cliente;
		Direccion.Text = cita.Direccion;
		Telf.Text = "Telefono:  " + cita.Telefono.ToString();
	}

}