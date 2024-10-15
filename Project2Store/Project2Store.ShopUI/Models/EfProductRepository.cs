namespace Project2Store.ShopUI.Models
{
    public class EfProductRepository : IProductRepository
    {
        private readonly StoreDbContext storeDbContext;

        public EfProductRepository(StoreDbContext storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        }
        public PagedData<Product> GetAll(int pageNumber, int pageSize, string category)
        {
            var result = new PagedData<Product>()
            {
                PageInfo = new PageInfo()
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize
                }
            };
            
            result.Data = storeDbContext.Products.Where(p => string.IsNullOrWhiteSpace(category) || p.Category == category ).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            result.PageInfo.TotalCount = storeDbContext.Products.Where(p => string.IsNullOrWhiteSpace(category) || p.Category == category).Count();
            return result;
        }
    }
}
