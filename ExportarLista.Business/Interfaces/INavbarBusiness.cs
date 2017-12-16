using ExportarLista.Entities;
using System.Collections.Generic;

namespace ExportarLista.Business.Interfaces
{
    public interface INavbarBusiness
    {
        IEnumerable<NavBar> navbarItems();

        IEnumerable<NavBar> obtenerTodos();

        void guardar(NavBar menu);

        List<NavBar> obtenerPadres();

        void eliminar(int id);

        NavBar obtenerPorId(int id);
    }
}
