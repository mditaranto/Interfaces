using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio5.Models.DAL
{
    internal static class ListaPersonas
    {
        public static ObservableCollection<ClsPersona> ListaDePersonas()
        {
            return new ObservableCollection<ClsPersona>()
            {
                (new ClsPersona("Matias", "Ditaranto", 1, "01/01/2000", "Calle falsa 123", "123456789", "https://thispersondoesnotexist.com")),
                (new ClsPersona("Juan", "Perez", 2, "01/01/2000", "Calle falsa 123", "123456789", "https://thispersondoesnotexist.com")),
                (new ClsPersona("Pedro", "Gonzalez", 3, "01/01/2000", "Calle falsa 123", "123456789", "https://thispersondoesnotexist.com")),
            };
        }
    }
}
