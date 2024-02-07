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
            #region atributos privados
            private ClsDepartamento departamento;
            private DelegateCommand aceptarCommand;
            private bool esInsertar;
            #endregion

            #region propiedades publicas
            public DelegateCommand AceptarCommand
            {
                get
                {
                    return aceptarCommand;
                }
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
            #endregion

            #region constructores
            public EditarInsertarDepartamentoPageVM()
            {
                this.departamento = new ClsDepartamento();
                esInsertar = true;
                aceptarCommand = new DelegateCommand(aceptarCommand_Executed, aceptarCommand_CanExecute);
            }

            public EditarInsertarDepartamentoPageVM(ClsDepartamento departamento)
            {
                this.departamento = departamento;
                esInsertar = false;
                aceptarCommand = new DelegateCommand(aceptarCommand_Executed, aceptarCommand_CanExecute);
            }


            #endregion

            #region commands
            /// <summary>
            /// Comando que llama al metodo aceptarCommand_Executed
            /// </summary>
            /// <returns></returns>
            private bool aceptarCommand_CanExecute()
            {
                return true;
            }
               
            /// <summary>
            /// Comando que llama al metodo insertarDepartamentoBL o actualizarDepartamentoBL de la capa BL
            /// </summary>
            private void aceptarCommand_Executed()
            {
                if (esInsertar)
                {
                    BL.clsManejadoraDepartamentosBL.insertarDepartamentoBL(departamento);
                    Shell.Current.Navigation.PopAsync();
                }
                else
                {
                    BL.clsManejadoraDepartamentosBL.actualizarDepartamentoBL(departamento);
                    Shell.Current.Navigation.PopAsync();
                }
            }
            #endregion

    }
}
