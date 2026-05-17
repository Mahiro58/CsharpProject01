using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class WhoBorrowed
    {
        public User User { get; private set; }
        public Book Book { get; private set; }
        public DateTime BorrowingTime { get; private set; }
        public DateTime ReturnDate { get; private set; }

        public void SetUser(User user)
        {
            User = user;
        }

        public void SetBook(Book book)
        {
            Book = book;
        }

        public void SetBorrowingTime()
        {
            BorrowingTime = DateTime.Now;
        }

        public void setReturnDate()
        {
            ReturnDate = DateTime.Now;
        }
    }
}
