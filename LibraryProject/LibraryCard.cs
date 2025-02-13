using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibraryManagementSystem
{
    public class LibraryCard
    {
        public string CardNumber { get; private set; }
        public string CardName { get;private set; }
        public LibraryCard(string name)
        {
            CardNumber = GenerateCardNumber();
            CardName = name;
        }

         string GenerateCardNumber()
        {
            Random random = new Random();
            return "LIB - " +random.Next(1000, 9999);
        }        

    }
}
