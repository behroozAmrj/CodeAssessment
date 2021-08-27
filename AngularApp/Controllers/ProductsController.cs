using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WingTipsToys.BusinessContract;
using WingTipsToys.Model;
using WingTipsToys.ViewModel;
using WingTipsToys.WebApp.ActionFilters;
using WingTipsToys.WebApp.Mapping;

namespace WingTipsToys.WebApp.Controllers
{
      [Auther(typeof(Human))]
      public class ProductsController : MasterApiController 
      {
            private readonly IProductBusinessContract _productBusinessService;
            private readonly IMapper _mapper;

            public ProductsController(IProductBusinessContract productBusinessService , IMapper mapper)
            {
                  _productBusinessService = productBusinessService;
                  this._mapper = mapper;
            }

            [HttpGet]
            public async Task<List<ProductViewModel>> GetProducts()
            {

                  this.attibuteLoading();
                 
                  var result = await _productBusinessService.GetAllProductsAsync();
                 // var mapResult = this._mapper.Map<List<ProductViewModel>>(result);
                  return (result);

            }

            [HttpPost]
            [GreetingTypeFilterWapper(typeof(Person))]
            public async Task<List<ProductViewModel>> SearchProduct([FromBody] ProductSearchViewModel searchValue)
            {
                  
                        

                  var result = await _productBusinessService.SearchProductByName(searchValue);
                  //var mapResult = this._mapper.Map<List<ProductViewModel>>(result);
                  return (result);
            }


            private void attibuteLoading()
            {
                  var type = typeof(ProductsController);
                  var be = (type
                         .GetMethod("SearchProduct")      
                        .GetCustomAttributes(typeof(GreetingTypeFilterWapper), false).First() as GreetingTypeFilterWapper);

                  var ii = (Person)Activator.CreateInstance(be.MyName);
                  string name = ii.PersonFamily;

                  
            }
      }
}
