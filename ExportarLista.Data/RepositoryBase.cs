using ExportarLista.Entities;
using ExportarLista.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace ExportarLista.Data
{
    public class RepositoryBase<T> : IRepository<T>
        where T : EntityBase
    {
        protected EFDbContext context = new EFDbContext();

        public RepositoryBase()
        {
        }

        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> query = this.context.Set<T>();
            return query;
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = this.context.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Save(T entity)
        {
            try
            {

                if (this.EntityIsNew(entity))
                {
                    this.Insert(entity);
                }
                else
                {
                    this.Update(entity);
                }
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected virtual void Insert(T entity)
        {
            this.context.Set<T>().Add(entity);
        }

        protected virtual void Update(T entity)
        {
            this.context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public virtual void Delete(Int64 key)
        {
            try
            {
                var entity = this.context.Set<T>().Find(key);
                this.context.Set<T>().Remove(entity);

                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                //TODO:
            }
        }

        public virtual IEnumerable<T> ExecuteSP(string spName, object[] parameters)
        {
            return this.context.Database.SqlQuery<T>(spName, parameters).ToList();
        }

        private Boolean EntityIsNew(T entity)
        {
            string keyName = GetPropertyNameKey();
            return entity.GetType().GetProperty(keyName).GetValue(entity, null).ToString() == "0";
        }

        private String GetPropertyNameKey()
        {
            System.Data.Entity.Core.Objects.ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;
            System.Data.Entity.Core.Objects.ObjectSet<T> set = objectContext.CreateObjectSet<T>();
            string keyNames = set.EntitySet.ElementType.KeyMembers.Select(k => k.Name).FirstOrDefault();
            return keyNames;
        }
    }
}
