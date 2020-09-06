using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public static class DataSetHelper
    {
        static Lazy<List<Product>> _products = new Lazy<List<Product>>();
        
        static DataSetHelper()
        {
            _products.Value.AddRange(
                new List<Product> {
                new Product(new Guid("546e2731-e4af-46e5-ad42-bc47c8ae8a6b"), "A", 50m),
                new Product(new Guid("98d7592c-7269-498f-a372-d18ead5ddfb4"), "B", 30m),
                new Product(new Guid("0aae1781-eeab-40ab-bfe0-08e7f9b284e3"), "C", 20m),
                new Product(new Guid("de35112b-b6fc-4e60-b0b4-a0723b311ba3"), "D", 15m),

                });
        }

        public static List<Product> Products { get { return _products.Value; } }

        public static Product GetProductBySKU(string sku) { return _products.Value.First(p => p.SKU.Equals(sku)); }

        public static Product GetProductById(Guid id) { return _products.Value.First(p => p.Id == id); }

    }
}
