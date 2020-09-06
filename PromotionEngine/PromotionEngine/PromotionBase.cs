using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public abstract class PromotionBase
    {
        public PromotionBase(Guid id, decimal discountedPrice)
        {
            this.Id = id;
            this.DiscountedPrice = discountedPrice;
        }
        public Guid Id { get; set; }

        public decimal DiscountedPrice { get; set; }

        public abstract decimal GetDiscount(List<LineItem> lineItems);
    }
}
