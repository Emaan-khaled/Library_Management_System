using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class Librarian : User
    {
        public Librarian(string name, string password): base(name, password, "Librarian") { }
        public void AddBook (Book newBook, Library library)
        {
            if (IsLibraryNull(library)) return;
            library.AddBook(newBook);

        }
        public void RemoveBook (int id, Library library)
        {
            if (IsLibraryNull(library)) return;
            library.RemoveBook(id);

        }

        

    }
}
