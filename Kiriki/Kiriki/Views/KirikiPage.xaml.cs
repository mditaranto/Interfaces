using Kiriki.Models;
using Kiriki.ViewModel;

namespace Kiriki.Views;

public partial class KirikiPage : ContentPage
{
    public KirikiPage(String usuario, clsSala sala)
    {
        InitializeComponent();
        var vm = new KirikiVM(usuario, sala);
        BindingContext = vm;
    }
}