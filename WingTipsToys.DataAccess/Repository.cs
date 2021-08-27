using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WingTipsToys.DataAccessContract;
using WingTipsToys.Model;

namespace WingTipsToys.DataAccess
{
      public class Repository<T> : IRepository<T> where T : BaseEntity
      {
            private readonly ApplicationDBContext _appDBContext;
            private DbSet<T> _dbEntity;
            public Repository(ApplicationDBContext appDBContext)
            {
                  _appDBContext = appDBContext;
                  _dbEntity = _appDBContext.Set<T>();
            }
            public Task<bool> DeleteAsync(T entity)
            {
                  _dbEntity.Remove(entity);
                  _appDBContext.SaveChanges();
                  return (Task.FromResult(true));
            }


            public Task<bool> UpdateAsync(T entity)
            {
                  var updatedEntity = _dbEntity.Find(entity);
                  if (updatedEntity != null)
                  {
                        _appDBContext.Entry(updatedEntity)
                                          .CurrentValues
                                          .SetValues(entity);

                        //_appDBContext.SaveChanges();
                        return (Task.FromResult(true));
                  }
                  else
                        return (Task.FromResult(false));
                                                
            }

            public IQueryable<T> getByQuery() => this._dbEntity;

            public Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
            {
                  if (filter == null)
                        return (_dbEntity.ToListAsync());
                  return (_dbEntity.Where(filter).ToListAsync());
            }

            public Task<bool> InsetAsync(T entity)
            {
                  _dbEntity.Add(entity);
                  _appDBContext.SaveChanges();
                  return (Task.FromResult(true));
            }

            public T Single(string storedProcedureName, DynamicParameters dynamicParameters = null)
            {
                  throw new NotImplementedException();
            }
      }
}
