using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WingTipsToys.Model;

namespace WingTipsToys.BusinessContract
{
      public interface ICategoryBusinessContract
      {
            Task<List<CategoryModel>> GetCategorys(Expression<Func<CategoryModel, bool>> filter = null);
            Task<CategoryModel> GetSingleCategory(CategoryModel category);
      }
}
