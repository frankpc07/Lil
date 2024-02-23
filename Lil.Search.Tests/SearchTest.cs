using Lil.Search.Controllers;
using Lil.Search.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lil.Search.Tests
{
	[TestClass]
	public class SearchTest
	{
		[TestMethod]
		public void GetAsyncReturnsOk()
		{
			var customersServiceProvider = new CustomersServiceProvider();
			var productsServiceProvider = new ProductsServiceProvider();
			var salesServiceProvider = new SalesServiceProvider();

			var searchController = new SearchController(customersServiceProvider, productsServiceProvider, salesServiceProvider);

			var result = searchController.SearchAsync("3").Result;

			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(OkObjectResult));
		}

		[TestMethod]
		public void GetAsyncReturnsNotFound()
		{
			var customersServiceProvider = new CustomersServiceProvider();
			var productsServiceProvider = new ProductsServiceProvider();
			var salesServiceProvider = new SalesServiceProvider();

			var searchController = new SearchController(customersServiceProvider, productsServiceProvider, salesServiceProvider);

			var result = searchController.SearchAsync("101").Result;

			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(NotFoundResult));
		}
	}
}
