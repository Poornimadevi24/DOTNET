/*3. Create a class called Saledetails which has data members like Salesno,  Productno,  Price, dateofsale, Qty, TotalAmount
- Create a method called Sales() that takes qty, Price details of the object and updates the TotalAmount as  Qty *Price
- Pass the other information like SalesNo, Productno, Price,Qty and Dateof sale through constructor
- call the show data method to display the values without an object.*/
using System;

namespace Assignment3
{
    class SaleDetails
    {
        int SalesNo;
        int ProductNo;
        double Price;
        int Qty;
        DateTime DateOfSale;
        double TotalAmount;

       
        public SaleDetails(int salesNo, int productNo, double price, int qty, DateTime date)
        {
            SalesNo = salesNo;
            ProductNo = productNo;
            Price = price;
            Qty = qty;
            DateOfSale = date;
        }

        
        public void Sales()
        {
            TotalAmount = Qty * Price;
        }

        
        public static void ShowData(SaleDetails s)
        {
            Console.WriteLine("\n--- Sale Details ---");
            Console.WriteLine("Sales No: " + s.SalesNo);
            Console.WriteLine("Product No: " + s.ProductNo);
            Console.WriteLine("Price: " + s.Price);
            Console.WriteLine("Quantity: " + s.Qty);
            Console.WriteLine("Date of Sale: " + s.DateOfSale);
            Console.WriteLine("Total Amount: " + s.TotalAmount);
        }

        class Program
        {
            static void Main()
            {
                SaleDetails s = new SaleDetails(1, 101, 50.0, 3, DateTime.Now);

                s.Sales();
               SaleDetails.ShowData(s);
            }
        }
    }
}
