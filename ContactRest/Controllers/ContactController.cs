using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using ContactRest.Dto;
using ContactRest.Models;
using ContactRest.Services;
using AutoMapper;

namespace ContactRest.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ContactController : ApiController
    {
        private readonly IContactService _contactService;

        public ContactController()
        {
            _contactService = new ContactService();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Contact, ContactDto>();
                cfg.CreateMap<ContactDto, Contact>();
            });
        }

        [HttpGet]
        [ActionName("contacts")]
        public ContactsDto GetContacts()
        {
            return new ContactsDto
            {
                Contacts = Mapper.Map<IList<ContactDto>>(_contactService.GetAllContacts())
            };
        }

        [HttpGet]
        [ActionName("contacts")]
        public ContactDto GetContact(int id)
        {
            return Mapper.Map<ContactDto>(_contactService.GetContactById(id));
        }

        [HttpPost]
        [ActionName("contacts")]
        public int PostContact(ContactDto contact)
        {
            return _contactService.AddContact(Mapper.Map<Contact>(contact));
        }

        [HttpDelete]
        [ActionName("contacts")]
        public bool DeleteContact(int id)
        {
            return _contactService.DeleteContactById(id);
        }

        [HttpPut]
        [ActionName("contacts")]
        public ContactDto PutContact(ContactDto contact)
        {
            return Mapper.Map<ContactDto>(_contactService.EditContact(Mapper.Map<Contact>(contact)));
        }
    }
}
