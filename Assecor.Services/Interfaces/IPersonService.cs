using System.Threading.Tasks;
using Assecor.Data.Dto;
using Assecor.Data.Entities;

namespace Assecor.Services.Interfaces
{
    public interface IPersonService
    {
        Task<PersonDto> AddPerson();
    }
}