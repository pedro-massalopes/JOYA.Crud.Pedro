namespace Product.Models
{
    public class ProductModel
    {
        public int ID { get; set; } = 0;

        public string? Name { get; set; }

        public string? Description { get; set; }

        public byte Active { get; set; }
        public decimal Price { get; set; }

    }
}
