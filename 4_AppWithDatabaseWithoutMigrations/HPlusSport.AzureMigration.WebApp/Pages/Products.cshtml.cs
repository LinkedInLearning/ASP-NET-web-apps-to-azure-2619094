using HPlusSport.AzureMigration.Models;
using HPlusSport.AzureMigration.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HPlusSport.AzureMigration.WebApp.Pages
{
    public class ProductsModel : BasePageModel<ProductsModel>
    {

		public ProductsModel(ShopContext context) : base(context)
		{
		}

		public List<Product> Products { get; set; } = new List<Product>();

		public IActionResult OnGet(int id)
		{
			Products = _context.Products.Where(p => p.CategoryId == id).ToList();

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
