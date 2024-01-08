using Entidades;
using Newtonsoft.Json;

namespace DAL
{
    // All the code in this file is included in all platforms.
    public class clsListados
    {

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


        public static async Task<List<ClsDepartamento>> listadoDepartamentos()
        {
            //Pido la cadena de la Uri al método estático

            string miCadenaUrl = Conexion.CadenaConexion();

            Uri miUri = new Uri($"{miCadenaUrl}Departamento");

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


