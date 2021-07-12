using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity3BL
{
    public class Seller
    {

        private string sellerId;
        private string sellerName;
        public static int sellerIdCount;
        private string[] sellerLocations = new string[50];


        public string SellerId
        {
            get { return sellerId; }
            set { sellerId = value; }
        }

        public string SellerName
        {
            get { return sellerName; }
            set { sellerName = value; }
        }

        public string[] SellerLocations
        {
            get { return sellerLocations; }
            set { sellerLocations = value; }
        }

        static Seller()
        {
            sellerIdCount = 1001;
        }

        public Seller()
        {
            sellerId = 'S' + sellerIdCount.ToString();
            sellerIdCount++;
        }

        public Seller(string sellerName):this()
        {
            this.sellerName = sellerName;
        }
    }
}
