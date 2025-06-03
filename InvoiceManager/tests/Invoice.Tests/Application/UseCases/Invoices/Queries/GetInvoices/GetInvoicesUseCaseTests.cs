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

        var invoices = handler.HandleAsync().Result;
        Assert.IsNotNull(invoices);
        Assert.IsTrue(!invoices.Any());        
    }
    
    [TestMethod]
    public void Handle_ShouldReturnOneItem()
    {
        var mockRepo = new Mock<IInvoiceRepo>();
        var handler = new GetInvoicesUseCase(mockRepo.Object);
        var expectedInvoices = new List<Domain.Entities.Invoice> { new Domain.Entities.Invoice { Id = 0, CustomerName = "Test Customer" } };
        mockRepo.Setup(r => r.GetInvoicesAsync()).ReturnsAsync(expectedInvoices);

        var invoices = handler.HandleAsync().Result;
        Assert.IsNotNull(invoices);
        Assert.IsTrue(invoices.Any());
        Assert.IsTrue(expectedInvoices[0].CustomerName == invoices.FirstOrDefault()?.CustomerName);
    }
}
