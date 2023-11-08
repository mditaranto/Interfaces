using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public static class ListaPersonas
    {
        /// <summary>
        /// Funcion que devuelve una lista de personas
        /// Pre: 
        /// Post: 
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Persona> GetListadoCompletoPersonas()
        {

            ObservableCollection<Persona> lista = new ObservableCollection<Persona> {
                new Persona() {Nombre="Mateo", Apellido="Aguas"},
                new Persona() {Nombre="Manu", Apellido="Cordobes"},
                new Persona() {Nombre="Manuel", Apellido="Cosano"},
                new Persona() {Nombre="Manito", Apellido="Arjona"},
                new Persona() {Nombre="Maria", Apellido="Coar"},
                new Persona() {Nombre="Jesus", Apellido="Luque"},
                new Persona() {Nombre="Gerardo", Apellido="Chismoso"},
                new Persona() {Nombre="Luis", Apellido="Pocacosa"},
                new Persona() {Nombre="Teseo", Apellido="Mortal"},
                new Persona() {Nombre="Garen", Apellido="Pesadilla"}
            };

            return lista;

        }
    }
}
