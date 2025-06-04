using Invoice.Application.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Invoice.Application.UseCases.Invoices.Commands.CreateInvoice
{
    public class CreateInvoiceCommand
    {
        public required string CustomerName { get; set; }

        [MinLength(1)]
        public required List<InvoiceItemDto> Items { get; set; }

        public DateTime InvoiceDate { get; set; }
    }
}
