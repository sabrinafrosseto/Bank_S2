using System.Globalization;

namespace Bank
{
    public class BankAccount
    {
        public int Numero { get; set; }
        public string Titular { get; set; }
        public decimal Saldo { get; set; }
        public BankAccount(int numero, string titular)
        {
            Numero = numero;
            Titular = titular;
        }
        public BankAccount(int numero, string titular, decimal depositoinicial) : this(numero, titular)
        {
            Saldo = depositoinicial;
        }
        public BankAccount()
        {
        }
        public void Deposito(decimal quantia)
        {
            Saldo += quantia;
        }
        public void Saque(decimal quantia)
        {
            Saldo -= quantia + 5;
        }
        public override string ToString()
        {
            return "Conta " + Numero + ", Titular: " + Titular + ", Saldo: $ " + Saldo.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}