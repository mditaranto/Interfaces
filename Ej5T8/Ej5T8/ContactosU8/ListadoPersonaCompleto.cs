using Biblioteca;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactosU8
{
    public static class ListadoPersonaCompleto
    {
        /// <summary>
        /// Función que devuelve un listado completo de las personas
        /// </summary>
        /// <returns>Listado de personas</returns>
        public static ObservableCollection<Persona> ListadoCompletoPersona()
        {
            ObservableCollection<Persona> listaPersonas = new ObservableCollection<Persona>{
                new Persona() { Nombre = "Juanma", Apellido = "Sanchez" },
                new Persona() { Nombre = "David", Apellido = "De Isla" },
                new Persona() { Nombre = "Raul", Apellido = "Ruiz" },
                new Persona() { Nombre = "Alejandro", Apellido = "Jimenez" },
                new Persona() { Nombre = "Felix", Apellido = "Dominguez" },
                new Persona() { Nombre = "Diego", Apellido = "Limon" },
                new Persona() { Nombre = "Juanje", Apellido = "Alonso" },
                new Persona() { Nombre = "Angel", Apellido = "Mancilla" },
                new Persona() { Nombre = "Nicolas", Apellido = "Nuñez" },
                new Persona() { Nombre = "Auxi", Apellido = "Caballero" }

            };

            return listaPersonas;
        }

    }
}
