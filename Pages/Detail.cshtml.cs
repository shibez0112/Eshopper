using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Eshopper.Models;

namespace Eshopper.Pages
{
    public class DetailPageModel : PageModel
    {
        private IStoreRepository repository;
        public Product? product;
        public DetailPageModel(IStoreRepository repo) {
            repository = repo;
        }

        public string ReturnUrl { get; set; } = "/";

        public IActionResult OnGet(long id) {
            product = repository.Products.FirstOrDefault(p => p.ProductID == id);
            return Page();
        }
    }
}
