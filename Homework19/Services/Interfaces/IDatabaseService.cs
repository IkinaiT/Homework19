using Homework19.Models;

namespace Homework19.Services.Interfaces
{
    public interface IDatabaseService
    {
        public IEnumerable<Contact> GetContacts();
        public Contact? GetContact(int id);
        public bool DeleteContact(int id);
        public bool AddContact(Contact contact);
        public bool EditContact(Contact contact);
    }
}
