namespace Project2Store.ShopUI.Models
{
    public interface IProductRepository
    {
        List<Product> GetAll(int pageNumber, int pageSize);
    }
}
