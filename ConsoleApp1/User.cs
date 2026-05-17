using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class User
    {
        public long Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }

        public List<Book> BorrowedBooks { get; } = new();

        public User (long id, string firstName, string lastName, string email)
        {
            if (id <= 0) 
            { 
                throw new ArgumentException("Id have to be greater than 0."); 
            }
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("First name cannot be null or whitespace.");
            }
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Last name cannot be null or whitespace.");
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be null or whitespace.");
            }
            if (!email.Contains("@"))
            {
                throw new ArgumentException("Email must contain '@' character.");
            }

            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

    }
}
