using HPlusSport.AzureMigration.Models;
using HPlusSport.AzureMigration.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HPlusSport.AzureMigration.WebApp.Pages
{
    public class ProductsModel : PageModel
    {
		public List<Product> Products { get; set; } = new List<Product>();

		public IActionResult OnGet(int id)
		{
			Products = ProductRepository.Products.Where(p => p.CategoryId == id).ToList();

			if (Products == null || Products.Count == 0)
			{
				return NotFound();
			}
			else
			{
				return Page();
			}
		}
	}
}
