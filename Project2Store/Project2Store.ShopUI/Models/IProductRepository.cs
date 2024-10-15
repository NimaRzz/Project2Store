namespace Project2Store.ShopUI.Models
{
    public interface IProductRepository
    {
        PagedData<Product> GetAll(int pageNumber, int pageSize);
    }
}
