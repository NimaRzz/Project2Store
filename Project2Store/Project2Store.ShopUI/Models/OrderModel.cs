namespace Project2Store.ShopUI.Models
{
    public class Order
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public List<OrderDetail> orderDetails { get; set; } = new List<OrderDetail>();
    }

    public class OrderDetail
    {
        public long Id { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
