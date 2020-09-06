using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public class MinQuantityPromotion : PromotionBase
    {
        /// <summary>
        /// Gets or Sets Products list with there respective min quantity to get discount.
        /// </summary>
        public Dictionary<Guid, int> ProductsWithMinQuantity { get; set; }

        public MinQuantityPromotion(Guid id, Dictionary<Guid, int> products, decimal discountedPrice) : base(id, discountedPrice)
        {
            this.ProductsWithMinQuantity = products;
        }

        /// <summary>
        /// If Promo applicable then calculate discount amount.
        /// </summary>
        /// <param name="lineItems">Order LineItems.</param>
        /// <returns>Total discount amount.</returns>
        public override decimal GetDiscount(List<LineItem> lineItems)
        {
            int orderApplicableTimes = 0;

            foreach (var item in ProductsWithMinQuantity)
            {
                int itemApplicableTimes = GetApplicableTimes(item, lineItems);
                if (itemApplicableTimes == 0)
                {
                    return 0m;
                }
                else
                {
                    // For case of difrent product on promotion finds minmum applicable time for all promotion items.
                    if (orderApplicableTimes == 0 || itemApplicableTimes < orderApplicableTimes)
                    {
                        orderApplicableTimes = itemApplicableTimes;
                    }
                }
            }

            var itemNonDiscountedPrice = GetItemsPrice();

            // Calculates discount amount.
            return (orderApplicableTimes * itemNonDiscountedPrice) - (orderApplicableTimes * DiscountedPrice);
        }

        /// <summary>
        /// Get How many times a discount is applicable on order for an item.
        /// </summary>
        /// <param name="discountedItem"></param>
        /// <param name="lineItems"></param>
        /// <returns></returns>
        public int GetApplicableTimes(KeyValuePair<Guid, int> discountedItem, List<LineItem> lineItems)
        {
            int totalQuantity = lineItems.Where(i => i.Id == discountedItem.Key).Sum(i => i.Quantity);

            if (totalQuantity > 0)
            {
                return totalQuantity / discountedItem.Value;
            }

            return 0;
        }

        private decimal GetItemsPrice()
        {
            decimal actualPrice = 0;
            foreach (var item in ProductsWithMinQuantity)
            {
                actualPrice += DataSetHelper.GetProductById(item.Key).UnitPrice * item.Value;
            }

            return actualPrice;
        }
    }
}
