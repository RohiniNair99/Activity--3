﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Activity3BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity3BL.Tests
{
    [TestClass()]
    public class RegularCustomerTests
    {
        string name = "Rohit";
        string address = "Mumbai";
        DateTime date = DateTime.ParseExact("22/03/1999", "dd/MM/yyyy", null);
        Gender gend = new Gender();
        string password = "password";
        string email = "roh@gmail.com";

        [TestMethod()]
        public void RegularCustomerTest()
        {
            RegularCustomer reg = new RegularCustomer(name, address, date, email, gend, password);
            double expected = 2;
            double actual = reg.DiscountPercentage;
            Assert.AreEqual(expected, actual);


        }
    }
}