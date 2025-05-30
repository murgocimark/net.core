namespace Invoice.Tests;

[TestClass]
public class InvoiceItemTests
{
    [TestMethod]
    public void NewItem_ShouldThrowErrorIfNegativeQuantity()
    {        
        string description = "Test Item";
        int quantity = -1;
        decimal price = 10.00m;
     
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Invoice.Core.Entities.InvoiceItem(description, quantity, price));
    }
}
