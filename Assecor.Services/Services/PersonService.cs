using System;
using System.Threading.Tasks;
using Assecor.Data.Dto;
using Assecor.Data.Entities;
using Assecor.Data.Repositories.Interfaces;
using Assecor.Services.Interfaces;

namespace Assecor.Services.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<PersonDto> AddPerson()
        {
           var data= await _personRepository.GetById(1);
            return new PersonDto
            {
                City = data.City,
                ColorId = data.ColorId,
                Id = data.Id,
                Lastname = data.Lastname,
                Name = data.Name,
                Zipcode = data.Zipcode
            };
           
        }
    }
}