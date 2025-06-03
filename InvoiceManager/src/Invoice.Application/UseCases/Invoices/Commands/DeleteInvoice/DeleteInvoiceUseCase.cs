using Invoice.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.UseCases.Invoices.Commands.DeleteInvoice
{
    public class DeleteInvoiceUseCase : IDeleteInvoiceUseCase
    {
        private readonly IInvoiceRepo _invoiceRepo;
        public DeleteInvoiceUseCase(IInvoiceRepo repo)
        {
            _invoiceRepo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        public async Task<bool> HandleAsync(int invoiceId)
        {
            if (invoiceId <= 0)
            {
                throw new ArgumentException("Invoice ID must be greater than zero.", nameof(invoiceId));
            }

            return await _invoiceRepo.DeleteInvoiceAsync(invoiceId);
        }
    }
}
