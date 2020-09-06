using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public class Order
    {
        private readonly Lazy<List<LineItem>> _lineItems = new Lazy<List<LineItem>>();

        public Guid Id { get; set; }

        public List<LineItem> LineItems { get { return _lineItems.Value; } }

        public Order(Guid id)
        {
            this.Id = id;
        }

        public bool Add(LineItem item)
        {
            _lineItems.Value.Add(item);
            return true;
        }

        public decimal CalculateOrderPrice()
        {            
            decimal totalPrice = LineItems.Sum(i => i.UnitPrice * i.Quantity);
            
            return totalPrice;
        }
    }
}
