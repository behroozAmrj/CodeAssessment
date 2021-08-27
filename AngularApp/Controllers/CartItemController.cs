using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WingTipsToys.BusinessContract;
using WingTipsToys.ViewModel;
using WingTipsToys.ViewModel.CartItemsViewModels;
using WingTipsToys.WebApp.ActionFilters;

namespace WingTipsToys.WebApp.Controllers
{
      
      public class CartItemController : MasterApiController
      {
            private readonly IMapper _mapper;
            private readonly ICartItemBusinessContract _cartItemBusinessService;

            public CartItemController(IMapper mapper , ICartItemBusinessContract cartItemBusinessService)
            {
                  this._mapper = mapper;
                  this._cartItemBusinessService = cartItemBusinessService;
            }

            [HttpGet]
            public async Task<List<CartItemViewModel>> GetCartItem()
            {
                  var result =  await _cartItemBusinessService.GetAllCartItemAsync();
                  return (result);
            }

            [HttpPost]
            public async Task<bool> InsertCartItem([FromBody]CartItemInsertRM cartItem)
            {
                  
                  return( await _cartItemBusinessService.InsertCartItem(this._mapper.Map<Model.CartItemModel>(cartItem)));
            }
      }
}
