using Invoice.Domain.Repositories;

namespace Invoice.Infrastructure.Persistence
{
    public class SqlInvoiceRepo : IInvoiceRepo
    {
        public Task<int> AddInvoiceAsync(Domain.Entities.Invoice invoice)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteInvoiceAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Invoice> GetInvoiceAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Domain.Entities.Invoice>> GetInvoicesAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateInvoiceAsync(Domain.Entities.Invoice invoice)
        {
            throw new NotImplementedException();
        }
    }
}
