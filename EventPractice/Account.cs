using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MainApp;

namespace AccountConfig
{
    public delegate void AccountOperation();
    class Account
    {        
        int userId;
        string userName;
        public int ID { get { return userId; } }        
        public string Name { get { return userName; } }
        double balance = 0;
        //
        public Account(int id, string name)
        {
            userId = id;
            userName = name;
        }
        //
        public event AccountOperation AccessSuccessfull;
        public event AccountOperation AccessError;
        //       
        public double Balance {get{return balance;}}
        //
        public void Withraw(double lessBalance)
        {
            if(lessBalance <= 0)
            {
                global::System.Console.WriteLine("The amount can not be negative or zero!");
            }
            else
            {
                balance -= lessBalance;
                if (balance < 0)
                {                    
                    if (AccessError != null)
                        AccessError();
                    balance += lessBalance;
                }
                else
                { 
                    if (AccessSuccessfull != null)
                        AccessSuccessfull();
                }
            }
        }
        //
        public void Deposit(double addBalance)
        {
            if (addBalance <= 0)
            {
                global::System.Console.WriteLine("The amount can not be negative or zero!");
            }
            else
            {
                balance += addBalance;
                if (AccessSuccessfull != null)
                    AccessSuccessfull();
            }            
        }
        //
        public double GetBalance() => balance;        
    }
}