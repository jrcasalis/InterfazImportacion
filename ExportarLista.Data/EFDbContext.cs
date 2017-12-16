using ExportarLista.Entities;
using System.Data.Entity;

namespace ExportarLista.Data
{
    public class EFDbContext : DbContext, IContext
    {

        public EFDbContext()
            : base()
        {
            //seteando esto no vuelve a generar las tablas en la bd
            Database.SetInitializer<EFDbContext>(null);

            this.Database.Initialize(true);

            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;      
        }

        //public DbSet<NavBar> Menus { get; set; }
        //public DbSet<F0101> F0101s { get; set; }
        //public DbSet<F0413> F0413s { get; set; }
        //public DbSet<F0414> F0414s { get; set; }


    }
}
