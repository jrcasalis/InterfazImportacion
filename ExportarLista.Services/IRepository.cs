using System;
using System.Linq;
using System.Collections.Generic;
using ExportarLista.Entities;

namespace ExportarLista.Services
{
    public interface IRepository<T> where T : EntityBase
    {
        IQueryable<T> GetAll();

        IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate);

        void Save(T entity);

        void Delete(Int64 key);

        IEnumerable<T> ExecuteSP(string spName, object[] parameters);
    }
}
