using Kiriki.ViewModel.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiriki.ViewModel
{
    public class LoginVM : clsVMBase
    {
        private string usuario;
        private DelegateCommand loginCommand;

        public LoginVM()
        {
            loginCommand = new DelegateCommand(loginCanExecute());
        }

        private Action loginCanExecute()
        {
            
        }
    }
}
