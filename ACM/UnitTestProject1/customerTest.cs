using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.Remoting;

namespace UnitTestProject1
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void FullNameTestValid()
        {
            //----Arrange 
            Customer customer = new customer;
            {
                FirstName = "Bilbo",
                LastName = "Baggins"
            };

            string expected = "Baggins, Bilbo";
            
            //----Act 
            string actual = customer.FullName;

            //----Assert
            Assert.AreEqual(expected, actual);
        }
    }
}




