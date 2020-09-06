using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Tests
{
    [TestFixture]
    public class When_NoApplicable_Promotion
    {
        List<Product> _products;

        [SetUp]
        public void SetupTest()
        {
            _products = DataSetHelper.Products;
        }

        [Test]
        public void NoApplicable_Promo_On_Order_Items_Returns_TotalAmount()
        {
            var order = new Order(Guid.NewGuid());

            order.Add(new LineItem(DataSetHelper.GetProductBySKU("A"), 1));
            order.Add(new LineItem(DataSetHelper.GetProductBySKU("B"), 1));
            order.Add(new LineItem(DataSetHelper.GetProductBySKU("C"), 1));
            DataSetHelper.AddAllPromosToOrder(order);
            var total = order.CalculateOrderPrice();
            Assert.AreEqual(100, total);
        }
    }
}