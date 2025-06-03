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
            InvoiceDate = DateTime.Now,
        };        
        expectedInvoice.AddItem(new Domain.Entities.InvoiceItem
        {
            Id = 1,
            Description = "Test Item",
            Quantity = 2,
            UnitPrice = 50.00m
        });
        mockRepo.Setup(repo => repo.GetInvoiceAsync(1))
                .ReturnsAsync(expectedInvoice);
        var handler = new GetInvoiceUseCase(mockRepo.Object);
        
        var result = handler.ExecuteAsync(1).Result;
        Assert.IsNotNull(result);
        Assert.AreEqual(expectedInvoice.Id, result.Id);
        Assert.AreEqual(expectedInvoice.CustomerName, result.CustomerName);
        Assert.IsTrue(result.Items.Any(item => item.Description == "Test Item" && item.Quantity == 2 && item.UnitPrice == 50.00m));
    }

    [TestMethod]
    public void Handle_ShouldThrowArgumentException_WhenInvoiceIdIsZeroOrNegative()
    {
        var mockRepo = new Mock<Domain.Repositories.IInvoiceRepo>();
        var handler = new GetInvoiceUseCase(mockRepo.Object);

        Assert.ThrowsExceptionAsync<ArgumentException>(() => handler.ExecuteAsync(0));
        Assert.ThrowsExceptionAsync<ArgumentException>(() => handler.ExecuteAsync(-1));
    }
}
