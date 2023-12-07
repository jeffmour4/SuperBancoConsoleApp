using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SuperBancoConsoleApp
{
    internal class BankAccount
    {
        long TransactionNumber = 0;
        List<Customer> customerList = new List<Customer>();
        List<Transaction> transactionsList = new List<Transaction>();
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
                if (customer.Number.Equals(number))
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
                if (customer.Number.Equals(number))
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
                if(customer.Number.Equals(number))
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
                if (customer.Number.Equals(number))
                {
                    string zip = string.Format("{00.000-000}", zipCode);
                    customer.ZipCode = zip;
                    confirmUpdate = true;
                    Console.WriteLine($"CEP {customer.ZipCode} de Cliente conta {number} atualizado com sucesso");
                    break;
                }
            }
            if (!confirmUpdate)
            {
                Console.WriteLine($"Cliente {number} não encontrado");
            }
        }
        public void DepositMoney(string number, double amount, string description)
        {
            bool confirmDeposit = false;
            foreach (Customer customer in customerList)
            {
                if (customer.Number.Equals(number))
                {
                    DateTime date = DateTime.Now;
                    GenerateTransaction(amount, date, description);
                    customer.Balance += amount;
                    confirmDeposit = true;
                    Console.WriteLine($"Depósito realizado com sucesso. Novo saldo: R$ {customer.Balance}");
                    break;
                }
            }
            if (!confirmDeposit)
            {
                Console.WriteLine($"Cliente {number} não encontrado");
            }
        }
        public void WithdrawalMoney(string number, double amount, string description)
        {
            bool confirmWithdrawal = false;
            foreach (Customer customer in customerList)
            {
                if (customer.Number.Equals(number))
                {
                    if (customer.Balance >= amount)
                    {
                        DateTime date = DateTime.Now;
                        GenerateTransaction(amount, date, description);
                        customer.Balance -= amount;
                        confirmWithdrawal = true;
                        Console.WriteLine($"Saque realizado com sucesso. Novo saldo: R$ {customer.Balance}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Saldo insuficiente");
                        break;
                    }
                }
            }
            if (!confirmWithdrawal)
            {
                Console.WriteLine($"Cliente {number} não encontrado");
            }
        }
        long GenerateTransaction(double value, DateTime date, string description)
        {
            long number = TransactionNumber++;
            transactionsList.Add(new Transaction(number, value, date, description));
            return number;
        } 
        
    }
}
