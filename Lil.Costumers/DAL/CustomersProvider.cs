using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lil.Costumers.Models;

namespace Lil.Costumers.DAL
{
	public class CustomersProvider : ICustomersProvider
	{
		private readonly List<Customer> repo = new List<Customer>();
		
		public CustomersProvider()
		{
			repo.Add(new Customer() { Id = "1", Name = "Rodrigo", City = "Ciudad de México " });
			repo.Add(new Customer() { Id = "2", Name = "Renata", City = "Lima " });
			repo.Add(new Customer() { Id = "3", Name = "Raúl", City = "Madrid" });
			repo.Add(new Customer() { Id = "4", Name = "Raquel", City = "Buenos Aires " });
			repo.Add(new Customer() { Id = "5", Name = "Rachel", City = "San Salvador" });
		}
		public Task<Customer> GetAsync(string id)
		{
			var customer = repo.FirstOrDefault(p => p.Id == id);

			return   Task.FromResult(customer);
		}
	}
}
