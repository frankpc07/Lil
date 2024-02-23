using Lil.Search.Interfaces;
using Lil.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lil.Search.DAL
{
	public class ProductsServiceProvider : IProductsService
	{
		private List<Product> repo = new List<Product>();

		public ProductsServiceProvider()
		{
			for (int i = 0; i < 100; i++)
			{
				repo.Add(new Product()
				{
					Id = (i + 1).ToString(),
					Name = $"Product {i + 1}",
					Price = (double)i * 3.14
				});
			}
		}
		public Task<Product> GetAsync(string id)
		{
			var product = repo.FirstOrDefault(p => p.Id == id);

			return Task.FromResult(product);
		}
	}
}
