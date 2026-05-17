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
            if (book.IsBorrowed)
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
            bool userExists = Users.Exists(u => u.Email == user.Email);
            if (!userExists)
            {
                Users.Add(user);
            }
        }

        public void BorrowBook(User user, Book book)
        {
            if (book.IsBorrowed)
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
            if (!book.IsBorrowed)
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
            if (Books.Count > 0)
            {
                List<Book> availableBooks = Books.Where(b => !b.IsBorrowed).ToList();
                availableBooks = availableBooks.OrderBy(b => b.Title).ToList();
                foreach (Book book in availableBooks)
                {
                    Console.WriteLine($"{book.Id}. {book.Title} by {book.Author} ({book.Year}) - {book.Category}");
                }
            }
            else
            {
                Console.WriteLine("No books available.");
            }
        }

        public void ShowBorrowedBooks()
        {
            if (Books.Count > 0)
            {
                List<Book> borrowedBooks = Books.Where(b => b.IsBorrowed).ToList();
                borrowedBooks = borrowedBooks.OrderBy(b => b.Title).ToList();
                foreach (Book book in borrowedBooks)
                {
                    Console.WriteLine($"{book.Id}. {book.Title} by {book.Author} ({book.Year}) - {book.Category}");
                }
            }
            else
            {
                Console.WriteLine("No books available.");
            }
        }

        public Book SearchBooksById(long id)
        {
            Book foundBook = Books.FirstOrDefault(b => b.Id == id);
            if (foundBook != null)
            {
                return foundBook;
            }
            else
            {
                Console.WriteLine($"No book with Id {id} found.");
                return null;
            }
        }

        public Book SearchBook(string title, string author)
        {
            Book foundBook = Books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase) && b.Author.Equals(author, StringComparison.OrdinalIgnoreCase));

            if (foundBook != null)
            {
                if (title == null)
                {
                    Book foundBookbyAuthor = Books.FirstOrDefault(b => b.Author.Equals(author, StringComparison.OrdinalIgnoreCase));
                    return foundBookbyAuthor;
                }
                else if (author == null)
                {
                    Book foundBookbyTitle = Books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
                    return foundBookbyTitle;
                }
                else
                {
                    return foundBook;
                }
            }
            else
            {
                Console.WriteLine($"{title} by {author} does not exists");
                return null;
            }
        }

        public void ShowAllBooks()
        {
            if (Books.Count > 0)
            {
                List<Book> sortedBooks = Books.OrderBy(b => b.Title).ToList();
                foreach (Book book in sortedBooks)
                {
                    Console.WriteLine($"{book.Title} by {book.Author} ({book.Year}) - {book.Category} - {(book.IsBorrowed ? "Borrowed" : "Available")}");
                }
            }
            else
            {
                Console.WriteLine("There's no books in library.");
            }
        }

        public void SearchUser(string email)
        {
            User foundUser = Users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

            if (foundUser != null)
            {
                Console.WriteLine($"Welcome {foundUser.FirstName} {foundUser.LastName}!");
            }
            else
            {
                Console.WriteLine($"User with email {email} does not exist.");
            }


        }
    }
}
