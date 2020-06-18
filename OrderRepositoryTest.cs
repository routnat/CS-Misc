using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACM.BL;

namespace ACM.BLTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class OrderRepositoryTest
    {
        [TestMethod]
        public void RetrieveOrderDisplayTest()
        {
            //-- Arrange

            var orderRepository = new OrderRepository();
            var expected = new Order(10)
            {
                OrderDate = new DateTimeOffset(DateTime.Now.Year, 4, 14, 10, 00, 00,
                    new TimeSpan(7, 0, 0)),
            };
            
            //-- Act
            var actual = orderRepository.Retrieve(10);

            //-- Assert
            Assert.AreEqual(expected.OrderDate, actual.OrderDate);

        }

        [TestMethod()]
        public void SaveTestValid()
        {
            //-- Arrange
            var orderRepository = new OrderRepository();
            var updatedOrder = new Order(10)
            {
                OrderDate = new DateTimeOffset(DateTime.Now.Year, 3, 13, 10, 00, 00,
                    new TimeSpan(7, 0, 0)),
                HasChanges = true
            };

            //-- Act
            var actual = orderRepository.Save(updatedOrder);

            //-- Assert
            Assert.AreEqual(true, actual);
        }

        [TestMethod()]
        public void SaveTestMissingDate()
        {
            //-- Arrange
            var orderRepository = new OrderRepository();
            var updatedOrder = new Order(10)
            {
                OrderDate = null,
                HasChanges = true
            };

            //-- Act
            var actual = orderRepository.Save(updatedOrder);

            //-- Assert
            Assert.AreEqual(false, actual);
        }

    }
}
