using Invoice.Core.Entities;
using Invoice.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Infrastructure.Persistence
{
    public class SqlInvoiceRepo : IInvoiceRepo
    {
        public Task AddInvoiceAsync(Core.Entities.Invoice invoice)
        {
            throw new NotImplementedException();
        }
        
        public Task<bool> DeleteInvoiceAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Core.Entities.Invoice> GetInvoiceAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Core.Entities.Invoice>> GetInvoicesAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateInvoiceAsync(Core.Entities.Invoice invoice)
        {
            throw new NotImplementedException();
        }
    }
}
