using Moq;
using Invoice.Domain.Repositories;
using Invoice.Application.UseCases.Invoices;
using Invoice.Application.UseCases.Invoices.Queries.GetInvoices;

namespace Invoice.Tests.Application.UseCases.Invoices.Queries.GetInvoices;

[TestClass]
public class GetInvoicesUseCaseTests
{
    [TestMethod]
    public void Handle_ShouldReturnEmptyList()
    {
        var mockRepo = new Mock<IInvoiceRepo>();
        var handler = new GetInvoicesUseCase(mockRepo.Object);
        var expectedInvoices = new List<Domain.Entities.Invoice>();
        mockRepo.Setup(r => r.GetInvoicesAsync()).ReturnsAsync(expectedInvoices);

        var invoices = handler.ExecuteAsync().Result;
        Assert.IsNotNull(invoices);
        Assert.IsTrue(!invoices.Any());        
    }
    
    [TestMethod]
    public void Handle_ShouldReturnOneItem()
    {
        var mockRepo = new Mock<IInvoiceRepo>();
        var handler = new GetInvoicesUseCase(mockRepo.Object);
        var invoice = new Domain.Entities.Invoice
        {
            Id = 0,
            CustomerName = "Test Customer"
        };
        invoice.AddItem(new Domain.Entities.InvoiceItem { Description = "item 1", Quantity = 3, UnitPrice = 10m } );
        var expectedInvoices = new List<Domain.Entities.Invoice> { invoice };            
        mockRepo.Setup(r => r.GetInvoicesAsync()).ReturnsAsync(expectedInvoices);

        var invoices = handler.ExecuteAsync().Result.ToList();
        Assert.IsNotNull(invoices);
        Assert.IsTrue(invoices.Any());
        Assert.IsTrue(invoice.CustomerName == invoices.FirstOrDefault()?.CustomerName);
        Assert.IsTrue(invoices.Count == 1);
        Assert.IsTrue(invoices[0].Items.Count == 1);
        Assert.IsTrue(invoices[0].Items[0].UnitPrice == 10m);
    }
}
