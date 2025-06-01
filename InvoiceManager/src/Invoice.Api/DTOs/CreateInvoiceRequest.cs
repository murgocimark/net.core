using System.ComponentModel.DataAnnotations;

namespace Invoice.Api.DTOs
{
    public class CreateInvoiceRequest
    {
        [Required]
        public string CustomerName { get; set; }
        public DateTime InvoiceDate { get; set; }
        [Required]
        public List<CreateInvoiceItemRequest> Items { get; set; } = new List<CreateInvoiceItemRequest>();
    }
}
