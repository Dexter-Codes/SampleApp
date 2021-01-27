using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sample.Core.Models;


namespace Sample.Core.Interfaces
{
    public class PeopleService : IPeopleService
    {
        //private readonly IRestClient _restClient;

        public PeopleService()
        {
            //_restClient = restClient;
        }

        //public Task<PagedResult<Person>> GetPeopleAsync(string url = null)
        //{
        //    //return string.IsNullOrEmpty(url)
        //    //             ? _restClient.MakeApiCall<PagedResult<Person>>($"{Constants.BaseUrl}/people/", HttpMethod.Get)
        //    //             : _restClient.MakeApiCall<PagedResult<Person>>(url, HttpMethod.Get);
        //}

        //public Task<Person> GetPersonAsync()
        //{
        //    //return _restClient.MakeApiCall<Person>($"{Constants.BaseUrl}/people/1/", HttpMethod.Get);
        //}

        public PagedResult<Person> GetMockedPeople()
        {
            return new PagedResult<Person>()
            {
                Count = 3,
                Next = string.Empty,
                Previous = string.Empty,
                Results = new List<Person>
                {
                    new Person
                    {
                        Name = "Master Yoda",
                        SkinColor = "Green",
                        Height = "65"
                    },
                    new Person
                    {
                        Name = "Obi-Wan Kenobi",
                        Mass = "80"
                    },
                    new Person
                    {
                        Name = "Master Windu",
                        Height = "165",
                        Mass = "85"
                    }
                }
            };
        }

       
    }

    public class PagedResult<T> where T : class
    {
        public int Count { get; set; }

        public string Next { get; set; }

        public string Previous { get; set; }

        public IEnumerable<T> Results { get; set; }
    }
}
