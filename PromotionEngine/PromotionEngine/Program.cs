using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Scenario A ***");
            Order order = new Order(Guid.NewGuid());

            order.Add(new LineItem(DataSetHelper.GetProductBySKU("A"), 7));
            order.Add(new LineItem(DataSetHelper.GetProductBySKU("B"), 1));
            order.Add(new LineItem(DataSetHelper.GetProductBySKU("C"), 1));
            DataSetHelper.AddAllPromosToOrder(order);

            var output = order.CalculateOrderPrice();

            Console.ReadLine();
        }
    }
}
