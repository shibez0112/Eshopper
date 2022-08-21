using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Eshopper.Infrastructure;
using Eshopper.Models;
namespace Eshopper.Pages
{
    public class CartModel : PageModel
    {
        private IStoreRepository repository;
        public CartModel(IStoreRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; } = "/";
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }
        public IActionResult OnPost(long productId, string returnUrl, int quantity)
        {
            Product? product = repository.Products
            .FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                if (quantity > -1)
                {
                    Cart.AddItem(product, quantity);
                }
                else
                {
                    Cart.RemoveItem(product, -quantity);
                }

            }
            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostSet(long productId, string returnUrl, int quantity) {
            Product? product = repository.Products
            .FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                    Cart.SetQuantityItem(product, quantity);
            }
            return RedirectToPage(new { returnUrl = returnUrl });
        }


        public IActionResult OnPostRemove(long productId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl =>
            cl.Product.ProductID == productId).Product);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}