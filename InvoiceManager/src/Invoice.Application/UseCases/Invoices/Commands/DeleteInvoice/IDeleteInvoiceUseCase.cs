namespace Invoice.Application.UseCases.Invoices.Commands.DeleteInvoice
{
    public interface IDeleteInvoiceUseCase
    {
        Task<bool> ExecuteAsync(int invoiceId);
    }
}
