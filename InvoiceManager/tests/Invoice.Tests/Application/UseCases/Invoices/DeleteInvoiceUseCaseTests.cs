using Invoice.Application.UseCases.Invoices;
using Invoice.Core.Repositories;
using Moq;

namespace Invoice.Tests;

[TestClass]
public class DeleteInvoiceUseCaseTests
{
    [TestMethod]
    public async Task Handle_ShouldDeleteInvoice_CorrectId()
    {        
        var mockRepo = new Mock<IInvoiceRepo>();
        var handler = new DeleteInvoiceUseCase(mockRepo.Object);
        int invoiceId = 1;
     
        await handler.HandleAsync(invoiceId);
     
        mockRepo.Verify(repo => repo.DeleteInvoiceAsync(invoiceId), Times.Once);
    }

    [TestMethod]
    public async Task Handle_ShouldThrowArgumentException_InvalidId()
    {
        var mockRepo = new Mock<IInvoiceRepo>();
        var handler = new DeleteInvoiceUseCase(mockRepo.Object);
        int invalidId = 0; 
        await Assert.ThrowsExceptionAsync<ArgumentException>(() => handler.HandleAsync(invalidId));

        mockRepo.Verify(repo => repo.DeleteInvoiceAsync(It.IsAny<int>()), Times.Never);
    }
}
