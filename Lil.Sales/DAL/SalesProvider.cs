using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lil.Sales.Models;

namespace Lil.Sales.DAL
{
	public class SalesProvider : ISalesProvider
	{
		private readonly List<Order> repo = new List<Order>();

		public SalesProvider()
		{
			repo.Add(new Order
			{
				Id = "0004",
				CustomerId = "3",
				OrderDate = DateTime.Now.AddDays(-10),
				Total = 50,
				Items = new List<OrderItem>()
				{
					new OrderItem() {OrderId = "0003", Id= 1, Price = 50, ProductId = "23", Quantity = 2 },
					new OrderItem() {OrderId = "0004", Id= 2, Price = 100, ProductId = "26", Quantity = 4 }
				}
			});
			repo.Add(new Order
			{
				Id = "0005",
				CustomerId = "4",
				OrderDate = DateTime.Now.AddDays(-6),
				Total = 50,
				Items = new List<OrderItem>()
				{
					new OrderItem() {OrderId = "0005", Id= 1, Price = 50, ProductId = "29", Quantity = 6 },
					new OrderItem() {OrderId = "0006", Id= 2, Price = 100, ProductId = "32", Quantity = 8 }
				}
			});
			repo.Add(new Order
			{
				Id = "0006",
				CustomerId = "5",
				OrderDate = DateTime.Now.AddDays(-4),
				Total = 50,
				Items = new List<OrderItem>()
				{
					new OrderItem() {OrderId = "0007", Id= 3, Price = 150, ProductId = "35", Quantity = 10 },
					new OrderItem() {OrderId = "0008", Id= 4, Price = 200, ProductId = "38", Quantity = 12 }
				}
			});
		}

		public Task<ICollection<Order>> GetAsync(string customerId)
		{
			var orders = repo.Where(c => c.CustomerId == customerId).ToList();

			return Task.FromResult((ICollection<Order>)orders);
		}
	}
}
