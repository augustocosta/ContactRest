using System.Collections.Generic;
using ContactRest.Models;

namespace ContactRest.Repository
{
    public interface IContactRepository
    {
        IList<Contact> GetAllContacts();
        Contact GetContactById(int id);
        int AddContact(Contact contact);
        bool DeleteContactById(int id);
        Contact EditContact(Contact contact);
    }
}
