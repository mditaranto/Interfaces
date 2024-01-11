using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class clsManejadoraDepartamentos
    {

        /// <summary>
        /// Metodo que elimina un departamento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<HttpStatusCode> eliminarDepartamento(int id)
        {


            HttpClient mihttpClient = new HttpClient();

            string miCadenaUrl = Conexion.CadenaConexion();

            Uri miUri = new Uri($"{miCadenaUrl}Departamentos/{id}");

            //Usaremos el Status de la respuesta para comprobar si ha borrado

            HttpResponseMessage miRespuesta = new HttpResponseMessage();

            try
            {

                miRespuesta = await mihttpClient.DeleteAsync(miUri);

            }

            catch (Exception ex)
            {

                throw ex;

            }
            return miRespuesta.StatusCode;
        }

        /// <summary>
        /// Metodo que inserta un departamento
        /// </summary>
        /// <param name="departamento"></param>
        /// <returns></returns>
        public static async Task<HttpStatusCode> insertarDepartamento(ClsDepartamento departamento)
        {

            HttpClient mihttpClient = new HttpClient();

            string datos;

            HttpContent contenido;

            string miCadenaUrl = Conexion.CadenaConexion();

            Uri miUri = new Uri($"{miCadenaUrl}Departamentos");

            //Usaremos el Status de la respuesta para comprobar si ha insertado

            HttpResponseMessage miRespuesta = new HttpResponseMessage();

            try
            {

                datos = JsonConvert.SerializeObject(departamento);

                contenido = new StringContent(datos, System.Text.Encoding.UTF8, "application/json");

                miRespuesta = await mihttpClient.PostAsync(miUri, contenido);

            }

            catch (Exception ex)
            {

                throw ex;

            }

            return miRespuesta.StatusCode;

        }

        /// <summary>
        /// Metodo que actualiza un departamento
        /// </summary>
        /// <param name="departamento"></param>
        /// <returns></returns>
        public static async Task<HttpStatusCode> actualizarDepartamento(ClsDepartamento departamento)
        {

            HttpClient mihttpClient = new HttpClient();

            string datos;

            HttpContent contenido;

            string miCadenaUrl = Conexion.CadenaConexion();

            Uri miUri = new Uri($"{miCadenaUrl}Departamentos/{departamento.Id}");

            //Usaremos el Status de la respuesta para comprobar si ha insertado

            HttpResponseMessage miRespuesta = new HttpResponseMessage();

            try
            {

                datos = JsonConvert.SerializeObject(departamento);

                contenido = new StringContent(datos, System.Text.Encoding.UTF8, "application/json");

                miRespuesta = await mihttpClient.PutAsync(miUri, contenido);

            }

            catch (Exception ex)
            {

                throw ex;

            }

            return miRespuesta.StatusCode;

        }
    }
}
