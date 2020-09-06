using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public class LineItem : Product
    {
        public LineItem(Product product, int quantity) : base(product)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity should be greater than zero.", nameof(quantity));
            }

            this.Quantity = quantity;
        }

        public int Quantity { get; set; }

    }
}
