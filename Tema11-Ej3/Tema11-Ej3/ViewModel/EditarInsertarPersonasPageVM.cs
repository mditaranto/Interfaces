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
                //Da un error 400 y no se por que. Solo se me ocurre que sea porque estoy introduciendo
                // un id a la persona y devuelva error al intentar hacer un post con un id
                BL.clsManejadoraPersonaBL.insertaPersonaBL(persona);
                Shell.Current.Navigation.PopAsync();
            }
            else
            {
                BL.clsManejadoraPersonaBL.actualizarPersonaBL(persona);
                Shell.Current.Navigation.PopAsync();
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
