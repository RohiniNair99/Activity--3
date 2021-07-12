using Microsoft.VisualStudio.TestTools.UnitTesting;
using Activity3BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity3BL.Tests
{
    [TestClass()]
    public class EliteCustomerTests
    {
        string name = "Rohit";
        string address = "Mumbai";
        DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        Gender gend = new Gender();
        string password = "password";
        string email = "roh@gmail.com";
        

        [TestMethod()]
        public void PEliteTest()
        {
            EliteCustomer obj = new EliteCustomer(name, address, date, email, gend, password, 5);
            int expected = 5;
            int actual = obj.OwnedCoupons;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void NEliteTest()
        {
            EliteCustomer obj = new EliteCustomer
                (name, address, date, email, gend, password, 5);
            int expected = 0;
            int actual = obj.OwnedCoupons;
            Assert.AreNotEqual(expected, actual);
        }
    }
}