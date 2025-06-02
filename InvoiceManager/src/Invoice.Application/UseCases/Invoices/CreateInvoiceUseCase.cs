using Invoice.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.UseCases.Invoices
{
    public class CreateInvoiceUseCase : ICreateInvoiceUseCase
    {
        private readonly IInvoiceRepo _invoiceRepo;
        public CreateInvoiceUseCase(IInvoiceRepo repo)
        {
            _invoiceRepo = repo ?? throw new ArgumentNullException(nameof(repo), "Invoice repository cannot be null.");
        }
        public async Task<int> HandleAsync(CreateInvoiceCommand command)
        {
            Invoice.Domain.Entities.Invoice invoice = new()
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
