﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Http;
using Lil.Search.Interfaces;
using Lil.Search.Services;

namespace Lil.Search
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();

			services.AddSingleton<ICustomersService, CustomersService>();
			services.AddSingleton<IProductsService, ProductsService>();
			services.AddSingleton<ISalesService, SalesService>();

			services.AddHttpClient("customersService", c =>
			{
				c.BaseAddress = new Uri(Configuration["Services:Customers"]);
			});
			services.AddHttpClient("productsService", c =>
			{
				c.BaseAddress = new Uri(Configuration["Services:Products"]);
			});
			services.AddHttpClient("salesService", c =>
			{
				c.BaseAddress = new Uri(Configuration["Services:Sales"]);
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseMvc();
		}
	}
}
