using System.Collections.Generic;
using System.Linq;
using ContactRest.Models;

namespace ContactRest.Repository
{

    public class ContactRepository : IContactRepository
    {
        private readonly ContactContext _contactContext;

        public ContactRepository()
        {
            _contactContext = new ContactContext();
        }

        public IList<Contact> GetAllContacts()
        {
            return _contactContext.Contacts.OrderBy(o => o.FirstName).ThenBy(o => o.LastName).ToList();
        }

        public Contact GetContactById(int id)
        {
            return _contactContext.Contacts.FirstOrDefault(w => w.Id == id);
        }

        public int AddContact(Contact contact)
        {
            _contactContext.Contacts.Add(contact);
            _contactContext.SaveChanges();
            return contact.Id;
        }

        public Contact EditContact(Contact contact)
        {
            var dbContact = GetContactById(contact.Id);

            if (dbContact == null) return null;

            dbContact.FirstName = contact.FirstName;
            dbContact.LastName = contact.LastName;
            _contactContext.Entry(dbContact).CurrentValues.SetValues(contact);
            _contactContext.SaveChanges();
                
            return dbContact;
        }

        public bool DeleteContactById(int id)
        {
            var contact = GetContactById(id);

            if (contact == null) return false;

            _contactContext.Contacts.Remove(contact);
            _contactContext.SaveChanges();

            return true;
        }
    }
}