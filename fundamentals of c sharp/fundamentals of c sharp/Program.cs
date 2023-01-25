// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//------------hello world------

//namespace Helloworld
//{
//    class Program
//    {  
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Hello World");
//        }
//    }
//}


//-------------variable output------

//namespace Variables
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var number = 2;
//            var num = 10;
//            var complex = 2.34f;
//            var name = "kishan";
//            var isit = false;
//            const float k = 2.43f;

//            Console.WriteLine(number);
//            Console.WriteLine(num);
//            Console.WriteLine(complex);
//            Console.WriteLine(name);
//            Console.WriteLine(isit);
//            Console.WriteLine(k);
//        }
//    }
//}


//--------------conversion------------

namespace conversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // ----implict 
            //byte k = 2;
            //int m = k;

            // --- explict
            //int k = 2000;
            //byte m = (byte)k;

            // -----convert type---
            //var number = "12345";
            //int m = Convert.ToInt32(number);
            //Console.WriteLine(m);


            //------try catch----
            //try
            //{
            //    var number = "12345";
            //    int m = Convert.ToByte(number);
            //    Console.WriteLine(m);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("the numbr could not converted");
            //}

            //--------2nd try catch-----
            //try
            //{
            //    string str = "true";
            //    bool b = Convert.ToBoolean(str); 
            //    Console.WriteLine(b);

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("the number could not converted");
            //}


            //--------operator-------

            //var a = 5;
            //var b = 21;
            //var c = 23;

            //Console.WriteLine(a+b*c);
            //Console.WriteLine(!(a != c));
            //Console.WriteLine(c>b && a<b);
            //Console.WriteLine(c>b || a>b);

            //var a = 2;
            //var b = a++;

            //var c = 3;
            //var d = ++c;
            //Console.WriteLine(a);   
            //Console.WriteLine(b);
            //Console.WriteLine(c);   
            //Console.WriteLine(d);
        }
    }
}


