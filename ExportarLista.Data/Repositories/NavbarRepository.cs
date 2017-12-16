using ExportarLista.Entities;
using ExportarLista.Services;
using System.Linq;

namespace ExportarLista.Data.Repositories
{
    public class NavbarRepository : RepositoryBase<NavBar>, INavbarRepository
    {
        public override IQueryable<NavBar> GetAll()
        {
            IQueryable<NavBar> query = context.Set<NavBar>().Include("Padre");
            return query;
        }
    }
}
