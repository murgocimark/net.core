using Moq;
using Invoice.Core.Repositories;
using Invoice.Application.UseCases.Invoices;

namespace Invoice.Tests;

[TestClass]
public class GetInvoicesUseCaseTests
{
    [TestMethod]
    public void Handle_ShouldReturnEmptyList()
    {
        var mockRepo = new Mock<IInvoiceRepo>();
        var handler = new GetInvoicesUseCase(mockRepo.Object);
        var expectedInvoices = new List<Invoice.Core.Entities.Invoice>();
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
        var expectedInvoices = new List<Invoice.Core.Entities.Invoice> { new Core.Entities.Invoice { Id = 0, CustomerName = "Test Customer" } };
        mockRepo.Setup(r => r.GetInvoicesAsync()).ReturnsAsync(expectedInvoices);

        var invoices = handler.HandleAsync().Result;
        Assert.IsNotNull(invoices);
        Assert.IsTrue(invoices.Any());
        Assert.IsTrue(expectedInvoices[0].CustomerName == invoices.FirstOrDefault().CustomerName);
    }
}
