using Dapper;
using Invoice.Domain.Repositories;
using System.Data;

namespace Invoice.Infrastructure.Persistence
{
    public class SqliteInvoiceRepo : IInvoiceRepo
    {
        private readonly IDbConnection _dbConnection;
        public SqliteInvoiceRepo(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
        }
        public async Task<int> AddInvoiceAsync(Domain.Entities.Invoice invoice)
        {
            if (_dbConnection.State != ConnectionState.Open)
            {
                _dbConnection.Open();
            }

            using (var transaction = _dbConnection.BeginTransaction())
            {
                try
                {
                    const string sql = @"
                        INSERT INTO Invoices (CustomerName, InvoiceDate)
                        VALUES (@CustomerName, @InvoiceDate);
                        SELECT last_insert_rowid();";

                    var invoiceId = await _dbConnection.ExecuteScalarAsync<int>(sql, new
                    {
                        CustomerName = invoice.CustomerName,
                        InvoiceDate = invoice.InvoiceDate
                    }, transaction);

                    const string itemSql = @"
                        INSERT INTO InvoiceItems (InvoiceId, Description, Quantity, UnitPrice)
                        VALUES (@InvoiceId, @Description, @Quantity, @UnitPrice);";

                    foreach (var item in invoice.Items)
                    {
                        await _dbConnection.ExecuteAsync(itemSql, new
                        {
                            InvoiceId = invoiceId,
                            Description = item.Description,
                            Quantity = item.Quantity,
                            UnitPrice = item.UnitPrice
                        }, transaction);
                    }

                    transaction.Commit();

                    return invoiceId;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public Task<bool> DeleteInvoiceAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Domain.Entities.Invoice> GetInvoiceAsync(int id)
        {
            if (_dbConnection.State != ConnectionState.Open)
            {
                _dbConnection.Open();
            }

            const string sql = @"
                        select i.Id, i.CustomerName, i.InvoiceDate,
                            ii.Id, ii.Description, ii.Quantity, ii.UnitPrice
                        from Invoices i
                        left join InvoiceItems ii on i.Id = ii.InvoiceId
                        where i.Id = @id;";

            var invoiceDict = new Dictionary<int, Domain.Entities.Invoice>();

            var invoice = await _dbConnection.QueryAsync<Domain.Entities.Invoice, Domain.Entities.InvoiceItem, Domain.Entities.Invoice>(sql,
                (invoice, item) =>
                {
                    if (!invoiceDict.TryGetValue(invoice.Id, out var currentInvoice))
                    {
                        currentInvoice = invoice;
                        invoiceDict.Add(invoice.Id, currentInvoice);
                    }

                    if (item != null && item.Id != 0)
                    {
                        currentInvoice.AddItem(item);
                    }

                    return currentInvoice;
                },
                new { id });


            return invoiceDict.Values.FirstOrDefault() ?? throw new KeyNotFoundException($"Invoice with ID {id} not found.");
        }

        public async Task<IEnumerable<Domain.Entities.Invoice>> GetInvoicesAsync()
        {
            if (_dbConnection.State != ConnectionState.Open)
            {
                _dbConnection.Open();
            }

            const string sql = @"
                        select * from Invoices;";

            return await _dbConnection.QueryAsync<Domain.Entities.Invoice>(sql);
        }

        public Task UpdateInvoiceAsync(Domain.Entities.Invoice invoice)
        {
            throw new NotImplementedException();
        }
    }
}
