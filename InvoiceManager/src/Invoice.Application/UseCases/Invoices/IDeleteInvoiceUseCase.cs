using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.UseCases.Invoices
{
    public interface IDeleteInvoiceUseCase
    {
        Task<bool> HandleAsync(int invoiceId);
    }
}
