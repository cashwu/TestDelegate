using System;

namespace TestDelegate
{
    public class OrderController
    {
        private readonly IModel model;

        public OrderController(IModel model)
        {
            this.model = model;
        }

        public void DeleteOrder()
        {
            model.DeleteOrder(a => a.Age > 18);
        }
    }

    public interface IModel
    {
        void DeleteOrder(Func<Order, bool> func);
    }

    public class Order 
    {
        public int Age { get; set; }
    }
}