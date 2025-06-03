using Invoice.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.UseCases.Invoices.Queries.GetInvoice
{
    public interface IGetInvoiceUseCase
    {
        Task<InvoiceDto> HandleAsync(int invoiceId);
    }
}
