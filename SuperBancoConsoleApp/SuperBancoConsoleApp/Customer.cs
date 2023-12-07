using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBancoConsoleApp
{
    internal class Customer
    {
        public string Name {  get; }
        public string Number { get; }
        public double Balance { get; set; }
        public string ZipCode { get; set; }
        public Customer(string name, string number, double balance, string zipCode) 
        { 
            this.Name = name;
            this.Number = number;
            this.Balance = balance;
            this.ZipCode = zipCode;
        }
        public override string ToString()
        {
            return "Cliente: " + Name + ". Número da conta: " + Number
                + ". Saldo: R$ " + string.Format("{0:N}", Balance) + ". CEP: " + ZipCode;
        }
    }
}
