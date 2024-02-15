using Kiriki.ViewModel.Sources;
using Kiriki.Views;


namespace Kiriki.ViewModel
{
    public class LoginVM : clsVMBase
    {
        private string usuario;
        private DelegateCommand loginCommand;

        public LoginVM()
        {
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
            await Shell.Current.Navigation.PushAsync(new KirikiPage(usuario));
        }

    }
}
