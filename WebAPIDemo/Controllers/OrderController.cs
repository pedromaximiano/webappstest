using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{
    public class OrderController : ApiController
    {
        private IRepository _repo;

        public OrderController(IRepository repository)
        {
            _repo = repository;
        }

        public IQueryable<Order> Get()
        {
            var orders = _repo.GetAllOrders();

            return orders;
        }

        public IQueryable<Order> Get(bool getDetails)
        {
            IQueryable<Order> orders;

            if (getDetails)
                orders = _repo.GetAllOrdersWithDetails();
            else
            {
                orders = _repo.GetAllOrders();
            }

            return orders;
        }

        public Order Get(int id)
        {
            var order = _repo.GetOrder(id);

            return order;
        }
    }
}
