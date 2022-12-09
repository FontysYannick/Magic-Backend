namespace Magic_Interface.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int Stock { get; set; }

        public ProductDTO() { }

        public ProductDTO(int id, string name, string color, int stock)
        {
            Id = id;
            Name = name;
            Color = color;
            Stock = stock;
        }
    }
}
