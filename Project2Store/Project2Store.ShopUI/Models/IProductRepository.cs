namespace Project2Store.ShopUI.Models
{
    public interface IProductRepository
    {
        PagedData<Product> GetAll(int pageNumber, int pageSize, string category);

        List<string> GetAllCategories();

        Product GetById(long Id);
    }
}
