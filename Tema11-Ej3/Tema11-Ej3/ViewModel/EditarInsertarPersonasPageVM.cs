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

        #region atributos privados
        private ClsPersona persona;
        private DelegateCommand aceptarCommand;
        #endregion

        #region propiedades publicas

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

        public DelegateCommand AceptarCommand
        {
            get
            {
                return aceptarCommand;
            }
        }

        #endregion

        public EditarInsertarPersonasPageVM()
        {
            
        }


    }
}
