using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class RepositoryBase<T> :IRepositoryBase<T> where T : class
    {
        public SchoolContext SchoolContext { get; set; }
        public RepositoryBase(SchoolContext schoolContext)
        {
            SchoolContext = schoolContext;
        }
        public IQueryable<T> FindAll()
        {
            return SchoolContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T,bool>> expression)
        {
            return SchoolContext.Set<T>().Where(expression).AsNoTracking();
        }
        public void Create(T entity)
        {
            SchoolContext.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            SchoolContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            SchoolContext.Set<T>().Remove(entity);
        }
    }
}
