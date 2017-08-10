using System.Collections.Generic;
using ContactRest.Models;

namespace ContactRest.Services
{
    public interface IContactService
    {
        Contact GetContactById(int id);
        IList<Contact> GetAllContacts();
        int AddContact(Contact contact);
        bool DeleteContactById(int id);
        Contact EditContact(Contact contact);
    }
}
