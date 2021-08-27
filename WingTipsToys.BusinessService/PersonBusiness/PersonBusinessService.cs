using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WingTipsToys.BusinessContract;
using WingTipsToys.DataAccessContract;
using WingTipsToys.Model;
using WingTipsToys.ViewModel.Person;

namespace WingTipsToys.BusinessService.PersonBusiness
{
      public class PersonBusinessService : IPersonBusinessContract
      {
            private readonly IRepository<PersonModel> _personRepository;
            private readonly IMapper _mapper;

            public PersonBusinessService(IRepository<PersonModel> personRepository, IMapper mapper)
            {
                  this._personRepository = personRepository;
                  this._mapper = mapper;
            }

            public async Task<bool> CreatePerson(PersonViewModel person)
            {
                  var tempPerson = new PersonModel()
                  {
                        Activity = person.Activity,
                        FirstName = person.FirstName,
                        LastName = person.LastName,
                        Comment = person.Comment,
                        Email = person.Email
                  };

                  await _personRepository.InsetAsync(tempPerson);
                  return true;
            }

            public async Task<IList<PersonViewModel>> GetPersonAsync()
            {
                  var personList = await _personRepository.GetAllAsync();
                  var personRsultList = _mapper.Map<List<PersonViewModel>>(personList);
                  return personRsultList;

            }
      }
}
