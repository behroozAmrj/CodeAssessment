using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WingTipsToys.BusinessContract;
using WingTipsToys.DataAccessContract;
using WingTipsToys.Model;

namespace WingTipsToys.BusinessService
{
      public class CategoryBusinessService : ICategoryBusinessContract
      {
            private readonly IRepository<CategoryModel> _categoryRespository;

            public CategoryBusinessService(IRepository<CategoryModel> repository)
            {
                  this._categoryRespository = repository;
            }
            //public Task<List<CategoryModel>> GetCategorys()
            //{
            //      var result = _categoryRespository.GetAllAsync();
            //      return (result);
            //}

            public Task<List<CategoryModel>> GetCategorys(Expression<Func<CategoryModel, bool>> filter = null)
            {
                  var result = _categoryRespository.GetAllAsync(filter);
                  return (result);
            }

            public Task<CategoryModel> GetSingleCategory(CategoryModel category)
            {
                  //var singleResult = _categoryRespository.GetSingleAsync<int>(category.CategoryID);
                  return (Task.FromResult(new CategoryModel()));
            }
      }
}
