using Kiriki.ViewModel;

namespace Kiriki.Views;

public partial class KirikiPage : ContentPage
{
    public KirikiPage(String usuario)
    {
        InitializeComponent();
        var vm = new KirikiVM(usuario);
        BindingContext = vm;
    }
}