using Kiriki.ViewModel.Sources;
using Kiriki.Views;


namespace Kiriki.ViewModel
{
    /// <summary>
    /// Clase que representa el ViewModel de la pagina de login
    /// </summary>
    public class LoginVM : clsVMBase
    {
        private string usuario;
        private DelegateCommand loginCommand;

        public LoginVM()
        {
            //Boton de login
            loginCommand = new DelegateCommand(loginExecuteAsync, loginCanExecute);
        }

        public string Usuario
        {
            set { usuario = value; NotifyPropertyChanged("Usuario"); loginCommand.RaiseCanExecuteChanged(); }
            get { return usuario; }
        }

        public DelegateCommand LoginCommand
        { get { return loginCommand; } }

        private bool loginCanExecute()
        {
            if (usuario != null)
            {
                return true;
            } else
            {
                return false;
            }
        }

        private async void loginExecuteAsync()
        {
            // Navega a la pagina de salas
            await Shell.Current.Navigation.PushAsync(new Salas(usuario));
        }

    }
}
