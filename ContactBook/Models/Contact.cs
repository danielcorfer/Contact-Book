namespace ContactBook.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Number { get; set; }
        public string Email { get; set; }

        public Contact()
        {

        }

        public Contact(int id, string name, long number, string email)
        {
            Id = id;
            Name = name;
            Number = number;
            Email = email;
        }
    }
}
