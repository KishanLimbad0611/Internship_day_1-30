// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPDemo
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public class CustomerDataAccess : ICustomerDataAccess
    {
        public CustomerDataAccess()
        {

        }

        public string GetCustomerNameDataAccess()
        {
            return "Customer Name";
        }
    }

    public interface ICustomerDataAccess
    {
        string GetCustomerNameDataAccess();
    }

    public class DataAccessFactory
    {
        public static ICustomerDataAccess GetCustomerName()
        {
            return new CustomerDataAccess(); 
        }
    }
    public class CustomerBL
    {
        public CustomerBL()
        {

        }
        public void GetCustomerNameBL()
        {
            ICustomerDataAccess obj = DataAccessFactory.GetCustomerName();
            obj.GetCustomerNameDataAccess();
        }
    }
}
