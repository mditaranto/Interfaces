using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema11_Ej3.ViewModel
{
    public class EditarInsertarPersonasPageVM
    {

        public ClsPersona persona;
        public DelegateCommand aceptarCommand;

        public EditarInsertarPersonasPageVM()
        {
            
        }

        public ClsPersona Persona
        {
            get
            {
                return persona;
            }
            set
            {
                persona = value;
            }
        }

    }
}
