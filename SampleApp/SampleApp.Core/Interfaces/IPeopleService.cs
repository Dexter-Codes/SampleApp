using System;
using System.Threading.Tasks;
using Sample.Core.Models;

namespace Sample.Core.Interfaces
{
    public interface IPeopleService
    {
        //Task<PagedResult<Person>> GetPeopleAsync(string url = null);

        //Task<Person> GetPersonAsync();
        PagedResult<Person> GetMockedPeople();

    }
}
