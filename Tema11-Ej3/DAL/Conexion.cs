using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class Conexion
    {
        /// <summary>
        /// Metodo que devuelve la cadena de conexion
        /// </summary>
        /// <returns></returns>
        public static string CadenaConexion() 
        {
            return "https://crudnervion.azurewebsites.net/api/";
        }

    }
}
