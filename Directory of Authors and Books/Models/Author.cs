using System;

namespace Directory_of_Authors_and_Books.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public DateTime Birthday { get; set; }

        public Author(string firstName, string lastName, string? middleName, DateTime birthday)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            Birthday = birthday;
        }
    }
}
