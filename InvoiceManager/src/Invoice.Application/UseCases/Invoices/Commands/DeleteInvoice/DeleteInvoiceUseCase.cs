using Invoice.Domain.Repositories;

namespace Invoice.Application.UseCases.Invoices.Commands.DeleteInvoice
{
    public class DeleteInvoiceUseCase(IInvoiceRepo repo) : IDeleteInvoiceUseCase
    {
        private readonly IInvoiceRepo _invoiceRepo = repo;

        public async Task<bool> ExecuteAsync(int invoiceId)
        {
            if (invoiceId <= 0)
            {
                throw new ArgumentException("Invoice ID must be greater than zero.", nameof(invoiceId));
            }

            return await _invoiceRepo.DeleteInvoiceAsync(invoiceId);
        }
    }
}
