using System;

namespace BankingTransaction
{


    class Program
    {
        class bank
        {
            
            public static int[] balance = new int[] { 1000, 1000, 1000, 1000, 1000,0,0,0,0,0 };
            int[] acc_no = new int[] { 101, 102, 103, 104, 105,0,0,0,0,0 };

            public void displayoptions(int n)
            {
                Console.WriteLine("enter the options:");
                Console.WriteLine("1.Withdraw\t 2.Deposit\t 3.Check Balance");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        withdraw(n);
                        break;
                    case 2:
                        Deposit(n);
                        break;
                    case 3:
                        CheckBalance(n);
                        break;
                    default:
                        Console.WriteLine("invalid option");
                        break;
                }

            }

            public void accountnumbers(int id,int number)
            {

                
                int flag = 0;
                foreach (var item in acc_no)
                {
                    if (item == number)
                    {
                        flag = 1;
                        Console.WriteLine("Account Exists");
                        displayoptions(number);
                        break;
                    }
                }
                if (flag == 0)
                {
                    Console.WriteLine("Account doesn't exist, new account created");
                    Console.WriteLine("Add opening balance of rs1000");
                    acc_no[id] = number;
                    balance[id] += 1000;
                    displayoptions(number);
                }


            }
            public void withdraw(int num)
            {
                int amount;
                Console.WriteLine("enter the amount to withdraw");
                amount = int.Parse(Console.ReadLine());
                int exit = 0;
                for (int m = 0; m < acc_no.Length; m++)
                {
                    if (num == acc_no[m])
                    {
                        if (balance[m] > 500)
                        {
                            balance[m] -= amount;
                            exit = 1;
                            break;
                        }
                    }
                }
                if (exit == 0)
                {
                    Console.WriteLine("less balance amount.Requested transaction failed");
                }

            }
            public void CheckBalance(int num)
            {
                for (int k = 0; k < acc_no.Length; k++)
                {
                    if (num == acc_no[k])
                    {
                        Console.WriteLine("Balance amount is:{0}", balance[k]);
                        break;
                    }

                }


            }

            public void Deposit(int num)
            {
                int amt;
                Console.WriteLine("enter the amount to deposit");
                amt = int.Parse(Console.ReadLine());
                for (int l = 0; l < acc_no.Length; l++)
                {
                    if (num == acc_no[l])
                    {
                        balance[l] += amt;
                    }
                }

            }

            static void Main(string[] args)
            {
                int id = 5;
                Console.WriteLine("Enter Account Number");
                int number = int.Parse(Console.ReadLine());
                bank customer = new bank();
                customer.accountnumbers(id++,number);
                while (true)
                {
                    Console.WriteLine("Continue transaction? y/n");
                    char ans = Convert.ToChar(Console.ReadLine());
                    if(ans=='y')
                    {
                        customer.displayoptions(number);
                    }
                    else
                    {
                        break;
                    }
                    
                }
               
                Console.ReadLine();

            }
        }
    }
}

