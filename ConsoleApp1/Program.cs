using ConsoleApp1;

bool check = true;
User currentUser = null;

Library libraryControl = new Library();

while (check)
{

    Console.WriteLine("Welcome to your local Library!");
    Console.WriteLine("Choose what do you want to do by choosing number.");
    Console.WriteLine("1. Add new book.");
    Console.WriteLine("2. Register new user.");
    Console.WriteLine("3. Change user. ");
    Console.WriteLine("4. Borrow book.");
    Console.WriteLine("5. Return book.");
    Console.WriteLine("6. Show books.");
    Console.WriteLine("7. Show avaliable books.");
    Console.WriteLine("8. Search for a book.");
    Console.WriteLine("9. Check your borrowed books.");
    Console.WriteLine("10. Exit.");

    switch (Console.ReadLine())
    {
        case "1":
            Console.Clear();
            Console.WriteLine("Enter book's Id: ");
            long bookId = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter book's title: ");
            string bookTitle = Console.ReadLine();
            Console.WriteLine("Enter book's author: ");
            string bookAuthor = Console.ReadLine();
            Console.WriteLine("Enter book's year: ");
            int bookYear = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter book's category: ");
            Console.WriteLine("You can choose from\r\n        Fantasy,\r\n        Programming,\r\n        History,\r\n        Science,\r\n        Biography,");
            Category bookCategory = Enum.Parse<Category>(Console.ReadLine());

            Book book = new Book(bookId, bookTitle, bookAuthor, bookYear, bookCategory);
            libraryControl.AddBook(book);
            Console.Clear();
            Console.WriteLine($"Book {bookTitle} by {bookAuthor} was succesfully added!");
            Console.WriteLine();
            break;
        case "2":
            Console.Clear();
            Console.WriteLine("Enter user's Id: ");
            long userId = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter user's first name: ");
            string userFirstName = Console.ReadLine();
            Console.WriteLine("Enter user's last name: ");
            string userLastName = Console.ReadLine();
            Console.WriteLine("Enter user's emal: ");
            string userEmail = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            string userPassword = Console.ReadLine();

            User user = new User(userId, userFirstName, userLastName, userEmail, userPassword);
            libraryControl.RegisterUser(user);
            currentUser = user;
            Console.Clear();
            Console.WriteLine($"User {userFirstName} {userLastName} was successfully registered!");
            Console.WriteLine();
            break;
        case "3":
            Console.WriteLine("Enter your email: ");
            string searchUserEmail = Console.ReadLine();
            User foundUser = libraryControl.Users.FirstOrDefault(u => u.Email == searchUserEmail);
            if (foundUser != null)
            {
                Console.WriteLine("Enter your password: ");
                string userPasswordCheck = Console.ReadLine();
                if (foundUser.Password == userPasswordCheck)
                {
                    Console.WriteLine($"Welcome back {foundUser.FirstName}!");
                    currentUser = foundUser;
                }
                else
                {
                    Console.WriteLine("Wrong password.");
                }
            }
            else
            {
                Console.WriteLine("User does not exists.");
            }
            break;
        case "4":
            Console.Clear();
            libraryControl.ShowAvailableBooks();
            Console.WriteLine("Choose book's id that you would like to borrow: ");
            long bookIdToBorrow = long.Parse(Console.ReadLine());
            Book bookToBorrow = libraryControl.SearchBooksById(bookIdToBorrow);

            if (currentUser != null && bookToBorrow != null)
            {
                libraryControl.BorrowBook(currentUser, bookToBorrow);
            }
            break;
        case "5":
            Console.Clear();
            libraryControl.ShowBorrowedBooks();
            Console.WriteLine("Choose book's id that you would like to return: ");
            long bookIdToReturn = long.Parse(Console.ReadLine());
            Book bookToReturn = libraryControl.SearchBooksById(bookIdToReturn);

            if (currentUser != null && bookToReturn != null)
            {
                libraryControl.ReturnBook(currentUser, bookToReturn);
            }
            break;
        case "6":
            Console.Clear();
            libraryControl.ShowAllBooks();
            break;
        case "7":
            Console.Clear();
            libraryControl.ShowAvailableBooks();
            break;
        case "8":
            Console.Clear();
            Console.WriteLine("Enter book's title that you're looking for: ");
            string searchBookTitle = Console.ReadLine();
            Console.WriteLine("Enter book's author that you're looking for: ");
            string searchBookAuthor = Console.ReadLine();
            Console.Clear();
            libraryControl.SearchBook(searchBookTitle, searchBookAuthor);
            break;
        case "9":
            Console.Clear();
            if (currentUser != null)
            {
                currentUser.ShowUserBorrowedBooks();
            }
            else
            {
                Console.WriteLine("There's no user to check your borrowed books.");
            }
            break;
        case "10":
            Console.WriteLine("Goodbye!");
            check = false;
            return;
        default:
            Console.WriteLine("Invalid choice. Please choose a number from 1 to 9.");
            break;
    }
}
