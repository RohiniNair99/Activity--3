using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity3BL
{
    public class Purchase
    {
        private DateTime dateOfPurchase;
        private string paymentType;
        private string purchaseId;
        static int purchaseCounter;
        private int quantityOrdered;
        private string shippingAddress;

        public DateTime DateOfPurchase
        {
            get { return dateOfPurchase; }
            set { dateOfPurchase = value; }
        }

        public string PaymentType
        {
            get { return paymentType; }
            set { paymentType = value; }
        }

        public string PurchaseId
        {
            get { return purchaseId; }
            set { purchaseId = value; }

        }

        public int QuantityOrdered
        {
            get { return quantityOrdered; }
            set { quantityOrdered = value; }
        }

        public string ShippingAddress
        {
            get { return shippingAddress; }
            set { shippingAddress = value; }
        }

        public double CalculateBillAmount(double price)
        {
            return quantityOrdered * price;
        }

        public double CalculateBillAmount(double price, double discountPercentage)
        {
            return  quantityOrdered* (price - ((discountPercentage * price) / 100));
        }

        static Purchase()
        {
            purchaseCounter = 1001;
        }

        public Purchase()
        {
            purchaseId = 'B' + purchaseCounter.ToString();
            purchaseCounter++;
        }

        public Purchase(int quantityOrdered, string shippingAddress, DateTime dateOfPurchase, string paymentType):this()
        {
            this.quantityOrdered = quantityOrdered;
            this.shippingAddress = shippingAddress;
            this.dateOfPurchase = dateOfPurchase;
            this.paymentType = paymentType;
        }

        public static double RoundOffBill(double amount)
        {
            amount = (Math.Round(amount, 2));
            return amount;
        }

        public static double GetPurchasePercentage(DateTime[] transactionDates, DateTime dateForReport)
        {
            int count = 0;
            foreach (DateTime dates in transactionDates)
            {
                if (dates == dateForReport)
                    count += 1;
            }
            return (count * 100) / transactionDates.Length;
        }
    }
}
