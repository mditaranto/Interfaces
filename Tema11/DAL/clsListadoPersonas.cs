using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class clsListadoPersonas
    {
        /// <summary>
        /// Funcion que pide a la API un listado completo de personas y lo devuelve
        /// Pre: -
        /// Post: Si no se ha podido conectar a la API devuelve una lista vacia
        /// </summary>
        /// <returns></returns>
        public static async Task<List<ClsPersona>> listadoPersonas()
        {
            //Pido la cadena de la Uri al método estático

            string miCadenaUrl = Conexion.CadenaConexion();

            Uri miUri = new Uri($"{miCadenaUrl}Persona");

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
    }
}

