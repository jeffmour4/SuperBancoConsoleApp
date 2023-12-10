using System.Security.Principal;

namespace SuperBancoConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount bankAccount = new BankAccount();
            try
            {

                int option1;
                int option2;
                do
                {
                    Console.WriteLine("-----------------SuperBankApp---------------");
                    Console.WriteLine("----------------Acesso Gerente--------------");
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine("Digite uma alternativa e pressione ENTER:");
                    Console.WriteLine("[1] Adicionar Cliente");
                    Console.WriteLine("[2] Mostrar informações do cliente");
                    Console.WriteLine("[3] Atualizar CEP do cliente");
                    Console.WriteLine("[4] Realizar Transação");
                    Console.WriteLine("[5] Mostrar todas as transações");
                    Console.WriteLine("[6] Mostrar todos os clientes");
                    Console.WriteLine("[7] Remover cliente");
                    Console.WriteLine("[8] Sair");
                    option1 = Convert.ToInt32(Console.ReadLine());
                    switch (option1)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Digite Nome, Saldo e CEP:");
                            Console.WriteLine("Obs.: Pressione ENTER a cada dado inserido");
                            bankAccount.AddCustomer(Console.ReadLine(),
                                Convert.ToDouble(Console.ReadLine()), Console.ReadLine());
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Digite o número da conta do cliente:");
                            bankAccount.ShowCustomerInformation(Console.ReadLine());
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Digite o número da conta e o novo CEP:");
                            Console.WriteLine("Obs.: Pressione ENTER a cada dado inserido");
                            bankAccount.UpdateZipCode(Console.ReadLine(), Console.ReadLine());
                            break;
                        case 4:
                            Console.Clear();
                            do
                            {
                                Console.WriteLine("Digite uma alternativa e pressione ENTER:");
                                Console.WriteLine("[1] Depósito");
                                Console.WriteLine("[2] Saque");
                                Console.WriteLine("[3] Sair");
                                option2 = Convert.ToInt32(Console.ReadLine());
                                switch (option2)
                                {
                                    case 1:
                                        Console.Clear();
                                        Console.WriteLine("Digite número da conta, valor e descrição:");
                                        Console.WriteLine("Obs.: Pressione ENTER a cada dado inserido");
                                        bankAccount.DepositMoney(Console.ReadLine(),
                                            Convert.ToDouble(Console.ReadLine()),
                                            Console.ReadLine());
                                        break;
                                    case 2:
                                        Console.Clear();
                                        Console.WriteLine("Digite número da conta, valor e descrição:");
                                        Console.WriteLine("Obs.: Pressione ENTER a cada dado inserido");
                                        bankAccount.WithdrawalMoney(Console.ReadLine(),
                                            Convert.ToDouble(Console.ReadLine()),
                                            Console.ReadLine());
                                        break;
                                    case 3:
                                        Console.Clear();
                                        break;
                                    default:
                                        Console.Clear();
                                        Console.WriteLine("Digite um valor válido");
                                        break;
                                }
                            } while (option2 != 3);
                            break;
                        case 5:
                            Console.Clear();
                            bankAccount.ListAllTransactions();
                            break;
                        case 6:
                            Console.Clear();
                            bankAccount.ListAllCustomers();
                            break;
                        case 7:
                            Console.Clear();
                            Console.WriteLine("Digite o número da conta:");
                            bankAccount.RemoveCustomer(Console.ReadLine());
                            break;
                        case 8:
                            Console.Clear();
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Digite um valor válido");
                            break;
                    }
                } while (option1 != 8);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Finalizando operação...");
            }
        }
    }
}
