namespace Project2Store.ShopUI.Models;

    public class Basket
    {
        private List<BasketItem> _Items = new();

        public virtual void Add(Product product, int quantity)
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

        public virtual void Remove(Product product) =>
            _Items.RemoveAll(p => p.Product.Id == product.Id);

        public int TotalPrice() =>
            _Items.Sum(p => p.Product.Price * p.Quantity);

        public virtual void Clear() => _Items.Clear();

        public IEnumerable<BasketItem> Items => _Items;
    }

    public class SessionBasket : Basket
    {
        private ISession _session;

        public static SessionBasket GetBasket(IServiceProvider service)
        {
            var session = service.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;
            SessionBasket basket = session.GetJson<SessionBasket>("Basket") ?? new SessionBasket();

            basket._session = session;

            return basket;
        }

        public override void Add(Product product, int quantity)
        {
            base.Add(product, quantity);
            _session.SetJson("Basket", this);
        }

        public override void Remove(Product product)
        {
            base.Remove(product);
            _session.SetJson("Basket", this);
        }

        public override void Clear()
        {
            base.Clear();
            _session.Remove("Basket");
    }
}

    public class BasketItem
    {
        public long Id { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
