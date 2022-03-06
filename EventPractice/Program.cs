using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using AccountConfig;

namespace MainApp
{
  class Program
  {
    static void Main(string[] args)
    {      
        Account a1 = new Account( 1234, "Lisa" );                 
        a1.AccessSuccessfull += OnAccessSuccessfull;
        a1.AccessError += OnAccessError;
        //
        static void  OnAccessSuccessfull()
        {
            Console.WriteLine("The Deposit Operation Ended Successfully.");
        }
        static void OnAccessError()
        {                
            Console.WriteLine("The operation failed!");
        }
        //
        double balance;
        bool breakFlag = false;
        while (!breakFlag)
        {
            Console.WriteLine($"Hello {a1.Name}, What action would you like to take? \n 1 = Get Balance Information \n 2 = Deposit Ammount \n 3 = Withraw Ammount \n 4 = Quit App");
            int UserInput = int.Parse(Console.ReadLine());            
            switch(UserInput)
            {
                case 1:
                    balance = a1.GetBalance();
                    Console.WriteLine($"Account ID: {a1.ID}\nName: {a1.Name}\nAmmount: {balance}\n");
                    break;
                //
                case 2:
                    Console.WriteLine("Deposit Amount:");
                    balance = int.Parse(Console.ReadLine());
                    a1.Deposit(balance);
                    Console.WriteLine($"Your Account Balance is {a1.GetBalance()}\n");
                    break;
                //
                case 3:
                    Console.WriteLine("Withraw Amount:");
                    balance = int.Parse(Console.ReadLine());
                    a1.Withraw(balance);
                    Console.WriteLine($"Your Account Balance is {a1.GetBalance()}\n");
                    break;
                //
                case 4:
                    breakFlag = true;
                        break;
                //
                default:
                    Console.WriteLine("Wrong number, please try again!\n");
                    break;
            }
        }
    }
  }
}