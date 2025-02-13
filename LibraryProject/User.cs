using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public abstract class User
    {
        public string Name { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }

        public User(string name, string password, string role)
        {
            Name = name;
            Password = password;
            Role = role;
        }

        public bool VerifyPassword (string password)
        {
            return Password == password;
        }
        public void DisplayBook (Library library)
        {
            if (IsLibraryNull(library)) return;
            library.DisplayBook();
        }

        public override string ToString()
        {
            return $"User : {Name} , Role: {Role}";
        }

        //check if library exist
        public bool IsLibraryNull(Library library)
        {
            if (library == null)
            {
                Console.WriteLine("Library can't found");
                return true;
            }
            return false;

        }

    }
}
