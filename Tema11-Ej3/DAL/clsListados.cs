﻿using Entidades;
using Newtonsoft.Json;

namespace DAL
{
    // All the code in this file is included in all platforms.
    public class clsListados
    {

        /// <summary>
        /// Metodo que devuelve el listado de personas
        /// </summary>
        /// <returns></returns>
        public static async Task<List<ClsPersona>> listadoPersonas()
        {
            //Pido la cadena de la Uri al método estático

            string miCadenaUrl = Conexion.CadenaConexion();

            Uri miUri = new Uri($"{miCadenaUrl}Personas");

            List<ClsPersona> listadoPersonas = new List<ClsPersona>();

            HttpClient mihttpClient;

            HttpResponseMessage miCodigoRespuesta;

            string textoJsonRespuesta;

            //Instanciamos el cliente Http

            mihttpClient = new HttpClient();

            try

            {

                miCodigoRespuesta = await mihttpClient.GetAsync(miUri);

                if (miCodigoRespuesta.IsSuccessStatusCode)

                {

                    textoJsonRespuesta = await mihttpClient.GetStringAsync(miUri);

                    mihttpClient.Dispose();

                    //JsonConvert necesita using Newtonsoft.Json;

                    //Es el paquete Nuget de Newtonsoft

                    listadoPersonas =
                    JsonConvert.DeserializeObject<List<ClsPersona>>(textoJsonRespuesta);

                }

            }

            catch (Exception ex)

            {

                throw ex;

            }

            return listadoPersonas;

        }

        /// <summary>
        /// Metodo que devuelve el listado de departamentos
        /// </summary>
        /// <returns></returns>
        public static async Task<List<ClsDepartamento>> listadoDepartamentos()
        {
            //Pido la cadena de la Uri al método estático

            string miCadenaUrl = Conexion.CadenaConexion();

            Uri miUri = new Uri($"{miCadenaUrl}Departamentos");

            List<ClsDepartamento> listadoDepartamentos = new List<ClsDepartamento>();

            HttpClient mihttpClient;

            HttpResponseMessage miCodigoRespuesta;

            string textoJsonRespuesta;

            //Instanciamos el cliente Http

            mihttpClient = new HttpClient();

            try

            {

                miCodigoRespuesta = await mihttpClient.GetAsync(miUri);

                if (miCodigoRespuesta.IsSuccessStatusCode)

                {

                    textoJsonRespuesta = await mihttpClient.GetStringAsync(miUri);

                    mihttpClient.Dispose();

                    //JsonConvert necesita using Newtonsoft.Json;

                    //Es el paquete Nuget de Newtonsoft

                    listadoDepartamentos =
                    JsonConvert.DeserializeObject<List<ClsDepartamento>>(textoJsonRespuesta);

                }

            }

            catch (Exception ex)

            {

                throw ex;

            }

            return listadoDepartamentos;

        }
    }
}


