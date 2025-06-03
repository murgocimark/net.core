using Invoice.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.UseCases.Invoices.Queries.GetInvoices
{
    public interface IGetInvoicesUseCase
    {
        Task<IEnumerable<InvoiceDto>> HandleAsync();
    }
}
