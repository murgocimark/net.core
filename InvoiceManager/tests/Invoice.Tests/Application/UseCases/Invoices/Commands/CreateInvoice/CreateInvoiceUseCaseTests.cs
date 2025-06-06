using Invoice.Application.DTOs;
using Invoice.Application.UseCases.Invoices.Commands.CreateInvoice;
using Invoice.Domain.Repositories;
using Moq;

namespace Invoice.Tests.Application.UseCases.Invoices.Commands.CreateInvoice;

[TestClass]
public class CreateInvoiceUseCaseTests
{
    [TestMethod]
    public async Task Handle_ShouldCreateInvoice_WithCorrectData()
    {
        var mockRepo = new Mock<IInvoiceRepo>();
        mockRepo.Setup(repo => repo.AddInvoiceAsync(It.IsAny<Domain.Entities.Invoice>()))
                .Returns(Task.FromResult(10));
        var handler = new CreateInvoiceUseCase(mockRepo.Object);
        var command = new CreateInvoiceCommand
        {
            CustomerName = "Test Customer",
            InvoiceDate = DateTime.Now,
            Items =
            [
                new InvoiceItemDto
                {
                    Description = "Item 1",
                    Quantity = 2,
                    UnitPrice = 50.00m
                },
                new InvoiceItemDto
                {
                    Description = "Item 2",
                    Quantity = 1,
                    UnitPrice = 100.00m
                }
            ]
        };

        var newInvoiceID = await handler.ExecuteAsync(command);
        mockRepo.Verify(repo => repo.AddInvoiceAsync(It.Is<Domain.Entities.Invoice>(inv =>
            inv.CustomerName == command.CustomerName &&
            inv.InvoiceDate.Date == command.InvoiceDate.Date &&
            inv.Items.Count == command.Items.Count &&
            inv.Items.Any(item => item.Description == "Item 1" && item.Quantity == 2 && item.UnitPrice == 50.00m) &&
            inv.Items.Any(item => item.Description == "Item 2" && item.Quantity == 1 && item.UnitPrice == 100.00m)
        )), Times.Once);
        Assert.AreEqual(10, newInvoiceID);
    }
}
