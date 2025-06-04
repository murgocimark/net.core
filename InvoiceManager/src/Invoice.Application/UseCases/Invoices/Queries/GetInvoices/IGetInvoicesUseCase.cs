using Invoice.Application.DTOs;

namespace Invoice.Application.UseCases.Invoices.Queries.GetInvoices
{
    public interface IGetInvoicesUseCase
    {
        Task<IEnumerable<InvoiceDto>> ExecuteAsync();
    }
}
