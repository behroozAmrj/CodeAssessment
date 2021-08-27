using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WingTipsToys.BusinessContract;
using WingTipsToys.ViewModel.Person;

namespace WingTipsToys.WebApp.Controllers
{
     
      public class PersonController : MasterApiController
      {
            private readonly IPersonBusinessContract _businessContract;

            public PersonController(IPersonBusinessContract businessContract)
            {
                  this._businessContract = businessContract;
            }

            [HttpGet]
            public async Task<IList<PersonViewModel>> GetPersons()
            {
                  var personResponse = await _businessContract.GetPersonAsync();
                  return personResponse;
            }

            [HttpPost]
            public async Task<bool> CreatePerson([FromBody] PersonViewModel createPersonRequestModel)
            {
                  var createResult = await _businessContract.CreatePerson(createPersonRequestModel);
                  return (createResult);
            }
      }
}
