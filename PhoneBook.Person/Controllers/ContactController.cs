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
    public class ContactController : ControllerBase
    {
        private readonly ILogger<ContactController> _logger;
        private readonly IContactService _service;

        public ContactController(IContactService service, ILogger<ContactController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        public ServiceResultView AddContact(ContactView contact)
        {
            return _service.Add(contact);
        }

        [HttpDelete]
        [Route("{contactId}")]
        public ServiceResultView DeletePerson(Guid contactId)
        {
            return _service.Delete(contactId);
        }

        [HttpGet]
        [Route("types")]
        public IEnumerable<ContactTypeView> GetContactTypes()
        {
            return _service.GetContactTypes();
        }

    }
}
