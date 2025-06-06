﻿using System.Diagnostics.CodeAnalysis;

namespace Invoice.Domain.Entities
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount => Quantity * UnitPrice;
        [SetsRequiredMembers]
        public InvoiceItem(string description, int quantity, decimal price)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Description cannot be empty.", nameof(description));
            }
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");
            }
            if (price < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(price), "Price cannot be negative.");
            }
            Description = description;
            Quantity = quantity;
            UnitPrice = price;                    
        }
        public InvoiceItem(){}
    }
}
