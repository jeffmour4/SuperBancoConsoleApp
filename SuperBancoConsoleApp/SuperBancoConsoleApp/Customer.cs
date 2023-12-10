using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SuperBancoConsoleApp
{
    internal class Customer
    {
        public string Name { get; }
        public string Number { get; }
        public double Balance { get; set; }
        public string ZipCode { get; set; }
        public Customer(string name, string number, string zipCode) 
        { 
            this.Name = name;
            this.Number = number;
            this.ZipCode = zipCode;
        }
        public override string ToString()
        {
            return "Cliente: " + Name + ". Número da conta: " + string.Format("{0:D6}", Number)
                + ". Saldo: R$ " + string.Format("{0:N}", Balance) + ". CEP: " + Convert.ToUInt32(ZipCode).ToString(@"00\.000\-000");
        }
    }
}
