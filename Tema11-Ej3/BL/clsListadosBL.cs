using Entidades;

namespace BL
{
    // All the code in this file is included in all platforms.
    public class clsListadosBL
    {

        public static async Task<List<ClsPersona>> listadoPersonasBL()
        {
            return await DAL.clsListados.listadoPersonas();
        }

        public static async Task<List<ClsDepartamento>> listadoDepartamentosBL()
        {
            return await DAL.clsListados.listadoDepartamentos();
        }

    }
}