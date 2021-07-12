using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Activity3BL;
namespace Activity_3
{
    class MyCart
    {
        static void Main(string[] args)
        {
            Gender gen = new Gender();
            double price = 0.0D;
            string sellerName = "";
            int quantityOrdered = 0;
            DateTime dateOfPurchase = new DateTime();
            string paymentType = "";
            string productName = "", description = "";
            string[] sellerLoc = new string[30];
            double discountPrice = 0.0D;

            try
            {
                Console.WriteLine("Enter the Customer Name: ");
                string name = Console.ReadLine();
                if (name == null)
                {
                    throw new ArgumentException();
                }
                Console.WriteLine("Enter Customer Address: ");
                string address = Console.ReadLine();
                if (address == null)
                {
                    throw new ArgumentException();
                }

                Console.WriteLine("Date of Birth: ");
                DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                Console.WriteLine("Gender: ");
                gen.gender = Console.ReadLine();

                Console.WriteLine("Enter mail id");
                string email = Console.ReadLine();
                if (!email.Contains('@') || !email.Contains('.'))
                {
                    throw new FormatException();
                }
                Console.WriteLine("enter password: ");
                string password = Console.ReadLine();
                if (password == null)
                {
                    throw new ArgumentException();
                }

                Console.WriteLine("Choose the type of customer: \n1.Regular  \n2.Privileged  \n3.Elite");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice.GetType() != typeof(int) || choice > 3 || choice < 1)
                {
                    throw new ArgumentException();
                }
                
                Console.WriteLine("Enter Product Name:");
                productName = Console.ReadLine();
                if (productName == null)
                    throw new ArgumentException();
                if (productName != null)
                    foreach (char ch in productName)
                    {
                        if ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z') || (ch == ' '))
                            continue;
                        else
                            throw new ArgumentException();
                    }

                Console.WriteLine("Enter Product Description:");
                description = Console.ReadLine();
                if (description == null)
                    throw new ArgumentException();
                if (description != null)
                    foreach (char ch in description)
                    {
                        if ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z') || (ch == ' '))
                            continue;
                        else
                            throw new ArgumentException();
                    }
                Console.WriteLine("Enter Price:");
                price = Convert.ToDouble(Console.ReadLine());
                if (price.GetType() != typeof(double))
                    throw new ArgumentException();

                Console.WriteLine("Enter Purchase Date:");
                dateOfPurchase = DateTime.ParseExact(Console.ReadLine(), "dd/mm/yyyy", null);
                if (dateOfPurchase.GetType() != typeof(DateTime))
                    throw new ArgumentException();

                Console.WriteLine("Enter PaymentType:");
                paymentType = Console.ReadLine();
                if (paymentType == null && paymentType.GetType() != typeof(string))
                    throw new ArgumentException();

                Console.WriteLine("Enter Seller Name:");
                sellerName = Console.ReadLine();
                if (sellerName == null)
                    throw new ArgumentException();
                if (sellerName != null)
                    foreach (char ch in sellerName)
                    {
                        if ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z') || (ch == ' '))
                            continue;
                        else
                            throw new ArgumentException();
                    }


                Console.WriteLine("Enter number of locations seller available:");
                int numloc = Convert.ToInt32(Console.ReadLine());
                if (numloc.GetType() != typeof(int))
                    throw new ArgumentException();
                for (int index = 0; index < numloc; index++)
                {
                    Console.WriteLine($"Enter Location {index + 1}: ");
                    sellerLoc[index] = Console.ReadLine();
                }


                /* sellerId = Console.ReadLine();
                 if (sellerId == null && sellerId.GetType() != typeof(string))
                     throw new ArgumentException();*/

                Console.WriteLine("Enter Quantity Entered:");
                quantityOrdered = Convert.ToInt32(Console.ReadLine());
                if (quantityOrdered.GetType() != typeof(int))
                    throw new ArgumentException();

                Product product = new Product(productName, description, price);
                Purchase purchase = new Purchase(quantityOrdered, address, dateOfPurchase, paymentType);
                Seller seller = new Seller(sellerName);
                seller.SellerLocations = sellerLoc;

                switch (choice)
                {
                    case 1:
                        RegularCustomer customer = new RegularCustomer(name, address, date, email, gen, password);
                        Console.WriteLine($"Customer Information: \n\nCustomer Name:{customer.CustomerName} \nCustomer Address: {customer.Address} \nCustomer Type: Regular \nCustomer Birthdate: {customer.DateOfBirth} \nEmailId: {customer.EmailId} \nGender: {gen.gender} \nPassword: {customer.Password} \nDiscount Percentage: {customer.DiscountPercentage}");
                        discountPrice = purchase.CalculateBillAmount(price, customer.DiscountPercentage);
                        break;
                    case 2:
                        Console.WriteLine("\nDiscounts: \nPlatinum=50% \nGold=30% \nSilver=15%");
                        Console.WriteLine("Enter Card Type: ");
                        customerCardType cardType = (customerCardType)Enum.Parse(typeof(customerCardType), Console.ReadLine());
                        PrivilegedCustomer pcustomer = new PrivilegedCustomer(name, address, date, email, gen, password, cardType);
                        if (cardType == customerCardType.Platinum)
                            discountPrice = purchase.CalculateBillAmount(price, 50);
                        else if (cardType == customerCardType.Gold)
                            discountPrice = purchase.CalculateBillAmount(price, 30);
                        else if (cardType == customerCardType.Silver)
                            discountPrice = purchase.CalculateBillAmount(price, 15);
                        else
                            discountPrice = purchase.CalculateBillAmount(price);
                        Console.WriteLine($"Customer Information: \n\nCustomer Name:{pcustomer.CustomerName} \nCustomer Address: {pcustomer.Address} \nCustomer Type: Privileged \nCustomer Birthdate: {pcustomer.DateOfBirth} \nEmailId: {pcustomer.EmailId} \nGender: {gen.gender} \nPassword: {pcustomer.Password} \nCard Type: {pcustomer.CardType}");
                        break;
                    case 3:
                        
                        Console.WriteLine("\nDiscount for 1 coupon is 5%");
                        Console.WriteLine("Enter number of owned coupons: ");
                        int coupons = Convert.ToInt32(Console.ReadLine());
                        if (coupons.GetType() != typeof(int))
                        {
                            throw new ArgumentException();
                        }
                        discountPrice = price*quantityOrdered;
                        for (int coup=0;coup<coupons;coup++)
                        {
                            discountPrice = purchase.CalculateBillAmount(discountPrice/quantityOrdered, 5);
                        }
                        EliteCustomer ecustomer = new EliteCustomer(name, address, date, email, gen, password, coupons);
                        Console.WriteLine($"Customer Information: \n\nCustomer Name:{ecustomer.CustomerName} \nCustomer Address: {ecustomer.Address} \nCustomer Type : Elite  \nCustomer Birthdate: {ecustomer.DateOfBirth} \nEmailId: {ecustomer.EmailId} \nGender: {gen.gender} \nPassword: {ecustomer.Password} \nOwned Coupons: {ecustomer.OwnedCoupons}");
                        break;
                }

                

                Console.WriteLine($"\n\nSeller details:\n \nSeller Name: {seller.SellerName} \nSeller Id: {seller.SellerId}\nSeller loc:");
                for (int loop = 0; loop < numloc; loop++)
                {
                    Console.WriteLine($"Location{loop + 1}:{seller.SellerLocations[loop]}");
                }
                Console.WriteLine($"\n\nProduct details:\n\nProduct Name: {product.ProductName} \nProduct Id: {product.ProductId} \nProduct Description: {product.Description} \nPrice: {product.Price} ");
                Console.WriteLine($"\n\n Purchase details: \n\nPurchase Id: {purchase.PurchaseId} \nShipping Address: {purchase.ShippingAddress} \nPurchase Date: {purchase.DateOfPurchase} \nPurchase quantity : {purchase.QuantityOrdered} \nPayment Type: {purchase.PaymentType} \nBill Amount: {discountPrice} \nRounded off Amount: {Purchase.RoundOffBill(discountPrice)}");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid format");
            }

            finally
            {
                Console.ReadLine();
                System.Environment.Exit(1000);
            }

        }
    }
}
