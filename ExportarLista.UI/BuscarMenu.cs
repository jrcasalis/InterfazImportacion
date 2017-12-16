using ExportarLista.Business.Interfaces;
using ExportarLista.Entities;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExportarLista.UI
{
    class BuscarMenu
    {
        [Dependency]
        private INavbarBusiness NavbarBusiness { get; set; }

        public void buscar()
        {
            List<NavBar> navBar = NavbarBusiness.obtenerTodos().ToList();
            foreach (NavBar menu in navBar)
            {
                Console.WriteLine("Entidad: " + menu.Id + " - " + menu.Titulo);
            }
        }
    }
}
