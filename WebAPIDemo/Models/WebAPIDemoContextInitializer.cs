using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAPIDemo.Models
{
    public class WebAPIDemoContextInitializer : DropCreateDatabaseAlways<WebAPIDemoContext>
    {
        protected override void Seed(WebAPIDemoContext context)
        {
            var books = new List<Book>
            {
                new Book() { Name = "War and Peace", Author = "Tolstoy, Lev", Price = 19.95m },
                new Book() { Name = "Do Androids Dream of Electric Sheep?", Author = "Dick, Philip K.", Price = 9.99m },
                new Book() { Name = "Neuromancer", Author = "Gibson, William", Price = 18.00m },
                new Book() { Name = "Stranger in a Strange Land", Author = "Heinlein, Robert A.", Price = 17.89m },
                new Book() { Name = "Dune", Author = "Herbert, Frank", Price = 19.95m },
                new Book() { Name = "Fahrenheit 451", Author = "Bradbury, Ray", Price = 7.99m },
                new Book() { Name = "The War of the Worlds", Author = "Wells, H. G.", Price = 9.99m },
                new Book() { Name = "A Clockwork Orange", Author = "Burgess, Anthony", Price = 10.95m }
            };
            books.ForEach(b => context.Books.Add(b));
            context.SaveChanges();

            var orders = new List<Order>()
            {
                new Order() { Customer = "John Doe", OrderDate = DateTime.Now },
                new Order() { Customer = "Ali Alatas", OrderDate = new DateTime(2014, 01, 01) },
                new Order() { Customer = "Robert Mitchum", OrderDate = new DateTime(2013, 06, 30) }
            };
            orders.ForEach(b => context.Orders.Add(b));
            
            var orderDetails = new List<OrderDetail>()
            {
                new OrderDetail() { Book = books[0], Quantity = 1, Order = orders[0] },
                new OrderDetail() { Book = books[1], Quantity = 1, Order = orders[0] },
                new OrderDetail() { Book = books[2], Quantity = 1, Order = orders[0] },

                new OrderDetail() { Book = books[0], Quantity = 1, Order = orders[1] },
                new OrderDetail() { Book = books[0], Quantity = 1, Order = orders[1] },
                new OrderDetail() { Book = books[1], Quantity = 1, Order = orders[1] },
                new OrderDetail() { Book = books[2], Quantity = 1, Order = orders[1] },

                new OrderDetail() { Book = books[4], Quantity = 1, Order = orders[2] },
                new OrderDetail() { Book = books[5], Quantity = 1, Order = orders[2] },
                new OrderDetail() { Book = books[6], Quantity = 2, Order = orders[2] },
            };
            orderDetails.ForEach(b => context.OrderDetails.Add(b));
            context.SaveChanges();
                
            base.Seed(context);
        }
    }
}