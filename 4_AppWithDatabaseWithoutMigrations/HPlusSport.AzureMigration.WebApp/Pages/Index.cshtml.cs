using HPlusSport.AzureMigration.Models;
using HPlusSport.AzureMigration.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HPlusSport.AzureMigration.WebApp.Pages
{
	public class IndexModel : BasePageModel<IndexModel>
	{
		public List<Category> Categories = new List<Category>();

		public IndexModel(ShopContext context) : base(context)
		{
		}

		public void OnGet()
		{
			Categories = _context.Categories.ToList();
		}
	}
}