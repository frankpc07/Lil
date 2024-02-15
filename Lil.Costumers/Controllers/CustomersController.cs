using Lil.Costumers.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lil.Costumers.Controllers
{
	[Route("api/[controller]")]
	public class CustomersController:ControllerBase
	{
		private readonly ICustomersProvider _customersProvider;

		public CustomersController(ICustomersProvider customersProvider)
		{
			this._customersProvider = customersProvider;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetAsync(string id)
		{
			var customer = await this._customersProvider.GetAsync(id);

			if (customer != null)
				return Ok(customer);

			return NotFound();
		}

	}
}
