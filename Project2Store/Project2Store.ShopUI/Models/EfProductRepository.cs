namespace Project2Store.ShopUI.Models
{
    public class EfProductRepository : IProductRepository
    {
        private readonly StoreDbContext storeDbContext;

        public EfProductRepository(StoreDbContext storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        }
        public PagedData<Product> GetAll(int pageNumber, int pageSize)
        {
            var result = new PagedData<Product>()
            {
                PageInfo = new PageInfo()
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize
                }
            };
            
            result.Data = storeDbContext.Products.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            result.PageInfo.TotalCount = storeDbContext.Products.Count();
            return result;
        }
    }
}
