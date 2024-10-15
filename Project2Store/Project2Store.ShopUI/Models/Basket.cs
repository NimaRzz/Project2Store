namespace Project2Store.ShopUI.Models;

    public class Basket
    {
        public List<BasketItem> _Items = new();

        public void Add(Product product, int quantity)
        {
            var basketItem = _Items.Where(p => p.Product.Id == product.Id).FirstOrDefault();
            if (basketItem != null)
            {
                basketItem.Quantity += quantity;
            }
            else
            {
                _Items.Add(new BasketItem()
                {
                    Product = product,
                    Quantity = quantity
                });
            }
        }

        public void Remove(Product product) =>
            _Items.RemoveAll(p => p.Product.Id == product.Id);

        public int TotalPrice() =>
            _Items.Sum(p => p.Product.Price * p.Quantity);

        public void Clear() => _Items.Clear();

        public IEnumerable<BasketItem> Items => Items;
    }

    public class BasketItem
    {
        public long Id { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
