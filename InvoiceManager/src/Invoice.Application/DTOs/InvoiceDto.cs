namespace Invoice.Application.DTOs
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public required string CustomerName { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<InvoiceItemDto> Items { get; set; } = [];
    }
}
