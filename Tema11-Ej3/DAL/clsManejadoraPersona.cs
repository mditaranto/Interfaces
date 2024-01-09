using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Entidades;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DAL
{
    public class clsManejadoraPersona
    {

        public static async Task<HttpStatusCode> insertaPersonaDAL(ClsPersona persona)

        {

            HttpClient mihttpClient = new HttpClient();

            string datos;

            HttpContent contenido;

            string miCadenaUrl = Conexion.CadenaConexion();

            Uri miUri = new Uri($"{miCadenaUrl}Personas");

            //Usaremos el Status de la respuesta para comprobar si ha insertado

            HttpResponseMessage miRespuesta = new HttpResponseMessage();

            try

            {

                datos = JsonConvert.SerializeObject(persona);

                contenido = new StringContent(datos, System.Text.Encoding.UTF8, "application/json");

                miRespuesta = await mihttpClient.PostAsync(miUri, contenido);

            }

            catch (Exception ex)

            {

                throw ex;

            }

            return miRespuesta.StatusCode;

        }

        public async Task<HttpStatusCode> borrarPersonaDAL(int id)

        {

            HttpClient mihttpClient = new HttpClient();

            string miCadenaUrl = Conexion.CadenaConexion();

            Uri miUri = new Uri($"{miCadenaUrl}Personas/{id}");

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
    }

}
