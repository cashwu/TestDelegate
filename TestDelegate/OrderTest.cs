using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDelegate
{
    [TestClass]
    public class OrderTest
    {
        [TestMethod]
        public void TestDeleteOrder_isTrue()
        {
            var order = new Order
            {
                Age = 19
            };

            var model = new FakeModel(order);
            var controller = new OrderController(model);

            controller.DeleteOrder();

            Assert.IsTrue(model.IsDelete);
        }

        [TestMethod]
        public void TestDeleteOrder_isFalse()
        {
            var order = new Order
            {
                Age = 18
            };

            var model = new FakeModel(order);
            var controller = new OrderController(model);

            controller.DeleteOrder();

            Assert.IsFalse(model.IsDelete);
        }
    }

    public class FakeModel : IModel
    {
        private readonly Order _order;

        public bool IsDelete { get; set; }

        public FakeModel(Order order)
        {
            _order = order;
        }

        public void DeleteOrder(Func<Order, bool> func)
        {
            IsDelete = func(_order);
        }
    }
}