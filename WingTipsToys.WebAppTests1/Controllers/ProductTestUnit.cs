using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WingTipsToys.BusinessContract;
using WingTipsToys.BusinessService;
using WingTipsToys.DataAccessContract;
using WingTipsToys.Model;
using WingTipsToys.ViewModel;
using WingTipsToys.WebApp.Controllers;
using WingTipsToys.WebApp.Mapping;
using Xunit;

namespace WingTipsToys.WebAppTests1.Controllers
{
      public class checkEmployeeBusiness
      {
            public virtual Boolean checkEmp()
            {
                  throw new NotImplementedException();
            }
      }

      public class processEmployeeController
      {
            public Boolean insertEmployee(checkEmployeeBusiness objtmp)
            {
                  objtmp.checkEmp();
                  return true;
            }
      }

      public class ProductTestUnit
      {
            private readonly ProductsController _productController;
            private readonly Mapper _mapper;

            public ProductTestUnit()
            {
                  var myProfile = new MappingProfile();
                  var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
                  this._mapper = new Mapper(configuration);

                  Mock<IProductBusinessContract> mock = new Mock<IProductBusinessContract>();





            }
            [Fact]
            public async void  GetProduct()
            {



                  var pro = new ProductViewModel();

                  Mock<IProductBusinessContract> mock = new Mock<IProductBusinessContract>();
                  mock.Setup(x => x.GetAllProductsAsync())
                        .ReturnsAsync(() =>  null );

                  var ctr = new ProductsController(mock.Object, _mapper);
                  var resutlList = (await ctr.GetProducts()).ToList();

                  Assert.IsType<Task<List<ProductViewModel>>>(resutlList);


            }


            [Fact]
            public void SearchProduct()
            {



                  Mock<checkEmployeeBusiness> chk = new Mock<checkEmployeeBusiness>();
                  chk.Setup(x => x.checkEmp()).Returns(true);

                  processEmployeeController obje = new processEmployeeController();
                  Assert.IsType<bool>(obje.insertEmployee(chk.Object));

                  var searchProduct = new ProductSearchViewModel() { ProductName = "old" };


                  Mock<IProductBusinessContract> mock = new Mock<IProductBusinessContract>();
                  mock.Setup(x => x.SearchProductByName(searchProduct))
                        .Returns(Task.FromResult<List<ProductViewModel>>(null));

                  var ctr = new ProductsController(mock.Object, _mapper);
                  Assert.IsType<Task<List<ProductViewModel>>>(ctr.SearchProduct(searchProduct));


            }

            [Fact]
            public async Task getProduct_ShouldReturnProduct_InAll()
            {
                  ///Arange
                  //Mock<IRepository<ProductModel>> productRepMock = new Mock<IRepository<ProductModel>>();
                  //Mock<IRepository<CategoryModel>> categoryRepMock = new Mock<IRepository<CategoryModel>>();
                  //var categoryBusinessService = new CategoryBusinessService(categoryRepMock.Object);

                  //var _myProfile = new MappingProfile();
                  //var _configuration = new MapperConfiguration(cfg => cfg.AddProfile(_myProfile));
                  //var _mapper = new Mapper(_configuration);

                  //productRepMock.Setup(x => x.GetAllAsync(null))
                  //               .ReturnsAsync(() => List<ProductModel>);    

                  /////Act

                  //var productBusinessService = new ProductBusinessService(productRepMock.Object,
                  //                                                categoryBusinessService,
                  //                                                _mapper);
                  //var productResult = await productBusinessService.GetAllProductsAsync();
                  /////Assert

                  //Assert.IsType<List<ProductViewModel>>(productResult);
                  int count = -1;
                  var pro = new List<ProductViewModel>() { new ProductViewModel() { CategoryID = 1, Description = "te", ProductID = 5 } };
                  Mock<ICartItemBusinessContract> cartBusinessMock = new Mock<ICartItemBusinessContract>();
                  cartBusinessMock.Setup(x => x.GetAllCartItemAsync());
                  // .ReturnsAsync(new List<CartItemViewModel>());  


                  Mock<IProductBusinessContract> proBusimock = new Mock<IProductBusinessContract>();
                  proBusimock.Setup(x => x.GetAllProductsAsync())
                        .Callback<List<ProductViewModel>>((value) =>
                        {
                              count = value.Count;
                        });


                  var myProfile = new MappingProfile();
                  var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
                  var mapper = new Mapper(configuration);

                  var productController = new ProductsController(proBusimock.Object,
                                                                  mapper);

                  var result = (await productController.GetProducts()).ToList();


                  Assert.IsType<List<ProductViewModel>>(result);

            }



      }
}
