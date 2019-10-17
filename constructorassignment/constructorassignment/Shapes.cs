using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace constructorassignment
{
    
    class Shapes
    {
        int side,len,bre;
        double rad, a, b, c;
        Shapes(int side)
        {
            this.side = side;
            Console.WriteLine("Area of square is:{0}",this.side*this.side);
        }
        Shapes(int len,int bre)
        {
            this.len = len;
            this.bre = bre;
            Console.WriteLine("Area of Rectangle is:{0}", this.len * this.bre);
        }
        Shapes(double rad)
        {
            this.rad = rad;
            Console.WriteLine("Area of circle is:{0}",3.14*this.rad*this.rad);
        }
        Shapes(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            double s,ar;
            s = (this.a +this.b +this.c) / 2;
            ar = s * (s - this.a) * (s - this.b) * (s - this.c);
            ar = Math.Pow(ar, 0.5);
            Console.WriteLine("Area of rectangle is:{0}",ar);
        }

        static void Main(string[] args)
        {

            Console.WriteLine("enter the following options to calculate area of respective shapes\n");
            Console.WriteLine("1.Square\t 2.Rectangle\t 3.Circle\t 4.Triangle");
            int choice = int.Parse(Console.ReadLine());
            switch(choice)
            {
                case 1: Console.WriteLine("enter side of a square");
                    int side = int.Parse(Console.ReadLine());
                    Shapes a1 = new Shapes(side);
                    break;
                case 2:
                    Console.WriteLine("enter length and breadth of Rectangle");
                    int len = int.Parse(Console.ReadLine());
                    int bre = int.Parse(Console.ReadLine());
                    Shapes a2 = new Shapes(len,bre);
                    break;
                case 3:
                    Console.WriteLine("enter Radius of a Circle");
                    double rad = Convert.ToDouble(Console.ReadLine());
                    Shapes a3 = new Shapes(rad);
                    break;
                case 4:
                    Console.WriteLine("enter sides of Rectangle");
                    int a = int.Parse(Console.ReadLine());
                    int b = int.Parse(Console.ReadLine());
                    int c = int.Parse(Console.ReadLine());
                    Shapes a4 = new Shapes(a, b,c);
                    break;
                default:
                    Console.WriteLine("invalid entry");
                    break;

            }
            Console.ReadLine();
                
        }
    }
}
