using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WingTipsToys.Model;

namespace WingTipsToys.DataAccessContract
{
      public interface IRepository<T> where T : BaseEntity
      {
            Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
            Task<bool> DeleteAsync(T entity);
            Task<bool> UpdateAsync(T entity);
            Task<bool> InsetAsync(T entity);
            IQueryable<T> getByQuery();

            T Single(string storedProcedureName, DynamicParameters dynamicParameters = null);

      }
}
