using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class Library
    {
        private List<Book> Books = new List<Book>();


        // follow borrowed book wihtin user card
        private Dictionary<string, List<Book> > BorrowedBooks = new Dictionary<string, List<Book>>();
        
        private int bookID = 1;

        // Add new book to library
        public void AddBook(Book book)
        {
            book.ID = bookID++;
            Books.Add(book);
            Console.WriteLine($"The {book.Title} Book added successfully");
            Console.WriteLine("********************************************");

            
        }

        // Remove book from library
        public void RemoveBook(int bookid)
        {
            Book booktoremove = Books.Find(b => b.ID == bookid);
            if (booktoremove != null)
            {
                Books.Remove(booktoremove);
                Console.WriteLine($"{booktoremove.Title}Book removed successfully");
                Console.WriteLine("***************");
            }
            else
            {
                Console.WriteLine("Book not found");
                Console.WriteLine("***************");
            }


        }

        // Display all books in the library
        public void DisplayBook()
        {
            if (bookID == 0)
            {
                Console.WriteLine("NO books found to display");
                Console.WriteLine("***************");
                return;
            }
                Console.WriteLine("Here is Library's Books: ");
                foreach (var book in Books)
                {
                Console.WriteLine(book.ToString());
                }
                Console.WriteLine("***************");            
        }

        //Borrow book from library
        public void BorrowBook(int bookid, LibraryUser user)
        {
            Book book = Books.Find(b => b.ID == bookid && !b.IsBorrowed);
            if (book != null)
            {
                book.IsBorrowed = true;
                if (!BorrowedBooks.ContainsKey(user.Card.CardNumber))
                {
                    BorrowedBooks[user.Card.CardNumber] = new List<Book>();
                }
                BorrowedBooks[user.Card.CardNumber].Add(book);
                Console.WriteLine($"[{user.Name}] has borrowed [{book.Title}] book successfully");             
            }
            else
            {
                Console.WriteLine("Book is not avillable for borrowing");

            }
        } 

        //Display the list ob borrowed boo by a specfic user
        public void DisplayBorrowBook(LibraryUser user)
        {
            if (BorrowedBooks.ContainsKey(user.Card.CardNumber) && BorrowedBooks[user.Card.CardNumber].Count>0)
            {
                Console.WriteLine($" the borrowed books list by [{user.Name}] is : ");
                foreach (var book in BorrowedBooks[user.Card.CardNumber])
                {
                    Console.WriteLine(book.ToString());
                    Console.WriteLine("*******************************");
                }
            }
            else
            {
                Console.WriteLine("No books borrowed by this user");
                Console.WriteLine("*******************************");
            }

        } 

        //return a borrowed book to the library
        public void ReturnBook(int bookid, LibraryUser user)
        {
            if (BorrowedBooks.ContainsKey(user.Card.CardNumber))
            {
                Book book = BorrowedBooks[user.Card.CardNumber].Find(b => b.ID==bookid);
                if (book != null)
                {
                    book.IsBorrowed = false;
                    BorrowedBooks[user.Card.CardNumber].Remove(book);
                    Console.WriteLine($"book {book.Title} return successfully");
                    Console.WriteLine("*******************************");

                }
                else
                {
                    Console.WriteLine($"book not found in your borrowed");
                    Console.WriteLine("*******************************");
                }

            }
               
            else
                
            {
                Console.WriteLine("No Book borrowed by this user");               
            }
            }

        }
    }

