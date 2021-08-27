using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WingTipsToys.Model;
using WingTipsToys.ViewModel;

namespace WingTipsToys.BusinessContract
{
      public interface IProductBusinessContract
      {
            Task<List<ProductViewModel>> GetAllProductsAsync();
            Task<ProductModel> GetProductAsync();
            Task<List<ProductViewModel>> SearchProductByName(ProductSearchViewModel searchValue);
      }
}
