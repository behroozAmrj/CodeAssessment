using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WingTipsToys.BusinessContract;
using WingTipsToys.DataAccessContract;
using WingTipsToys.Model;
using WingTipsToys.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;

namespace WingTipsToys.BusinessService
{
      public class ProductBusinessService : IProductBusinessContract
      {
            private readonly IRepository<ProductModel> _productRepository;
            private readonly ICategoryBusinessContract _categroyBuisinessService;
            private readonly IMapper _mapper;

            public ProductBusinessService(IRepository<ProductModel> ProductRepository,
                                          ICategoryBusinessContract categroyBusinessService,
                                          IMapper mapper)
            {
                  _productRepository = ProductRepository;
                  this._categroyBuisinessService = categroyBusinessService;
                  this._mapper = mapper;
            }


            #region private Methods
            private async Task<List<ProductViewModel>> getAllProductAsync(string? productName = null)
            {
                  Task<List<ProductViewModel>> tsk = Task.Factory.StartNew(() =>
                  {
                        var categoryResult = _categroyBuisinessService.GetCategorys(x => x.CategoryName == "Cars")
                                                                      .ConfigureAwait(false)
                                                                        .GetAwaiter()
                                                                        .GetResult()
                                                                       .Select(p => p.CategoryID)
                                                                       .ToList();



                        var result = _productRepository.GetAllAsync(x => categoryResult.Contains((int)x.CategoryID))
                                                                        .ConfigureAwait(false)
                                                                        .GetAwaiter()
                                                                        .GetResult()
                                                                        .ToList();



                        return (_mapper.Map<List<ProductViewModel>>(result));


                  });

                  //var q = (from qu in _productRepository.getByQuery()
                  //        join ca in (await _categroyBuisinessService.GetCategorys()).ToList()
                  //        on qu.CategoryID equals ca.CategoryID
                  //        where ca.CategoryName == "Cars"
                  //        select new
                  //        {
                  //              CategoryID = qu.CategoryID,
                  //              ProductName = qu.ProductName
                  //        }).ToList();

                  //var tsMap  = _mapper.Map<List<ProductViewModel>>(q);

                  //var cat = (await _categroyBuisinessService.GetCategorys(x => x.CategoryName == "Cars"))
                  //                                                .Select(z => z.CategoryID)
                  //                                                .ToList();


                  //var result = (await _productRepository.GetAllAsync(x => cat.Contains((int)x.CategoryID)))
                  //                                                      .ToList();



                  return (await tsk);
            }
            #endregion
            public async Task<List<ProductViewModel>> GetAllProductsAsync()
            {
                  // Expression<Func<LisProductModel>,bool>> exp = p => p.
                  //var result = (await getAllProductAsync()).ToList();
                 /// throw new Exception("test exception");
                  return (await getAllProductAsync());
            }

            public Task<ProductModel> GetProductAsync()
            {
                  throw new NotImplementedException();
            }



            public Task<List<ProductViewModel>> SearchProductByName(ProductSearchViewModel searchValue)
            {
                  Task<List<ProductViewModel>> tsk = Task.Factory.StartNew(() =>
                  {
                        var categoryResult = _categroyBuisinessService.GetCategorys(x => x.CategoryName == "Cars")
                                                                      .ConfigureAwait(false)
                                                                        .GetAwaiter()
                                                                        .GetResult()
                                                                       .Select(p => p.CategoryID)
                                                                       .ToList();

                        var result = _productRepository.GetAllAsync(x => categoryResult.Contains((int)x.CategoryID) &
                                                                        (x.ProductName.Contains(searchValue.ProductName) ||
                                                                         x.Description.Contains(searchValue.ProductName)))
                                                                              .ConfigureAwait(false)
                                                                              .GetAwaiter()
                                                                              .GetResult()
                                                                              .ToList();

                        return ((_mapper.Map<List<ProductViewModel>>(result)));
                  });
                  return (tsk);
            }
      }
}
