

namespace Eshopper.Models
{
    public class EFStoreRepository : IStoreRepository
    {
        private StoreDbContext context;
        private IWebHostEnvironment environment;
        public EFStoreRepository(StoreDbContext ctx, IWebHostEnvironment env)
        {
            context = ctx;
            environment = env;
        }
        public IQueryable<Product> Products => context.Products;

        public void CreateProduct(Product p)
        {
            context.Add(p);
            context.SaveChanges();
        }
        public void DeleteProduct(Product p)
        {
            var fullPath = $"{environment.WebRootPath}\\{p.Image}";
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            context.Remove(p);
            context.SaveChanges();
        }
        public void SaveProduct(Product p)
        {
            context.SaveChanges();
        }
    }
}