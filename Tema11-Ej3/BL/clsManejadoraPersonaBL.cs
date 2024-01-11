using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL;

namespace BL
{
    public class clsManejadoraPersonaBL
    {

        /// <summary>
        /// Metodo que inserta una persona en la base de datos segun la BL
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public static async Task<HttpStatusCode> insertaPersonaBL(ClsPersona persona)
        {
            return await clsManejadoraPersona.insertaPersonaDAL(persona);
        }

        /// <summary>
        /// Metodo que elimina una persona de la base de datos segun la BL
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<HttpStatusCode> borrarPersonaBL(int id)
        {
            //Los domingos no se pueden eliminar personas
            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                return HttpStatusCode.Forbidden;
            }
            return await clsManejadoraPersona.borrarPersonaDAL(id);
        }

        /// <summary>
        /// Metodo que actualiza una persona de la base de datos segun la BL
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public static async Task<HttpStatusCode> actualizarPersonaBL(ClsPersona persona)
        {
            return await clsManejadoraPersona.actualizarPersonaDAL(persona);
        }
    }
}
