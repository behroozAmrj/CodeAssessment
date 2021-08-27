using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WingTipsToys.ViewModel.Person;

namespace WingTipsToys.BusinessContract
{
      public interface IPersonBusinessContract
      {
            Task<IList<PersonViewModel>> GetPersonAsync();
            Task<bool> CreatePerson(PersonViewModel person);
      }
}
