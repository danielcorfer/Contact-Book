using ContactBook.Models;

namespace ContactBook.Interfaces
{
    public interface IContactService
    {
        public void AddContact(Contact input);
        public List<Contact> ListContacts();
        public void DeleteContact(Contact input);

    }
}
