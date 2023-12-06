using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBancoConsoleApp
{
    internal class Customer
    {
        public string name {  get; }
        public string number { get; }
        public double balance {  get; }
        public string zipCode { get; set; }
        public Customer(string name, string number, double balance, string zipCode) 
        { 
            this.name = name;
            this.number = number;
            this.balance = balance;
            this.zipCode = zipCode;
        }
        public override string ToString()
        {
            return "Cliente: " + name + ". Número da conta: " + number
                + ". Saldo: " + balance + ". CEP: " + zipCode;
        }
    }
}
