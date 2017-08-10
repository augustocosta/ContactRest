using System.Collections.Generic;
using ContactRest.Models;
using ContactRest.Repository;

namespace ContactRest.Services
{

    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService()
        {
            _contactRepository = new ContactRepository();
        }

        public Contact GetContactById(int id)
        {
            return _contactRepository.GetContactById(id);
        }

        public IList<Contact> GetAllContacts()
        {
            return _contactRepository.GetAllContacts();
        }

        public int AddContact(Contact contact)
        {
            return _contactRepository.AddContact(contact);
        }

        public Contact EditContact(Contact contact)
        {
            return _contactRepository.EditContact(contact);
        }

        public bool DeleteContactById(int id)
        {
            return _contactRepository.DeleteContactById(id);
        }
    }
}