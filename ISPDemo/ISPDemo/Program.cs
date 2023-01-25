// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPDemo
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public interface IPrinterCommonOperation
    {
        void Print(string PrintContent);
        void Scan(string ScanContent);
    }

    public interface IFaxOperation
    {
        void Fax(string FaxContent);
    }

    public interface IPrintDuplexOperation
    {
        void PrintDuplex(string PrintDuplexContent);
    }


    //public interface IPrinterOperation
    //{
    //    void Print(string PrintContent);
    //    void Scan(string ScanContent);
    //    void Fax(string FaxContent);
    //    void PrintDuplex(string PrintDuplex);
    //}
    

    // --------------canon Printer----------
    public class CanonPrinter : IPrinterCommonOperation, IFaxOperation, IPrintDuplexOperation
    {
        public void Fax(string FaxContent)
        {
            Console.WriteLine(FaxContent);
        }

        public void Print(string PrintContent)
        {
            Console.WriteLine(PrintContent);
        }

        public void PrintDuplex(string PrintDuplex)
        {
            Console.WriteLine(PrintDuplex);
        }

        public void Scan(string ScanContent)
        {
            Console.WriteLine(ScanContent);
        }
    }


    //--------  HPLaserPrinter------------
    public class HPLaserPrinter : IPrinterCommonOperation
    {

        public void Print(string PrintContent)
        {
            Console.WriteLine(PrintContent);
        }
        public void Scan(string ScanContent)
        {
            Console.WriteLine(ScanContent);
        }
    }


    //--------unknown company------
    public class ABCPrinter : IFaxOperation
    {
        public void Fax(string FaxContent)
        {
            Console.WriteLine(FaxContent);
        }
    }
}