using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Tests
{
    [TestFixture]
    public class OrderTotal
    {
        List<Product> _products;

        [SetUp]
        public void SetupTest()
        {
            _products = DataSetHelper.Products;
        }

        [Test]
        public void No_Items_Returns_TotalAmount_Zero()
        {
            var order = new Order(Guid.NewGuid());

            var total = order.CalculateOrderPrice();

            Assert.AreEqual(0m, total);
        }

        [Test]
        public void Added_Items_Returns_TotalAmount()
        {
            var order = new Order(Guid.NewGuid());

            order.Add(new LineItem(DataSetHelper.GetProductBySKU("A"), 5));
            order.Add(new LineItem(DataSetHelper.GetProductBySKU("B"), 5));
            order.Add(new LineItem(DataSetHelper.GetProductBySKU("C"), 1));
            var total = order.CalculateOrderPrice();

            Assert.AreEqual(420, total);
        }
    }
}