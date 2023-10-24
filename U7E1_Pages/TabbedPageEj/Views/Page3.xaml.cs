namespace TabbedPageEj.Views;

public partial class Page3 : ContentPage
{
	public Page3()
	{
		InitializeComponent();
	}

    private async void IrAMain(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}