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

        private readonly Lazy<List<PromotionBase>> _promotions = new Lazy<List<PromotionBase>>();

        public Guid Id { get; set; }
        public List<LineItem> LineItems { get { return _lineItems.Value; } }
        public List<PromotionBase> Promotions { get { return _promotions.Value; } }
        public Order(Guid id)
        {
            this.Id = id;
        }

        public bool Add(LineItem item)
        {
            _lineItems.Value.Add(item);
            return true;
        }

        public bool AddPromotion(PromotionBase promo)
        {
            _promotions.Value.Add(promo);
            return true;
        }

        public decimal CalculateOrderPrice()
        {
            decimal totalDiscount = 0;
            decimal totalPrice = LineItems.Sum(i => i.UnitPrice * i.Quantity);
            foreach (var item in Promotions)
            {
                totalDiscount += item.GetDiscount(LineItems);
            }

            decimal finalPrice = totalPrice - totalDiscount;

            Console.WriteLine($"OrderID: {this.Id} => Total price: {totalPrice.ToString("0.00")} | Discount: {totalDiscount.ToString("0.00")} | Final price: {finalPrice.ToString("0.00")}");

            return finalPrice;
        }
    }
}
