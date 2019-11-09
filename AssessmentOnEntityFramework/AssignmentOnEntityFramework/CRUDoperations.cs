using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOnEntityFramework
{
    class CRUDoperations
    {
        public static void InsertEmployee()
        {
            Console.WriteLine("enter firstname,lastname,gender,salary and department of of an employee");
            Employee e = new Employee();
            e.FirstName = Console.ReadLine();
            e.LastName = Console.ReadLine();
            e.Gender = Console.ReadLine();
            e.Salary = int.Parse(Console.ReadLine());
            e.DepartmentID = int.Parse(Console.ReadLine());

            DBfirstDemoEntities db = new DBfirstDemoEntities();
            db.Employees.Add(e);
            db.SaveChanges();
        }
        public static void DisplayEmployee()
        {
            using (var db = new DBfirstDemoEntities())
            {
                var deptlist = db.Departments;

                var emplist = db.Employees;
                Console.WriteLine("ID \t FirstName \t LastName \t Gender \t Salary \t DepartmentID");
                foreach (var emp in emplist)
                {
                    Console.WriteLine($"{emp.ID} \t {emp.FirstName} \t\t {emp.LastName} \t {emp.Gender} \t\t {emp.Salary} \t\t\t {emp.DepartmentID}");
                }
            }
        }

        public static void UpdateEmployee()
        {

            DBfirstDemoEntities db = new DBfirstDemoEntities();

            try
            {
                Console.WriteLine("enter the id to update");
                int identity = int.Parse(Console.ReadLine());
                Employee emp = db.Employees.First(x => x.ID == identity);
                Console.WriteLine("enter firstname,lastname,gender,salary,department id");
                emp.FirstName = Console.ReadLine();
                emp.LastName = Console.ReadLine();
                emp.Gender = Console.ReadLine();
                emp.Salary = int.Parse(Console.ReadLine());
                emp.DepartmentID = int.Parse(Console.ReadLine());
                db.SaveChanges();


            }
            catch (Exception e)
            {

                Console.WriteLine("error:" + e.Message);
            }

        }

        public static void DeleteEmployee()
        {
            DBfirstDemoEntities db = new DBfirstDemoEntities();
            try
            {
                Console.WriteLine("enter the id to update");
                int identity = int.Parse(Console.ReadLine());
                Employee emp = db.Employees.First(x => x.ID == identity);
                db.Employees.Remove(emp);
                db.SaveChanges();

            }
            catch (Exception e)
            {

                Console.WriteLine("error:" + e.Message);
            }
        }

        public static void DisplayDepartmentEmp()
        {
            DBfirstDemoEntities db = new DBfirstDemoEntities();
            try
            {
                Console.WriteLine("enter the department id according to the following table:");
                var deptlist = db.Departments;
                var emplist = db.Employees;
                foreach(var dep1 in deptlist)
                {
                    Console.WriteLine(dep1.ID+" "+dep1.Name);
                }
                int identity = int.Parse(Console.ReadLine());
                Department dep = db.Departments.FirstOrDefault(x => x.ID == identity);
                Console.WriteLine("Department: "+dep.Name);
                Console.WriteLine(" Employees:");
                Console.WriteLine("\t ID \t FirstName \t LastName \t Gender \t Salary");
                foreach (var emp1 in emplist)
                {
                    if(emp1.DepartmentID==dep.ID)
                    {
                        Console.WriteLine($"\t {emp1.ID} \t {emp1.FirstName} \t\t {emp1.LastName} \t {emp1.Gender} \t\t {emp1.Salary}");
                    }

                }
            }

            catch (Exception e)
            {

                Console.WriteLine("error:" + e.Message);
            }

        }
        static void Main(string[] args)
        {
            int exit = 0;
            while (true)
            {

                CRUDoperations emp = new CRUDoperations();
                Console.WriteLine("enter the options:");
                Console.WriteLine("1.To Insert \t 2.To Display table \t 3. To Update \t 4.To delete \t 5.To Display Employees in a Department \t 6.To Exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        InsertEmployee();
                        break;
                    case 2:
                        DisplayEmployee();
                        break;
                    case 3:
                        UpdateEmployee();
                        break;
                    case 4:
                        DeleteEmployee();
                        break;
                    case 5:
                        DisplayDepartmentEmp();
                        break;
                    case 6:
                        exit = 1;
                        break;
                    default:
                        Console.WriteLine("invalid choice");
                        break;
                }
                if (exit == 1)
                {
                    break;
                }
            }




            Console.ReadLine();
        }
}
}
