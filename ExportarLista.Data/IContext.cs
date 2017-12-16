using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ExportarLista.Entities;

namespace ExportarLista.Data
{
    public interface IContext
    {
        int SaveChanges();

        DbEntityEntry Entry(object entity);

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Database Database { get; }

        #region Entities

        //DbSet<F0101> F0101s { get; set; }
        //DbSet<F0413> F0413s { get; set; }
        //DbSet<F0414> F0414s { get; set; }

        //DbSet<NavBar> Menus { get; set; }

        #endregion
    }
}
