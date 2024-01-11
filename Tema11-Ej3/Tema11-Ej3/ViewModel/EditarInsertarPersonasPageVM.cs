using BL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema11_Ej3.ViewModel
{
    public class EditarInsertarPersonasPageVM : clsVMBase
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
           
            esInsertar = true;
            persona = new ClsPersona();
            aceptarCommand = new DelegateCommand(aceptarCommand_Executed, aceptarCommand_CanExecute);
        }

        public EditarInsertarPersonasPageVM(ClsPersona persona)
        {
            this.persona = persona;
            esInsertar = false;
            aceptarCommand = new DelegateCommand(aceptarCommand_Executed, aceptarCommand_CanExecute);
        }

        #endregion

        #region commands
        /// <summary>
        /// Comando que llama al metodo insertarPersonaBL o actualizarPersonaBL de la capa BL
        /// </summary>
        private void aceptarCommand_Executed()
        {
            if (esInsertar)
            {
                BL.clsManejadoraPersonaBL.insertaPersonaBL(persona);
            }
            else
            {
                BL.clsManejadoraPersonaBL.actualizarPersonaBL(persona);
            }
        }

        /// <summary>
        /// Comando que devuelve true siempre
        /// </summary>
        /// <returns></returns>
        private bool aceptarCommand_CanExecute()
        {
            return true;
        }
        #endregion


    }
}
