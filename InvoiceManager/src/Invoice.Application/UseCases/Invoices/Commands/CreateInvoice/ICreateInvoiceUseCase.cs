namespace Invoice.Application.UseCases.Invoices.Commands.CreateInvoice
{
    public interface ICreateInvoiceUseCase
    {
        Task<int> ExecuteAsync(CreateInvoiceCommand command);
    }
}
