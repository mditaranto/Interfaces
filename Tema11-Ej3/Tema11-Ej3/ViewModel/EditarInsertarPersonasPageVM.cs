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
        private bool esInsertar;
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

        #region constructores
        public EditarInsertarPersonasPageVM()
        {
            aceptarCommand = new DelegateCommand(aceptarCommand_Executed, aceptarCommand_CanExecute);
        }

        private void aceptarCommand_Executed()
        {
            if (esInsertar)
            {
                //insertar
            }
            else
            {
                //editar
            }
        }

        private bool aceptarCommand_CanExecute()
        {
            return true;
        }
        #endregion

        #region metodos
        #endregion

        #region commands

        #endregion


    }
}
