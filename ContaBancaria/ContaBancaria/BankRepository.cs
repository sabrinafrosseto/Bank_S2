using MySql.Data.MySqlClient;
namespace Bank
{
    public class BankRepository
    {
        public BankAccount FindAccount(int numero)
        {
            var connString = "Server=localhost; Database=Bank_S2; Uid=root; Pwd=password";
            var connection = new MySqlConnection(connString);
            var command = connection.CreateCommand();
            try
            {
                command.CommandText = "select * from BankAccount where numero = @numero";
                command.Parameters.AddWithValue("@numero", numero);
                connection.Open();
                MySqlDataReader datareader = command.ExecuteReader();
                if (datareader.Read())
                {
                    BankAccount bankAccount = new BankAccount();
                    bankAccount.Titular = datareader["Titular"].ToString();
                    bankAccount.Saldo = decimal.Parse(datareader["Saldo"].ToString());
                    bankAccount.Numero = int.Parse(datareader["Numero"].ToString());
                    return bankAccount;
                }
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
                command.Parameters.Clear();
            }
            return null;
        }
        public void AddAccount(BankAccount bankAccount)
        {
            var connString = "Server=localhost; Database=Bank_S2; Uid=root; Pwd=password";
            var connection = new MySqlConnection(connString);
            var command = connection.CreateCommand();
            try
            {
                connection.Open();
                command.CommandText = "INSERT INTO BankAccount(Titular, Numero, Saldo) values (@titular, @numero, @saldo)";
                command.Parameters.AddWithValue("@titular", bankAccount.Titular);
                command.Parameters.AddWithValue("@numero", bankAccount.Numero);
                command.Parameters.AddWithValue("@saldo", bankAccount.Saldo);
                command.ExecuteNonQuery();
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
                command.Parameters.Clear();
            }
        }
        public void ModifyAccount(BankAccount bankAccount)
        {
            var connString = "Server=localhost; Database=Bank_S2; Uid=root; Pwd=password";
            var connection = new MySqlConnection(connString);
            var command = connection.CreateCommand();
            try
            {
                connection.Open();
                command.CommandText = "UPDATE BankAccount set Saldo = @saldo where Numero = @numero";
                command.Parameters.AddWithValue("@numero", bankAccount.Numero);
                command.Parameters.AddWithValue("@saldo", bankAccount.Saldo);
                command.ExecuteNonQuery();
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
                command.Parameters.Clear();
            }
        }
    }
}