using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using ContactRest.Dto;
using ContactRest.Exceptions;
using ContactRest.Exceptions.Handler;
using ContactRest.Models;
using ContactRest.Services;
using AutoMapper;
using Facebook;

namespace ContactRest.Controllers
{
    public class Teste
    {
        public string Name { get; set; }
    }

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
        [WebApiExceptionHandling]
        public ContactsDto GetContacts()
        {
            ValidateFacebookToken();

            return new ContactsDto
            {
                Contacts = Mapper.Map<IList<ContactDto>>(_contactService.GetAllContacts())
            };
        }

        [HttpGet]
        [ActionName("contacts")]
        [WebApiExceptionHandling]
        public ContactDto GetContact(int id)
        {
            ValidateFacebookToken();

            return Mapper.Map<ContactDto>(_contactService.GetContactById(id));
        }

        [HttpPost]
        [ActionName("contacts")]
        [WebApiExceptionHandling]
        public int PostContact(ContactDto contact)
        {
            ValidateFacebookToken();

            return _contactService.AddContact(Mapper.Map<Contact>(contact));
        }

        [HttpDelete]
        [ActionName("contacts")]
        [WebApiExceptionHandling]
        public bool DeleteContact(int id)
        {
            ValidateFacebookToken();

            return _contactService.DeleteContactById(id);
        }

        [HttpPut]
        [ActionName("contacts")]
        [WebApiExceptionHandling]
        public ContactDto PutContact(ContactDto contact)
        {
            ValidateFacebookToken();

            return Mapper.Map<ContactDto>(_contactService.EditContact(Mapper.Map<Contact>(contact)));
        }

        private void ValidateFacebookToken()
        {
            var re = Request;
            var headers = re.Headers;

            if (headers.Contains("Authorization"))
            {
                var token = headers.GetValues("Authorization").First();

                var fb = new FacebookClient(token);

                dynamic result = fb.Get("/me?fields=id,name");

                if (result == null)
                {
                    throw new FacebookOAuthException("Authentication failed");
                }
            }
            else
            {
                throw new ContactRestAuthException("Missing Authorization Header");
            }
        }
    }
}
