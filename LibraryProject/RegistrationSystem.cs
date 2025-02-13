using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public  class RegistrationSystem
    {
         List<User> users = new List<User>();


        private Dictionary<string, Librarian>   LibrariansList   = new Dictionary<string, Librarian>();
        private Dictionary<string, LibraryUser> LibraryUsersList = new Dictionary<string, LibraryUser>();
        private Dictionary<string, LibraryUser> LibraryCardsList = new Dictionary<string, LibraryUser>();

        public void SignUP(string name, string password, string role)
        {
            if (role == "Librarian")
            {
                if (LibrariansList.ContainsKey(name))
                {
                    Console.WriteLine("user already exist!");
                    Console.WriteLine("*************************");
                    return;
                }
                LibrariansList[name] = new Librarian(name, password);
                Console.WriteLine($"{name} signed in succefully as [Librarian]");
                Console.WriteLine("*************************");

            }
            else if (role == "LibraryUser")
            {
                if (LibraryUsersList.ContainsKey(name))
                {
                    Console.WriteLine("user already exist!");
                    Console.WriteLine("*************************");
                    return;
                }
                LibraryUser newlibraryuser = new LibraryUser(name, password);
                LibraryUsersList[name] = newlibraryuser;
                LibraryCardsList[newlibraryuser.Card.CardNumber] = newlibraryuser;
                Console.WriteLine($"{name} signed in succefully as [LibraryUser] ");
                newlibraryuser.DisplayCardInfo();
                Console.WriteLine("*************************");

            }
            else
            {
                Console.WriteLine("Invalid role, please try again");
                Console.WriteLine("*************************");
            }

        }
        public User Login(string name, string password)
        {
            if (LibrariansList.TryGetValue(name, out Librarian librarian) && librarian.VerifyPassword(password))
            {
                Console.WriteLine($"Welcome to the library : {librarian.Name}!");
                Console.WriteLine("*************************");
                return librarian;
            }

            Console.WriteLine("Invaild username or password");
            Console.WriteLine("*************************");
            return null;
        }
         public User CardLogin(string cardno)
        {
            if (LibraryCardsList.TryGetValue(cardno, out LibraryUser user))
            {
                Console.WriteLine($"Welcome to the library : {user.Name}!");
                Console.WriteLine("*************************");
                return user;
            }

            Console.WriteLine("Invaild Card Number, please try again");
            Console.WriteLine("*************************");
            return null;
        }

       
    }
}
