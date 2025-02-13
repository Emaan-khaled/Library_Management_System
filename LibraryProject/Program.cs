using System.Data;
using System.Xml.Linq;

namespace LibraryManagementSystem
{
    internal class Program
    {

        static void Main(string[] args)
        {
            User Currentuser = null;
            RegistrationSystem registrationSystem = new RegistrationSystem();
            Library library = new Library();
            library.AddBook(new Book(0, "lion", "ahmed"));
            library.AddBook(new Book(0, "learn how to learn", "esraa"));
            library.AddBook(new Book(0, "dog", "ali"));
            library.AddBook(new Book(0, "flower", "rahma"));
            library.AddBook(new Book(0, "tree", "mona"));

            
                /*
                 * Registration System
                 * */
                while (Currentuser == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Welcome to the Library system\n ********************");
                    Console.WriteLine("[1] Register a new account\n[2] Login to your account");
                    Console.ResetColor();
                    Console.WriteLine("Choose an option :");
                    int choice = int.Parse(Console.ReadLine());

                    if (choice == 1)
                    {
                        Console.WriteLine("Enter your name :");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter your password :");
                        string password = Console.ReadLine();
                        Console.WriteLine("Enter your role: \"Librarian\" or \"LibraryUser\"");
                        string role = Console.ReadLine();
                        registrationSystem.SignUP(name, password, role);
                        Console.WriteLine("**********************");
                    }
                    else if (choice == 2)
                    {
                        Console.WriteLine("Enter your role: [Librarian] or [Libraryuser]");
                        string role = Console.ReadLine();
                        if (role == "Librarian")
                        {
                            Console.WriteLine("Enter your name :");
                            string name = Console.ReadLine();
                            Console.WriteLine("Enter your password :");
                            string password = Console.ReadLine();
                            Currentuser = registrationSystem.Login(name, password);
                        }
                        else if (role == "LibraryUser")
                        {
                            Console.WriteLine("Enter your Card number :");
                            string cardno = Console.ReadLine();
                            Currentuser = registrationSystem.CardLogin(cardno);
                        }
                        else
                        {
                            Console.WriteLine("invaild choice, try again");
                        }
                        Console.WriteLine("**********************");
                    }
                    else
                    {
                        Console.WriteLine("invaild role, try agein");
                        Console.WriteLine("**********************");
                    }
                }


                /*
                 * Display options after login
                 * */
                if (Currentuser is Librarian librarian)
                {
                    LibrarianMenu(librarian, library);
                }
                else if (Currentuser is LibraryUser libraryuser)
                {
                    LibraryUserMenu(libraryuser, library);
                }

            
        }

        /*
         * Menu for LibraryUser
         * */
        private static void LibraryUserMenu(LibraryUser libraryuser, Library library)
        {
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Library User Menu:\n **************************");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[1] Display Library's Books\n[2] Borrow a book from the Library");
                Console.WriteLine("[3] Return a book to the Library\n[4] Display borrowed Books\n[5] Exit");
                Console.WriteLine("*****************************************");
                Console.WriteLine("Choose an option: ");
                Console.ResetColor();

                int Choice = int.Parse(Console.ReadLine());
                switch (Choice)
                {
                    case 1:
                        libraryuser.DisplayBook(library);
                        break;
                    case 2:
                        Console.WriteLine("Enter the book ID to borrow it :");
                        int bookid = int.Parse(Console.ReadLine());
                        libraryuser.BorrowBook(bookid, library);
                        break;
                    case 3:
                        Console.WriteLine("Enter the book ID to return it :");
                        int bookId = int.Parse(Console.ReadLine());
                        libraryuser.ReturnBook(bookId,library);
                        break;
                    case 4:
                        libraryuser.DisplayBorrowedBook(library);
                        break;
                    case 5:
                        Console.WriteLine("Exiting the system");
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again");
                        break;
                }
            }
        }

        /*
        * Menu for Librarian
        * */
        private static void LibrarianMenu(Librarian librarian, Library library)
        {
            while (true)
            {
                Console.WriteLine("Librarian Menu:");
                Console.WriteLine("[1] Add book to the Library\n[2] Remove book from the Library");
                Console.WriteLine("[3] Display Library's Books\n[4] Exit");
                Console.WriteLine("*****************************************");
                Console.WriteLine("Select Number of your choice");

                int LibrarianChoice = int.Parse(Console.ReadLine());
                switch (LibrarianChoice)
                {
                    case 1:
                        Console.WriteLine("Enter book deatails : \n Enter the Title:");
                        string bookTitle = Console.ReadLine();
                        Console.WriteLine(" Enter The Author :");
                        string bookAuthor = Console.ReadLine();

                        Book newbook = new Book(0, bookTitle, bookAuthor);
                        librarian.AddBook(newbook, library);
                        break;
                    case 2:
                        Console.WriteLine("Enter the book ID you want to remove it :");
                        int bookid = int.Parse(Console.ReadLine());
                        librarian.RemoveBook(bookid, library);
                        break;
                    case 3:
                        librarian.DisplayBook(library);
                        break;
                    case 4:
                        Console.WriteLine("Exiting the system!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again");
                        break;
                }
            }
        }
    }
}
