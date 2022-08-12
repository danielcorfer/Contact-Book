using ContactBook.Models;
using ContactBook.Controllers;
using ContactBook.Database;
using ContactBook.Interfaces;

namespace ContactBook.Services
{
    public class ContactService : IContactService
    {
        public ApplicationDbContext database { get; set; }

        public ContactService(ApplicationDbContext database)
        {
            this.database = database;
        }

        public void AddContact(Contact input)
        {
            database.Contacts.Add(input);
            database.SaveChanges();
        }

        public List<Contact> ListContacts()
        {
            return database.Contacts.ToList();
        }

        public void DeleteContact(Contact input)
        {
            database.Contacts.Remove(database.Contacts.First(c => c.Id == input.Id));
            database.SaveChanges();
        }
    }
}
