using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;

namespace ConsoleApp1
{
    internal class Library
    {
        public List<Book> Books { get; } = new();
        public List<User> Users { get; } = new();
        public List<WhoBorrowed> BorrowingHistory { get; } = new();

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
        {   bool userExists = Users.Exists(u => u.Email == user.Email);
            if (!userExists)
            {
                Users.Add(user);
            }
        }

        public void BorrowBook(User user, Book book)
        {
            if (book.isBorrowed)
            {
                throw new InvalidOperationException($"{book.Title} is already borrowed.");
            }
            else
            {
                book.Borrow();
                WhoBorrowed record = new WhoBorrowed();
                record.SetUser(user);
                record.SetBook(book);
                record.SetBorrowingTime();
                BorrowingHistory.Add(record);
                user.BorrowBook(book);
            }
        }

        public void ReturnBook(User user, Book book)
        {
            if (!book.isBorrowed)
            {
                throw new InvalidOperationException($"{book.Title} is not currently borrowed.");
            }
            else
            {
                book.Return();
                user.ReturnBook(book);
                WhoBorrowed record = BorrowingHistory.FirstOrDefault(r => r.Book == book && r.User == user);
                if (record != null)
                {
                    record.setReturnDate();
                }
                Console.WriteLine($"{book.Title} returned.");
            }
        }

        public void ShowAvailableBooks()
        {
            Console.WriteLine("Avalible books: ");
            foreach (var book in Books)
            {
                if (!book.isBorrowed)
                {
                    Console.WriteLine($"{book.Title} by {book.Author} category: {book.Category}. ");
                }
            }
        }

        public Book SearchBook(string title, string author)
        {
            Book foundBook = Books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase) && b.Author.Equals(author, StringComparison.OrdinalIgnoreCase));
            
            if (foundBook != null)
            {
                return foundBook;
            }
            else
            {
                Console.WriteLine($"{title} by {author} does not exists");
                return null;
            }
        }


    }
}
