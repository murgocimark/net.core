using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Domain.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }
        private readonly List<InvoiceItem> _items = new();
        public IReadOnlyList<InvoiceItem> Items => _items.AsReadOnly();
        public void AddItem(InvoiceItem item)
        {
            _items.Add(item);
            TotalAmount += item.Amount;
        }
        public void RemoveItem(int _id)            
        {
            var item = _items.FirstOrDefault(i => i.Id == _id);
            if (item == null)
            {
                throw new InvalidOperationException("Item not found.");
            }
            if (_items.Remove(item))
            {
                TotalAmount -= item.Amount;
            }
        }
    }
}
