using System;
using System.Globalization;
namespace Bank
{
    class Bank
    {
        public static void Main(string[] args)
        {
            BankAccount bankAccount;
            BankRepository bankRepository;  // Declaraçao da variavel
            bankRepository = new BankRepository(); // criaçao da instancia do objeto e atribuiçao a variavel
            bool fluxoInicial = true;
            Console.WriteLine("Olá! Bem vindo ao Sistema do Banco S2.");
            Console.WriteLine();
            while (fluxoInicial)
            {
                Console.WriteLine("Já é cliente? Digite 1. Quer Abrir uma conta? Digite 2");
                int opcao = int.Parse(Console.ReadLine());
                if (opcao == 2)
                {
                    Console.WriteLine("Para abrir sua conta, favor informar os dados abaixo");
                    Console.Write("Conta Bancária: ");
                    int numero = int.Parse(Console.ReadLine());
                    Console.Write("Titular da Conta: ");
                    string titular = Console.ReadLine();
                    Console.Write("Deseja realizar um depósito inicial? (S/N)");
                    char respdeposito = char.Parse(Console.ReadLine());
                    if (respdeposito == 's' || respdeposito == 'S')
                    {
                        Console.WriteLine("Favor informar saldo inicial: ");
                        decimal depositoinicial = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        bankAccount = new BankAccount(numero, titular, depositoinicial);
                    }
                    else
                    {
                        bankAccount = new BankAccount(numero, titular);
                    }
                    bankRepository.AddAccount(bankAccount);
                    Console.WriteLine(bankAccount.ToString());
                }
                else
                {
                    Console.WriteLine("Para realizar uma operação financeira, favor informar");
                    Console.Write("número de sua conta bancária: ");
                    int numero = int.Parse(Console.ReadLine());
                    bankAccount = bankRepository.FindAccount(numero);
                    Console.WriteLine(bankAccount.ToString());
                    Console.WriteLine("Digite: '1' para Depósito ou '2' para Saque.");
                    opcao = int.Parse(Console.ReadLine());
                    if (opcao == 1)
                    {
                        Console.Write("Entre com o valor a depositar: ");
                        decimal quantia = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        bankAccount.Deposito(quantia);
                        Console.WriteLine("Dados da Conta atualizados: ");
                        Console.WriteLine(bankAccount);
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.Write("Entre um valor para saque: ");
                        var quantia = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        bankAccount.Saque(quantia);
                        Console.WriteLine("Dados da conta atualizados:");
                        Console.WriteLine(bankAccount);
                    }
                    bankRepository.ModifyAccount(bankAccount);
                }
                Console.WriteLine("Para realizar uma nova operacao digite 1. Para sair digite 9");
                opcao = int.Parse(Console.ReadLine());
                if (opcao == 1)
                    fluxoInicial = true;
                if (opcao == 9)
                {
                    fluxoInicial = false;
                    Console.WriteLine("Agradecemos pela parceria e permanecemos à disposição.");
                }
            }
        }
    }
}