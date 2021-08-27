using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WingTipsToys.Model;
using WingTipsToys.ViewModel;
using WingTipsToys.ViewModel.CartItemsViewModels;
using WingTipsToys.ViewModel.Person;

namespace WingTipsToys.WebApp.Mapping
{
      public class MappingProfile : Profile
      {
            public MappingProfile()
            {
                  CreateMap<ProductModel, ProductViewModel>().ReverseMap();
                  CreateMap<CartItemInsertRM, CartItemModel>();
                  CreateMap<PersonModel, PersonViewModel>().ReverseMap();
            }
      }
}
