using Lil.Costumers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lil.Costumers.DAL
{
	public interface ICustomersProvider
	{
		Task<Customer> GetAsync(string id);
	}
}
