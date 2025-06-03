using Invoice.Application.UseCases.Invoices.Queries.GetInvoice;
using Moq;

namespace Invoice.Tests.Application.UseCases.Invoices.Queries.GetInvoice;

[TestClass]
public class GetInvoiceUseCasesTests
{
    [TestMethod]
    public void Handle_ShouldReturnInvoice_WithCorrectData()
    {        
        var mockRepo = new Mock<Domain.Repositories.IInvoiceRepo>();
        var expectedInvoice = new Domain.Entities.Invoice
        {
            Id = 1,
            CustomerName = "Test Customer",
            InvoiceDate = DateTime.Now
        };
        mockRepo.Setup(repo => repo.GetInvoiceAsync(1))
                .ReturnsAsync(expectedInvoice);
        var handler = new GetInvoiceUseCase(mockRepo.Object);
        
        var result = handler.ExecuteAsync(1).Result;
        Assert.IsNotNull(result);
        Assert.AreEqual(expectedInvoice.Id, result.Id);
        Assert.AreEqual(expectedInvoice.CustomerName, result.CustomerName);
    }
}
