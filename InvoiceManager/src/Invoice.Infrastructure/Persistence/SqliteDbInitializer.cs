using Dapper;
using System.Data;

namespace Invoice.Infrastructure.Persistence
{
    public class SqliteDbInitializer
    {
        private readonly IDbConnection _connection;

        public SqliteDbInitializer(IDbConnection connection)
        {
            _connection = connection;
        }

        public void Initialize()
        {
            const string sql = @"
            CREATE TABLE IF NOT EXISTS Invoices (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                CustomerName TEXT NOT NULL,
                InvoiceDate TEXT NOT NULL
            );

            CREATE TABLE IF NOT EXISTS InvoiceItems (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                InvoiceId INTEGER NOT NULL,
                Description TEXT NOT NULL,
                Quantity INTEGER NOT NULL,
                UnitPrice REAL NOT NULL,
                FOREIGN KEY(InvoiceId) REFERENCES Invoices(Id)
            );";

            _connection.Execute(sql);
        }
    }

}
