﻿using Lil.Products.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lil.Products.Controllers
{
	[Route("api/[controller]")]
	public class ProductsController: ControllerBase 
	{
		private readonly IProductsProvider productsProvider;

		public ProductsController(IProductsProvider productsProvider)
		{
			this.productsProvider = productsProvider;
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetAsync(string id)
		{
			var result = await this.productsProvider.GetAsync(id);

			if (result != null)
				return Ok(result);
			else
				return NotFound();
		}
	}
}
