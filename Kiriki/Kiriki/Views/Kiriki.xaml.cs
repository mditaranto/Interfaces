using Kiriki.ViewModel;

namespace Kiriki.Views;

public partial class Kiriki : ContentPage
{
    public Kiriki(String usuario)
    {
        InitializeComponent();
        var vm = new KirikiVM(usuario);
        BindingContext = vm;
    }
}