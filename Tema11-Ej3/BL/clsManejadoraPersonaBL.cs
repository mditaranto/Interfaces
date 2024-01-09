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

        public static async Task<HttpStatusCode> insertaPersonaBL(ClsPersona persona)
        {
            return await clsManejadoraPersona.insertaPersonaDAL(persona);
        }

    }
}
