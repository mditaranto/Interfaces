using Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class clsListadoPersonasBL
    {
        /// <summary>
        /// Funcion que llama a la DAL para obtener un listado de personas, aplicando las reglas de negocio que se establezcan
        /// </summary>
        /// <returns></returns>
        public async static Task<List<ClsPersona>> listadoPersonasBL()
        {
            return await DAL.clsListadoPersonas.listadoPersonas();
        }
    }
}
 