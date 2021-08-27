using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WingTipsToys.BusinessContract;
using WingTipsToys.DataAccessContract;
using WingTipsToys.Model;
using WingTipsToys.ViewModel;
using WingTipsToys.ViewModel.CartItemsViewModels;

namespace WingTipsToys.BusinessService
{
      public class CartItemBusinessService : ICartItemBusinessContract
      {
            private readonly IRepository<CartItemModel> _cartITemRepository;
            private readonly IRepository<ProductModel> _productRepository;
            private readonly IMapper _mapper;

            public CartItemBusinessService(IRepository<CartItemModel> cartItemRepository,
                                           IRepository<ProductModel> productRepository,
                                           IMapper mapper)
            {
                  this._cartITemRepository = cartItemRepository;
                  this._productRepository = productRepository;
                  this._mapper = mapper;
            }

         

            public Task<List<CartItemViewModel>> GetAllCartItemAsync()
            {
                  Task<List<CartItemViewModel>> tsk = Task.Factory.StartNew(() =>
                  {
                        var product = _productRepository.getByQuery();
                        var cartItem = _cartITemRepository.getByQuery();

                        var result = product.Join(cartItem.AsQueryable(),
                                                  pro => pro.ProductID,
                                                  cat => cat.ProductId,
                                                  (pro, cat) =>
                                                  new CartItemViewModel()
                                                  {
                                                        ItemId = cat.ItemId,
                                                        CartId = cat.CartId,
                                                        Quantity = cat.Quantity,
                                                        DateCreated = cat.DateCreated,
                                                        ProductId = pro.ProductID,
                                                        ProductName = pro.ProductName
                                                  }).ToList();


                        //var res = _mapper.Map<List<CartItemViewModel>>((from pro in _productRepository.getByQuery()
                        //           join cat in _cartITemRepository.getByQuery()
                        //           on pro.ProductID equals cat.ProductId
                        //           select new
                        //           {
                        //                 ItemId = cat.ItemId,
                        //                 CartId = cat.CartId,
                        //                 Quantity = cat.Quantity,
                        //                 DateCreated = cat.DateCreated,
                        //                 ProductId = pro.ProductID,
                        //                 ProductName = pro.ProductName
                        //           }).ToList());

                        return (result);
                  });

                  return (tsk);
            }

            public Task<bool> InsertCartItem(CartItemModel cartItem)
            {

                  cartItem.CartId = Guid.NewGuid().ToString();
                  cartItem.ItemId = Guid.NewGuid().ToString();
                  cartItem.DateCreated = DateTime.Now;
                  return (_cartITemRepository.InsetAsync(cartItem));
            }

            public Task<bool> Update(CartItemModel cartItemID)
            {
                  cartItemID.DateCreated = DateTime.Now;
                  return (_cartITemRepository.UpdateAsync(cartItemID));
            }

            public Task<List<CartItemViewModel>> SearchCartItemByID(CartItemViewModel searchValue)
            {
                  throw new NotImplementedException();
            }
           
      }
}
