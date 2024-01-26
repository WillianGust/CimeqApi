using CimeqApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CimeqApi.Services
{
    public class OrderService
    {
        private static List<Order> orders = new List<Order>()
        {
            new Order()
            {
                Id = 1,
                IdClient = 1,
                Description = "Pomme",
                DateOrder = DateTime.Now,
                CostOrder = 2.3,
                Client = ClientService.GetById(1) 
            },
            new Order()
            {
                Id = 2,
                IdClient = 2,
                Description = "Raisin",
                DateOrder = DateTime.Now,
                CostOrder = 4.5,
                Client = ClientService.GetById(2) 
            },
            new Order()
            {
                Id = 3,
                IdClient = 3,
                Description = "Patate",
                DateOrder = DateTime.Now,
                CostOrder = 0.55,
                Client = ClientService.GetById(3) 
            },
        };

        public static List<Order> All()
        {
            return orders.ToList();
        }

        public static Order GetById(int id)
        {
            return orders.FirstOrDefault(o => o.Id == id);
        }

        public static Order Add(Order order)
        {
            if (order != null)
            {
                order.Id = orders.Count + 1;
                order.Client = ClientService.GetById(order.IdClient);
                orders.Add(order);
            }
            return order;
        }

        public static Order Update(int id, Order updatedOrder)
        {
            var existingOrder = orders.FirstOrDefault(o => o.Id == id);
            if (existingOrder != null)
            {
                existingOrder.IdClient = updatedOrder.IdClient;
                existingOrder.Description = updatedOrder.Description;
                existingOrder.DateOrder = updatedOrder.DateOrder;
                existingOrder.CostOrder = updatedOrder.CostOrder;
                updatedOrder.Client = ClientService.GetById(updatedOrder.Id);
                return existingOrder;
            }
            return null;
        }

        public static bool Delete(int id)
        {
            var orderToRemove = orders.FirstOrDefault(o => o.Id == id);
            if (orderToRemove != null)
            {
                orders.Remove(orderToRemove);
                return true;
            }
            return false;
        }
    }
}
