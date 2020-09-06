using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public class Product
    {
        public Product(Product product) : this(product.Id, product.SKU, product.UnitPrice)
        {

        }
        public Product(Guid id, string sku, decimal unitPrice)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Can not be empty guid.", nameof(id));
            }

            if (string.IsNullOrWhiteSpace(sku))
            {
                throw new ArgumentException("Can not be blank.", nameof(sku));
            }

            if (unitPrice < 0)
            {
                throw new ArgumentException("Can not be negative.", nameof(unitPrice));
            }

            Id = id;
            SKU = sku;
            UnitPrice = unitPrice;
        }
        public Guid Id { get; }

        public string SKU { get; }

        public decimal UnitPrice { get; }
    }
}

