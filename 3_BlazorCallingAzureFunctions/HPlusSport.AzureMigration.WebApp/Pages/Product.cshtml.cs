using HPlusSport.AzureMigration.Models;
using HPlusSport.AzureMigration.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using static System.Net.WebRequestMethods;

namespace HPlusSport.AzureMigration.WebApp.Pages
{
    public class ProductModel : PageModel
    {
        public Product? Product { get; set; }

        public IActionResult OnGet(int id)
        {
			Product = ProductRepository.Products.Where(p => p.Id == id).FirstOrDefault();

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
