using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public bool IsBorrowed { get;set; } 

        // Constructor to initialize a book
        public Book (int id, string title, string author)
        {
            ID = id;
            Title = title??"Unknown";
            Author = author ?? "Unknown";
            IsBorrowed = false;
        }
        public override string ToString ()
        {
            return $"Title: {Title} - Author: {Author} - ID: {ID} - {(IsBorrowed? "Borrowed": "avialble")}";
        }

      


    }
}
