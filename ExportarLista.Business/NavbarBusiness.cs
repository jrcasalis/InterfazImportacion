using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.Practices.Unity;
using ExportarLista.Business.Interfaces;
using ExportarLista.Entities;
using ExportarLista.Services;

namespace ExportarLista.Business
{
    public class NavbarBusiness : INavbarBusiness
    {
        [Dependency]
        public INavbarRepository NavbarRepository { get; set; }

        public void guardar(NavBar menu)
        {
            var menuOriginal = NavbarRepository.FindBy(x => x.Id == menu.Id).FirstOrDefault();
            
            NavbarRepository.Save(menu);
        }

        public IEnumerable<NavBar> navbarItems()
        {
            return this.NavbarRepository.GetAll().ToList();
        }

        public List<NavBar> obtenerPadres()
        {
            return NavbarRepository.FindBy(p => p.EsPadre == true).ToList();
        }

        public NavBar obtenerPorId(int id)
        {
            var navBar = this.NavbarRepository.FindBy(x => x.Id == id).FirstOrDefault();
            return navBar;
        }

        public IEnumerable<NavBar> obtenerTodos()
        {
            try
            {
                var navBar = NavbarRepository.GetAll().ToList();
                return navBar;
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        public void eliminar(int id)
        {
            NavbarRepository.Delete(id);
        }
    }
}
