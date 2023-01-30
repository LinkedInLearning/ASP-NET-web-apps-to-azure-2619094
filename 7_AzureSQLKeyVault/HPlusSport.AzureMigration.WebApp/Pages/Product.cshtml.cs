using HPlusSport.AzureMigration.Models;
using HPlusSport.AzureMigration.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HPlusSport.AzureMigration.WebApp.Pages
{
    public class ProductModel : BasePageModel<ProductModel>
    {
		public ProductModel(ShopContext context) : base(context)
		{
		}

		public Product? Product { get; set; }

        public IActionResult OnGet(int id)
        {
			Product = _context.Products.Where(p => p.Id == id).FirstOrDefault();

            if (Product == null)
            {
                return NotFound();
            } else
            {
                return Page();
            }
		}
	}
}
