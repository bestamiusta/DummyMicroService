using ProductMicroService.DbContexts;
using ProductMicroService.Model;

namespace ProductMicroService.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _dbContext;

        public ProductRepository(ProductContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public void DeleteProduct(int id)
        {
            var product = _dbContext.Products.Find(id);

            _dbContext.Products.Remove(product);
            Save();

        }

        public Product GetProductById(int id)
        {
            return _dbContext.Products.Find(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dbContext.Products.ToList();
        }

        public void InsertProduct(Product product)
        {
            _dbContext.Products.Add(product);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _dbContext.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }
    }
}
