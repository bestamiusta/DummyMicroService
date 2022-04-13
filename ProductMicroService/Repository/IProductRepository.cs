using ProductMicroService.Model;

namespace ProductMicroService.Repository
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetProducts();

        public Product GetProductById(int id);

        public void InsertProduct(Product product);

        public void UpdateProduct(Product product);

        public void DeleteProduct(int id);

        public void Save();

    }
}
