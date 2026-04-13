using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    class Product
    {
        public int ProductId;
        public string ProductName;
        public double Price;
    }
    internal class Class1
    {
        static void Main()
        {
            Product[] products = new Product[10];
            for(int i=0;i<10;i++)
            {
                products[i] = new Product();
                Console.Write("Enter Product Id: ");
                products[i].ProductId = int.Parse(Console.ReadLine());

                Console.Write("Enter Product Name: ");
                products[i].ProductName = Console.ReadLine();

                Console.Write("Enter Price: ");
                products[i].Price = double.Parse(Console.ReadLine());
            }
            var sorted = products.OrderBy(p => p.Price);
            foreach(var p in sorted)
            {
                Console.WriteLine($"{p.ProductId} {p.ProductName} {p.Price} ");
            }
            Console.Read();
        }
    }
}
