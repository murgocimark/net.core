namespace Invoice.Domain.Repositories
{
    public interface IInvoiceRepo
    {
        Task<Entities.Invoice> GetInvoiceAsync(int id);
        Task<IEnumerable<Entities.Invoice>> GetInvoicesAsync();
        Task<int> AddInvoiceAsync(Entities.Invoice invoice);
        Task UpdateInvoiceAsync(Entities.Invoice invoice);
        Task<bool> DeleteInvoiceAsync(int id);
    }
}
