using Clases;

namespace TabbedPageEj.Views;

public partial class Page4 : ContentPage
{
	public Page4()
	{
		InitializeComponent();
	}

	public Page4(clsPersona persona)
	{
		
		nombre.Text = persona.nombres;
		apellido.Text = persona.apellido;

        Navigation.PopModalAsync();

    }
}