using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity3BL
{
    public class EliteCustomer:Customer
    {
        private int ownedCoupons;

        public int OwnedCoupons
        {
            get { return ownedCoupons; }
            set {
                if (value <= 0)
                    throw new InvalidOperationException("Value should be greater than 0");
                ownedCoupons = value; }
        }

        public EliteCustomer(string customerName,string address,DateTime dateOfBirth,string emailId,Gender gender,string password,int ownedCoupons)
        :base(customerName,address,dateOfBirth,emailId,gender,password)
        {
            this.ownedCoupons = ownedCoupons;
        }
    }
}
