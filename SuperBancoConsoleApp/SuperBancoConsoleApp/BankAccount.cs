using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SuperBancoConsoleApp
{
    internal class BankAccount
    {
        private long transactionNumber = 0;
        private List<Customer> customerList = new List<Customer>();
        private List<Transaction> transactionsList = new List<Transaction>();
        public void AddCustomer(string name, double balance, string zipCode)
        {
            int countList = customerList.Count;
            bool verify;
            string number;
            do
            {
                Random random = new Random();
                number = Convert.ToString(random.Next(1, 1000000));
                verify = VerifyNumber(number);
            } while (!verify);
            customerList.Add(new Customer(name, number, zipCode));
            DepositMoney(number, balance, "Depósito inicial");
            if (customerList.Count > countList)
            {
                Console.WriteLine($"Cliente {name}, conta {number}, adicionado com sucesso");
            }
            else 
            {
                Console.WriteLine("Cliente não adicionado");
            }
        }
        private bool VerifyNumber(string number)
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
                    customer.ZipCode = zipCode;
                    confirmUpdate = true;
                    Console.WriteLine($"CEP {Convert.ToUInt32(customer.ZipCode).ToString(@"00\.000\-000")} de Cliente conta {number} atualizado com sucesso");
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
                    if (amount > 0)
                    {
                        DateTime date = DateTime.Now;
                        GenerateTransaction(number, amount, date, description);
                        customer.Balance += amount;
                        confirmDeposit = true;
                        Console.WriteLine($"Depósito realizado com sucesso. Novo saldo: R$ {customer.Balance}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Valor do depósito insuficiente");
                        throw new ArgumentOutOfRangeException(nameof(amount), "O valor precisa ser maior que zero");
                    }
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
                        if (amount <= 0)
                        {
                            throw new ArgumentOutOfRangeException(nameof(amount), "O valor precisa ser maior que zero");
                        }
                        DateTime date = DateTime.Now;
                        GenerateTransaction(number, -amount, date, description);
                        customer.Balance -= amount;
                        confirmWithdrawal = true;
                        Console.WriteLine($"Saque realizado com sucesso. Novo saldo: R$ {customer.Balance}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Saldo insuficiente");
                        throw new InvalidOperationException("O valor precisa ser menor ou igual ao saldo");
                    }
                }
            }
            if (!confirmWithdrawal)
            {
                Console.WriteLine($"Cliente {number} não encontrado");
            }
        }
        private void GenerateTransaction(string numberAccount, double value, DateTime date, string description)
        {
            transactionNumber++;
            transactionsList.Add(new Transaction(transactionNumber, numberAccount, value, date, description));
        } 
        public void ListAllCustomers() 
        {
            if (customerList.Any()) 
            {
                StringBuilder stringBuilderCustomers = new StringBuilder();
                foreach (Customer customer in customerList)
                {
                    stringBuilderCustomers.AppendLine(customer.ToString());
                }
                Console.WriteLine(stringBuilderCustomers.ToString());
            }
            else 
            {
                Console.WriteLine("Lista de clientes vazia");
            }
            
        }
        public void ListAllTransactions()
        {
            if (transactionsList.Any())
            {
                StringBuilder transactionListString = new StringBuilder();
                foreach (Transaction transaction in transactionsList)
                {
                    transactionListString.AppendLine(transaction.ToString());
                }
                Console.WriteLine(transactionListString.ToString());
            }
            else
            {
                Console.WriteLine("Lista de Transações vazia");
            }
        }
    }
}
