using Invoice.Domain.Repositories;
using Invoice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Invoice.Application.DTOs;

namespace Invoice.Application.UseCases.Invoices.Queries.GetInvoice
{
    public class GetInvoiceUseCase : IGetInvoiceUseCase
    {
        private readonly IInvoiceRepo _invoiceRepo;
        public GetInvoiceUseCase(IInvoiceRepo repo)
        {
            _invoiceRepo = repo ?? throw new ArgumentNullException(nameof(repo), "Invoice repository cannot be null.");
        }
        public async Task<InvoiceDto> HandleAsync(int invoiceId)
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
