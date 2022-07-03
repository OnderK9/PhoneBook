using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhoneBook.Core.Filters;
using PhoneBook.Core.View;
using PhoneBook.Person.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Person.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [ValidateModel] //Veriler controllera gelmeden ModelState kontrol ediliyor, hata var ise istek geri çevriliyor
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _service;

        public PersonController(IPersonService service, ILogger<PersonController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<PersonView> GetAll()
        {
            return _service.GetAll();
        }

        [HttpPost]
        public ServiceResultView AddPerson(PersonView person)
        {
            return _service.Add(person);
        }

        [HttpGet]
        [Route("{personId}")]
        public ServiceResultView GetPerson(Guid personId)
        {
            return _service.Get(personId);
        }

        [HttpDelete]
        [Route("{personId}")]
        public ServiceResultView DeletePerson(Guid personId)
        {
            return _service.Delete(personId);
        }

    }
}
