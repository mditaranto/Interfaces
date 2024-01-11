using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BL
{
    public class clsManejadoraDepartamentosBL
    {

        /// <summary>
        /// Metodo que inserta un departamento en la BBDD segun la BL
        /// </summary>
        /// <param name="departamento"></param>
        /// <returns></returns>
        public static async Task<HttpStatusCode> insertarDepartamentoBL(ClsDepartamento departamento)
        {
            return await clsManejadoraDepartamentos.insertarDepartamento(departamento);
        }

        /// <summary>
        /// Metodo que elimina un departamento de la BBDD segun la BL
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<HttpStatusCode> eliminarDepartamentoBL(int id)
        {
            return await clsManejadoraDepartamentos.eliminarDepartamento(id);
        }

        /// <summary>
        /// Metodo que actualiza un departamento de la BBDD segun la BL
        /// </summary>
        /// <param name="departamento"></param>
        /// <returns></returns>
        public static async Task<HttpStatusCode> actualizarDepartamentoBL(ClsDepartamento departamento)
        {
            return await clsManejadoraDepartamentos.actualizarDepartamento(departamento);
        }

    }
}
