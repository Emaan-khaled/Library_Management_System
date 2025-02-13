using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class LibraryUser : User
    {
        public LibraryCard Card { get; private set; }

        // Constructor to initalize a library user
        public LibraryUser(string name, string password) : base (name, password, "LibraryUser")
        {
            Card = new LibraryCard(name);
        }

        // Display the user's library card information 
        public void DisplayCardInfo ()
        {
            Console.WriteLine($"Your Card name   is : {Card.CardName} ");
            Console.WriteLine($"Your Card number is : {Card.CardNumber} ");
            Console.WriteLine("**********************************************");
        }


        //Borrow book from library
        public void BorrowBook(int bookid,Library library)
        {
            if (IsLibraryNull(library)) return;

            library.BorrowBook(bookid,this);
        }

        

        //Display the list of book borrowed by the user
        public void DisplayBorrowedBook(Library library)
        {
            if (IsLibraryNull(library)) return;
            library.DisplayBorrowBook(this);
        }

        //return the borrowed book to the library
        public void ReturnBook(int bookid, Library library)
        {
            if (IsLibraryNull(library)) return;
            library.ReturnBook(bookid,this);
        }





}
}
