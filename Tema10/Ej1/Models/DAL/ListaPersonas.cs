using Ej1.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1.Models.DAL
{
    public static class ListaDePersonas
    {
        /// <summary>
        /// Funcion que devuelve una lista de personas
        /// Pre: 
        /// Post: 
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<ClsPersona> GetListadoCompletoPersonas()
        {

            ObservableCollection<ClsPersona> lista = new ObservableCollection<ClsPersona> {
                new ClsPersona() {Id = 1,Nombre="Mateo", Apellido="Aguas"},
                new ClsPersona() {Id = 2,Nombre="Manu", Apellido="Cordobes"},
                new ClsPersona() {Id = 3,Nombre="Manuel", Apellido="Cosano"},
                new ClsPersona() {Id = 4,Nombre="Manito", Apellido="Arjona"},
                new ClsPersona() {Id = 5,Nombre="Maria", Apellido="Coar"},
                new ClsPersona() {Id = 6,Nombre="Jesus", Apellido="Luque"},
                new ClsPersona() {Id = 7,Nombre="Gerardo", Apellido="Chismoso"},
                new ClsPersona() {Id = 8,Nombre="Luis", Apellido="Pocacosa"},
                new ClsPersona() {Id = 9,Nombre="Teseo", Apellido="Mortal"},
                new ClsPersona() {Id = 10,Nombre="Garen", Apellido="Pesadilla"}
            };

            return lista;

        }
    }
}
