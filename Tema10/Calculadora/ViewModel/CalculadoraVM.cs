using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculadora.ViewModel.Utilidades;

namespace Calculadora.ViewModel
{
    public class CalculadoraVM : clsVMBase
    {
        private DelegateCommand recogerCommand;

        public CalculadoraVM()
        {
            recogerCommand = new DelegateCommand(operacionCommandExecute, operacionCommandCanExecute);

        }

        private bool operacionCommandCanExecute()
        {
            throw new NotImplementedException();
        }

        private void operacionCommandExecute()
        {
            throw new NotImplementedException();
        }
    }
}
