using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using HPlusSport.AzureMigration.WebApp.Models;

namespace HPlusSport.AzureMigration.AzureFunctions
{
    public static class ShopFunctions
    {
        [FunctionName("get_categories")]
        public static async Task<IActionResult> GetCategories(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "categories")] HttpRequest req,
            ILogger log)
        {
            return new OkObjectResult(ProductRepository.Categories);
        }

		[FunctionName("get_products")]
		public static async Task<IActionResult> GetProducts(
	[HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "products")] HttpRequest req,
	ILogger log)
		{
			return new OkObjectResult(ProductRepository.Products);
		}
	}
}
