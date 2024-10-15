namespace Project2Store.ShopUI.Models
{
    public class EfProductRepository : IProductRepository
    {
        private readonly StoreDbContext storeDbContext;

        public EfProductRepository(StoreDbContext storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        }
        public List<Product> GetAll(int pageNumber, int pageSize)
        {
            return storeDbContext.Products.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
