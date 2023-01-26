﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCPDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SalaryCalculate calculate = new SalaryCalculate(new PartTimeEmployee());
            calculate.CalculateSalary();
        }

    }
    //---------------------Before 

    //class FullTimeEmployee
    //{
    //    public void CalculateSalary()
    //    {
    //        Console.WriteLine("Full");
    //    }
    //}
    //class PartTimeEmployee
    //{
    //    public void CalculateSalary()
    //    {
    //        Console.WriteLine("Part");
    //    }
    //}
    //class SupportEmployee
    //{
    //    public void CalculateSalary()
    //    {
    //        Console.WriteLine("Support");
    //    }
    //}

    //class SalaryCalculate
    //{
    //    public void CalculateSalary(string employeeType)
    //    {
    //        if(employeeType == "Full")
    //        {
    //            new FullTimeEmployee().CalculateSalary();
    //        }
    //        else if(employeeType == "Support")
    //        {
    //            new SupportEmployee().CalculateSalary();
    //        }
    //        else
    //        {
    //            new PartTimeEmployee().CalculateSalary();
    //        }
    //    }
    //}

    

    // ------------------After---------------------
    public interface IEmployee
    {
        void CalculateSalary();
    }
    class FullTimeEmployee : IEmployee
    {
        public void CalculateSalary()
        {
            Console.WriteLine("Full");
        }
    }
    class PartTimeEmployee : IEmployee
    {
        public void CalculateSalary()
        {
            Console.WriteLine("Part");
        }
    }
    class SupportEmployee : IEmployee
    {
        public void CalculateSalary()
        {
            Console.WriteLine("Support");
        }
    }

    class SalaryCalculate
    {
        private readonly IEmployee _employee;
        public SalaryCalculate(IEmployee employee)
        {
            _employee = employee;
        }
        public void CalculateSalary()
        {
            this._employee.CalculateSalary();
        }
    }
   
}
