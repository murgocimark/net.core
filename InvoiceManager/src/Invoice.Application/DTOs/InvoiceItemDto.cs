namespace Invoice.Application.DTOs
{
    public class InvoiceItemDto
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount;
    }
}
