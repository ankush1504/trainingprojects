using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace constructorassignment
{
    class Product
    {
        static void Main(string[] args)
        {
            string[] products = new string[] { "pen", "pencil", "eraser", "scale" };
            int[] price = new int[] { 10, 5, 3, 15 };
            Console.WriteLine("Product Details:");
            Console.WriteLine("product \t price \t");
            Console.WriteLine();
            for (int i = 0; i < 4; i++)
            {

                Console.Write("{0} \t\t {1}\n", products[i], price[i]);
            }
            Console.WriteLine();
            Console.WriteLine("enter number of items to buy:");
            int itemquant = int.Parse(Console.ReadLine());
            string[] selectitem = new string[itemquant];
            Console.WriteLine("enter the products to buy");
            for (int k = 0; k < itemquant; k++)
            {
                selectitem[k] = Console.ReadLine();
            }


            int quantity, count = 0 ;
            int total = 0;
            string flag = "false";
            foreach (var item in selectitem)
            { 
                for (int j = 0; j < 4; j++)
                {
                    if (item.ToLower() == products[j])
                    {
                        Console.WriteLine("enter {0} quantity:",products[j]);
                        quantity = int.Parse(Console.ReadLine());
                        total = total + quantity * price[j];
                        flag = "true";
                        break;
                    }
                    count++;
                }
                if(count==4)
                {
                    Console.WriteLine("the product {0} is not available",item);
                }
            }
           
            if (flag=="false")
            {
                Console.WriteLine("product not found");
            }
            else
            {
                Console.WriteLine("total price is:{0}", total);
            }
            Console.ReadLine();
   

        }
    }
}
