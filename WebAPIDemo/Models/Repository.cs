using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIDemo.Models
{
    public class Repository : IRepository
    {
        private WebAPIDemoContext dbContext;

        public Repository(WebAPIDemoContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<Order> GetAllOrders()
        {
            var orders = dbContext.Orders;

            return orders;
        }

        public IQueryable<Order> GetAllOrdersWithDetails()
        {
            var orders = dbContext.Orders.Include("OrderDetails");

            return orders;
        }

        public Order GetOrder(int id)
        {
            var order = dbContext.Orders.Include("OrderDetails.Book").FirstOrDefault(c => c.Id == id);

            return order;
        }
    }
}