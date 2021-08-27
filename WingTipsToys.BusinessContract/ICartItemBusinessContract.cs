using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WingTipsToys.Model;
using WingTipsToys.ViewModel;
using WingTipsToys.ViewModel.CartItemsViewModels;

namespace WingTipsToys.BusinessContract
{
      public interface ICartItemBusinessContract
      {
            Task<List<CartItemViewModel>> GetAllCartItemAsync();
            Task<List<CartItemViewModel>> SearchCartItemByID(CartItemViewModel searchValue);

            Task<bool> InsertCartItem(CartItemModel cartItem);
            Task<bool> Update(CartItemModel cartItemID);
                  
      }
}
