using System.ComponentModel.DataAnnotations;

namespace Invoice.Api.DTOs
{
    public class CreateInvoiceItemRequest
    {
        [Required]
        public required string Description { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; } = 1;

        public decimal Total => Price * Quantity;
    }
}