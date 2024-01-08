using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema11_Ej3.ViewModel
{
    public class EditarInsertarDepartamentoPageVM
    {
        public class EditarInsertarPersonasPageVM
        {

            public ClsDepartamento departamento;
            public DelegateCommand aceptarCommand;

            public EditarInsertarPersonasPageVM()
            {

            }

            public ClsDepartamento Departamento
            {
                get
                {
                    return departamento;
                }
                set
                {
                    departamento = value;
                }
            }

        }
    }
}
