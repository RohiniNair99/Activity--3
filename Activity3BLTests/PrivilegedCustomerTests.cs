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
    public class PrivilegedCustomerTests
    {

        string name = "Rohit";
        string address = "Mumbai";
        DateTime date = DateTime.ParseExact("22/03/1999", "dd/MM/yyyy", null);
        Gender gend = new Gender();
        string password = "password";
        string email = "roh@gmail.com";
        customerCardType cardType = (customerCardType)Enum.Parse(typeof(customerCardType),"Platinum");

        [TestMethod()]
        public void PrivilegedCustomerTest()
        {
            PrivilegedCustomer p = new PrivilegedCustomer(name, address, date, email, gend, password, cardType);
            customerCardType actual = p.CardType;
            customerCardType expected= (customerCardType)Enum.Parse(typeof(customerCardType), "Platinum");
            Assert.AreEqual(actual, expected);
        }
    }
}