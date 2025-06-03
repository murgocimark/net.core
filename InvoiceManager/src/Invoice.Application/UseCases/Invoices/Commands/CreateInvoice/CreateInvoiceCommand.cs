using Invoice.Application.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.UseCases.Invoices.Commands.CreateInvoice
{
    public class CreateInvoiceCommand
    {
        [Required]
        public required string CustomerName { get; set; }

        [MinLength(1)]
        public required List<InvoiceItemDto> Items { get; set; }

        public DateTime InvoiceDate { get; set; }        
    }
}
