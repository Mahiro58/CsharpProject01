using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class Book
    {
        public long Id { get; }
        public string Title { get; }
        public string Author { get; }
        public int Year { get; }
        public bool isBorrowed { get; }
        public Category Category { get; }

        public Book (long id, string title, string author, int year, bool isBorrowed, Category category)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id have to be greater than 0.");
            }
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be null or whitespace.");
            }
            if (string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentException("Author cannot be null or whitespace.");
            }
            if (year > DateTime.Today.Year)
            {
                throw new ArgumentException("Year cannot be in the future.");
            }

            Id = id;
            Title = title;
            Author = author;
            Year = year;
            this.isBorrowed = isBorrowed;
            Category = category;
        }
    }
}
