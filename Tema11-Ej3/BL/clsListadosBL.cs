using Entidades;

namespace BL
{
    // All the code in this file is included in all platforms.
    public class clsListadosBL
    {
        /// <summary>
        /// Metodo que devuelve el listado de personas con la BL aplicada
        /// </summary>
        /// <returns></returns>
        public static async Task<List<ClsPersona>> listadoPersonasBL()
        {
            //Los viernes y sabados el listado sera solo de personas que tengan mas de 18 años
            List<ClsPersona> listado = await DAL.clsListados.listadoPersonas();
            int Edad = 0;
            foreach (ClsPersona persona in listado)
            {
                Edad = DateTime.Now.Year - persona.FechaNacimiento.Year;
                if (DateTime.Now.DayOfWeek == DayOfWeek.Friday || DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
                {
                    if (Edad < 18)
                    {
                        listado.Remove(persona);
                    }
                }
            }
            return await DAL.clsListados.listadoPersonas();
        }

        /// <summary>
        /// Metodo que devuelve el listado de departamentos con la BL aplicada
        /// </summary>
        /// <returns></returns>
        public static async Task<List<ClsDepartamento>> listadoDepartamentosBL()
        {
            return await DAL.clsListados.listadoDepartamentos();
        }

    }
}