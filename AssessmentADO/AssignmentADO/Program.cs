using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AssignmentADO
{
    class Program
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        static void Main(string[] args)
        {
            Program prog = new Program();
           
            int exit = 0;
            while(true)
            {
                Console.WriteLine("enter options:\n 1.To Insert\t 2.To Read\t 3.To Exit");
                int choice = int.Parse(Console.ReadLine());
                switch(choice)
                {
                    case 1: Console.WriteLine("Select Table to Insert\n 1.Customer\t 2.Supplier\t 3.Products" );
                        int sel = int.Parse(Console.ReadLine());
                        switch(sel)
                        {
                            case 1:prog.insertCustomer();
                                break;
                            case 2:prog.insertSupplier();
                                break;
                            case 3:prog.insertProduct();
                                break;
                            default:
                                Console.WriteLine("invalid choice");
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("Select Table to Read\n 1.Customer\t 2.Supplier\t 3.Products");
                        int sel1 = int.Parse(Console.ReadLine());
                        switch (sel1)
                        {
                            case 1:
                                prog.ReadCustomer();
                                break;
                            case 2:
                                prog.ReadSupplier();
                                break;
                            case 3:
                                prog.ReadProduct();
                                break;
                            default:
                                Console.WriteLine("invalid choice");
                                break;
                        }
                        break;
                    case 3: exit = 1;
                        break;
                    default: Console.WriteLine("invalid choice");
                        break;
                }
                if(exit==1)
                {
                    break;
                }

            }


            Console.ReadLine();
        }

        public void insertCustomer()
        {
            Console.WriteLine("enter the name,Number of Products,Supplier Id and Product Id");
            Customer cus = new Customer();
            cus.Name = Console.ReadLine();
            cus.Number_products = int.Parse(Console.ReadLine());
            cus.SupplierId = int.Parse(Console.ReadLine());
            cus.ProductId = int.Parse(Console.ReadLine());
            con = new SqlConnection();
            con.ConnectionString = @"data source=IN5CG9214Y0Z\MSSQLSERVER01;database=ADOassessment;integrated security=true";
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@Name", cus.Name);
            cmd.Parameters.AddWithValue("@Product", cus.Number_products);
            cmd.Parameters.AddWithValue("@SupplierId", cus.SupplierId);
            cmd.Parameters.AddWithValue("@ProductId", cus.ProductId);


            cmd.CommandText = "insert into Customers values(@Name,@Product,@SupplierId,@ProductId)";
            cmd.Connection = con;
            con.Open();
            int rowcount = cmd.ExecuteNonQuery();
            if (rowcount > 0)
            {
                Console.WriteLine("inserted successfully");
            }
            con.Close();
         
        }

        public void ReadCustomer()
        {
            con = new SqlConnection();
            con.ConnectionString = @"data source=IN5CG9214Y0Z\MSSQLSERVER01;database=ADOassessment;integrated security=true";
            cmd = new SqlCommand();
            cmd.CommandText = "select * from Customers";
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            Console.WriteLine($"Id\t\tName\t\tNo_Of_Products\t\tSupplierId\t\tProductId");
            while (rdr.Read())
            {
                Console.WriteLine($"{rdr[0]}\t\t{rdr[1]}\t\t{rdr[2]}\t\t{rdr[3]}\t\t{rdr[4]}");
            }
            con.Close();
        }

        public void insertSupplier()
        {
            Console.WriteLine("enter the name,Location,Product Id and price");
            Supplier sup = new Supplier();
            sup.Name = Console.ReadLine();
            sup.Location = Console.ReadLine();
            sup.ProductId = int.Parse(Console.ReadLine());
            sup.Price = int.Parse(Console.ReadLine());
            con = new SqlConnection();
            con.ConnectionString = @"data source=IN5CG9214Y0Z\MSSQLSERVER01;database=ADOassessment;integrated security=true";
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@Name", sup.Name);
            cmd.Parameters.AddWithValue("@Location", sup.Location);
            cmd.Parameters.AddWithValue("@Price", sup.Price);
            cmd.Parameters.AddWithValue("@ProductId", sup.ProductId);


            cmd.CommandText = "insert into Suppliers values(@Name,@Location,@Price,@ProductId)";
            cmd.Connection = con;
            con.Open();
            int rowcount = cmd.ExecuteNonQuery();
            if (rowcount > 0)
            {
                Console.WriteLine("inserted successfully");
            }
            con.Close();

        }
        public void ReadSupplier()
        {
            con = new SqlConnection();
            con.ConnectionString = @"data source=IN5CG9214Y0Z\MSSQLSERVER01;database=ADOassessment;integrated security=true";
            cmd = new SqlCommand();
            cmd.CommandText = "select * from Suppliers";
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            Console.WriteLine($"Id\t\tName\t\tLocation\t\tProductId\t\tPrice");
            while (rdr.Read())
            {
                Console.WriteLine($"{rdr[0]}\t\t{rdr[1]}\t\t{rdr[2]}\t\t{rdr[4]}\t\t{rdr[3]}");
            }
            con.Close();
        }
        public void insertProduct()
        {
            Console.WriteLine("enter the Product name");
            Product pro = new Product();
            pro.Name = Console.ReadLine();
            con = new SqlConnection();
            con.ConnectionString = @"data source=IN5CG9214Y0Z\MSSQLSERVER01;database=ADOassessment;integrated security=true";
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@Name", pro.Name);
        
            cmd.CommandText = "insert into Products values(@Name)";
            cmd.Connection = con;
            con.Open();
            int rowcount = cmd.ExecuteNonQuery();
            if (rowcount > 0)
            {
                Console.WriteLine("inserted successfully");
            }
            con.Close();
        }
        public void ReadProduct()
        {
            con = new SqlConnection();
            con.ConnectionString = @"data source=IN5CG9214Y0Z\MSSQLSERVER01;database=ADOassessment;integrated security=true";
            cmd = new SqlCommand();
            cmd.CommandText = "select * from Products";
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            Console.WriteLine($"Id\t\tName");
            while (rdr.Read())
            {
                Console.WriteLine($"{rdr[0]}\t\t{rdr[1]}");
            }
            con.Close();
        }
    }
   
}
