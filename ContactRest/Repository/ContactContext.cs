using System.Data.Entity;
using ContactRest.Models;

namespace ContactRest.Repository
{
    public class ContactContext : DbContext
    {
        public ContactContext() : base("name=DefaultConnection") { }
        public DbSet<Contact> Contacts { get; set; }
    }
}