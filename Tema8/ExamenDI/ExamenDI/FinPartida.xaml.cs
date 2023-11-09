namespace ExamenDI;

public partial class FinPartida : ContentPage
{
	public FinPartida(String texto)
	{
		InitializeComponent();
		//Recoge el texto enviado
		textoFin.Text = texto;
	}

	/// <summary>
	/// Funcion que al pulsar un boton vuelve a la vista anterior
	/// Pre:
	/// Post:
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new MainPage());
    }
}