using Invoice.Application.DTOs;
using Invoice.Domain.Repositories;

namespace Invoice.Application.UseCases.Invoices.Queries.GetInvoice
{
    public class GetInvoiceUseCase(IInvoiceRepo repo) : IGetInvoiceUseCase
    {
        private readonly IInvoiceRepo _invoiceRepo = repo;

        public async Task<InvoiceDto> ExecuteAsync(int invoiceId)
        {
            if (invoiceId <= 0)
            {
                throw new ArgumentException("Invoice ID must be greater than zero.", nameof(invoiceId));
            }

            var invoice = await _invoiceRepo.GetInvoiceAsync(invoiceId);
            return new InvoiceDto
            {
                Id = invoice.Id,
                CustomerName = invoice.CustomerName,
                TotalAmount = invoice.TotalAmount,
                InvoiceDate = invoice.InvoiceDate,
                Items = invoice.Items.Select(item => new InvoiceItemDto
                {
                    Id = item.Id,
                    Description = item.Description,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                }).ToList()
            };
        }
    }
}
