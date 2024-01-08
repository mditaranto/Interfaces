﻿namespace DAL
{
    public class Conexion
    {
        /// <summary>
        /// Funcion que devuelve la cadena de la URL de la API
        /// </summary>
        /// <returns></returns>
        public static string CadenaConexion() 
        {
            return "https://crudmati.azurewebsites.net/API/";
        }
    }
}