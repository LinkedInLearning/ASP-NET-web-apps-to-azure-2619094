#nullable disable
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HPlusSport.AzureMigration.WebApp.Models
{
	public class BasePageModel<T> : PageModel where T: BasePageModel<T>
	{
		protected readonly ShopContext _context;

		public BasePageModel(ShopContext context)
		{
			_context = context;
			//_context.Database.EnsureCreated();
		}
	}
}
