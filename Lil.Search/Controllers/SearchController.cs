using Lil.Search.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lil.Search.Controllers
{
	[Route("api/[controller]")]
	
	public class SearchController:ControllerBase
	{
		private readonly ICustomersService _customersService;
		private readonly IProductsService _productsService;
		private readonly ISalesService _salesService;

		public SearchController(ICustomersService customersService, IProductsService productsService, ISalesService salesService)
		{
			this._customersService = customersService;
			this._productsService = productsService;
			this._salesService = salesService;

		}

		[HttpGet("customers/{customerId}")]
		public async Task<IActionResult> SearchAsync(string customerId)
		{


			if (string.IsNullOrWhiteSpace(customerId))
				return BadRequest();


			try
			{
				var customer = await this._customersService.GetAsync(customerId);

				var sales = await this._salesService.GetAsync(customerId);

				foreach (var sale in sales)
				{
					foreach (var item in sale.Items)
					{
						var product = await this._productsService.GetAsync(item.ProductId);

						item.Product = product;
					}

				}

				var result = new
				{
					Customer = customer,
					Sales = sales
				};

				return Ok(result);

			}
			catch (Exception ex)
			{

				throw;
			}
		}


	}
}
