using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class Library
    {
        public List<Book> Books { get; } = new();
        public List<User> Users { get; } = new();

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            if (book.isBorrowed)
            {
                throw new InvalidOperationException("Cannot remove a borrowed book.");
            }
            else
            {

                Books.Remove(book);
            }
        }

        public void RegisterUser(User user)
        {
            Users.Add(user);
        }
    }
}
