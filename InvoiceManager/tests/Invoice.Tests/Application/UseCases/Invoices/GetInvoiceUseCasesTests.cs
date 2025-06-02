using Moq;

namespace Invoice.Tests;

[TestClass]
public class GetInvoiceUseCasesTests
{
    [TestMethod]
    public void Handle_ShouldReturnInvoice_WithCorrectData()
    {        
        var mockRepo = new Mock<Invoice.Domain.Repositories.IInvoiceRepo>();
        var expectedInvoice = new Invoice.Domain.Entities.Invoice
        {
            Id = 1,
            CustomerName = "Test Customer",
            InvoiceDate = DateTime.Now
        };
        mockRepo.Setup(repo => repo.GetInvoiceAsync(1))
                .ReturnsAsync(expectedInvoice);
        var handler = new Invoice.Application.UseCases.Invoices.GetInvoiceUseCase(mockRepo.Object);
        
        var result = handler.HandleAsync(1).Result;
        Assert.IsNotNull(result);
        Assert.AreEqual(expectedInvoice.Id, result.Id);
        Assert.AreEqual(expectedInvoice.CustomerName, result.CustomerName);
    }
}
