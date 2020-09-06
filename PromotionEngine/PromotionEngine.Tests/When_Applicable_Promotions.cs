using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Tests
{
    [TestFixture]
    public class When_Applicable_Promotions
    {
        List<Product> _products;

        [SetUp]
        public void SetupTest()
        {
            _products = DataSetHelper.Products;
        }

        [Test]
        public void WhenSingleApplicable_Promo_On_Order_Items_Returns_TotalAmountWithDiscount()
        {
            var order = new Order(Guid.NewGuid());

            order.Add(new LineItem(DataSetHelper.GetProductBySKU("A"), 3));
            order.Add(new LineItem(DataSetHelper.GetProductBySKU("B"), 1));
            order.Add(new LineItem(DataSetHelper.GetProductBySKU("C"), 1));
            DataSetHelper.AddAllPromosToOrder(order);
            var total = order.CalculateOrderPrice();
            Assert.AreEqual(180, total);
        }

        [Test]
        public void WhenSingleApplicable_Promo_WithMultipleApplicableTimes_On_Order_Items_Returns_TotalAmountWithDiscount()
        {
            var order = new Order(Guid.NewGuid());

            order.Add(new LineItem(DataSetHelper.GetProductBySKU("A"), 7));
            order.Add(new LineItem(DataSetHelper.GetProductBySKU("B"), 1));
            order.Add(new LineItem(DataSetHelper.GetProductBySKU("C"), 1));
            DataSetHelper.AddAllPromosToOrder(order);
            var total = order.CalculateOrderPrice();
            Assert.AreEqual(360, total);
        }

        [Test]
        public void WhenMultipleApplicable_Promo_On_Order_Items_Returns_TotalAmountWithDiscount()
        {
            var order = new Order(Guid.NewGuid());

            order.Add(new LineItem(DataSetHelper.GetProductBySKU("A"), 3));
            order.Add(new LineItem(DataSetHelper.GetProductBySKU("B"), 5));
            order.Add(new LineItem(DataSetHelper.GetProductBySKU("C"), 1));
            order.Add(new LineItem(DataSetHelper.GetProductBySKU("D"), 1));
            DataSetHelper.AddAllPromosToOrder(order);
            var total = order.CalculateOrderPrice();
            Assert.AreEqual(280, total);
        }
    }
}
