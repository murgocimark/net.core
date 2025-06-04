using Invoice.Application.DTOs;

namespace Invoice.Application.UseCases.Invoices.Queries.GetInvoice
{
    public interface IGetInvoiceUseCase
    {
        Task<InvoiceDto> ExecuteAsync(int invoiceId);
    }
}
