using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public static class ListadoCitas
    {

        public static ObservableCollection<Citas> GetListadoCitas()
        {
            ObservableCollection<Citas> lista = new ObservableCollection<Citas> {
                new Citas() {Cliente="Juan Manuel Sanchez", Direccion="C/Las 3000", Telefono=654789321},
                new Citas() {Cliente="Antonio toñito perez", Direccion="C/Armadura Dura", Telefono=321654987},
                new Citas() {Cliente="Juan", Direccion="C/Lejos", Telefono=987654987},
                new Citas() {Cliente="Pablo pepe", Direccion="C/En 1º", Telefono=111111111},
                new Citas() {Cliente="Matias Jefazo", Direccion="C/El mejor", Telefono=999999999},

            };

            return lista;
        }
    }
}
