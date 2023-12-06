using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBancoConsoleApp
{
    internal class BankAccount
    {
        List<Customer> customerList;
        public void AddCustomer(string name, double balance, string zipCode)
        {
            bool verify;
            string number;
            string zip = string.Format("00.000-000", zipCode);
            do
            {
                Random random = new Random();
                number = Convert.ToString(random.Next(1, 1000000));
                number = string.Format("0:D6", number);
                verify = VerifyNumber(number);
            } while (!verify);
            customerList.Add(new Customer(name, number, balance, zip));
            Console.WriteLine($"Cliente {name}, conta {number}, adicionado com sucesso");
        }
        bool VerifyNumber(string number)
        {
            bool result = true;
            foreach (Customer customer in customerList) 
            {
                if (customer.number.Equals(number))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
        public void RemoveCustomer(string number) 
        {
            bool confirmRemove = false;
            foreach (Customer customer in customerList)
            {
                if (customer.number.Equals(number))
                {
                    customerList.Remove(customer);
                    confirmRemove = true;
                    Console.WriteLine($"Cliente número {number} removido com sucesso");
                    break;
                }
            }
            if (!confirmRemove)
            {
                Console.WriteLine($"Cliente número {number} não encontrado");
            }
        }
        public void ShowCustomerInformation(string number)
        {
            foreach(Customer customer in customerList)
            {
                if(customer.number.Equals(number))
                {
                    Console.WriteLine(customer);
                    break;
                }
            }
        }
        public void UpdateZipCode(string number, string zipCode)
        {
            bool confirmUpdate = false;
            foreach(Customer customer in customerList)
            {
                if(customer.number.Equals(number)) 
                {
                    string zip = string.Format("00.000-000", zipCode);
                    customer.zipCode = zip;
                    confirmUpdate = true;
                    Console.WriteLine($"CEP {customer.zipCode} de Cliente conta {number} atualizado com sucesso");
                    break;
                }
            }
            if (!confirmUpdate)
            {
                Console.WriteLine($"Cliente {number} não encontrado");
            }
        }
    }
}
