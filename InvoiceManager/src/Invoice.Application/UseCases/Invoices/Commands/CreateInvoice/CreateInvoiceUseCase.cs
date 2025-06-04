using Invoice.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.UseCases.Invoices.Commands.CreateInvoice
{
    public class CreateInvoiceUseCase(IInvoiceRepo repo) : ICreateInvoiceUseCase
    {
        private readonly IInvoiceRepo _invoiceRepo = repo;

        public async Task<int> ExecuteAsync(CreateInvoiceCommand command)
        {
            Domain.Entities.Invoice invoice = new()
            {
                CustomerName = command.CustomerName,
                InvoiceDate = command.InvoiceDate
            };

            foreach (var item in command.Items)
            {
                invoice.AddItem(new Domain.Entities.InvoiceItem(item.Description, item.Quantity, item.UnitPrice));
            }

            return await _invoiceRepo.AddInvoiceAsync(invoice);            
        }
    }
}
