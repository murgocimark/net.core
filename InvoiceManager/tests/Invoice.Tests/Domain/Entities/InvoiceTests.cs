namespace Invoice.Tests;

[TestClass]
public class InvoiceTests
{
    [TestMethod]
    public void AddItem_ShouldIncreaseCountAndTotal()
    {        
        var invoice = new Invoice.Domain.Entities.Invoice { CustomerName = "Client1"};
        var item = new Invoice.Domain.Entities.InvoiceItem("Test Item", 2, 35.00m);
     
        invoice.AddItem(item);
     
        Assert.AreEqual(1, invoice.Items.Count);
        Assert.AreEqual(70.00m, invoice.TotalAmount);
    }

    [TestMethod]
    public void RemoveItem_ShouldDecreaseCountAndTotal()
    {
        var invoice = new Invoice.Domain.Entities.Invoice { CustomerName = "Client1" };
        var item = new Invoice.Domain.Entities.InvoiceItem("Test Item", 1, 35.00m);

        invoice.AddItem(item);
        invoice.RemoveItem(item.Id);

        Assert.AreEqual(0, invoice.Items.Count);
        Assert.AreEqual(0.00m, invoice.TotalAmount);
    }
    [TestMethod]
    public void RemoveItem_ThrowInvalidOperationException()
    {
        var invoice = new Invoice.Domain.Entities.Invoice { CustomerName = "Client1" };        
        Assert.ThrowsException<InvalidOperationException>(() => invoice.RemoveItem(10));
    }
}
