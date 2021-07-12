using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity3BL
{

    public enum customerCardType
    {
        Silver,
        Gold,
        Platinum
    }

    public class PrivilegedCustomer: Customer
    {
        private customerCardType cardType;

        public customerCardType CardType
        {
            get { return cardType; }
            set { cardType = value; }
        }

        public PrivilegedCustomer(string customerName,string address,DateTime dateOfBirth,string emailId,Gender gender,string password,customerCardType cardType)
         : base(customerName, address, dateOfBirth, emailId, gender, password)
        {
            this.cardType = cardType;
        }


    }
}
