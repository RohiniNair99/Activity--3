using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity3BL
{
    public class Product
    {

        static int currentProductId;
        private string description;
        private double price;
        private string productId;
        private string productName;

        public string Description
        {
            get { return description; }
            set { description = value; }

        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public string ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }

        }

        static Product()
        {
            currentProductId = 100;
        }

        public Product()
        {
            productId = 'P' + currentProductId.ToString();
            currentProductId++;
        }

        public Product(string productName, string description, double price):this()
        {
            this.productName = productName;
            this.description = description;
            this.price = price;
        }

    }
}
