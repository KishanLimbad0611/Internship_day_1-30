using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIPDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new PartTimeEmployee();
        }
    }
    class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    class PartTimeEmployee : Employee
    {
        public decimal DailyWage { get; set; }
    }

    class FullTimeEmployee : Employee
    {
        public decimal HourlyWage { get; set; }
    }
}
