﻿using Invoice.Application.DTOs;
using Invoice.Domain.Repositories;

namespace Invoice.Application.UseCases.Invoices.Queries.GetInvoices
{
    public class GetInvoicesUseCase(IInvoiceRepo invoiceRepo) : IGetInvoicesUseCase
    {
        private readonly IInvoiceRepo _invoiceRepo = invoiceRepo;

        public async Task<IEnumerable<InvoiceDto>> ExecuteAsync()
        {
            var invoices = await _invoiceRepo.GetInvoicesAsync();
            return invoices.Select(invoice => new InvoiceDto
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
            }).ToList();
        }
    }
}
