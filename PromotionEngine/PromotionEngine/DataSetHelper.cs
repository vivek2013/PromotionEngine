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
        static Lazy<List<PromotionBase>> _promotions = new Lazy<List<PromotionBase>>();
        static DataSetHelper()
        {
            _products.Value.AddRange(
                new List<Product> {
                new Product(new Guid("546e2731-e4af-46e5-ad42-bc47c8ae8a6b"), "A", 50m),
                new Product(new Guid("98d7592c-7269-498f-a372-d18ead5ddfb4"), "B", 30m),
                new Product(new Guid("0aae1781-eeab-40ab-bfe0-08e7f9b284e3"), "C", 20m),
                new Product(new Guid("de35112b-b6fc-4e60-b0b4-a0723b311ba3"), "D", 15m),

                });

            Dictionary<Guid, int> promoProducts;
            // 3 of A's for 130
            promoProducts = new Dictionary<Guid, int> { [DataSetHelper.GetProductBySKU("A").Id] = 3 };
            _promotions.Value.Add(new MinQuantityPromotion(Guid.NewGuid(), promoProducts, 130));

            // 2 of B's for 45
            promoProducts = new Dictionary<Guid, int> { [DataSetHelper.GetProductBySKU("B").Id] = 2 };
            _promotions.Value.Add(new MinQuantityPromotion(Guid.NewGuid(), promoProducts, 45));


            // C&D for 30 
            promoProducts = new Dictionary<Guid, int>
            {
                [DataSetHelper.GetProductBySKU("C").Id] = 1,
                [DataSetHelper.GetProductBySKU("D").Id] = 1
            };

            _promotions.Value.Add(new MinQuantityPromotion(Guid.NewGuid(), promoProducts, 30));
        }

        public static List<Product> Products { get { return _products.Value; } }

        public static List<PromotionBase> Promotions { get { return _promotions.Value; } }

        public static Product GetProductBySKU(string sku) { return _products.Value.First(p => p.SKU.Equals(sku)); }

        public static Product GetProductById(Guid id) { return _products.Value.First(p => p.Id == id); }

        public static void AddAllPromosToOrder(Order order)
        {
            foreach (var promo in DataSetHelper.Promotions)
            {
                order.AddPromotion(promo);
            }
        }
    }
}
