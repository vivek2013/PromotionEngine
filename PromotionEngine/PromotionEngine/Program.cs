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
            order.Add(new LineItem(DataSetHelper.GetProductBySKU("A"), 1));
            order.Add(new LineItem(DataSetHelper.GetProductBySKU("B"), 1));
            order.Add(new LineItem(DataSetHelper.GetProductBySKU("C"), 1));
            DataSetHelper.AddAllPromosToOrder(order);

            order.CalculateOrderPrice();

            Console.WriteLine("*** Scenario B ***");
            order = new Order(Guid.NewGuid());
            order.Add(new LineItem(DataSetHelper.GetProductBySKU("A"), 5));
            order.Add(new LineItem(DataSetHelper.GetProductBySKU("B"), 5));
            order.Add(new LineItem(DataSetHelper.GetProductBySKU("C"), 1));
            DataSetHelper.AddAllPromosToOrder(order);

            order.CalculateOrderPrice();

            Console.WriteLine("*** Scenario C ***");
            order = new Order(Guid.NewGuid());
            order.Add(new LineItem(DataSetHelper.GetProductBySKU("A"), 3));
            order.Add(new LineItem(DataSetHelper.GetProductBySKU("B"), 5));
            order.Add(new LineItem(DataSetHelper.GetProductBySKU("C"), 1));
            order.Add(new LineItem(DataSetHelper.GetProductBySKU("D"), 1));
            DataSetHelper.AddAllPromosToOrder(order);

            order.CalculateOrderPrice();

            Console.ReadLine();

        }
    }
}
