using Homework19.Models;

namespace Homework19.Services.Interfaces
{
    public interface IDatabaseService
    {
        public IEnumerable<Contact> GetContacts();
        public Contact? GetContact(int id);
    }
}
