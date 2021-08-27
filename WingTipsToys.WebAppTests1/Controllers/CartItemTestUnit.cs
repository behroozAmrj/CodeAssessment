using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WingTipsToys.BusinessContract;
using WingTipsToys.ViewModel.CartItemsViewModels;
using WingTipsToys.WebApp.Controllers;
using WingTipsToys.WebApp.Mapping;
using Xunit;

namespace WingTipsToys.WebAppTests1.Controllers
{
    public class CartItemTestUnit
    {
        private readonly CartItemController _cartItemController;

        public CartItemTestUnit()
        {
            var myProfile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);

            Mock<ICartItemBusinessContract> mock = new Mock<ICartItemBusinessContract>();

            //IProductBusinessContract proeductBusiness = new ProductBusinessService();
            this._cartItemController = new CartItemController(mapper, mock.Object);
        }

        [Fact]
        public void AddCartItem()
        {


            var cartItem = new CartItemInsertRM() { ProductId = 1, Quantity = 3 };
            var insertResult = this._cartItemController.InsertCartItem(cartItem);


            Assert.True(true);


        }
    }
}
