using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace class_and_object_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book1= new Book();
            book1.title = "Mr name";
            book1.description = "hello";
            book1.pages = 700;

            Console.WriteLine(book1.title);
            Console.WriteLine(book1.description);
            Console.WriteLine(book1.pages);
            Console.ReadLine();
        }
       

    }
}
